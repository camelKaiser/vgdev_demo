using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseController : MonoBehaviour
{
    public float speed = 0;
    public GameObject playerObject; 
    GameObject timerobject;
    TimerController thescript;

    // Start is called before the first frame update
    void Start()
    {
        timerobject = GameObject.Find("Timer");
        thescript = timerobject.GetComponent<TimerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thescript.isday && !thescript.gameover){
            transform.LookAt(playerObject.transform);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        
    }
}
