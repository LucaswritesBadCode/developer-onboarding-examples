using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ExampleScript1 script1;
    public ExampleScript2 script2;

    /* in most cases, Start(), Update() (and its variations) and OnDestroy() should only be called in a central GameManager script
    which then calls the other scripts manually using Init(), OnUpdate() and Dispose().
    
    This is done so we have greater control over the order in which each script executes its life cycle functions */

    void Start()
    {
        script1.Init();
        script2.Init();
    }

    void Update()
    {
        script2.OnUpdate();
        script1.OnUpdate();
    }

    void OnDestroy()
    {
        script1.Dispose();
    }
}
