using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Vuforia;

public class VirtualButton : MonoBehaviour
{ 

 VirtualButtonBehaviour[] mVirtualButtonBehaviours;
    public Material VirtualButtonDefault;
    public Material VirtualButtonPressed;
    public GameObject plane;

    public UnityEvent OnVirtualButtonPressed = new UnityEvent();
    public UnityEvent OnVirtualButtonReleased = new UnityEvent();
     
        void Start()
        {
            mVirtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

            for (var i = 0; i < mVirtualButtonBehaviours.Length; ++i)
            {
                mVirtualButtonBehaviours[i].RegisterOnButtonPressed(OnButtonPressed);
                mVirtualButtonBehaviours[i].RegisterOnButtonReleased(OnButtonReleased);
            }
        }

         void Destroy()
        {
           
            mVirtualButtonBehaviours = GetComponentsInChildren<VirtualButtonBehaviour>();

            for (var i = 0; i < mVirtualButtonBehaviours.Length; ++i)
            {
                mVirtualButtonBehaviours[i].UnregisterOnButtonPressed(OnButtonPressed);
                mVirtualButtonBehaviours[i].UnregisterOnButtonReleased(OnButtonReleased);
            }
        }

        // задаем действие кнопки в нажатом состоянии:
        public void OnButtonPressed(VirtualButtonBehaviour vb)
        {
    
            Debug.Log("Работает");
            plane.GetComponent<Renderer>().material = VirtualButtonPressed;
        
            OnVirtualButtonPressed?.Invoke();
        }

      
        public void OnButtonReleased(VirtualButtonBehaviour vb)
        {
     
            plane.GetComponent<Renderer>().material = VirtualButtonDefault;
            
            OnVirtualButtonReleased?.Invoke();
        }

}