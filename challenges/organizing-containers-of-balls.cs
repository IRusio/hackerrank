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

    // Complete the organizingContainers function below.
    static string organizingContainers(int[][] container) 
    {
        List<int> listOfElementsInMatrix = new List<int>();
        List<int> containerCapacity = new List<int>();
        
        for(int i = 0 ; i < container.Length ; i++)
        {
            for(int j = 0 ; j < container[i].Length ; j++)
            {
                if(i==0)
                {
                    listOfElementsInMatrix.Add(container[i][j]);
                    containerCapacity.Add(container[j][i]);
                }
                else
                {
                    listOfElementsInMatrix[j] += container[i][j];
                    containerCapacity[j] += container[j][i];
                }
            }
        }
        
        return IsPossibleSwapElements(listOfElementsInMatrix, containerCapacity);
    }

    private static string IsPossibleSwapElements(List<int> listOfElementsInMatrix, List<int> containerCapacity)
    {
        int valueBefore = listOfElementsInMatrix[0];
        foreach(var ballsInContainers in listOfElementsInMatrix)
        {
            if(valueBefore != ballsInContainers && !containerCapacity.Contains(ballsInContainers))
            {
                return "Impossible";
            }
            else
            {
                containerCapacity.Remove(ballsInContainers);
            }
        }

        return "Possible";
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            int n = Convert.ToInt32(Console.ReadLine());

            int[][] container = new int[n][];

            for (int i = 0; i < n; i++) {
                container[i] = Array.ConvertAll(Console.ReadLine().Split(' '), containerTemp => Convert.ToInt32(containerTemp));
            }

            string result = organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
