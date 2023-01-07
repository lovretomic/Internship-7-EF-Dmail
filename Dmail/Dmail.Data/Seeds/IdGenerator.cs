using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dmail.Data.Seeds
{
    public static class IdGenerator
    {
        private static int MaxUserId = 0;
        private static int MaxMessageEventId = 0;
        public static int NewUserId()
        {
            MaxUserId++;
            return MaxUserId;
        }
        public static int NewMessageEventId()
        {
            MaxMessageEventId++;
            return MaxMessageEventId;
        }
        public static string GetMailDummyText()
        {
            var dummy = "Lorem ipsum dolor sit amet, consectetur adipiscing elit." +
                " Etiam auctor lorem at auctor cursus. Nunc gravida tincidunt mauris," +
                " non laoreet magna gravida vitae. Nullam tempor consequat sem, id iaculis ante tristique a." +
                " Pellentesque fringilla mattis molestie. Nunc eu ante a urna feugiat congue. Donec volutpat" +
                " nisi eu libero commodo, a.";
            return dummy;
        }
    }
}
