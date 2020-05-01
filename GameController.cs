using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    
  private Camera [] cameras ;
  private AudioListener  [] audioListeners;
 //   private List<Camera> cameras= new List<Camera>();
  private Camera mainCamera;
  private int cameraCounter;
//colors.Add("Red");

   
    
    // Start is called before the first frame update
    void Start()
    {
        var count = Camera.allCameras.Length;//print("count"+count);
        //var count1= AudioListener.allAudioListeners.Length;print("count"+count);
       // print("We've got " + count + " cameras");
      
       // print(Camera.allCameras);
        cameras=Camera.allCameras;
          audioListeners= GetComponents<AudioListener>();
        for( var i=0;i<cameras.Length;i++)
        {
            //print("i"+(cameras[i].GetComponent<AudioListener>().enabled));
            cameras[i].GetComponent<AudioListener>().enabled=false;
           // print("i"+(cameras[i].GetComponent<AudioListener>().enabled));
             cameras[i].enabled=false;
          //audioListeners[i]=(cameras[i].GetComponent<AudioListener>());
        }
       // print("audioListeners"+audioListeners.Length);
       // print("listcameras="+cameras[1]);
        cameraCounter=0;//it s an array so begin at zero
         mainCamera= GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        
        mainCamera.enabled=true;
        mainCamera.GetComponent<AudioListener>().enabled=true;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (Input.GetKeyDown (KeyCode.C)) {
        cameraCounter=SwitchCamera(cameraCounter);
    }
}
    // SwithcCamera
    private int SwitchCamera(int cameraCounter)
    {
        print("SwitchCamera");
        cameras[cameraCounter].GetComponent<AudioListener>().enabled=false;
         cameras[cameraCounter].enabled=false;
        cameraCounter++; cameraCounter=cameraCounter%cameras.Length;
        cameras[cameraCounter].GetComponent<AudioListener>().enabled=true;
        cameras[cameraCounter].enabled=true;
        return cameraCounter;
    }


}
