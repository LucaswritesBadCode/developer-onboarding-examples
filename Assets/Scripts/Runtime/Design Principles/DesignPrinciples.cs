using System;
using UnityEngine;

public class KeepItSimple
{
    /*KISS is predacated on the idea that code should be simple.
    Unless there is a very good reason (ie. Optimization, Maintainability), avoid unnecessary complexity in your code 
    Sometimes, the simplest implementation is the best.*/

    //the following code gets a person's name based on an assigned seat.
    int seatNumber = 1;

    //Not following KISS
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

    //Notice that the simplified function's logic is far easier to follow.
}

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

public class DontRepeatYourself
{
    /*DRY suggests that you should only write code once. 
    That is to say, do not repeat the same functions and logic as it will make your code harder to maintain.*/

    //let's say you wanted to create a few types of interactions when the player presses E.
}

//without DRY
public class ItemOne : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }

    private void OnInteract()
    {
        //implementation here.
    }
}

public class ItemTwo : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OnInteract();
        }
    }

    private void OnInteract()
    {
        //implementation here.
    }
}

/*while this might not look too bad right now, the repetition can become a problem the more items you add.
and becomes a nightmare the minute you want to change the binding*/


/*we can reduce repetition in this case by using inheritance
with DRY*/
public interface IInteractable
{
    public void OnInteract();
}

public class InteractionHandler : MonoBehaviour
{
    IInteractable interactable;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactable.OnInteract();
        }
    }
}

public class ItemOneDRY : IInteractable
{
    public void OnInteract()
    {
        //implementation here.
    }
}
public class ItemTwoDRY : IInteractable
{
    public void OnInteract()
    {
        //implementation here.
    }
}

public class WriteEverythingTwice
{
    /*WET is an opposite school of thought that basically encourages programmers to duplicate small parts of code
    to avoid over-abstracting/complicating code, as well as making it easier to read.
    Both approaches have their merits, it is advised to use DRY in complex functions that are likely to be altered,
    while WET can be used in simpler lines of code where trying to merge things would add unnecessary complexity*/

    /*let's say you have UI for your Main Menu and Settings, you might be tempted to combine them
    since they share certain game objects and functionality*/
}

//without WET
public class MenuHandler
{
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;

    public void StartGame() { }
    public void OpenSettings() { ChangeScreen(false); }
    public void ExitGame() { }

    public void BackToMainMenu() { ChangeScreen(true); }
    public void ChangeSound(float volume) { }
    public void ChangeBrightness(float brightness) { }

    public void ChangeScreen(bool openMainMenu)
    {
        mainMenuScreen.SetActive(openMainMenu);
        settingsScreen.SetActive(!openMainMenu);
    }
}

/* however, it would still be a good idea to keep the two elements separate to reduce coupling and potential complexity
You can rest easier knowing that changing the settings menu won't somehow break the Main Menu*/

//with WET
public class MainMenuHandler
{
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;

    public void StartGame() { }
    public void OpenSettings()
    {
        mainMenuScreen.SetActive(false);
        settingsScreen.SetActive(true);
    }
    public void ExitGame() { }
}

public class SettingsMenuHandler
{
    public GameObject mainMenuScreen;
    public GameObject settingsScreen;

    public void BackToMainMenu()
    {
        mainMenuScreen.SetActive(true);
        settingsScreen.SetActive(false);
    }
    public void ChangeSound(float volume) { }
    public void ChangeBrightness(float brightness) { }
}

/*You'll have to use your judgement to figure out when to use DRY and when to use WET,
but a good rule of thumb is maintainability vs readability/flexibility.
DRY code is more maintainable but can be harder to parse and more coupled
while WET code is more fragile but is usually more readable and provides more flexibility*/