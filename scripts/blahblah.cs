using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;


public class blahblah : MonoBehaviour
{

    public Slider enemy;
    public Text blah1;
    public Text timecount;
    


    // Start is called before the first frame update
    void Start()
    {

       // timer timeco= gameObject.GetComponent<timer>();

        //timeco.final = 10;
        float fin = PlayerPrefs.GetFloat("damage");
        float blah = ((100 - fin) * 1000) ;
        string b = blah.ToString();
        blah1.text = b;
    }

    // Update is called once per frame
    void Update()
    {
        float damage = enemy.value;
        PlayerPrefs.SetFloat("damage", damage);
    }
}
