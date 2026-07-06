using System;
using UnityEngine;

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