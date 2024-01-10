using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kSave : MonoBehaviour
{
    public GameObject turret1, turret2;
    public GameObject saveButton1, saveButton2, saveButton3;
    
    int state = 0;

    bool firstShootedTurret1 = false;
    bool firstShootedTurret2 = false;

   private void Start() 
   {
    saveButton2.SetActive(false);
    saveButton3.SetActive(false);
   }
    // Start is called before the first frame update
    public void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "bullet1")
        {
            Debug.Log("hit");
            turret2.SetActive(false);
            Destroy(other.gameObject);
          
        }

        if (other.gameObject.tag == "bullet2")
        {
            Debug.Log("hit");
            turret1.SetActive(false);
            Destroy(other.gameObject);
        
        }
    }

  

    public void SavePrev() {
        if (turret1.activeInHierarchy)
        {
            turret2.SetActive(true);
           
            saveButton2.SetActive(true);
            state++;
            if (state>1)
                saveButton3.SetActive(true);
            firstShootedTurret2 = true;
        }

        else 
         {
            turret1.SetActive(true);
           
            saveButton2.SetActive(true);
            state++;
            if (state>1)
                saveButton3.SetActive(true);
            firstShootedTurret1 = true;
         }
    }

    public void SaveNextButn2()
    {
       

            if (turret1.activeInHierarchy && turret2.activeInHierarchy && firstShootedTurret2)
            {
                turret2.SetActive(false);
                saveButton3.SetActive(false);
            }

            if (turret1.activeInHierarchy && turret2.activeInHierarchy && !firstShootedTurret2)
            {
                turret1.SetActive(false);
                saveButton3.SetActive(false);
            }
        
        else
        {
            if (turret1.activeInHierarchy && turret2.activeInHierarchy && firstShootedTurret1)
            {
                turret2.SetActive(false);
                saveButton2.SetActive(false);
            }

            if (turret1.activeInHierarchy && turret2.activeInHierarchy && !firstShootedTurret1)
            {
                turret1.SetActive(false);
                saveButton2.SetActive(false);
            }
        }
    }
        
    public void SaveNextButn3()
    {
        
            if (turret1.activeInHierarchy && turret2.activeInHierarchy && !firstShootedTurret1)
            {
                turret2.SetActive(false);
                saveButton2.SetActive(false);
            }

            if (turret1.activeInHierarchy && turret2.activeInHierarchy && firstShootedTurret1)
            {
                turret1.SetActive(false);
                saveButton2.SetActive(false);
            }
        
        else 
        {
            if (turret1.activeInHierarchy && turret2.activeInHierarchy && !firstShootedTurret2)
            {
                turret2.SetActive(false);
                saveButton3.SetActive(false);
            }

            if (turret1.activeInHierarchy && turret2.activeInHierarchy && firstShootedTurret2)
            {
                turret1.SetActive(false);
                saveButton3.SetActive(false);
            }
        }
    
  
    }
}


