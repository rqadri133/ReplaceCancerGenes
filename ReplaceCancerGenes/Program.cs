using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;


namespace ReplaceCancerGenes
{
    public  class GeneticsConcluions
    {

        private static int GeneHealth(int n, List<string> genes, List<int> health, int s, int first, int last, string d)
        {
            List<Genetics> genetics = new List<Genetics>();
            List<int> healtheirs = new List<int>();
            int healthCount = 0;

            int index = 0;
            for (int healthIndex = 0; healthIndex < health.Count; healthIndex++)
            {
                var genetic = new Genetics() { gene = genes[healthIndex], health = health[healthIndex], index = index };

                genetics.Add(genetic);
                index++;

            }

            var lstGenetics = genetics.FindAll(p => p.index >= first && p.index <= last);
            // Console.WriteLine("Total Genetics Frame " + lstGenetics.Count);
            int chrCounts = 0;
            foreach (Genetics block in lstGenetics)
            {

                //  Console.WriteLine(d);
                if (d.Contains(block.gene))
                {
                    // Console.WriteLine($"Gene Found {block.gene}");
                    string[] separator = { block.gene };
                    string[] blockentries = d.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                
                    for (int i = 0; i < blockentries.Count(); i++)
                    {
                        //Console.WriteLine("Block Health " + block.health);  
                        healthCount = healthCount + block.health;
                    }

                }



            }



            return healthCount;





        }

        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> genes = Console.ReadLine().TrimEnd().Split(' ').ToList();

            List<int> health = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(healthTemp => Convert.ToInt32(healthTemp)).ToList();

            int s = Convert.ToInt32(Console.ReadLine().Trim());
            List<int> temps = new List<int>();

            for (int sItr = 0; sItr < s; sItr++)
            {
                string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

                int first = Convert.ToInt32(firstMultipleInput[0]);

                int last = Convert.ToInt32(firstMultipleInput[1]);

                string d = firstMultipleInput[2];

                int healthAnalytics = GeneHealth(n, genes, health, s, first, last, d);

                temps.Add(healthAnalytics);


            }
            int min = temps.Min();
            int max = temps.Max();
            Console.WriteLine($"{min} {max}");
        }
    }

}


