using System;
using System.Collections.Generic;
using System.Text;

namespace AlergiesV2
{
    public class Allergies
    {
        private static Dictionary<string, int> allergies;

        public static int NrAllergies
        {
            get { return allergies.Count; }
        }

        static Allergies()
        {
            allergies = new Dictionary<string, int>();
                   
            allergies.Add("cats", 128);
            allergies.Add("pollen", 64);
            allergies.Add("chocolate", 32);
            allergies.Add("tomatoes", 16);
            allergies.Add("strawberries", 8);
            allergies.Add("shellfish", 4);
            allergies.Add("peanuts", 2);
            allergies.Add("eggs", 1);
        }

        public static string ReturnAlergies(int score)
        {
            StringBuilder setAlergies = new StringBuilder();

            score = score %((int) Math.Pow(2, allergies.Count));

            foreach (var allergy in allergies)
            {
                if (score >= allergy.Value)
                {
                    setAlergies.Append(String.Format($"\t- {allergy.Key}\n"));
                    score -= allergy.Value;
                }
            }

            return setAlergies.ToString();
        }

        public static int GenerateScoreAdd(int score = 0)
        {
            score = score % (int)Math.Pow(2, allergies.Count);
            if (score == (int)Math.Pow(2, allergies.Count)-1)
            {
                Console.WriteLine("The patient have allready all the allergies");
                return score;
            }
            string option = "";
            string options = "";

            foreach (var allergy in allergies)
                options+=String.Format($"\t- {allergy.Key}\n");
            options += "\t- exit to finish";
            do
            {
                Console.WriteLine($"Insert the new allergy (one from below):\n{options}");
                option = Console.ReadLine().ToLower();

                if (allergies.ContainsKey(option))
                    if (score % (allergies[option] * 2) >= allergies[option])
                        Console.WriteLine("This allergy was already added");
                    else
                        score += allergies[option];
                else if (option != "exit")
                    Console.WriteLine("This allergy is not on the list");

            } while (!option.ToLower().Equals("exit"));

            return score;
        }

        public static int GenerateScoreRemove(int score = 0)
        {
            if (score == 0)
            {
                Console.WriteLine("The patient have no allergy to remove");
                return 0;
            }
            score = score % (int)Math.Pow(2, allergies.Count);

            string option = "";
            string options = "";

            foreach (var allergy in allergies)
                options += String.Format($"\t- {allergy.Key}\n");
            options += "\t- exit to finish";
            do
            {
                Console.WriteLine($"Insert the allergy that you want to remove (one from below):\n{options}");
                option = Console.ReadLine().ToLower();

                if (allergies.ContainsKey(option))
                    if (score % (allergies[option] * 2) >= allergies[option])
                        score -= allergies[option];
                    else
                        Console.WriteLine("The patient didn't have this allergy");
                else if (option != "exit")
                    Console.WriteLine("This allergy is not on the list");

            } while (!option.ToLower().Equals("exit"));

            return score;
        }
    }
}
