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

    // Complete the twoStrings function below.
    static string TwoStrings(string s1, string s2) 
    {
        var s1Signs = DeserializeString(s1);
        var s2signs = DeserializeString(s2);        
        
        if(IsAviableSubstring(s1Signs,s2signs))
            return "YES";
        else
            return "NO";
    }

    static Dictionary<char,int> DeserializeString(string word)
    {
        var charDictionary = new Dictionary<char, int>();

        foreach(var sign in word)
            if(charDictionary.ContainsKey(sign))
                charDictionary[sign] += 1;
            else
                charDictionary[sign] = 1;

        return charDictionary;
    }

    static bool IsAviableSubstring(Dictionary<char,int> DictionaryOne, Dictionary<char,int> DictionaryTwo)
    {
        foreach(var key in DictionaryOne.Keys)
            if(DictionaryTwo.ContainsKey(key))
                return true;

        return false;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = TwoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
