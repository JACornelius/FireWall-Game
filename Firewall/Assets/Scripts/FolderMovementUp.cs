using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderMovementUp : MonoBehaviour {
    public Vector2 targetPos;
    public float speed;
    public double pathBarrierLeft;
    public double pathBarrierRight;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Folder is on the path or near the path
        if (transform.position.x > pathBarrierLeft && transform.position.x < pathBarrierRight)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
            transform.position = new Vector2(0, transform.position.y);
        }
        //Folder has left the screen
        if (transform.position.y > 5)
        {
            /*
            if (gameObject.GetComponent<Packet2>().safebool == false)
            {
                Debug.Log("You let something bad thru!");
            }
            */
            Destroy(gameObject);
        }
    }
}
