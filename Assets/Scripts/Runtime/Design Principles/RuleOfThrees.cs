using UnityEngine;

public class RuleOfThrees : MonoBehaviour
{
    //there are a few concepts that the rule of threes actually apply to, here are some examples.

    /* The common meaning of rule of threes in progrmming usually refers to the idea of
    "Three strikes and you refactor"; that is to say, only refactor duplications once they appear for a third time.*/

    public void OkayDuplication()
    {
        
    }

    public void YouShouldRefactor()
    {
        
    }

    public void Refactored()
    {
        
    }

    /*another meaning for the rule of threes can be applied to nesting,
    basically, nesting if statements, for loops and foreach loops is fine
    but don't do it more than thrice*/
    public bool boolean1;
    public bool boolean2;
    public bool boolean3;
    public bool boolean4;

    public void BadPractice(bool argument)
    {
        if (argument == boolean1) //1st layer
            if (argument == boolean2) //2nd layer
                if (argument == boolean3) //3rd layer
                    if (argument == boolean4) //please refactor.
                    {
                        //insert stuff here.
                    }
    }

    public void BetterPractice(bool argument)
    {
        if (argument != boolean1) return;
        if (argument != boolean2) return;
        if (argument != boolean3) return;

        if (argument != boolean4)
        {
            //insert stuff here.
        }

        //ALTERNATIVELY

        if (argument != boolean1 || argument != boolean2 || argument != boolean3)
            return;
        if (argument != boolean4)
        {
            //insert stuff here.
        }
    }

    public void NotAsGoodPractice(bool argument)
    {
        //you might be wondering if using && would work as well.

        if (argument == boolean1 && argument == boolean2 && argument == boolean3 && argument == boolean4)
        {
            //insert stuff here.
        }

        /*we'd recommend against doing it like this because it requires a lot more mental energy
        to keep track of all the variables and is a lot less readable*/
    }

    /*if you absolutely need that many nested statements, however, 
    it would be better to extract them into their own functions*/

    public void CheckBoolean1(bool argument)
    {
        if (argument == boolean1)
        {
            CheckBoolean2(argument);
        }
        else
        {
            //insert code here.
        }
    }

    public void CheckBoolean2(bool argument)
    {
        if (argument == boolean1)
        {
            //CheckBoolean3(), etc...
        }
        else
        {
            //insert code here.
        }
    }

    /* The final rule of 3 is similar to the nested if statements.
    Only perform at most 3 levels of abstraction. */
}
