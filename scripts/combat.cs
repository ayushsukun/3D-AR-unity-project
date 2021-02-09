using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class combat : MonoBehaviour
{
    public Slider healtbar;
    
    public string fightingwith;





    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {

        

        if (other.gameObject.tag=="Player" && healtbar.value <= 0)
        {
            // victory
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }

        if (other.gameObject.tag == "enemy" && healtbar.value <= 0)
        {
            // lose
           
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (other.gameObject.tag== fightingwith) 
        {
         
            healtbar.value -= 2;
            
            
        }
        
        
        

    }

    

    // Update is called once per frame
    
}
