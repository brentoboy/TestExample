using System;
namespace MegaDesk
{
    public class Desk
    {
        public const int MIN_WIDTH = 10;
        public const int MAX_WIDTH = 99;

        public const int MIN_DEPTH = 15;
        public const int MAX_DEPTH = 20;

        public int? Width;
        public int? Depth;

        public Desk(int depth = Desk.MIN_WIDTH, int width = Desk.MIN_DEPTH)
        {
            this.Width = width;
            this.Depth = depth;
        }

        public static int? ValidateWidth(int? value) {
            // whatever your logic is belongs here
            // it breaks a rule, throw an exception

            // if it needs to be adjusted, but isnt a problem, then just change the value

            return value; // if the validation logic changed it, we should return the updated logic
        }

        public static int? ValidateDepth(int? value) {
            // whatever your logic is belongs here
            // it breaks a rule, throw an exception

            // if it needs to be adjusted, but isnt a problem, then just change the value


            return value; // if the validation logic changed it, we should return the updated logic
        }
    }
}
