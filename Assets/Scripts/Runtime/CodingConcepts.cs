using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System;
using UnityEditor;

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

}