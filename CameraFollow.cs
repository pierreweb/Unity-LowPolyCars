
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public  float smoothSpeed;
    //public Vector3 offset;
    //public float speed;
    


    // Update is called once per frame
    void LateUpdate()
    {
        //Vector3 desiredPosition=target.position+offset;
        //Vector3  smoothedPosition=Vector3.Lerp( transform.position,desiredPosition,smoothSpeed);  
        //Vector3  smoothedTargetPosition=Vector3.Lerp( transform.position,desiredPosition,smoothSpeed);  
        //transform.position=smoothedPosition;
        //transform.LookAt(target);
        Vector3 relativePos = target.position - transform.position;
        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        //transform.rotation = rotation;
        // Smoothly rotate towards the target point.
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, smoothSpeed * Time.deltaTime);
        //Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position);


    }
}



     

