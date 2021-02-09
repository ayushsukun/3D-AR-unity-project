using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_work : MonoBehaviour
{
    public Transform player;

    public Vector3 points_offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = player.rotation;
      
        transform.position = player.position-points_offset;
    }
}
