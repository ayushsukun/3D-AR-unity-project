using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float counting = 0;
    public Text time;
    public Text fixedscore;
     

    private void Start()
    {
        float final = PlayerPrefs.GetFloat("timetotal",0);
        string fina = final.ToString();
        fixedscore.text = fina;
    }

    void Update()
    {
      
       counting += Time.deltaTime;
        int a = (int)counting;
        time.text = a.ToString();
        PlayerPrefs.SetFloat("timetotal", a);
        
    }
}
