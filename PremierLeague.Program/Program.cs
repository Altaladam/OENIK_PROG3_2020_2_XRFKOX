// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace PremierLeague.Program
{
    using System;
    using System.Linq;
    using ConsoleTools;
    using PremierLeague.Data;
    using PremierLeague.Logic;

    /// <summary>
    /// Instances everything and implements the menu.
    /// </summary>
    internal class Program
    {
        private const string EnterIDString = "ENTER ID HERE: ";
        private const string WrongIDInput = "THE INPUT ID IS IN THE WRONG FORMAT, PLEASE TRY AGAIN.";
        private const string WrongInput = "THE INPUT IS IN THE WRONG FORMAT, PLEASE TRY AGAIN.";

        private static void Main()
        {
            var menu = new ConsoleMenu()
                .Add(">> LIST ALL", () => ListAll(Factory.ReadLogic))
                .Add(">> GET TEAM BY ID", () => GetTeamByID(Factory.ReadLogic))
                .Add(">> GET PLAYER BY ID", () => GetPlayerByID(Factory.ReadLogic))
                .Add(">> GET MANAGER BY ID", () => GetManagerByID(Factory.ReadLogic))
                .Add(">> ADD TEAM", () => AddTeam(Factory.ModifyLogic))
                .Add(">> ADD PLAYER", () => AddPlayer(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> ADD MANAGER", () => AddManager(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> DELETE TEAM", () => DeleteTeam(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> DELETE PLAYER", () => DeletePlayer(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> DELETE MANAGER", () => DeleteManager(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> UPDATE TEAM", () => ChangeTeam(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> UPDATE PLAYER", () => ChangePlayer(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> UPDATE MANAGER", () => ChangeManager(Factory.ModifyLogic, Factory.ReadLogic))
                .Add(">> GET THE YOUNGEST PLAYER OF EVERY TEAM", () => GetYoungestPlayers(Factory.ReadLogic))
                .Add(">> GET THE TOTAL VALUE OF EVERY TEAM", () => GetTeamValue(Factory.ReadLogic))
                .Add(">> GET ALL ENGLISH PLAYERS BY TEAM", () => GetEnglishPlayers(Factory.ReadLogic))
                .Add(">> GET THE YOUNGEST PLAYER OF EVERY TEAM (ASYNC)", () => GetYoungestPlayersAsync(Factory.ReadLogic))
                .Add(">> GET THE TOTAL VALUE OF EVERY TEAM (ASYNC)", () => GetTeamValueAsync(Factory.ReadLogic))
                .Add(">> GET ALL ENGLISH PLAYERS BY TEAM (ASYNC)", () => GetEnglishPlayersAsync(Factory.ReadLogic))
                .Add(">> EXIT", ConsoleMenu.Close);

            menu.Show();
        }

        private static void ListAll(ReadLogic logic)
        {
            const string TeamsString = "\n:: ALL TEAMS ::\n";
            Console.WriteLine(TeamsString.ToString());
            logic.GetAllTeams()
                .ToList()
                .ForEach(x => Console.WriteLine(x.ToString()));

            const string PlayersString = "\n:: ALL PLAYERS ::\n";
            Console.WriteLine(PlayersString.ToString());
            logic.GetAllTeams()
                .ToList()
                .ForEach(x => x.Players.ToList().ForEach(y => Console.WriteLine(y.ToString())));

            const string ManagersString = "\n:: ALL MANAGERS ::\n";
            Console.WriteLine(ManagersString.ToString());
            logic.GetAllTeams()
                .ToList()
                .ForEach(x => x.Manager.ToList().ForEach(y => Console.WriteLine(y.ToString())));

            Console.ReadLine();
        }

        private static void GetTeamByID(ReadLogic logic)
        {
            Console.WriteLine(EnterIDString.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (logic.GetTeamByID(id) == null)
                {
                    const string IncorrectTeam = "THERE IS NO TEAM WITH THAT ID.";
                    Console.WriteLine(IncorrectTeam.ToString());
                }
            }
            while (!correctInput || logic.GetTeamByID(id) == null);

            var q = logic.GetTeamByID(id);

            const string SelectedTeamString = "\n:: SELECTED TEAM ::\n";
            Console.WriteLine(SelectedTeamString.ToString());
            Console.WriteLine(q);

            Console.ReadLine();
        }

        private static void GetPlayerByID(ReadLogic logic)
        {
            Console.WriteLine(EnterIDString.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (logic.GetPlayerByID(id) == null)
                {
                    const string IncorrectPlayer = "THERE IS NO PLAYER WITH THAT ID.";
                    Console.WriteLine(IncorrectPlayer.ToString());
                }
            }
            while (!correctInput || logic.GetPlayerByID(id) == null);

            var q = logic.GetPlayerByID(id);

            const string SelectedPlayerString = "\n:: SELECTED PLAYER ::\n";
            Console.WriteLine(SelectedPlayerString.ToString());
            Console.WriteLine(q);

            Console.ReadLine();
        }

        private static void GetManagerByID(ReadLogic logic)
        {
            Console.WriteLine(EnterIDString.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (logic.GetManagerByID(id) == null)
                {
                    const string IncorrectManager = "THERE IS NO MANAGER WITH THAT ID.";
                    Console.WriteLine(IncorrectManager.ToString());
                }
            }
            while (!correctInput || logic.GetManagerByID(id) == null);

            var q = logic.GetManagerByID(id);

            const string SelectedManagerString = "\n:: SELECTED MANAGER ::\n";
            Console.WriteLine(SelectedManagerString.ToString());
            Console.WriteLine(q);

            Console.ReadLine();
        }

        private static void AddTeam(ModifyLogic logic)
        {
            Team team = new Team();
            const string EnterNameString = "ENTER NAME HERE: ";
            Console.WriteLine(EnterNameString.ToString());
            team.Name = Console.ReadLine();

            const string EnterCityString = "ENTER CITY HERE: ";
            Console.WriteLine(EnterCityString.ToString());
            team.City = Console.ReadLine();

            const string EnterYearString = "ENTER FOUNDATION YEAR HERE: ";
            Console.WriteLine(EnterYearString.ToString());
            bool correctFoundationYear;
            int foundationYear;
            do
            {
                string input = Console.ReadLine();
                correctFoundationYear = int.TryParse(input, out foundationYear);
                if (!correctFoundationYear)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctFoundationYear);
            team.FoundationYear = foundationYear;

            const string EnterValueString = "ENTER VALUE HERE: ";
            Console.WriteLine(EnterValueString.ToString());
            bool correctValue;
            int value;
            do
            {
                string input = Console.ReadLine();
                correctValue = int.TryParse(input, out value);
                if (!correctValue)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctValue);
            team.TotalValue = value;

            const string EnterStadiumString = "ENTER STADIUM HERE: ";
            Console.WriteLine(EnterStadiumString.ToString());
            team.Stadium = Console.ReadLine();

            logic.AddTeam(team);

            const string NewTeamString = "\n:: NEW TEAM ::\n";
            Console.WriteLine(NewTeamString.ToString());
            Console.WriteLine(team);

            Console.ReadLine();
        }

        private static void AddPlayer(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Player player = new Player();
            const string EnterNameString = "ENTER NAME HERE: ";
            Console.WriteLine(EnterNameString.ToString());
            player.Name = Console.ReadLine();

            const string EnterBirthdayString = "ENTER BIRTHDAY HERE: ";
            Console.WriteLine(EnterBirthdayString.ToString());
            bool correctBirthday;
            DateTime birthday;
            do
            {
                string input = Console.ReadLine();
                correctBirthday = DateTime.TryParse(input, out birthday);
                if (!correctBirthday)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctBirthday);
            player.Birthday = birthday;

            const string EnterNationalityString = "ENTER NATIONALITY HERE: ";
            Console.WriteLine(EnterNationalityString.ToString());
            player.Nationality = Console.ReadLine();

            const string EnterPositionString = "ENTER POSITION HERE: ";
            Console.WriteLine(EnterPositionString.ToString());
            player.Position = Console.ReadLine();

            const string EnterValueString = "ENTER VALUE HERE: ";
            Console.WriteLine(EnterValueString.ToString());
            bool correctValue;
            int value;
            do
            {
                string input = Console.ReadLine();
                correctValue = int.TryParse(input, out value);
                if (!correctValue)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctValue);
            player.Value = value;

            const string EnterTeamID = "ENTER TEAM ID HERE: ";
            Console.WriteLine(EnterTeamID.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetTeamByID(id) == null)
                {
                    const string IncorrectTeam = "THERE IS NO TEAM WITH THAT ID.";
                    Console.WriteLine(IncorrectTeam.ToString());
                }
            }
            while (!correctInput || readLogic.GetTeamByID(id) == null);
            player.TeamID = id;

            modifyLogic.AddPlayer(player);
            const string NewPlayerString = "\n:: NEW PLAYER ::\n";
            Console.WriteLine(NewPlayerString.ToString());
            Console.WriteLine(player);

            Console.ReadLine();
        }

        private static void AddManager(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Manager manager = new Manager();
            const string EnterNameString = "ENTER NAME HERE: ";
            Console.WriteLine(EnterNameString.ToString());
            manager.Name = Console.ReadLine();

            const string EnterBirthdayString = "ENTER BIRTHDAY HERE: ";
            Console.WriteLine(EnterBirthdayString.ToString());
            bool correctBirthday;
            DateTime birthday;
            do
            {
                string input = Console.ReadLine();
                correctBirthday = DateTime.TryParse(input, out birthday);
                if (!correctBirthday)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctBirthday);
            manager.Birthday = birthday;

            const string EnterNationalityString = "ENTER NATIONALITY HERE: ";
            Console.WriteLine(EnterNationalityString.ToString());
            manager.Nationality = Console.ReadLine();

            const string EnterFormationString = "ENTER PREFERRED FORMATION HERE: ";
            Console.WriteLine(EnterFormationString.ToString());
            manager.PreferredFormation = Console.ReadLine();

            const string EnterContractStartString = "ENTER CONTRACT START HERE: ";
            Console.WriteLine(EnterContractStartString.ToString());
            bool correctContractStart;
            DateTime contractStart;
            do
            {
                string input = Console.ReadLine();
                correctContractStart = DateTime.TryParse(input, out contractStart);
                if (!correctContractStart)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctContractStart);
            manager.ContractStart = contractStart;

            const string EnterTeamID = "ENTER TEAM ID HERE: ";
            Console.WriteLine(EnterTeamID.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetTeamByID(id) == null)
                {
                    const string IncorrectTeam = "THERE IS NO TEAM WITH THAT ID.";
                    Console.WriteLine(IncorrectTeam.ToString());
                }
            }
            while (!correctInput || readLogic.GetTeamByID(id) == null);
            manager.TeamID = id;

            modifyLogic.AddManager(manager);
            const string NewManagerString = "\n:: NEW MANAGER ::\n";
            Console.WriteLine(NewManagerString.ToString());
            Console.WriteLine(manager);

            Console.ReadLine();
        }

        private static void DeleteTeam(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Console.WriteLine(EnterIDString.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetTeamByID(id) == null)
                {
                    const string IncorrectTeam = "THERE IS NO TEAM WITH THAT ID.";
                    Console.WriteLine(IncorrectTeam.ToString());
                }
            }
            while (!correctInput || readLogic.GetTeamByID(id) == null);

            modifyLogic.DeleteTeam(id);

            string text = "TEAM WITH ID " + id + " DELETED.";
            Console.WriteLine(text.ToString());

            Console.ReadLine();
        }

        private static void DeletePlayer(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Console.WriteLine(EnterIDString.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetPlayerByID(id) == null)
                {
                    const string IncorrectPlayer = "THERE IS NO PLAYER WITH THAT ID.";
                    Console.WriteLine(IncorrectPlayer.ToString());
                }
            }
            while (!correctInput || readLogic.GetPlayerByID(id) == null);

            modifyLogic.DeletePlayer(id);

            string text = "PLAYER WITH ID " + id + " DELETED.";
            Console.WriteLine(text.ToString());

            Console.ReadLine();
        }

        private static void DeleteManager(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Console.WriteLine(EnterIDString.ToString());
            bool correctInput;
            int id;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out id);
                if (!correctInput)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetManagerByID(id) == null)
                {
                    const string IncorrectManager = "THERE IS NO MANAGER WITH THAT ID.";
                    Console.WriteLine(IncorrectManager.ToString());
                }
            }
            while (!correctInput || readLogic.GetManagerByID(id) == null);

            modifyLogic.DeleteManager(id);

            string text = "MANAGER WITH ID " + id + " DELETED.";
            Console.WriteLine(text.ToString());

            Console.ReadLine();
        }

        private static void ChangeTeam(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Console.WriteLine(EnterIDString.ToString());
            int id;
            bool correctID;
            do
            {
                string readLine = Console.ReadLine();
                correctID = int.TryParse(readLine, out id);
                if (!correctID)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetTeamByID(id) == null)
                {
                    const string NoTeamString = "THERE IS NO TEAM WITH THAT ID.";
                    Console.WriteLine(NoTeamString.ToString());
                }
            }
            while (!correctID || readLogic.GetTeamByID(id) == null);
            const string PressButtonString = "PRESS THE BUTTON BELONGING TO THE ATTRIBUTE YOU WANT TO CHANGE";
            const string ButtonsString = "('n' FOR NAME, 'c' FOR CITY, 'f' FOR FOUNDATION YEAR, 'v' FOR VALUE, 's' FOR STADIUM)";
            Console.WriteLine(PressButtonString.ToString() + "\n" + ButtonsString.ToString());
            bool correctInput = false;
            do
            {
                char button = Console.ReadKey().KeyChar;
                switch (button)
                {
                    case 'n':
                        ChangeTeamName(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'c':
                        ChangeTeamCity(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'f':
                        ChangeTeamFoundationYear(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'v':
                        ChangeTeamValue(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 's':
                        ChangeTeamStadium(modifyLogic, id);
                        correctInput = true;
                        break;
                    default:
                        const string WrongCharacterString = "PLEASE PRESS ONE OF THESE CHARACTERS:";
                        Console.WriteLine(WrongCharacterString.ToString());
                        Console.WriteLine(ButtonsString.ToString());
                        break;
                }
            }
            while (!correctInput);
        }

        private static void ChangeTeamName(ModifyLogic logic, int id)
        {
            const string NewNameString = "\nENTER NEW NAME HERE: ";
            Console.WriteLine(NewNameString.ToString());
            string newName = Console.ReadLine();

            logic.ChangeTeamName(id, newName);

            const string NameUpdatedString = "\n:: NAME HAS BEEN UPDATED ::\n";
            Console.WriteLine(NameUpdatedString.ToString());
            Console.ReadLine();
        }

        private static void ChangeTeamCity(ModifyLogic logic, int id)
        {
            const string NewCityString = "\nENTER NEW CITY HERE: ";
            Console.WriteLine(NewCityString.ToString());
            string newCity = Console.ReadLine();

            logic.ChangeTeamCity(id, newCity);

            const string CityUpdatedString = "\n:: CITY HAS BEEN UPDATED ::\n";
            Console.WriteLine(CityUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeTeamFoundationYear(ModifyLogic logic, int id)
        {
            const string NewYearString = "\nENTER NEW FOUNDATION YEAR HERE: ";
            Console.WriteLine(NewYearString.ToString());
            bool correctInput;
            int newFoundationYear;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out newFoundationYear);
                if (!correctInput)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctInput);

            logic.ChangeTeamFoundationYear(id, newFoundationYear);

            const string YearUpdatedString = "\n:: FOUNDATION YEAR HAS BEEN UPDATED ::\n";
            Console.WriteLine(YearUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeTeamValue(ModifyLogic logic, int id)
        {
            const string NewValueString = "ENTER NEW VALUE HERE: ";
            Console.WriteLine(NewValueString.ToString());
            bool correctInput;
            int newValue;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out newValue);
                if (!correctInput)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctInput);

            logic.ChangeTeamValue(id, newValue);

            const string ValueUpdatedString = "\n:: VALUE HAS BEEN UPDATED ::\n";
            Console.WriteLine(ValueUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeTeamStadium(ModifyLogic logic, int id)
        {
            const string NewStadiumString = "ENTER NEW STADIUM HERE: ";
            Console.WriteLine(NewStadiumString.ToString());
            string newStadium = Console.ReadLine();

            logic.ChangeTeamStadium(id, newStadium);

            const string StadiumUpdatedString = "\n:: STADIUM HAS BEEN UPDATED ::\n";
            Console.WriteLine(StadiumUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangePlayer(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Console.WriteLine(EnterIDString.ToString());
            int id;
            bool correctID;
            do
            {
                string readLine = Console.ReadLine();
                correctID = int.TryParse(readLine, out id);
                if (!correctID)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetPlayerByID(id) == null)
                {
                    const string NoPlayerString = "THERE IS NO PLAYER WITH THAT ID.";
                    Console.WriteLine(NoPlayerString.ToString());
                }
            }
            while (!correctID || readLogic.GetPlayerByID(id) == null);
            const string PressButtonString = "PRESS THE BUTTON BELONGING TO THE ATTRIBUTE YOU WANT TO CHANGE";
            const string ButtonsString = "('n' FOR NAME, 'b' FOR BIRTHDAY, 'a' FOR NATIONALITY, 'p' FOR POSITION, 'v' FOR VALUE)";
            Console.WriteLine(PressButtonString.ToString() + "\n" + ButtonsString.ToString());
            bool correctInput = false;
            do
            {
                char button = Console.ReadKey().KeyChar;
                switch (button)
                {
                    case 'n':
                        ChangePlayerName(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'b':
                        ChangePlayerBirthday(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'a':
                        ChangePlayerNationality(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'p':
                        ChangePlayerPosition(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'v':
                        ChangePlayerValue(modifyLogic, id);
                        correctInput = true;
                        break;
                    default:
                        const string WrongCharacterString = "PLEASE PRESS ONE OF THESE CHARACTERS:";
                        Console.WriteLine(WrongCharacterString.ToString());
                        Console.WriteLine(ButtonsString.ToString());
                        break;
                }
            }
            while (!correctInput);
        }

        private static void ChangePlayerName(ModifyLogic logic, int id)
        {
            const string NewNameString = "ENTER NEW NAME HERE: ";
            Console.WriteLine(NewNameString.ToString());
            string newName = Console.ReadLine();

            logic.ChangePlayerName(id, newName);

            const string NameUpdatedString = "\n:: NAME HAS BEEN UPDATED ::\n";
            Console.WriteLine(NameUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangePlayerBirthday(ModifyLogic logic, int id)
        {
            const string NewBirthdayString = "ENTER NEW BIRTHDAY HERE: ";
            Console.WriteLine(NewBirthdayString.ToString());
            bool correctInput;
            DateTime newBirthday;
            do
            {
                string input = Console.ReadLine();
                correctInput = DateTime.TryParse(input, out newBirthday);
                if (!correctInput)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctInput);

            logic.ChangePlayerBirthday(id, newBirthday);

            const string BirthdayUpdatedString = "\n:: BIRTHDAY HAS BEEN UPDATED ::\n";
            Console.WriteLine(BirthdayUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangePlayerNationality(ModifyLogic logic, int id)
        {
            const string NewNationalityString = "ENTER NEW NATIONALITY HERE: ";
            Console.WriteLine(NewNationalityString.ToString());
            string newNationality = Console.ReadLine();

            logic.ChangePlayerNationality(id, newNationality);

            const string NationalityUpdatedString = "\n:: NATIONALITY HAS BEEN UPDATED ::\n";
            Console.WriteLine(NationalityUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangePlayerPosition(ModifyLogic logic, int id)
        {
            const string NewPositionString = "ENTER NEW POSITION HERE: ";
            Console.WriteLine(NewPositionString.ToString());
            string newPosition = Console.ReadLine();

            logic.ChangePlayerPosition(id, newPosition);

            const string PositionUpdatedString = "\n:: POSITION HAS BEEN UPDATED ::\n";
            Console.WriteLine(PositionUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangePlayerValue(ModifyLogic logic, int id)
        {
            const string NewValueString = "ENTER NEW VALUE HERE: ";
            Console.WriteLine(NewValueString.ToString());
            bool correctInput;
            int newValue;
            do
            {
                string input = Console.ReadLine();
                correctInput = int.TryParse(input, out newValue);
                if (!correctInput)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctInput);

            logic.ChangePlayerValue(id, newValue);

            const string ValueUpdatedString = "\n:: VALUE HAS BEEN UPDATED ::\n";
            Console.WriteLine(ValueUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeManager(ModifyLogic modifyLogic, ReadLogic readLogic)
        {
            Console.WriteLine(EnterIDString.ToString());
            int id;
            bool correctID;
            do
            {
                string readLine = Console.ReadLine();
                correctID = int.TryParse(readLine, out id);
                if (!correctID)
                {
                    Console.WriteLine(WrongIDInput.ToString());
                }
                else if (readLogic.GetManagerByID(id) == null)
                {
                    const string NoManagerString = "THERE IS NO MANAGER WITH THAT ID.";
                    Console.WriteLine(NoManagerString.ToString());
                }
            }
            while (!correctID || readLogic.GetPlayerByID(id) == null);
            const string PressButtonString = "PRESS THE BUTTON BELONGING TO THE ATTRIBUTE YOU WANT TO CHANGE";
            const string ButtonsString = "('n' FOR NAME, 'b' FOR BIRTHDAY, 'a' FOR NATIONALITY, 'p' FOR PREFERRED FORMATION, 'c' FOR CONTRACT START)";
            Console.WriteLine(PressButtonString.ToString() + "\n" + ButtonsString.ToString());
            bool correctInput = false;
            do
            {
                char button = Console.ReadKey().KeyChar;
                switch (button)
                {
                    case 'n':
                        ChangeManagerName(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'b':
                        ChangeManagerBirthday(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'a':
                        ChangeManagerNationality(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'p':
                        ChangeManagerPreferredFormation(modifyLogic, id);
                        correctInput = true;
                        break;
                    case 'c':
                        ChangeManagerContractStart(modifyLogic, id);
                        correctInput = true;
                        break;
                    default:
                        const string WrongCharacterString = "PLEASE PRESS ONE OF THESE CHARACTERS:";
                        Console.WriteLine(WrongCharacterString.ToString());
                        Console.WriteLine(ButtonsString.ToString());
                        break;
                }
            }
            while (!correctInput);
        }

        private static void ChangeManagerName(ModifyLogic logic, int id)
        {
            const string NewNameString = "ENTER NEW NAME HERE: ";
            Console.WriteLine(NewNameString.ToString());
            string newName = Console.ReadLine();

            logic.ChangeManagerName(id, newName);

            const string NameUpdatedString = "\n:: NAME HAS BEEN UPDATED ::\n";
            Console.WriteLine(NameUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeManagerBirthday(ModifyLogic logic, int id)
        {
            const string NewBirthdayString = "ENTER NEW BIRTHDAY HERE: ";
            Console.WriteLine(NewBirthdayString.ToString());
            bool correctInput;
            DateTime newBirthday;
            do
            {
                string input = Console.ReadLine();
                correctInput = DateTime.TryParse(input, out newBirthday);
                if (!correctInput)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctInput);

            logic.ChangeManagerBirthday(id, newBirthday);

            const string BirthdayUpdatedString = "\n:: BIRTHDAY HAS BEEN UPDATED ::\n";
            Console.WriteLine(BirthdayUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeManagerNationality(ModifyLogic logic, int id)
        {
            const string NewNationalityString = "ENTER NEW NATIONALITY HERE: ";
            Console.WriteLine(NewNationalityString.ToString());
            string newNationality = Console.ReadLine();

            logic.ChangeManagerNationality(id, newNationality);

            const string NationalityUpdatedString = "\n:: NATIONALITY HAS BEEN UPDATED ::\n";
            Console.WriteLine(NationalityUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeManagerPreferredFormation(ModifyLogic logic, int id)
        {
            const string NewFormationString = "ENTER NEW PREFERRED FORMATION HERE: ";
            Console.WriteLine(NewFormationString.ToString());
            string newPreferredFormation = Console.ReadLine();

            logic.ChangeManagerPreferredFormation(id, newPreferredFormation);

            const string FormationUpdatedString = "\n:: PREFERRED FORMATION HAS BEEN UPDATED ::\n";
            Console.WriteLine(FormationUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void ChangeManagerContractStart(ModifyLogic logic, int id)
        {
            const string NewContractString = "ENTER NEW CONTRACT START HERE: ";
            Console.WriteLine(NewContractString.ToString());
            bool correctInput;
            DateTime newContractStart;
            do
            {
                string input = Console.ReadLine();
                correctInput = DateTime.TryParse(input, out newContractStart);
                if (!correctInput)
                {
                    Console.WriteLine(WrongInput.ToString());
                }
            }
            while (!correctInput);

            logic.ChangeManagerContractStart(id, newContractStart);

            const string ContractUpdatedString = "\n:: CONTRACT START HAS BEEN UPDATED ::\n";
            Console.WriteLine(ContractUpdatedString.ToString());

            Console.ReadLine();
        }

        private static void GetYoungestPlayers(ReadLogic readLogic)
        {
            readLogic.GetYoungestPlayers().ToList().ForEach(x => Console.WriteLine("TEAM: " + x.Team.Name + "\nPLAYERS NAME: " + x.Name + "\nBIRTHDAY: " + x.Birthday + "\n"));

            Console.ReadLine();
        }

        private static void GetTeamValue(ReadLogic readLogic)
        {
            readLogic.GetTeamValue().ToList().ForEach(x => Console.WriteLine("TEAM: " + x.Key + "\nTOTAL VALUE: " + x.Value + "\n"));

            Console.ReadLine();
        }

        private static void GetEnglishPlayers(ReadLogic readLogic)
        {
            foreach (Team team in readLogic.GetAllTeams())
            {
                Console.WriteLine("TEAM: " + team.Name);
                if (!readLogic.GetEnglishPlayers().ToList().Exists(x => x.TeamID.Equals(team.TeamID)))
                {
                    const string NoEnglishString = "THE TEAM HAS NO ENGLISH PLAYERS.\n";
                    Console.WriteLine(NoEnglishString.ToString());
                }
                else
                {
                    readLogic.GetEnglishPlayers().Where(x => x.TeamID.Equals(team.TeamID)).ToList().ForEach(p => Console.WriteLine("PLAYER: " + p.Name));
                    Console.WriteLine("\n");
                }
            }

            Console.ReadLine();
        }

        private static void GetYoungestPlayersAsync(ReadLogic readLogic)
        {
            var task = readLogic.GetYoungestPlayersAsync();
            task.Wait();
            var result = task.Result;
            result.ToList().ForEach(x => Console.WriteLine("TEAM: " + x.Team.Name + "\nPLAYERS NAME: " + x.Name + "\nBIRTHDAY: " + x.Birthday + "\n"));

            Console.ReadLine();
        }

        private static void GetTeamValueAsync(ReadLogic readLogic)
        {
            var task = readLogic.GetTeamValueAsync();
            task.Wait();
            var result = task.Result;
            result.ToList().ForEach(x => Console.WriteLine("TEAM: " + x.Key + "\nTOTAL VALUE: " + x.Value + "\n"));

            Console.ReadLine();
        }

        private static void GetEnglishPlayersAsync(ReadLogic readLogic)
        {
            var result = readLogic.GetEnglishPlayersAsync().Result;
            foreach (Team team in readLogic.GetAllTeams())
            {
                Console.WriteLine("TEAM: " + team.Name);
                if (!result.ToList().Exists(x => x.TeamID.Equals(team.TeamID)))
                {
                    const string NoEnglishString = "THE TEAM HAS NO ENGLISH PLAYERS.\n";
                    Console.WriteLine(NoEnglishString.ToString());
                }
                else
                {
                    result.Where(x => x.TeamID.Equals(team.TeamID)).ToList().ForEach(p => Console.WriteLine("PLAYER: " + p.Name));
                    Console.WriteLine("\n");
                }
            }

            Console.ReadLine();
        }
    }
}
