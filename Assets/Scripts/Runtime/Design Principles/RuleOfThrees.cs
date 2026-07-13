using UnityEngine;
using UnityEngine.EventSystems;

public class RuleOfThrees : MonoBehaviour
{
    // there are a few concepts that the rule of threes actually apply to, here are some examples.

    /* The common meaning of rule of threes in progrmming usually refers to the idea of
    "Three strikes and you refactor"; that is to say, only refactor duplications once they appear for a third time. */

    public Transform playerTransform;

    public void OkayDuplication()
    {
        if (Input.GetKeyDown(KeyCode.A))
            playerTransform.position += Vector3.left * 0.3f;

        if (Input.GetKeyDown(KeyCode.D))
            playerTransform.position += Vector3.right * 0.3f;

        // note: you should probably still refactor this down the line, this rule mainly relates to immediately refactoring while you're still coding
    }

    public void YouShouldRefactor()
    {
        if (Input.GetKeyDown(KeyCode.A))
            playerTransform.position += Vector3.left * 0.3f;

        if (Input.GetKeyDown(KeyCode.D))
            playerTransform.position += Vector3.right * 0.3f;

        if (Input.GetKeyDown(KeyCode.W))
            playerTransform.position += Vector3.up * 0.3f;

        if (Input.GetKeyDown(KeyCode.S))
            playerTransform.position += Vector3.down * 0.3f;
    }

    public void Refactored()
    {
        if (Input.GetKeyDown(KeyCode.A))
            MoveCharacter(Vector3.left);

        if (Input.GetKeyDown(KeyCode.D))
            MoveCharacter(Vector3.right);

        if (Input.GetKeyDown(KeyCode.W))
            MoveCharacter(Vector3.up);

        if (Input.GetKeyDown(KeyCode.S))
            MoveCharacter(Vector3.down);

        // note: there are definitely further improvements that could be made to this code but this is just to illustrate a point
    }

    public void MoveCharacter(Vector3 movementVector)
    {
        playerTransform.position += movementVector * 0.3f;
    }

    /* another meaning for the rule of threes can be applied to nesting,
    basically, nesting if statements, for loops and foreach loops is fine
    but don't do it more than thrice */
    public bool boolean1;
    public bool boolean2;
    public bool boolean3;
    public bool boolean4;

    public void BadPractice(bool argument)
    {
        if (argument == boolean1) // 1st layer
            if (argument == boolean2) // 2nd layer
                if (argument == boolean3) // 3rd layer
                    if (argument == boolean4) // please refactor.
                    {
                        // insert stuff here.
                    }
    }

    public void BetterPractice(bool argument)
    {
        if (argument != boolean1) return;
        if (argument != boolean2) return;
        if (argument != boolean3) return;

        if (argument != boolean4)
        {
            // insert stuff here.
        }

        // ALTERNATIVELY

        if (argument != boolean1 || argument != boolean2 || argument != boolean3)
            return;
        if (argument != boolean4)
        {
            // insert stuff here.
        }
    }

    public void NotAsGoodPractice(bool argument)
    {
        // you might be wondering if using && would work as well.

        if (argument == boolean1 && argument == boolean2 && argument == boolean3 && argument == boolean4)
        {
            // insert stuff here.
        }

        /* we'd recommend against doing it like this because it requires a lot more mental energy
        to keep track of all the variables and is a lot less readable */
    }

    /* if you absolutely need that many nested statements, however, 
    it would be better to extract them into their own functions */

    public void CheckBoolean1(bool argument)
    {
        if (argument == boolean1)
        {
            CheckBoolean2(argument);
        }
        else
        {
            // insert code here.
        }
    }

    public void CheckBoolean2(bool argument)
    {
        if (argument == boolean1)
        {
            // CheckBoolean3(), etc...
        }
        else
        {
            // insert code here.
        }
    }

    /* The final rule of 3 is similar to the nested if statements.
    Only perform at most 3 levels of abstraction. */

    public abstract class Enemy // 1st level of abstraction
    {
        protected int healthPoints = 100;   
        protected float speed = 10;
        public abstract void Attack();    
    }

    public abstract class GroundEnemy : Enemy // 2nd level of abstraction
    {
        public GroundEnemy()
        {
            speed = 5;
        }
    }

    public class Soldier : GroundEnemy //3rd level of abstraction
    {
        public Soldier()
        {
            healthPoints = 50;
        }

        public override void Attack()
        {
            // insert attack here.
        }
    }

    // stop here. you shouldn't implement any more abstractions beyond this.

    /* do note that this concerns chaining abstract classes, 
    a script inheriting from more than 3 interfaces is allowed */
    public class Interface : IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
    {
        //this is permitted.
        
        public void OnPointerDown(PointerEventData eventData){  }
        public void OnPointerEnter(PointerEventData eventData){  }
        public void OnPointerExit(PointerEventData eventData){  }
        public void OnPointerUp(PointerEventData eventData){  }
    }
}
