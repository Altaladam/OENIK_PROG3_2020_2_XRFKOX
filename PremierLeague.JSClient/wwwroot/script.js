let players = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:15953/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("PlayerCreated", (user, message) => {
        getdata();
    });

    connection.on("PlayerDeleted", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:15953/player')
        .then(x => x.json())
        .then(y => {
            players = y;
            console.log(players);
            display();
        });
}

function display() {
    let innerhtml = "";
    players.forEach(t => {
        innerhtml +=
            "<tr><td>" + t.playerID + "</td><td>"
        innerhtml +=
            t.name + "</td><td>"
        innerhtml +=
            t.position + "</td><td>"
        innerhtml +=
            t.nationality + "</td><td>"
        innerhtml +=
            t.birthday + "</td><td>"
        innerhtml +=
            + t.value + "</td><td>"
        innerhtml +=
            t.teamname + "</td><td>"
        innerhtml +=
            `<button type="button" onclick="remove(${t.playerID})">Delete</button>`
            + "</td></tr>"
        innerhtml +=
            `<button type="button" onclick="put(${t.playerID})">Modify</button>`
            + "</td></tr>";
    });
    document.getElementById('resultarea').innerHTML = innerhtml;
}

function remove(id) {
    fetch('http://localhost:15953/player/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('playername').value;
    let position = document.getElementById('playerposition').value;
    let nationality = document.getElementById('playernationality').value;
    let birthday = document.getElementById('playerbirthday').value;
    let value = document.getElementById('playervalue').value;
    let teamname = document.getElementById('teamname').value;
    fetch('http://localhost:15953/player', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Position: position, Nationality: nationality, Birthday: birthday, Value: value, TeamName: teamname },
            )
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}function put(id) {
    let name = document.getElementById('playername').value;
    let position = document.getElementById('playerposition').value;
    let nationality = document.getElementById('playernationality').value;
    let birthday = document.getElementById('playerbirthday').value;
    let value = document.getElementById('playervalue').value;
    let teamname = document.getElementById('teamname').value;
    fetch('http://localhost:15953/player', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name, Position: position, Nationality: nationality, Birthday: birthday, Value: value, TeamName: teamname, PlayerID: parseInt(id) },
            )
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}