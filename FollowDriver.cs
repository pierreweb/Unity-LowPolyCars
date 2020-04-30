using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDriver : MonoBehaviour
{
    
   // public GameObject  voiture;
    public GameObject  driver;
    public Vector3 followOffset;
    public float followSharpness;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
        //Finds and assigns the child of the player named "Gun".
        //driver= player.transform.Find("Gun").gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Apply that offset to get a target position.
        Vector3 targetPosition = driver.position + followOffset;
         // Smooth follow.    
       // transform.position += (targetPosition - transform.position) * followSharpness;
         // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(target.position, transform.position, Time.deltaTime*speed);
    }
}
