using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ExampleScript1 script1;
    public ExampleScript2 script2;

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
