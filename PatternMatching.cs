using System;

namespace rvajustin.CSharp9
{
    public static class PatternMatching
    {

        public static void Example1() {
            
            var capital = GetCapitalUsingSwitchStatement(State.Virginia);

        }

        public enum State {
            Virginia,
            California
        }

        public static string GetCapitalUsingSwitchStatement(State state)
        {
            string capital;

            switch (state)
            {
                case State.Virginia:
                    capital = "Richmond";
                    break;
                case State.California:
                    capital = "Sacramento";
                    break;
                default:
                    throw new ArgumentException("Blaaaaarg!");
            };

            return capital;
        }

        public static void Example2() {
            var capital = GetCapitalUsingSwitchExpression(State.Virginia);
        }

        public static string GetCapitalUsingSwitchExpression(State state)
        {
            string capital = state switch 
            {
                State.Virginia => "Richmond",
                State.California => "Sacramento",
                _ => throw new ArgumentException("Blaaaaarg!")
            };

            return capital;
        }

        public static void Example3() {
            var capital = GetCapitalUsingComplexSwitchExpression(State.Virginia, 1855);
        }

        public static string GetCapitalUsingComplexSwitchExpression(State state, int year)
        {
            string capital = state switch 
            {
                State.Virginia => "Richmond",
                State.California when year >= 1854 => "Sacramento",
                State.California when year >= 1853 => "Benicia",
                State.California when year >= 1852 => "Vallejo",
                State.California when year >= 1850 => "San Jose",
                _ => throw new Exception("Blaaaaarg!")
            };

            return capital;
        }

    }
}