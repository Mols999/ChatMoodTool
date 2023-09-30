using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMoodTool.Models
{
    public class Conversation
    {

        // Declare public properties for storing different types of messages
        public List<string> HappyMessages { get; set; }
        public List<string> SadMessages { get; set; }
        public List<string> NeutralMessages { get; set; }


        // Declare public properties to store word counts for different sentiments
        public int HappyWordCount { get; set; }
        public int SadWordCount { get; set; }
        public int NeutralWordCount { get; set; }
    }
}
