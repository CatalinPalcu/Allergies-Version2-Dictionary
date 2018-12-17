using System;
using System.Collections.Generic;
using System.Text;

namespace AlergiesV2
{
    public class Patient
    {
        private readonly string name;
        private int score;

        public string Name
        {
            get
            {
                return this.name;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
            set
            {
                score = value>=0 ? value : 0;
            }
        }

        public Patient(string name, int score = 0)
        {
            this.name = name;
            this.Score = score;
        }

        public void ListAlergies()
        {
            string alergiesList = Allergies.ReturnAlergies(score);

            if (alergiesList.Length == 0)
            {
                Console.WriteLine($"{Name} doesn't have any of the tested allergies");
            }
            else
            {
                Console.WriteLine($"{Name} is allergic to the following allergens:\n{alergiesList}");
            }
        }

        public void AddAllergies()
        {
            score = Allergies.GenerateScoreAdd(score);
        }

        public void RemoveAllergies()
        {
            score = Allergies.GenerateScoreRemove(score);
        }


    }
}
