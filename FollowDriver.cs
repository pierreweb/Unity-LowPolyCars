using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowDriver : MonoBehaviour
{
    
   // public GameObject  voiture;
    public  Transform  driver;
  //  public Vector3 followOffset;
    //public float followSharpness;
    public float speed;

    public float maxSteerAngle;
    public WheelCollider  wheelFL;
    public WheelCollider  wheelFR;
    public float motorTorque;
    private Vector3 carSpeedVector;
    private float carSpeed;
    private Vector3 driverSpeedVector;
    private float driverSpeed;
    private Vector3 [] speedVector;
    // Start is called before the first frame update
    void Start()
    {
        carSpeedVector=transform.position;//Vector3.zero;
        carSpeed=0;//carSpeedVector.magnitude;
        driverSpeedVector=driver.position;//Vector3.zero;
        driverSpeed=0;//carSpeedVector.magnitude;
        speedVector=new Vector3[2] {carSpeedVector,driverSpeedVector}; // print("speedVector"+speedVector);
        //Finds and assigns the child of the player named "Gun".
        //driver= player.transform.Find("Gun").gameObject;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Apply that offset to get a target position.
        //Vector3 targetPosition = driver.position + followOffset;
         // Smooth follow.    
       // transform.position += (targetPosition - transform.position) * followSharpness;
         // Set our position as a fraction of the distance between the markers.
       // transform.position = Vector3.Lerp(driver.position+followOffset, transform.position, Time.deltaTime*speed);
        ApplySteer();
        speedVector=Run(speedVector);
         Debug.LogFormat("carSpeedVector:{0},driverSpeedVector:{1}",speedVector[0],speedVector[1]);
    }

    void ApplySteer(){
        //print("ApplySteer");
        Vector3 relativeVector=transform.InverseTransformPoint(driver.position).normalized;
        relativeVector=Vector3.Lerp(relativeVector,Vector3.zero,Time.deltaTime*speed);
        float newSteer=relativeVector.x*maxSteerAngle;
        wheelFL.steerAngle=newSteer;
        wheelFR.steerAngle=newSteer;
    }
    Vector3 [] Run(Vector3 [] speedVector){
        //print("Run()");
        //speedVector[0]=carSpeedVector & speedVector[1]=driverSpeedVector
        carSpeedVector=transform.position-speedVector[0];
        carSpeed=carSpeedVector.magnitude;
        speedVector[0]=transform.position;
        //print("driverSpeed"+driverSpeed);
        driverSpeedVector=driver.position-speedVector[1];
        driverSpeed=driverSpeedVector.magnitude;
        speedVector[1]=driver.position;
       // Debug.LogFormat("Number: {0}, string {1}, number again: {0}, character: {2}", num, str, chr);
       Debug.LogFormat("carSpeed:{0},driverSpeed:{1}",carSpeed,driverSpeed);
        //Vector3 relativeVector=transform.InverseTransformPoint(driver.position).magnitude;
        float relativeVectorMagnitude=Mathf.Abs(transform.InverseTransformPoint(driver.position).magnitude);
       // print("relativeVectorMagnitude="+relativeVectorMagnitude);
       //motorTorque=motorTorque*relativeVectorMagnitude*0.1f;
       //motorTorque=relativeVectorMagnitude*10.0f;
     // motorTorque=Mathf.Clamp(motorTorque,10,70);
       //motorTorque=Mathf.Exp(relativeVectorMagnitude*0.4f-3f);
        
    /*  if (relativeVectorMagnitude<5)
                motorTorque=-10;
                 else motorTorque=70; */
         if (carSpeed>driverSpeed+10)
                motorTorque=-30;
          if (carSpeed<driverSpeed-10)
                motorTorque=+30;
               //  else motorTorque+=30;
          motorTorque=Mathf.Clamp(motorTorque,0,100);
         print("motorTorque="+motorTorque);
        wheelFL.motorTorque=motorTorque;
        wheelFR.motorTorque=motorTorque;
        
        return  speedVector;
    }
}
