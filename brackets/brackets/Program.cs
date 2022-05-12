
using System;
using System.Diagnostics;
using brackets;


ShouldBeGood("{ Hi();There(); }");
ShouldBeBad("(()");
ShouldBeBad("{{}");
ShouldBeGood("[[{{}}]()]");
ShouldBeBad("[[{{}}]()]]");
ShouldBeBad("[[[{{}}]()]");


Console.WriteLine("Everything worked!!!");
Console.WriteLine("We thought of everything, right?");

void ShouldBeGood(string codeBlock)
{
    Debug.Assert(BracketsValidator.IsValid(codeBlock));
}

void ShouldBeBad(string codeBlock)
{
    Debug.Assert(!BracketsValidator.IsValid(codeBlock));
}