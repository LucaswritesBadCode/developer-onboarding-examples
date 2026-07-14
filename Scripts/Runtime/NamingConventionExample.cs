using System.Collections.Generic;
using NUnit.Framework;
using NUnit.Framework.Internal;
using UnityEngine;

namespace Runtime
{
    public class NamingConventionExample /* class in PascalCase */ : IExampleInterface
    {
        // VARIABLES //
        private string _privateField; // private fields in _camelCaseWithUnderscore
        [SerializeField] string serializedPrivateField; // serializedPrivateFields in camelCase
        public string publicField; // public field in camelCase
        const string Constant = "Constant"; // constants in PascalCase

        //COLLECTIONS//
        string[] stringArray; string[] strings; // arrays end with "array" or are plural
        List<string> stringList; // lists end with "List"
        Dictionary<string, string> stringDictionary; Dictionary<string, string> stringDict;

        //ENUMS//
        public enum ExampleEnum // enums in PascalCase
        {
            // enum elements in PascalCase
            None = 0, // Always reserve the 0th enum for "None"
            FirstEnum = 1, // Always assign an int to each enum element
            SecondEnum = 2
        }


        public void ExampleMethod /* methods in PascalCase */ (int exampleArgument) //arguments in camelCase
        {
            int exampleVariable = exampleArgument; //local variables in camelCase
        }
    }

    public interface IExampleInterface //interfaces starts with "I"
    {

    }

    public class UnitTests
    {
        // ensure that function and variable names are clear and descriptive of their purpose
        public int AddTwoNumbers(int num1, int num2)
        {
            return num1 + num2;
        }

        [Test] // test name format When_Condition_Expect_ExpectedOutcome
        public void When_TwoAndFourAdded_Expect_Six()
        {
            int cummulativeNum = AddTwoNumbers(2, 4);
            Assert.That(cummulativeNum == 6);
        }
    }
}
