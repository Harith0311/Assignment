using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    internal class palindrome
    {
        static void Main(string[] args)
        {
            // Prompt the user to enter input string and trash symbol string
            Console.Write("Enter input string: ");
            string inputString = Console.ReadLine();

            Console.Write("Enter trash symbol string: ");
            string trashSymbolString = Console.ReadLine();

            // Create an instance of PalindromeChecker
            PalindromeChecker checker = new PalindromeChecker(inputString, trashSymbolString);

            // Call the CheckPalindrome method and display the result
            bool isPalindrome = checker.IsPalindrome();
            Console.WriteLine("Is palindrome: " + isPalindrome);

            Console.ReadKey();
        }
    }

    public class PalindromeChecker
    {
        //readonly is used to indicates that this field can only be set once
        //HashSet<char> data type is used to store unique characters in no particular order
        private readonly string inputString;
        private readonly HashSet<char> trashSymbols;

        public PalindromeChecker(string inputString, string trashSymbolString)
        {
            this.inputString = inputString;
            //assign trashSymbolString to trashSymbols and converted to lower case to avoid case sensitive
            trashSymbols = new HashSet<char>(trashSymbolString.ToLower());
        }

        public bool IsPalindrome()
        {
            //Define left and right to check the palindrome from both side of the input string
            int left = 0, right = inputString.Length - 1;

            while (left < right)
            {
                //To check left side of string contain trash symbol or not.
                //If yes, left will be incremented by 1 to move to the next character
                while (left < right && trashSymbols.Contains(char.ToLower(inputString[left])))
                {
                    left++;
                }

                //To check right side of string contain trash symbol or not.
                //If yes, right will be decremented by 1 to move to the next character
                while (left < right && trashSymbols.Contains(char.ToLower(inputString[right])))
                {
                    right--;
                }

                //To check palindrome by checking left and right side of string is same or not
                if (char.ToLower(inputString[left]) != char.ToLower(inputString[right]))
                {
                    return false;
                }

                //Move to the next character
                left++;
                right--;
            }

            return true;
        }
    }


}
