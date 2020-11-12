namespace rvajustin.CSharp9
{
    public static class Records
    {

        public static void Example1() {
            // given some record type
            // and two instances of that type with the same member data
            var mine = new Vehicle("Honda", "Accord", 1993);
            var yours = new Vehicle("Honda", "Accord", 1993);

            // when equality is checked
            var areEquivalent = mine == yours;

            // then they are equal
            // areEquivalent is true
        }

        public static void Example2() {
            // and an instance of that type
            var mine = new Vehicle("Honda", "Accord", 1993);

            // when the data is modified
            // mine.Year = 2020; // can't upgrade, sorry :(

            // then (trust me on this one) the compiler will complain
            /* red squiggly underline and compiler panic */
        }

        public static void Example3() {
            // given some record type
            // and an instance of that type
            var mine = new Vehicle("Honda", "Accord", 1993);

            // when the data is modified using a "with" expression
            var tradeIn = mine with { Year = 2020 }; // sweet new ride!

            // then a new instance is created but with specific data modifications
            // and the new instance is not equal
            // mine != tradeIn
        }


    }

    // the following two declarations are the exact same
    // verbose, verbose, verbose
    public record Vehicle2 {
        public string Make { get; init; }
        public string Model { get; init; }
        public int Year { get; init; }
    }

    // sweet one-line sugar (this is called a positional record)
    public record Vehicle(string Make, string Model, int Year);

    // and here's the syntax for an inherited type
    public record Tractor(string Make, string Model, int Year, string Attachment) : Vehicle(Make, Model, Year);
}