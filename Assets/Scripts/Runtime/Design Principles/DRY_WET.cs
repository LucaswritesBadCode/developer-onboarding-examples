using UnityEngine;


/*DRY suggests that you should only write code once. 
That is to say, do not repeat the same functions and logic as it will make your code harder to maintain.*/

//let's say you wanted to create a few types of interactions when the player presses E.

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

/*WET is an opposite school of thought that basically encourages programmers to duplicate small parts of code
to avoid over-abstracting/complicating code, as well as making it easier to read.
Both approaches have their merits, it is advised to use DRY in complex functions that are likely to be altered,
while WET can be used in simpler lines of code where trying to merge things would add unnecessary complexity*/

/*let's say you have UI for your Main Menu and Settings, you might be tempted to combine them
since they share certain game objects and functionality*/

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