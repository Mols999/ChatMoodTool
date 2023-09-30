using ChatMoodTool.Models;
using System.Collections.Generic;  
using System.Windows;  
using System.Windows.Controls;  

namespace ChatMoodTool
{
    public partial class MainWindow : Window
    {
        public Conversation DataContext { get; set; } 
        private MessageLoader messageLoader;  
        private ChatSearchService searchService;  
        private string selectedMessage = null;  

        public MainWindow()
        {
            //Method to initialize the window
            InitializeComponent();  

            // Initialize the data context with a new Conversation object
            DataContext = new Conversation
            {
                HappyMessages = new List<string>(),
                SadMessages = new List<string>(),
                NeutralMessages = new List<string>(),
                HappyWordCount = 0,
                SadWordCount = 0,
                NeutralWordCount = 0
            };

            // Initialize the messageLoader and searchService objects
            messageLoader = new MessageLoader();
            searchService = new ChatSearchService();

            // Load messages into list boxes
            messageLoader.LoadMessages(happyListBox, sadListBox, neutralListBox);
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string searchWord = searchTextBox.Text.ToLower(); 

            // Use the searchService to search for the searchWord
            searchService.SearchForWord(searchWord, happyListBox, sadListBox, neutralListBox);

            // Retrieve word counts from the searchService
            int happyWordCount = searchService.HappyWordCount;
            int sadWordCount = searchService.SadWordCount;
            int neutralWordCount = searchService.NeutralWordCount;

            // Update labels displaying word counts
            happyWordCountLabel.Text = $"Happy Word Count: {happyWordCount}";
            sadWordCountLabel.Text = $"Sad Word Count: {sadWordCount}";
            neutralWordCountLabel.Text = $"Neutral Word Count: {neutralWordCount}";
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox listBox = sender as ListBox;

            // Check if a ListBox and an item within it are selected
            if (listBox != null && listBox.SelectedItem != null)
            {
                selectedMessage = listBox.SelectedItem.ToString(); 
            }
        }

        private void RemoveSelectedMessage(ListBox listBox)
        {
            // Check if a ListBox and a selected message exist
            if (listBox != null && selectedMessage != null)
            {
                // Remove the selected message from the ListBox
                listBox.Items.Remove(selectedMessage);
                selectedMessage = null;  
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            // Call RemoveSelectedMessage for each of the list boxes (happyListBox, sadListBox, neutralListBox)
            RemoveSelectedMessage(happyListBox);
            RemoveSelectedMessage(sadListBox);
            RemoveSelectedMessage(neutralListBox);
        }
    }
}
