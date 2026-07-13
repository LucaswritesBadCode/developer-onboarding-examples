using System;
using UnityEngine;

public class KeepItSimple
{
    /* KISS is predacated on the idea that code should be simple.
    Unless there is a very good reason (ie. Optimization, Maintainability), avoid unnecessary complexity in your code 
    Sometimes, the simplest implementation is the best. */

    // the following code gets a person's name based on an assigned seat.
    int seatNumber = 1;

    // Not following KISS
    public enum PersonName
    {
        Jake = 0, Edward = 1, Colin = 2, Bootsy = 4
    }

    public string GetNameFromSeatNumber()
    {
        foreach (int seat in Enum.GetValues(typeof(PersonName)))
        {
            if (seatNumber == seat)
            {
                string seatOwner = Enum.GetName(typeof(PersonName), seat);
                return seatOwner;
            }
        }

        return string.Empty;
    }

    //Following KISS

    public string GetNameFromSeatNumberSimplified()
    {
        string seatOwner = string.Empty;

        switch (seatNumber)
        {
            case 0:
                seatOwner = "Jake";
                break;
            case 1:
                seatOwner = "Edward";
                break;
            case 2:
                seatOwner = "Colin";
                break;
            case 4:
                seatOwner = "Bootsy";
                break;
            default:
                break;
        }

        return seatOwner;
    }

    // Notice that the simplified function's logic is far easier to follow.

    /* Do note that neither implementation is necessarily the "right" method, 
    the first implementation is technically more scalable and would work better the larger the set grows.
    However, if you're sure you won't have hundreds of names to work through, you're better off keeping it simple.
    Don't do more than you need to unless it brings a major benefit. */
}
