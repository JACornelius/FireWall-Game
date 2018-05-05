using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderMovement2 : MonoBehaviour {
    public Vector2 targetPos;
    public float speed;
    public double pathBarrier;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        //Folder is on the path or near the path
        if (transform.position.x > -pathBarrier && transform.position.x < pathBarrier)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPos, step);
            transform.position = new Vector2(0, transform.position.y);
        }
        //Folder has left the screen
        if (transform.position.y < -5)
        {
            
            if (gameObject.GetComponent<Packet2>().safebool == false)
            {
                Debug.Log("You let something bad thru!");
                Application.LoadLevel(4);
            }
            Destroy(gameObject);
        }
    }

    //Moving the Folder using the Mouse Drag
    void OnMouseDrag()
    {
        Vector2 mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = objPos;
    }
    
}
