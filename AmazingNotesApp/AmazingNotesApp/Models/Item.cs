using System;
using System.Collections.Generic;
using System.Text;

namespace AmazingNotesApp.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PublishDateTime { get; set; }

        public Item()
        {
            PublishDateTime = DateTime.Now;
        }
    }
}
