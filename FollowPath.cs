using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



public class FollowPath : MonoBehaviour
{
    
     //public GameObject wpManager;
     [SerializeField]
     [Header("Destination")]
    private GameObject [] waypoints;
    [Space]
     [SerializeField]
     [Header("Way")]
    private GameObject [] ways;
    int currentWaypoint;
    int currentWay;
    int [] current=new int[2];
    //int [] way;
    bool destinationReach;
    
        //Create a new dictionary with int keys and string values.
    Dictionary<int, GameObject []> dctWaypointWays= new Dictionary<int, GameObject[]>();

 

  UnityEngine.AI.NavMeshAgent  agent;
// Start is called before the first frame update
    void Start()
    {
        //voiture= GameObject.Find("Voiture_001");
        //wps=wpManager.GetComponent<WPManager>().waypoints;
        agent=this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        //way= new int[3] {1, 3, 5};
        dctWaypointWays.Add(1,ways);
        dctWaypointWays.Add(2,ways);
        destinationReach=true;

        currentWay=0;
        currentWaypoint=0;
        current[0]=currentWaypoint;current[1]=currentWay;
        print( "waypointslength"+waypoints.Length);
       current=ChooseWaypoint(current);
       
        

    }

    // Update is called once per frame
    void Update()
    {
     //destinationReach?ChooseWay();
       if (agent.remainingDistance<0.01 && destinationReach==true){ current=ChooseWaypoint(current);print("updateonestarrivewaypoint");return;};
     //print("agentRemainingDistance"+agent.remainingDistance);
     //if (agent.remainingDistance<0.001) print("on est arrive");
     
     if (agent.remainingDistance<5.0 && destinationReach==false) FinishWay(current);//5 to avoid brake in way
      
    }

     public int[] ChooseWaypoint(int [] current){
       print("ChoseWaypoint()");
       destinationReach=false;//print("destinationReach"+destinationReach);
       //int a=0;
       int a=Random.Range(0,waypoints.Length);print("a="+a);
       while (a==current[0]){
           a=Random.Range(0,waypoints.Length);
       }
       current[0]=a; print("currentWaypoint"+current[0]);
        //GoToWaypoint(currentWayPoint);
        current=ChooseWay(current);
        return current;
    }

    public void FinishWay(int [] current){
        //way is between 2 waypoints
       print("FinishWay()");
       //print("destinationReach"+destinationReach);
       //print(currentWaypoint);
       //print(dctWaypointWays[2]);
       //currentWay=Random.Range(1,dctWaypointWays[currentWaypoint].Length);currentWay+=-1;
        //print(currentWay);
        print("currentWaypoint="+current[0]);
     GoToWaypoint(current);
    }

    public int[] ChooseWay(int [] current){
        //way is between 2 waypoints
       print("ChoseWay()");
       //print(currentWaypoint);
       current[0]+=1;//car le dictionnaire commence à1
       //print(dctWaypointWays[2]);
        int a=Random.Range(0,dctWaypointWays[current[0]].Length);
         while (a==current[1]){
          a=Random.Range(0,dctWaypointWays[current[0]].Length);
       }
       current[1]=a;
      // current[1]+=-1;//la c est un tableau donc entre 0 et .
       current[0]+=-1;//je reviens au tableau qui commence a 0
       //print("currentWaypoint="+current[0]);
       // print("currentWay"+current[1]);
     GoToWay(current);
     return current;
   
    }

    public void GoToWay(int[] current){
        print("GoToWay()");print(current[1]);print("currentWay="+current[1]);
        //if (!destinationReach)
       
       agent.SetDestination(ways[current[1]].transform.position);
    }

    public void GoToWaypoint(int []current){
        print("GoToWaypoint()");
        //if (!destinationReach);
          //if (agent.remainingDistance<0.001 ) {print("on est arrive waypoint");destinationReach=true; return;};
          destinationReach=true;//print("destinationReach"+destinationReach);
       agent.SetDestination(waypoints[current[0]].transform.position);
    }

void CheckDestinationReached() {
 // float distanceToTarget = Vector3.Distance(transform.position, target);
//   if(distanceToTarget < destinationReachedTreshold)
//   {
//    print("Destination reached");
 }

}

