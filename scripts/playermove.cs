using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playermove : MonoBehaviour
{
    public CharacterController character;
    public float Speed=10f;
    public Transform cam;
    public Joystick Joystick;
    public buttonkick buttonkick;
    public headkick headkick;
    public punches punches;

    private bool doublekick;
    private bool head_kick;
    private bool punch;

    public Animator anim;

    public float turnsmoothtime = 0.1f;
    public float gravity=10f;
    float turnsmoothvel;

    // Start is called before the first frame update


   void Start()
    {
        FindObjectOfType<buttonkick>();
        FindObjectOfType<headkick>();
        FindObjectOfType<punches>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       float h = Joystick.Horizontal;
       float v = Joystick.Vertical;

        Vector3 mov = new Vector3(h, 0, v).normalized;

        if (transform.position.y<= -13.52)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }

        if (mov.magnitude >= 0.2f) {

            float targetangle = Mathf.Atan2(mov.x, mov.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetangle, ref turnsmoothvel, turnsmoothtime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 dir_mov = Quaternion.Euler(0f, targetangle, 0f) * Vector3.forward + Vector3.down;

            character.Move(dir_mov.normalized * Speed * Time.deltaTime);
            anim.SetTrigger("runnin");
        }

        if (mov.magnitude < 0.2f)
        {
            anim.SetTrigger("idling");
            character.Move(Vector3.down);
        }

        if (buttonkick.Pressed && !doublekick)
        {
            anim.SetTrigger("d_kick");
            character.Move(Vector3.down);
        }

        if (buttonkick.Pressed && doublekick)
        {
            doublekick=false;
        }


        if (headkick.Pressed && !head_kick)
        {
            anim.SetTrigger("headkick");
            character.Move(Vector3.down);
        }

        if (headkick.Pressed && head_kick)
        {
            head_kick = false;
        }


        if (punches.Pressed && !punch)
        {
            anim.SetTrigger("punchin");
            character.Move(Vector3.down);
            
        }

        if (punches.Pressed && punch)
        {
            punch = false;
        }



    }

   
}
