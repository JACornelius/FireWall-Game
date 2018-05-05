using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet : MonoBehaviour {
    public string ipaddr;
    public int portnum;
    public bool safebool;
    //public GameObject furnaceGO;
    //public GameObject packet;
    // Use this for initialization
    public void info(string IP, int port, bool safe)
    {
        ipaddr = IP;
        portnum = port;
        safebool = safe;
    }

    void Update()
    {
        SpriteRenderer spriteFurnace = GameObject.Find("furnace").GetComponent<SpriteRenderer>();
        float rightF = spriteFurnace.bounds.extents.x; //Distance to the right side, from your center point
        float leftF = -spriteFurnace.bounds.extents.x; //Distance to the left side
        float topF = spriteFurnace.bounds.extents.y; //Distance to the top
        float bottomF = -spriteFurnace.bounds.extents.y; //Distance to the bottom
        float rightboundF = rightF + spriteFurnace.transform.position.x;
        float leftboundF = leftF + spriteFurnace.transform.position.x;
        float topboundF = topF + spriteFurnace.transform.position.y;
        float bottomboundF = bottomF + spriteFurnace.transform.position.y;
        if (this.transform.position.x < rightboundF && this.transform.position.x > leftboundF && this.transform.position.y < topboundF && this.transform.position.y > bottomboundF)
        {
            //Debug.Log("placed in the furnance");
            Destroy(gameObject);
            if (this.safebool == true)
            {
                Debug.Log("Oh no you tossed out a good packet");
                Application.LoadLevel(3);
            }
        }
       

    }
}
