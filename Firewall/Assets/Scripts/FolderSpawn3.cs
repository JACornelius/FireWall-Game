using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FolderSpawn3 : MonoBehaviour
{
    public GameObject packet;
    public GameObject nextButton;
    public float spawnTime;
    public float repeatRate;
    public Vector2 startingPos;
    public int maxSpawns;
    private int spawnCount;
    public string[] ipaddr;
    public int[] port;
    public bool[] safe;
    public bool[] state = { false, true, false, false, true };
    public bool[] update = { false, true, false, true, true };
    public bool[] securityP = { false, false, true, false, false };


    // Use this for initialization
    void Start()
    {
        spawnCount = 0;
        InvokeRepeating("SpawnFolder", spawnTime, repeatRate);
        nextButton.SetActive(false);
    }

    void SpawnFolder()
    {
        if (spawnCount < maxSpawns)
        {
            GameObject Text = new GameObject();
            var newFolder = GameObject.Instantiate(packet, startingPos, Quaternion.identity);
            //Debug.Log("starting pos: " + startingPos);
            Packet2 sn = newFolder.GetComponent<Packet2>();
            sn.info(ipaddr[spawnCount], port[spawnCount], safe[spawnCount], state[spawnCount], update[spawnCount], securityP[spawnCount]);
            //Creating Text object
            Text.transform.parent = newFolder.transform;
            Text.transform.position = new Vector2(Text.transform.position.x, Text.transform.position.y + 5);
            Text.AddComponent(typeof(TextMesh));
            var render = Text.GetComponent<Renderer>();
            render.sortingLayerID = 24;

            var textmesh = Text.GetComponent<TextMesh>();
            //Debug.Log("spawn count " + spawnCount);
            textmesh.text = "IP Addr.: " + ipaddr[spawnCount] + "\n Port Number: " + port[spawnCount] + "\n New Connection: " + securityP[spawnCount];
            textmesh.characterSize = 0.2f;
            textmesh.anchor = TextAnchor.MiddleCenter;
            textmesh.fontSize = 10;
            textmesh.alignment = TextAlignment.Center;
            textmesh.lineSpacing = 1.5f;
            textmesh.color = Color.black;

            spawnCount++;
        }
        else
        {
            nextButton.SetActive(true);
        }

    }


}

