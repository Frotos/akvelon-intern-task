using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace BalanceVerificatorLib { 
  
  public class BalanceVerificator {
    private readonly Dictionary<char, char> _allowedSymbols = new Dictionary<char, char>() {
      {'{', '}'},
      {'(', ')'},
      {'[', ']'}
    };

    /// <summary>
    /// Validates if input string, with brackets, is balanced or no.
    /// </summary>
    /// <param name="value">Input string with brackets.</param>
    /// <returns>Position of bracket, that doesn't have pair, if string is not balanced or -1, if input string is balanced.</returns>
    /// <exception cref="ArgumentException">Thrown if in argument of function is any other symbol besides excluding brackets.</exception>
    public int Verify(string value) {
      // Throws exception, if there's another symbol besides allowed.
      if (!value.All(c => _allowedSymbols.Keys.Contains(c) || _allowedSymbols.Values.Contains(c))) {
        throw new ArgumentException("IllegalArgumentException");
      }
        
      List<KeyValuePair<char, int>> processedBrackets = new List<KeyValuePair<char, int>>();
      for (int i = 0; i < value.Length; i++) {
        // If list is empty, adds first character.
        if (processedBrackets.Count == 0) {
          processedBrackets.Add(new KeyValuePair<char, int>(value[i], i));
        }
        // Removes the opening bracket from list for the current(closing) bracket.
        else if (processedBrackets.Any(pair => _allowedSymbols[pair.Key] == value[i])) {
          // Finds opening bracket in list.
          var openingBracket = processedBrackets.Where(pair => pair.Key == _allowedSymbols.
              FirstOrDefault(x => x.Value == value[i]).Key);
         processedBrackets.Remove(openingBracket.ElementAt(openingBracket.Count() - 1));
        }
        // Adds current bracket to list if it hasn't opening bracket(or it's an opening bracket).
        else {
          processedBrackets.Add(new KeyValuePair<char, int>(value[i], i));
        }
      }
      // Returns position of unpaired bracket or -1, if input string is balanced.
      if (processedBrackets.Count > 0) {
        Console.WriteLine("NOT BALANCED");
        return processedBrackets[processedBrackets.Count - 1].Value + 1;
      }
      else { 
        Console.WriteLine("BALANCED");
        return -1;
      }
    }
  }
}