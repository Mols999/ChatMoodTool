using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using System.Xml.Linq;

namespace ChatMoodTool.Models
{
    public class MessageLoader
    {
        // Method to load chat messages into ListBoxes
        public void LoadMessages(ListBox happyChatListBox, ListBox sadChatListBox, ListBox neutralListBox)
        {
            try
            {
                // Specify the XML file containing chat messages
                string fileName = "messages.xml";

                // Load the XML document using LINQ to XML
                XDocument xdoc = XDocument.Load(fileName);

                // Load messages for each sentiment category into the corresponding ListBox
                LoadMessagesBySentiment(xdoc, happyChatListBox, "happy");
                LoadMessagesBySentiment(xdoc, sadChatListBox, "sad");
                LoadMessagesBySentiment(xdoc, neutralListBox, "neutral");
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error loading chat messages: " + ex.Message);
            }
        }

        // Method to load messages of a specific sentiment into a ListBox
        private void LoadMessagesBySentiment(XDocument xdoc, ListBox listBox, string sentiment)
        {
            // Clear the existing items in the ListBox
            listBox.Items.Clear();

            // Use LINQ to XML to select message values from the XML document
            var messages = from messageElement in xdoc.Root.Element(sentiment).Elements("message")
                           select messageElement.Value;

            // Iterate through the selected messages and add them to the ListBox
            foreach (var message in messages)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = message;
                listBox.Items.Add(item);
            }
        }
    }
}
