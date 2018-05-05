using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packet2 : MonoBehaviour {
    public string ipaddr;
    public int portnum;
    public bool safebool;
    public bool state;
    public bool update;
    public bool securityPolicy;
    //public GameObject furnaceGO;
    //public GameObject stateGO;
    //public GameObject updateGO;
    //public GameObject securityPolGO;

    //public GameObject packet;
    // Use this for initialization
    public void info(string IP, int port, bool safe, bool _state, bool _update, bool _securityPolicy)
    {
        ipaddr = IP;
        portnum = port;
        safebool = safe;
        state = _state;
        update = _update;
        securityPolicy = _securityPolicy;
    }
    void Update()
    {
        //Furnace check
        SpriteRenderer spriteFurnace = GameObject.Find("Furnace").GetComponent<SpriteRenderer>();
        float rightF = spriteFurnace.bounds.extents.x; //Distance to the right side, from your center point
        float leftF = -spriteFurnace.bounds.extents.x; //Distance to the left side
        float topF = spriteFurnace.bounds.extents.y; //Distance to the top
        float bottomF = -spriteFurnace.bounds.extents.y; //Distance to the bottom
        float rightboundF = rightF + spriteFurnace.transform.position.x;
        float leftboundF = leftF + spriteFurnace.transform.position.x;
        float topboundF = topF + spriteFurnace.transform.position.y;
        float bottomboundF = bottomF + spriteFurnace.transform.position.y;
        SpriteRenderer spriteState = GameObject.Find("State").GetComponent<SpriteRenderer>();
        float rightS = spriteState.bounds.extents.x; //Distance to the right side, from your center point
        float leftS = -spriteState.bounds.extents.x; //Distance to the left side
        float topS = spriteState.bounds.extents.y; //Distance to the top
        float bottomS = -spriteState.bounds.extents.y; //Distance to the bottom
        float rightboundS = rightS + spriteState.transform.position.x;
        float leftboundS = leftS + spriteState.transform.position.x;
        float topboundS = topS + spriteState.transform.position.y;
        float bottomboundS = bottomS + spriteState.transform.position.y;
        SpriteRenderer spriteUpdate = GameObject.Find("Update").GetComponent<SpriteRenderer>();
        float rightU = spriteUpdate.bounds.extents.x; //Distance to the right side, from your center point
        float leftU = -spriteUpdate.bounds.extents.x; //Distance to the left side
        float topU = spriteUpdate.bounds.extents.y; //Distance to the top
        float bottomU = -spriteUpdate.bounds.extents.y; //Distance to the bottom
        float rightboundU = rightU + spriteUpdate.transform.position.x;
        float leftboundU = leftU + spriteUpdate.transform.position.x;
        float topboundU = topU + spriteUpdate.transform.position.y;
        float bottomboundU = bottomU + spriteUpdate.transform.position.y;
        SpriteRenderer spriteSF = GameObject.Find("SecurityPolicy").GetComponent<SpriteRenderer>();
        float rightSF = spriteSF.bounds.extents.x; //Distance to the right side, from your center point
        float leftSF = -spriteSF.bounds.extents.x; //Distance to the left side
        float topSF = spriteSF.bounds.extents.y; //Distance to the top
        float bottomSF = -spriteSF.bounds.extents.y; //Distance to the bottom
        float rightboundSF = rightSF + spriteSF.transform.position.x;
        float leftboundSF = leftSF + spriteSF.transform.position.x;
        float topboundSF = topSF + spriteSF.transform.position.y;
        float bottomboundSF = bottomSF + spriteSF.transform.position.y;

        //Packet was placed in the furnance
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

        //State check
        //Packet was placed in the furnance
        else if (this.transform.position.x < rightboundS && this.transform.position.x > leftboundS && this.transform.position.y < topboundS && this.transform.position.y > bottomboundS)
        {
            if (this.state == true)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                //Debug.Log("fulfills the state table");
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log("does not fulfill the state table");
            }
        }

        //Update check
        //Packet was placed in the furnance
        else if (this.transform.position.x < rightboundU && this.transform.position.x > leftboundU && this.transform.position.y < topboundU && this.transform.position.y > bottomboundU)
        {
            if (this.update == true)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                //Debug.Log("fulfills the update table");
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log("does not fulfill the update table");
            }
        }

        //Security Policy check
        //Packet was placed in the furnance
        else if (this.transform.position.x < rightboundSF && this.transform.position.x > leftboundSF && this.transform.position.y < topboundSF && this.transform.position.y > bottomboundSF)
        {
            if (this.securityPolicy == true)
            {
                this.GetComponent<SpriteRenderer>().color = Color.green;
                //Debug.Log("fulfills the security policy");
            }
            else
            {
                this.GetComponent<SpriteRenderer>().color = Color.red;
                //Debug.Log("does not fulfill the security policy");
            }
        }
        else
        {
            //Debug.Log("Should be manila color");
            Color32 manila = new Color(1, 218/255.0f, 131/255.0f);
            this.GetComponent<SpriteRenderer>().color = manila;
        }
    }
}
