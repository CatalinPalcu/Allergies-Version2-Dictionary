using System;
using System.Collections.Generic;

namespace AlergiesV2
{
    class Program
    {
        static void Main(string[] args)
        {
            Patient tom = new Patient("Tom", 254);
            tom.ListAlergies();

            tom.AddAllergies();
            tom.ListAlergies();

            tom.AddAllergies();
            tom.ListAlergies();

            tom.RemoveAllergies();
            tom.ListAlergies();

            
        }
    }

    
}
