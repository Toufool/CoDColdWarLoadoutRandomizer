using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodColdWarRandomizer
{
    class Program
    {
        static void Main(string[] args)
        {
            bool generateLoadouts = true;
            while (generateLoadouts == true)
            {
                Random random = new Random();

                //user is asked the number of loadouts they want to generate and if they want to generate their own player names.
                int numberOfLoadouts = GetNumberOfLoadouts();
                bool playerNamesOption = PlayerNamesOption();
                List<string> playerNamesList = GetPlayerNamesList(playerNamesOption, numberOfLoadouts);

                for (int i = 0; i < numberOfLoadouts; i++)
                {
                    string wildcard = GetWildcard(random);
                    string primaryAndSecondary = GetPrimaryAndSecondary(wildcard, random);
                    string perks = GetPerks(wildcard, random);
                    string tactical = GetTactical(random);
                    string lethal = GetLethal(random);
                    string fieldUpgrade = GetFieldUpgrade(random);
                    string scorestreaks = GetScorestreaks(random);

                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(playerNamesList[i] + "'s Loadout");
                    Console.WriteLine("--------------------------------------");
                    Console.WriteLine(primaryAndSecondary);
                    Console.WriteLine("Tactical: " + tactical);
                    Console.WriteLine("Lethal: " + lethal);
                    Console.WriteLine("Field Upgrade: " + fieldUpgrade);
                    Console.WriteLine(perks);
                    Console.WriteLine("Scorestreaks: " + scorestreaks);
                    Console.WriteLine("Wildcard: " + wildcard);
                    Console.WriteLine(" ");
                }
                Console.WriteLine("All Loadouts have been generated.");
                generateLoadouts = GenerateLoadouts();
            }
            System.Environment.Exit(1);


        }

        static int GetNumberOfLoadouts()
        {
            while (true)
            {
                try
                {
                    Console.Write("How many random loadouts do you want to generate? ");
                    int numberOfLoadouts = Convert.ToInt32(Console.ReadLine());
                    return numberOfLoadouts;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                    Console.WriteLine(" ");
                }

            }
        }

        static bool PlayerNamesOption()
        {
            while(true)
            {
                Console.Write("Do you want to enter player names? y/n ");
                string playerNamesOptionstr = Console.ReadLine();
                if (playerNamesOptionstr == "y")
                {
                    bool playerNamesOption = true;
                    return playerNamesOption;
                }
                else if (playerNamesOptionstr == "n")
                {
                    bool playerNamesOption = false;
                    return playerNamesOption;
                }
                else
                {
                    Console.WriteLine("Invalid entry.\n");
                }
            }
        }

        static List<string> GetPlayerNamesList(bool playerNamesOption, int numberOfLoadouts)
        {
            List<string> playerNamesList = new List<string>();
            if (playerNamesOption == true)
            {
                for (int i = 1; i < numberOfLoadouts + 1; i++)
                {
                    Console.Write("Enter Player " + i.ToString() + "'s name: ");
                    playerNamesList.Add(Console.ReadLine());
                }
            }
            else
            {
                for (int i = 1; i < numberOfLoadouts + 1; i++)
                {
                    playerNamesList.Add("Player " + i.ToString());
                }
            }
            return playerNamesList;
        }
        static string GetWildcard(Random random)
        {
            List<string> wildcardList = new List<string>() { "Danger Close", "Law Breaker", "Gunfighter", "Perk Greed" };
            string wildcard = wildcardList[random.Next(wildcardList.Count())];
            return wildcard;
        }

        static string GetPrimaryAndSecondary(string wildcard, Random random)
        {
            List<string> primaryList = new List<string>() { "XM4", "AK-74", "Krig 6", "QBZ-83", "FFAR 1", "MP5", "Milano 821", "AK-74u", "KSP 45", "Bullfrog", "Type 63", "M16", "AUG", "DMR 14",
                "Stoner 63", "RPD", "M60", "Pellington 703", "LW3 - Tundra", "M82" };
            List<string> secondaryList = new List<string>() { "1911", "Magnum", "Diamatti", "Hauer 77", "Gallo SA12", "Cigma 2", "RPG-7", "Knife", "M79" };
            List<string> allWeaponsList = new List<string>() { "XM4", "AK-74", "Krig 6", "QBZ-83", "FFAR 1", "MP5", "Milano 821", "AK-74u", "KSP 45", "Bullfrog", "Type 63", "M16", "AUG", "DMR 14",
                "Stoner 63", "RPD", "M60", "Pellington 703", "LW3 - Tundra", "M82", "1911", "Magnum", "Diamatti", "Hauer 77", "Gallo SA12", "Cigma 2", "RPG-7", "Knife", "M79" };
            int i;
            string primary;
            string secondary;

            //Law Breaker wildcard allows the player to equip a primary or secondary weapon in either slot.
            if (wildcard == "Law Breaker")
            {
                i = random.Next(allWeaponsList.Count);
                primary = allWeaponsList[i];
                allWeaponsList.RemoveAt(i);
                i = random.Next(allWeaponsList.Count);
                secondary = allWeaponsList[i];
            }
            else
            {
                i = random.Next(primaryList.Count);
                primary = primaryList[i];
                i = random.Next(secondaryList.Count);
                secondary = secondaryList[i];
            }

            string primaryAndSecondary = "Primary: " + primary + "\nSecondary: " + secondary;
            return primaryAndSecondary;
        }

        static string GetPerks(string wildcard, Random random)
        {
            List<string> perk1List = new List<string>() { "Engineer", "Paranoia", "Flak Jacket", "Tactical Mask", "Forward Intel" };
            List<string> perk2List = new List<string>() { "Assassin", "Gearhead", "Scavenger", "Quartermaster", "Tracker" };
            List<string> perk3List = new List<string>() { "Gung-Ho", "Ghost", "Cold Blooded", "Ninja", "Spycraft" };
            List<string> perk1 = new List<string>();
            List<string> perk2 = new List<string>();
            List<string> perk3 = new List<string>();
            int i;

            //Perk Greed allows the user to equip an extra perk from each Perk Category
            if (wildcard == "Perk Greed")
            {
                i = random.Next(perk1List.Count);
                perk1.Add(perk1List[i]);
                perk1List.RemoveAt(i);
                i = random.Next(perk1List.Count);
                perk1.Add(perk1List[i]);

                i = random.Next(perk2List.Count);
                perk2.Add(perk2List[i]);
                perk2List.RemoveAt(i);
                i = random.Next(perk2List.Count);
                perk2.Add(perk2List[i]);

                i = random.Next(perk3List.Count);
                perk3.Add(perk3List[i]);
                perk3List.RemoveAt(i);
                i = random.Next(perk3List.Count);
                perk3.Add(perk3List[i]);

            }
            else
            {
                i = random.Next(perk1List.Count);
                perk1.Add(perk1List[i]);

                i = random.Next(perk2List.Count);
                perk2.Add(perk2List[i]);

                i = random.Next(perk3List.Count);
                perk3.Add(perk3List[i]);
            }

            string perk1str = string.Join(", ", perk1);
            string perk2str = string.Join(", ", perk2);
            string perk3str = string.Join(", ", perk3);
            string perks = "Perk 1: " + perk1str + "\nPerk 2: " + perk2str + "\nPerk 3: " + perk3str;
            return perks;
        }

        static string GetTactical(Random random)
        {
            List<string> tacticalList = new List<string>() { "Stun Grenade", "Stimshot", "Smoke Grenade", "Flashbang", "Decoy" };
            int i;
            i = random.Next(tacticalList.Count);
            string tactical = tacticalList[i];
            return tactical;
        }

        static string GetLethal(Random random)
        {
            List<string> lethalList = new List<string>() { "Frag", "C4", "Semtex", "Molotov", "Tomahawk" };
            int i;
            i = random.Next(lethalList.Count);
            string lethal = lethalList[i];
            return lethal;
        }

        static string GetFieldUpgrade(Random random)
        {
            List<string> fieldUpgradeList = new List<string>() { "Proximity Mine", "Field Mic", "Trophy System", "Assault Pack", "Sam Turret", "Jammer", "Gase Mine" };
            int i;
            i = random.Next(fieldUpgradeList.Count);
            string fieldUpgrade = fieldUpgradeList[i];
            return fieldUpgrade;
        }

        static string GetScorestreaks(Random random)
        {
            List<string> scorestreakList = new List<string>() {"Combat Bow", "RC-XD", "Spy Plane", "Counter Spy Plane", "Armor", "Sentry Turret", "Care Package", "Napalm Strike", "Air Patrol", "Artillery", "Cruise Missile",
                "War Machine", "Attack Helicopter", "Chopper Gunner", "VTOL Escort", "Gunship"};
            List<string> scorestreaks = new List<string>();
            int i;

            for (int index = 0; index < 3; index++)
            {
                i = random.Next(scorestreakList.Count);
                scorestreaks.Add(scorestreakList[i]);
                scorestreakList.RemoveAt(i);
            }

            string scorestreaksstr = string.Join(", ", scorestreaks);
            return scorestreaksstr;

        }

        static bool GenerateLoadouts()
        {
            while (true)
            {
                Console.Write("Do you want to generate more loadouts? Entering n will close the program. y/n ");
                string generateLoadoutsstr = Console.ReadLine();
                if (generateLoadoutsstr == "y")
                {
                    bool generateLoadouts = true;
                    return generateLoadouts;
                }
                else if (generateLoadoutsstr == "n")
                {
                    bool generateLoadouts = false;
                    return generateLoadouts;
                }
                else
                {
                    Console.WriteLine("Invalid entry.\n");
                }
            }
        }

    }
}
