// <copyright file="LogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using PremierLeague.Data;
    using PremierLeague.Repository;

    /// <summary>
    /// The class where the unit tests are implemented.
    /// </summary>
    [TestFixture]
    public class LogicTests
    {
        /// <summary>
        /// Tests the GetPlayerByID method.
        /// </summary>
        [Test]
        public void TestGetPlayerByID()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerID = 1 },
                new Player() { PlayerID = 2 },
                new Player() { PlayerID = 3 },
                new Player() { PlayerID = 4 },
                new Player() { PlayerID = 5 },
                new Player() { PlayerID = 6 },
                new Player() { PlayerID = 7 },
                new Player() { PlayerID = 8 },
                new Player() { PlayerID = 9 },
                new Player() { PlayerID = 10 },
                new Player() { PlayerID = 11 },
                new Player() { PlayerID = 12 },
                new Player() { PlayerID = 13 },
                new Player() { PlayerID = 14 },
                new Player() { PlayerID = 15 },
                new Player() { PlayerID = 16 },
                new Player() { PlayerID = 17 },
                new Player() { PlayerID = 18 },
            };

            mockedPlayerRepo.Setup(repo => repo.GetOne(It.IsAny<int>())).Returns(It.IsAny<Player>);
            ReadLogic readLogic = new ReadLogic(mockedPlayerRepo.Object);
            var result = readLogic.GetPlayerByID(1);

            mockedPlayerRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Once);
            mockedPlayerRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Tests the GetAllManagers method.
        /// </summary>
        [Test]
        public void TestGetAllManagers()
        {
            Mock<IManagerRepository> mockedManagerRepo = new Mock<IManagerRepository>(MockBehavior.Loose);

            List<Manager> managers = new List<Manager>()
            {
                new Manager() { ManagerID = 1 },
                new Manager() { ManagerID = 2 },
                new Manager() { ManagerID = 3 },
                new Manager() { ManagerID = 4 },
                new Manager() { ManagerID = 5 },
                new Manager() { ManagerID = 6 },
            };

            mockedManagerRepo.Setup(repo => repo.GetAll()).Returns(managers.AsQueryable());
            ReadLogic readLogic = new ReadLogic(mockedManagerRepo.Object);

            var result = readLogic.GetAllManagers();

            mockedManagerRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedManagerRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            mockedManagerRepo.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests the ChangePlayerName method.
        /// </summary>
        [Test]
        public void TestChangePlayerName()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerID = 1, Name = "Bernd Leno" },
                new Player() { PlayerID = 2, Name = "Dani Ceballos" },
                new Player() { PlayerID = 3, Name = "Pierre-Emerick Aubameyang" },
                new Player() { PlayerID = 4, Name = "Trent Alexander-Arnold" },
                new Player() { PlayerID = 5, Name = "Thiago Alcántara" },
                new Player() { PlayerID = 6, Name = "Mohamed Salah" },
                new Player() { PlayerID = 7, Name = "Harry Maguire" },
                new Player() { PlayerID = 8, Name = "Paul Pogba" },
                new Player() { PlayerID = 9, Name = "Mason Greenwood" },
                new Player() { PlayerID = 10, Name = "Aymeric Laporte" },
                new Player() { PlayerID = 11, Name = "Kevin De Bruyne" },
                new Player() { PlayerID = 12, Name = "Raheem Sterling" },
                new Player() { PlayerID = 13, Name = "Ben Chillwell" },
                new Player() { PlayerID = 14, Name = "César Azpilicueta" },
                new Player() { PlayerID = 15, Name = "Christian Pulisic" },
                new Player() { PlayerID = 16, Name = "James Maddison" },
                new Player() { PlayerID = 17, Name = "Jamie Vardy" },
                new Player() { PlayerID = 18, Name = "Cengiz Ünder" },
            };

            mockedPlayerRepo.Setup(repo => repo.ChangeName(It.IsAny<int>(), It.IsAny<string>()));
            ModifyLogic modifyLogic = new ModifyLogic(mockedPlayerRepo.Object);
            modifyLogic.ChangePlayerName(6, "uj nev");

            mockedPlayerRepo.Verify(repo => repo.ChangeName(It.IsAny<int>(), It.IsAny<string>()), Times.Once);
            mockedPlayerRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
            mockedPlayerRepo.Verify(repo => repo.GetAll(), Times.Never);
        }

        /// <summary>
        /// Tests the AddTeam method.
        /// </summary>
        [Test]
        public void TestAddTeam()
        {
            Mock<ITeamRepository> mockedTeamRepo = new Mock<ITeamRepository>(MockBehavior.Loose);

            List<Team> teams = new List<Team>()
            {
                new Team() { TeamID = 1 },
                new Team() { TeamID = 2 },
                new Team() { TeamID = 3 },
                new Team() { TeamID = 4 },
                new Team() { TeamID = 5 },
                new Team() { TeamID = 6 },
            };

            mockedTeamRepo.Setup(repo => repo.Add(It.IsAny<Team>()));
            ModifyLogic modifyLogic = new ModifyLogic(mockedTeamRepo.Object);

            Team team = new Team()
            {
                TeamID = 100,
            };

            modifyLogic.AddTeam(team);

            mockedTeamRepo.Verify(repo => repo.Add(It.IsAny<Team>()), Times.Once);
            mockedTeamRepo.Verify(repo => repo.GetAll(), Times.Never);
            mockedTeamRepo.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests the DeleteTeam method.
        /// </summary>
        [Test]
        public void TestDeleteTeam()
        {
            Mock<ITeamRepository> mockedTeamRepo = new Mock<ITeamRepository>(MockBehavior.Loose);

            List<Team> teams = new List<Team>()
            {
                new Team() { TeamID = 1 },
                new Team() { TeamID = 2 },
                new Team() { TeamID = 3 },
                new Team() { TeamID = 4 },
                new Team() { TeamID = 5 },
                new Team() { TeamID = 6 },
            };

            mockedTeamRepo.Setup(repo => repo.Delete(It.IsAny<int>()));
            ModifyLogic modifyLogic = new ModifyLogic(mockedTeamRepo.Object);

            modifyLogic.DeleteTeam(2);

            mockedTeamRepo.Verify(repo => repo.Delete(It.IsAny<int>()), Times.Once);
            mockedTeamRepo.Verify(repo => repo.GetAll(), Times.Never);
            mockedTeamRepo.Verify(repo => repo.Add(It.IsAny<Team>()), Times.Never);
        }

        /// <summary>
        /// Tests the GetEnglishPlayers method.
        /// </summary>
        [Test]
        public void TestGetEnglishPlayers()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);
            Mock<ITeamRepository> mockedTeamRepo = new Mock<ITeamRepository>(MockBehavior.Loose);

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerID = 1, Nationality = "German" },
                new Player() { PlayerID = 2, Nationality = "Spanish" },
                new Player() { PlayerID = 3, Nationality = "Gabonese" },
                new Player() { PlayerID = 4, Nationality = "English" },
                new Player() { PlayerID = 5, Nationality = "Spanish" },
                new Player() { PlayerID = 6, Nationality = "Egyptian" },
                new Player() { PlayerID = 7, Nationality = "English" },
                new Player() { PlayerID = 8, Nationality = "French" },
                new Player() { PlayerID = 9, Nationality = "English" },
                new Player() { PlayerID = 10, Nationality = "Spanish" },
                new Player() { PlayerID = 11, Nationality = "Belgian" },
                new Player() { PlayerID = 12, Nationality = "English" },
                new Player() { PlayerID = 13, Nationality = "English" },
                new Player() { PlayerID = 14, Nationality = "Spanish" },
                new Player() { PlayerID = 15, Nationality = "American" },
                new Player() { PlayerID = 16, Nationality = "English" },
                new Player() { PlayerID = 17, Nationality = "English" },
                new Player() { PlayerID = 18, Nationality = "Turkish" },
            };

            List<Team> teams = new List<Team>()
            {
                new Team() { TeamID = 1 },
                new Team() { TeamID = 2 },
                new Team() { TeamID = 3 },
                new Team() { TeamID = 4 },
                new Team() { TeamID = 5 },
                new Team() { TeamID = 6 },
            };
            players[0].TeamID = teams[0].TeamID;
            players[1].TeamID = teams[0].TeamID;
            players[2].TeamID = teams[0].TeamID;
            players[3].TeamID = teams[1].TeamID;
            players[4].TeamID = teams[1].TeamID;
            players[5].TeamID = teams[1].TeamID;
            players[6].TeamID = teams[2].TeamID;
            players[7].TeamID = teams[2].TeamID;
            players[8].TeamID = teams[2].TeamID;
            players[9].TeamID = teams[3].TeamID;
            players[10].TeamID = teams[3].TeamID;
            players[11].TeamID = teams[3].TeamID;
            players[12].TeamID = teams[4].TeamID;
            players[13].TeamID = teams[4].TeamID;
            players[14].TeamID = teams[4].TeamID;
            players[15].TeamID = teams[5].TeamID;
            players[16].TeamID = teams[5].TeamID;
            players[17].TeamID = teams[5].TeamID;
            teams[0].Players = new List<Player>
            {
                players[0],
                players[1],
                players[2],
            };
            teams[1].Players = new List<Player>
            {
                players[3],
                players[4],
                players[5],
            };
            teams[2].Players = new List<Player>
            {
                players[6],
                players[7],
                players[8],
            };
            teams[3].Players = new List<Player>
            {
                players[9],
                players[10],
                players[11],
            };
            teams[4].Players = new List<Player>
            {
                players[12],
                players[13],
                players[14],
            };
            teams[5].Players = new List<Player>
            {
                players[15],
                players[16],
                players[17],
            };

            List<Player> expectedEnglish = new List<Player>() { players[3], players[6], players[8], players[11], players[12], players[15], players[16], };

            mockedTeamRepo.Setup(repo => repo.GetAll()).Returns(teams.AsQueryable());
            mockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(players.AsQueryable());
            ReadLogic logic = new ReadLogic(mockedPlayerRepo.Object, mockedTeamRepo.Object);

            var result = logic.GetEnglishPlayers();

            Assert.That(result.Count, Is.EqualTo(expectedEnglish.Count));
            Assert.That(result, Is.EquivalentTo(expectedEnglish));

            mockedTeamRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedTeamRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests the GetYoungestPlayer method.
        /// </summary>
        [Test]
        public void TestGetYoungestPlayer()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);
            Mock<ITeamRepository> mockedTeamRepo = new Mock<ITeamRepository>(MockBehavior.Loose);

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerID = 1, Birthday = new DateTime(1992, 3, 4) },
                new Player() { PlayerID = 2, Birthday = new DateTime(1996, 8, 7) },
                new Player() { PlayerID = 3, Birthday = new DateTime(1989, 6, 18) },
                new Player() { PlayerID = 4, Birthday = new DateTime(1998, 10, 7) },
                new Player() { PlayerID = 5, Birthday = new DateTime(1991, 4, 11) },
                new Player() { PlayerID = 6, Birthday = new DateTime(1992, 6, 15) },
                new Player() { PlayerID = 7, Birthday = new DateTime(1993, 3, 5) },
                new Player() { PlayerID = 8, Birthday = new DateTime(1993, 3, 15) },
                new Player() { PlayerID = 9, Birthday = new DateTime(2001, 10, 1) },
                new Player() { PlayerID = 10, Birthday = new DateTime(1994, 3, 27) },
                new Player() { PlayerID = 11, Birthday = new DateTime(1991, 6, 28) },
                new Player() { PlayerID = 12, Birthday = new DateTime(1994, 12, 8) },
                new Player() { PlayerID = 13, Birthday = new DateTime(1996, 12, 21) },
                new Player() { PlayerID = 14, Birthday = new DateTime(1989, 8, 28) },
                new Player() { PlayerID = 15, Birthday = new DateTime(1998, 9, 18) },
                new Player() { PlayerID = 16, Birthday = new DateTime(1999, 11, 23) },
                new Player() { PlayerID = 17, Birthday = new DateTime(1987, 1, 11) },
                new Player() { PlayerID = 18, Birthday = new DateTime(1997, 7, 14) },
            };

            List<Team> teams = new List<Team>()
            {
                new Team() { TeamID = 1 },
                new Team() { TeamID = 2 },
                new Team() { TeamID = 3 },
                new Team() { TeamID = 4 },
                new Team() { TeamID = 5 },
                new Team() { TeamID = 6 },
            };
            players[0].TeamID = teams[0].TeamID;
            players[1].TeamID = teams[0].TeamID;
            players[2].TeamID = teams[0].TeamID;
            players[3].TeamID = teams[1].TeamID;
            players[4].TeamID = teams[1].TeamID;
            players[5].TeamID = teams[1].TeamID;
            players[6].TeamID = teams[2].TeamID;
            players[7].TeamID = teams[2].TeamID;
            players[8].TeamID = teams[2].TeamID;
            players[9].TeamID = teams[3].TeamID;
            players[10].TeamID = teams[3].TeamID;
            players[11].TeamID = teams[3].TeamID;
            players[12].TeamID = teams[4].TeamID;
            players[13].TeamID = teams[4].TeamID;
            players[14].TeamID = teams[4].TeamID;
            players[15].TeamID = teams[5].TeamID;
            players[16].TeamID = teams[5].TeamID;
            players[17].TeamID = teams[5].TeamID;
            teams[0].Players = new List<Player>
            {
                players[0],
                players[1],
                players[2],
            };
            teams[1].Players = new List<Player>
            {
                players[3],
                players[4],
                players[5],
            };
            teams[2].Players = new List<Player>
            {
                players[6],
                players[7],
                players[8],
            };
            teams[3].Players = new List<Player>
            {
                players[9],
                players[10],
                players[11],
            };
            teams[4].Players = new List<Player>
            {
                players[12],
                players[13],
                players[14],
            };
            teams[5].Players = new List<Player>
            {
                players[15],
                players[16],
                players[17],
            };

            List<Player> expectedYoungest = new List<Player>() { players[1], players[3], players[8], players[11], players[14], players[15], };

            mockedTeamRepo.Setup(repo => repo.GetAll()).Returns(teams.AsQueryable());
            mockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(players.AsQueryable());
            ReadLogic logic = new ReadLogic(mockedPlayerRepo.Object, mockedTeamRepo.Object);

            var result = logic.GetYoungestPlayers();

            Assert.That(result.Count, Is.EqualTo(expectedYoungest.Count));
            Assert.That(result, Is.EquivalentTo(expectedYoungest));

            mockedTeamRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedTeamRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }

        /// <summary>
        /// Tests the GetTeamValue method.
        /// </summary>
        [Test]
        public void TestGetTeamValue()
        {
            Mock<IPlayerRepository> mockedPlayerRepo = new Mock<IPlayerRepository>(MockBehavior.Loose);
            Mock<ITeamRepository> mockedTeamRepo = new Mock<ITeamRepository>(MockBehavior.Loose);

            List<Player> players = new List<Player>()
            {
                new Player() { PlayerID = 1, Value = 32000000 },
                new Player() { PlayerID = 2, Value = 32000000 },
                new Player() { PlayerID = 3, Value = 50000000 },
                new Player() { PlayerID = 4, Value = 110000000 },
                new Player() { PlayerID = 5, Value = 48000000 },
                new Player() { PlayerID = 6, Value = 120000000 },
                new Player() { PlayerID = 7, Value = 50000000 },
                new Player() { PlayerID = 8, Value = 80000000 },
                new Player() { PlayerID = 9, Value = 50000000 },
                new Player() { PlayerID = 10, Value = 60000000 },
                new Player() { PlayerID = 11, Value = 120000000 },
                new Player() { PlayerID = 12, Value = 128000000 },
                new Player() { PlayerID = 13, Value = 50000000 },
                new Player() { PlayerID = 14, Value = 20000000 },
                new Player() { PlayerID = 15, Value = 60000000 },
                new Player() { PlayerID = 16, Value = 55000000 },
                new Player() { PlayerID = 17, Value = 16000000 },
                new Player() { PlayerID = 18, Value = 23000000 },
            };

            List<Team> teams = new List<Team>()
            {
                new Team() { TeamID = 1, Name = "Arsenal" },
                new Team() { TeamID = 2, Name = "Liverpool" },
                new Team() { TeamID = 3, Name = "Manchester United" },
                new Team() { TeamID = 4, Name = "Manchester City" },
                new Team() { TeamID = 5, Name = "Chelsea" },
                new Team() { TeamID = 6, Name = "Leicester City" },
            };
            players[0].TeamID = teams[0].TeamID;
            players[1].TeamID = teams[0].TeamID;
            players[2].TeamID = teams[0].TeamID;
            players[3].TeamID = teams[1].TeamID;
            players[4].TeamID = teams[1].TeamID;
            players[5].TeamID = teams[1].TeamID;
            players[6].TeamID = teams[2].TeamID;
            players[7].TeamID = teams[2].TeamID;
            players[8].TeamID = teams[2].TeamID;
            players[9].TeamID = teams[3].TeamID;
            players[10].TeamID = teams[3].TeamID;
            players[11].TeamID = teams[3].TeamID;
            players[12].TeamID = teams[4].TeamID;
            players[13].TeamID = teams[4].TeamID;
            players[14].TeamID = teams[4].TeamID;
            players[15].TeamID = teams[5].TeamID;
            players[16].TeamID = teams[5].TeamID;
            players[17].TeamID = teams[5].TeamID;
            teams[0].Players = new List<Player>
            {
                players[0],
                players[1],
                players[2],
            };
            teams[1].Players = new List<Player>
            {
                players[3],
                players[4],
                players[5],
            };
            teams[2].Players = new List<Player>
            {
                players[6],
                players[7],
                players[8],
            };
            teams[3].Players = new List<Player>
            {
                players[9],
                players[10],
                players[11],
            };
            teams[4].Players = new List<Player>
            {
                players[12],
                players[13],
                players[14],
            };
            teams[5].Players = new List<Player>
            {
                players[15],
                players[16],
                players[17],
            };

            Dictionary<string, int> expectedValues = new Dictionary<string, int>
            {
                { "Arsenal", 114000000 },
                { "Liverpool", 278000000 },
                { "Manchester United", 180000000 },
                { "Manchester City", 308000000 },
                { "Chelsea", 130000000 },
                { "Leicester City", 94000000 },
            };

            mockedTeamRepo.Setup(repo => repo.GetAll()).Returns(teams.AsQueryable());
            mockedPlayerRepo.Setup(repo => repo.GetAll()).Returns(players.AsQueryable());
            ReadLogic logic = new ReadLogic(mockedPlayerRepo.Object, mockedTeamRepo.Object);

            var result = logic.GetTeamValue();

            Assert.That(result.Count, Is.EqualTo(expectedValues.Count));
            Assert.That(result, Is.EquivalentTo(expectedValues));

            mockedTeamRepo.Verify(repo => repo.GetAll(), Times.Once);
            mockedTeamRepo.Verify(repo => repo.GetOne(It.IsAny<int>()), Times.Never);
        }
    }
}
