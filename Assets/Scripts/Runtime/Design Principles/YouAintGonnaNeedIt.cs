using UnityEngine;

public class YouAintGonnaNeedIt
{
    /*YAGNI basically advocates for a minimal approach to programming;
    only implement features as they are necessary and do not add complexity if it
    isn't CURRENTLY necessary*/

    //let's say you wanted to implement a levelling system in a game

    private int xP;

    public void IncreaseXP(int addedXP)
    {
        xP += addedXP;
    }

    //You might be tempted to add use cases "JUST IN CASE" you ever need to remove XP or introduce modifiers.

    public void ChangeXP(int addedXP, bool isXPIncreased = true, float multiplier = 1)
    {
        if (isXPIncreased)
            xP += (int)(addedXP * multiplier);
        else
            xP -= (int)(addedXP * multiplier);
    }

    /*However, you're not sure if you will actually use either system
    If you end up not using them, then you've just cluttered the code and wasted your time
    
    It's better to code in a way that leaves your code open to change IN THE FUTURE
    than to try to guess RIGHT NOW what you'll need later down the line*/

}