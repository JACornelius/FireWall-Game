using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackwardsFolderMovement : MonoBehaviour {
    public Vector2 targetPos;
    public float speed;
    public double pathBarrier;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x > (3 - pathBarrier) && transform.position.x < (3 + pathBarrier))
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
            transform.position = new Vector2(3, transform.position.y);
        }

        //Folder has left the screen
        if (transform.position.y > 5)
        {

            if (gameObject.GetComponent<Packet3>().safebool == false)
            {
                Debug.Log("You let something out!");
                //FIX THIS
                Application.LoadLevel(4);
            }
            Destroy(gameObject);
        }
    }

    void OnMouseDrag()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;
    }
}
