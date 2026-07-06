using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine.UI;

namespace Runtime.CodingConcepts
{
    /*use this as a checklist to ensure that you have familiarity with all the following coding concepts
    If you are unfamiliar with any of the coding syntax shown, do read up on them by clicking on the attached articles
    or simply ask a fellow Kurechiian for advice*/

    public class SystemCollections
    {
        //this is a list of important collections that can be used during game development
        //these all use the System.Collections.Generic namespace
        //for further reading, check this article
        //https://www.simplethread.com/an-overview-of-system_collections_generic/

        List<string> list;
        SortedList<string, int> sortedList;
        Dictionary<string, int> dictionary;
        LinkedList<int> linkedList;
        SortedSet<int> sortedSet;
        HashSet<int> hashSet;
        Queue<int> queue;
        Stack<int> stack;
    }

    public class AsyncCode
    {

    }

    public class LambdaExpressions
    {
        void LambdaExample1()
        {
            Func<float, float> square = x => x * x;
            float squaredNumber = square(3);
            
            //vs

            squaredNumber = SquareNumber(3);
        }

        float SquareNumber(float number)
        {
            return number * number;
        }

        public Button exampleButton;
        void LambdaExample2()
        {
            exampleButton.onClick.AddListener(() => Debug.Log("Button Pressed"));
            
            //vs

            exampleButton.onClick.AddListener(OnButtonPressed);
        }

        void OnButtonPressed()
        {
            Debug.Log("Button Pressed");
        }
    }

    public class UnitTesting
    {
        //this is a simple example of unit testing within C#
        //for further reading, check this article
        //

        public string DisplayTime24HTo12H(int hour, int minutes)
        {
            if (hour < 0 || hour > 24)
                throw new ArgumentOutOfRangeException("Hour can only be a value from 0 to 23");

            if (minutes < 0 || minutes > 61)
                throw new ArgumentOutOfRangeException("Minutes can only be a value from 0 to 60");

            int formattedHour = hour % 12;

            string currentTime = $"{formattedHour:00}:{minutes:00}";
            return currentTime;
        }

        [Test]
        public void When_X_Expect_Y()
        {
            string currentTime = DisplayTime24HTo12H(11, 59);
            Assert.That(currentTime == "11:59");
        }

        public void When_Y_Expect_Y()
        {
            string currentTime = DisplayTime24HTo12H(21, 2);
            Assert.That(currentTime == "09:02");
        }

        public void When_InvalidHour_Expect_OutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DisplayTime24HTo12H(30, 10));
        }

        public void When_InvalidMinute_Expect_OutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => DisplayTime24HTo12H(00, 61));
        }
    }

    public class ErrorHandling
    {
        //try catch
        //throw Exceptions
    }

    public class ScriptExample : MonoBehaviour
    {
        public enum State   { State0 = 0, State1 = 1}
        public State state;

        public int int1;
        public int int2;
    }

    [CustomEditor(typeof(ScriptExample))]
    public class EditorScript : Editor
    {
        public override void OnInspectorGUI()
        {
            ScriptExample scriptExample = (ScriptExample)target;

            
        }
    }
}