using System.Collections.Generic; 
using System.Diagnostics; 
using System.Linq;  
using System.Text.RegularExpressions;  
using System.Windows.Controls;  
using ChatMoodTool.Models; 

namespace ChatMoodTool.Models
{

    public class ChatSearchService
    {
        // Public properties to store word counts for different sentiments
        public int HappyWordCount { get; set; }
        public int SadWordCount { get; set; }
        public int NeutralWordCount { get; set; }

        // Method to search for a word in different ListBoxes and update word counts
        public void SearchForWord(string word, ListBox happyListBox, ListBox sadListBox, ListBox neutralListBox)
        {
            // Call CountOccurrences method for each ListBox to count word occurrences
            HappyWordCount = CountOccurrences(word, happyListBox);
            SadWordCount = CountOccurrences(word, sadListBox);
            NeutralWordCount = CountOccurrences(word, neutralListBox);
        }

        // Private method to count word occurrences in a ListBox
        private int CountOccurrences(string word, ListBox listBox)
        {
            // Check if the ListBox is null, and if so, return 0 occurrences
            if (listBox == null)
                return 0;

            int count = 0; 

            // Iterate through items in the ListBox
            foreach (var item in listBox.Items)
            {
                // Check if the item is a ListBoxItem
                if (item is ListBoxItem listBoxItem)
                {
                    // Extract the text content of the ListBoxItem
                    string itemText = listBoxItem.Content?.ToString();

                    // Check if the itemText is not null or empty and if it contains the whole word
                    if (!string.IsNullOrEmpty(itemText) && ContainsWholeWord(itemText, word))
                    {
                        count++;  // Increment the count for word occurrences
                        Debug.WriteLine(itemText); 
                    }
                }
            }

            return count;  // Return the total count of word occurrences in the ListBox
        }

        // Method to check if a string contains the whole word using a regular expression
        public bool ContainsWholeWord(string input, string search)
        {
            // Define a regular expression pattern to match the whole word
            string pattern = @"\b" + Regex.Escape(search) + @"\b";

            // Use Regex.IsMatch to check if the input string contains the whole word (case-insensitive)
            return Regex.IsMatch(input, pattern, RegexOptions.IgnoreCase);
        }
    }
}
