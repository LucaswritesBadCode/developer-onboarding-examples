using System;
using System.Collections;
using TMPro;
using UnityEngine;

// The following are a few small examples of decoupling of code.
 
/* This first example uses interfaces to decouple the dependency between a switch and the objects it activates.
Basically, instead of the switch calling the door/light/radio classes directly,
we can make it call an interface instead and have them all inherit from the interface.

This allows us to keep our code more flexible and scalable since now the switch doesn't need to know what it's activating,
it just needs to call the interface, so we can add whatever new stuff we want as long as it uses the interface. */

namespace Runtime.DesignPrinciples.Coupling
{
    public class Switch
    {
        public enum SwitchType { Door, Light, Radio }
        public SwitchType switchType;

        public Door door;
        public Light light;
        public Radio radio;

        public void OnInteract()
        {
            switch (switchType)
            {
                case SwitchType.Door:
                    door.OnSwitchPulled();
                    break;
                case SwitchType.Light:
                    light.OnSwitchPulled();
                    break;
                case SwitchType.Radio:
                    radio.OnSwitchPulled();
                    break;
            }
        }
    }

    public class Door
    {
        public void OnSwitchPulled()
        {
            Debug.Log("Door Opened");
        }
    }

    public class Light
    {
        public void OnSwitchPulled()
        {
            Debug.Log("Light On");
        }
    }
    public class Radio
    {
        public void OnSwitchPulled()
        {
            Debug.Log("Radio Playing");
        }
    }
}

namespace Runtime.DesignPrinciples.Decoupled
{
    public interface ISwitchable
    {
        void OnSwitchPulled();
    }

    public class Switch
    {
        ISwitchable switchable;

        public void OnInteract()
        {
            switchable.OnSwitchPulled();
        }

        public class Door : ISwitchable
        {
            public void OnSwitchPulled()
            {
                Debug.Log("Door Opened");
            }
        }

        public class Light : ISwitchable
        {
            public void OnSwitchPulled()
            {
                Debug.Log("Light On");
            }
        }
        public class Radio : ISwitchable
        {
            public void OnSwitchPulled()
            {
                Debug.Log("Radio Playing");
            }
        }
    }
}

/* This second example shows how events can be used to reverse the dependency between a caller and called script.
Normally, script A will call Script B to trigger a function BUT that means that Script A is dependent on Script B to function properly.
If Script B fails, Script A also fails. This means that they are tightly coupled.

However, by using events, Script B can instead, subscribe to Script A event to trigger its function.
So, Script A doesn't need to know anything about what Script B does, it just needs to invoke its event and Script B does all the work.
This once again means that Script A is not dependent on Script B; if Script B fails, it doesn't affect it. */

namespace Runtime.DesignPrinciples.Coupling
{
    public class ItemPickUp
    {
        private AudioManager _audioManager;
        private UIManager _uiManager;

        public void OnPickUp()
        {
            _audioManager.PlaySoundEffect();
            _uiManager.ShowPickUpUI();
        }
    }

    public class AudioManager
    {
        private AudioSource _audioSource;

        public void PlaySoundEffect()
        {
            _audioSource.Play();
        }
    }

    public class UIManager
    {
        private GameObject _pickUpUI;

        public IEnumerator ShowPickUpUI()
        {
            _pickUpUI.SetActive(true);
            yield return new WaitForSeconds(1);
            _pickUpUI.SetActive(false);
        }
    }
}

namespace Runtime.DesignPrinciples.Decoupled
{
    public class ItemPickUp
    {
        public event Action onPickUp;

        public void OnPickUp()
        {
            onPickUp?.Invoke();
        }
    }

    public class AudioManager
    {
        private ItemPickUp itemPickUp;
        private AudioSource _audioSource;

        public void Init()
        {
            itemPickUp.onPickUp += PlaySoundEffect;
        }

        public void PlaySoundEffect()
        {
            _audioSource.Play();
        }

        public void Dispose()
        {
            itemPickUp.onPickUp -= PlaySoundEffect;
        }
    }

    public class UIManager
    {
        private ItemPickUp itemPickUp;
        private GameObject _pickUpUI;

        public void Init()
        {
            itemPickUp.onPickUp += ShowPickUpUI;
        }

        public void ShowPickUpUI()
        {
            _pickUpUI.SetActive(true);

        }

        public void Dispose()
        {
            itemPickUp.onPickUp -= ShowPickUpUI;
        }
    }
}

/* This last example shows an example of Separation of Concerns, basically a software component should only have one responsibility
(in this case, it's functions, but it can also be classes, interfaces, etc...)

This mainly helps modularity. If you keep all your code for different types of logic together,
you'll have to work around the coupled functions and create exceptions and edge cases
But if you just separate the logic into different elements, you can just call them individually as needed. Much cleaner. */

namespace Runtime.DesignPrinciples.Coupling
{
    public class PlayerHealth
    {
        private int _health;
        private TextMeshProUGUI _healthText;
        private AudioSource _audioSource;
        private AudioClip damageClip;

        public void TakeDamage(int damage)
        {
            _health -= damage;


            _audioSource.PlayOneShot(damageClip);

            _healthText.text = _health.ToString();

            if (_health > 80)
            {
                _healthText.color = Color.green;
            }
            else if (_health > 30)
            {
                _healthText.color = Color.yellow;
            }
            else
            {
                _healthText.color = Color.red;
            }

            if (_health < 0)
            {
                Debug.Log("Insert Player Death");
            }
        }
    }
}

namespace Runtime.DesignPrinciples.Decoupled
{
    public class PlayerHealth
    {
        private int _health;
        private TextMeshProUGUI _healthText;
        private AudioSource _audioSource;
        private AudioClip damageClip;

        public void TakeDamage(int damage)
        {
            _health -= damage;

            if (_health < 0)
            {
                Debug.Log("Insert Player Death");
            }
        }

        public void PlayDamageAudio()
        {
            _audioSource.PlayOneShot(damageClip);
        }

        public void DisplayHealthUI()
        {
            _healthText.text = _health.ToString();

            if (_health > 80)
            {
                _healthText.color = Color.green;
            }
            else if (_health > 30)
            {
                _healthText.color = Color.yellow;
            }
            else
            {
                _healthText.color = Color.red;
            }
        }
    }
}

/* Decoupling is one of the more abstract principles of software design, and there are too many techniques
to include in this brief explanation. However, they are all predicated on a similar mindset, reduce your dependencies.
When you code something think about how your code chunk interacts with other code 
and think about how difficult it would be to change anything about it. 

If you can already forsee a headache when trying to add new functionality or dealing with specific use cases,
either because changing something might break something else or that you have to add multiple if statements for speific exceptions,
you might want to try decoupling you code. */