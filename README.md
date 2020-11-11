# C# 9.0 Primer

There are large numebr of new features being released with C# 9.0 alongside .NET 5.  I'll cover some of the most ompelling features (IMHO) in this repository.  I hope this helps you in discovering C# 9.0!

## Contents
1. [Records](#records)
1. [Pattern matching](#pattern-matching)
1. [Covariant return types](#covariant-return-types)
1. [Low-level programming](#low-level-programming)
1. [Other details](#other-details)
---

## Records
Records are a brand-new reference type that use member-based value checking for equality and are immutable.  Records and read-only structs differ in how they’re allocated (heap vs. stack).

### Records can be described in a couple ways.  
I hope you like sugar!  *Oh, and that new property accessor is called the init-only setter accessor; writes are restricted to initialization only.  See more in [other details](#other-details).*
```csharp
// the following two declarations are the exact same
// verbose, verbose, verbose
public record Vehicle {
    public string Make { get; init; }
    public string Model { get; init; }
    public int Year { get; init; }
}

// sweet one-line sugar (this is called a positional record)
public record Vehicle(string Make, string Model, int Year);

// and here's the syntax for an inherited type
public record Tractor(string Make, string Model, int Year, string Attachment) : Vehicle(Make, Model, Year);
```

### The compiler synthesizes code to manage equality checking
If two instances of the same record type with the same property values are evaluated as being equals.  Beware of quirks with inheritance -- if two records are compared but don't have the same properties, then they will not evaluate as being eqivalent!  
```csharp
// given some record type
public record Vehicle(string Make, string Model, int Year);

// and two instances of that type with the same member data
var mine = new Vehicle("Honda", "Accord", 1993);
var yours = new Vehicle("Honda", "Accord", 1993);

// when equality is checked
var areEquivalent = mine == yours;

// then they are equal
Assert.True(areEquivalent);
```

### Records are immutable
Their data cannot be modified after the record has been instantiated.
```csharp
// given some record type
public record Vehicle(string Make, string Model, int Year);

// and an instance of that type
var mine = new Vehicle("Honda", "Accord", 1993);

// when the data is modified
mine.Year = 2020; // can't upgrade, sorry :(

// then (trust me on this one) the compiler will complain
/* red squiggly underline and compiler panic */
```

### Records can be cloned/mutated 
You should do so by using the “with” expression.
```csharp
// given some record type
public record Vehicle(string Make, string Model, int Year);

// and an instance of that type
var mine = new Vehicle("Honda", "Accord", 1993);

// when the data is modified using a "with" expression
var tradeIn = mine with { Year = 2020 }; // sweet new ride!

// then a new instance is created but with specific data modifications
// and the new instance is not equal
Assert.False(mine == tradeIn);
```

### So why use them?
1. They can make dealing with JSON a bit easier 
1. They're great as DTOs and in the context of CQRS
1. They come with built-in deconstructors (for those of the positional variety)

---

## Pattern matching



---

## Covariant Return Types



---

## Low-level Programming



---

## Other details
Here are some of the other features of the new language version (I thought these were important enough to mention, but not compelling enough to warrant their own section)

1. **Init-only setters**: You can now set a property to only be mutable at initialization using the `public PropName { get; init; }` syntax.  You can even make use of this accessor by using the property intitializer syntax.
1. **Top-level statements**: You no longer *have* to wrap you code in ```public static void Main(string[] args) { }```, because now C# supports top-level programs (to ease the burden of adoption).  I don't see the need, but it's cool.  The compiler will wrap the code you've written with the appropriate harness (if you're using async code it's smart enough to generate an async entry point behind the scenes).
1. 