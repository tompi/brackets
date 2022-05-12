
using System;
using System.Diagnostics;
using brackets;

/*
 * You're working with an intern that keeps coming to you
 * with JavaScript code that won't run because the braces,
 * brackets, and parentheses are off. To save you both some time,
 * you decide to write a braces/brackets/parentheses validator.
 */


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
    if (!BracketsValidator.IsValid(codeBlock)) throw new Exception("Expected valid...");
}

void ShouldBeBad(string codeBlock)
{
    if (BracketsValidator.IsValid(codeBlock)) throw new Exception("Expected invalid...");
}