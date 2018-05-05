using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet3 : MonoBehaviour {
    public bool safebool;
    public string ipaddr;
    //public GameObject furnaceGO;

    public void info(string IP, bool safe)
    {
        ipaddr = IP;
        safebool = safe;
    }
	
	// Update is called once per frame
	void Update () {
        //Furnance Check
        SpriteRenderer spriteFurnace = GameObject.Find("Furnace").GetComponent<SpriteRenderer>();
        float rightF = spriteFurnace.bounds.extents.x; //Distance to the right side, from your center point
        float leftF = -spriteFurnace.bounds.extents.x; //Distance to the left side
        float topF = spriteFurnace.bounds.extents.y; //Distance to the top
        float bottomF = -spriteFurnace.bounds.extents.y; //Distance to the bottom
        float rightboundF = rightF + spriteFurnace.transform.position.x;
        float leftboundF = leftF + spriteFurnace.transform.position.x;
        float topboundF = topF + spriteFurnace.transform.position.y;
        float bottomboundF = bottomF + spriteFurnace.transform.position.y;

        //Packet was placed in the furnance
        if (this.transform.position.x < rightboundF && this.transform.position.x > leftboundF && this.transform.position.y < topboundF && this.transform.position.y > bottomboundF)
        {
            //Debug.Log("placed in the furnance");
            Destroy(gameObject);
            if (this.safebool == true)
            {
                Debug.Log("Oh no you tossed out a good packet");
            }
        }
    }
}
