using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FolderSpawnBottom : MonoBehaviour {
    public GameObject packet;
    public float spawnTime;
    public float repeatRate;
    public Vector2 startingPos;
    public int maxSpawns;
    private int spawnCount;
    public string[] ipaddr;
    public bool[] safe;
    // Use this for initialization
    void Start()
    {
        spawnCount = 0;
        InvokeRepeating("SpawnFolder", spawnTime, repeatRate);
    }

    void SpawnFolder()
    {
        if (spawnCount < maxSpawns)
        {
            GameObject Text = new GameObject();
            var newFolder = GameObject.Instantiate(packet, startingPos, Quaternion.identity);
            Packet3 sn = newFolder.GetComponent<Packet3>();
            sn.info(ipaddr[spawnCount], safe[spawnCount]);
            //Creating Text object
            Text.transform.parent = newFolder.transform;
            Text.transform.position = new Vector2(Text.transform.position.x + 3, Text.transform.position.y - 5);
            Text.AddComponent(typeof(TextMesh));
            var render = Text.GetComponent<Renderer>();
            render.sortingLayerID = 24;

            var textmesh = Text.GetComponent<TextMesh>();
            //Debug.Log("spawn count " + spawnCount);
            textmesh.text = "IP Addr.: " + ipaddr[spawnCount];
            textmesh.characterSize = 0.2f;
            textmesh.anchor = TextAnchor.MiddleCenter;
            textmesh.color = Color.black;
            textmesh.fontSize = 10;
            textmesh.alignment = TextAlignment.Center;

            spawnCount++;
        }

    }

}
