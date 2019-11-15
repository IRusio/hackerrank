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

class Solution {

    // Complete the howManyGames function below.
         static int howManyGames(int startPrice, int howMuchDecreased, int minimalPrice, int budget)
        {
            int gamesToBuy = 0;
            int actualPrice = startPrice;
            while (budget > 0)
            {
                if (budget - actualPrice >= 0)
                {
                    gamesToBuy++;
                    budget -= actualPrice;
                    if (actualPrice - howMuchDecreased >= minimalPrice)
                    {
                        actualPrice -= howMuchDecreased;
                    }
                    else
                    {
                        actualPrice = minimalPrice;
                    }
                }
                else
                {
                    budget = 0;
                }
            }

            return gamesToBuy;
        }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] pdms = Console.ReadLine().Split(' ');

        int p = Convert.ToInt32(pdms[0]);

        int d = Convert.ToInt32(pdms[1]);

        int m = Convert.ToInt32(pdms[2]);

        int s = Convert.ToInt32(pdms[3]);

        int answer = howManyGames(p, d, m, s);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
