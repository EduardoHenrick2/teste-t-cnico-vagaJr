using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

public class Program
{
    public static bool Palindrome(string s)
    {
        string cleaned = Regex.Replace(s.ToLower(), @"[^a-z0-9]", "");

        int left = 0;
        int right = cleaned.Length - 1;

        while (left < right)
        {
            if (cleaned[left] != cleaned[right])
            {
                return false;
            }
            left++;
            right--;
        }

        return true;
    }

    public static void Main(string[] args)
    {
        string [] testes = [ "Arara", "Ovo", "Roma me tem amor", "O lobo ama bolo", "Hello"];

        foreach (string teste in testes)
        {
            Console.WriteLine($"'{teste}' é um palíndromo? {Palindrome(teste)}");
        }
    }
}