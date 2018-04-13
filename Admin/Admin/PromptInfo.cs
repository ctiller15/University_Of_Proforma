using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin
{
    // A simple helper class to place the prompt information in a more managable form.
    class PromptInfo
    {
        public string PromptText { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }

        public PromptInfo(string text, int lower, int upper)
        {
            PromptText = text;
            LowerBound = lower;
            UpperBound = upper;

        }
    }
}
