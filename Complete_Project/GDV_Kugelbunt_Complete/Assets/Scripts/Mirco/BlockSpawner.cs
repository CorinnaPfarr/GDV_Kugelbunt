using UnityEngine;

public class BlockSpawner : CameraMVMT {

    public GameObject Player;
    //List of SpawnPoints.
    public Transform[] spawnPoints;  

    //Referenz zum Gameobejct/Blöcke, die gespawnt werden sollen
    public GameObject blockPrefab;

    public Vector3 spawnOffset = new Vector3(0, 0, 50);

    public float triggerDistance = 5;
    private float timeToSpawn = 2;
    public float timeBetweenWaves = 1;

    private Vector3 startPlayerZValue;

    private void Start()
    {
    }

    private void Update()
    {
        //Spawne die erste Welle Blocks nach 2s und dann alle 2s danach weitere Wellen 
        //if (Time.time >= timeToSpawn) //Time.time ist die Zeit nach dem das Spiel gestartet wurde
        //{
        //    SpawnBlocks();
        //    timeToSpawn = Time.time + timeBetweenWaves;
        //}

        if(Vector3.Distance(Player.transform.position, gameObject.transform.position) <= triggerDistance)
        {
            SpawnBlocks();
        }

        
    }


    void SpawnBlocks()
    {
        //Generiere eine Random Zahl zwischen 1 und Größe des Arrays(5)
        int randomIndex = Random.Range(0, spawnPoints.Length);

        //Durchlaufe das Array und spawn Blöcke, außer bei dem SpawnPoint, der zufällig ausgewählt wurde
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spawnPoints[i].position + spawnOffset, Quaternion.identity);
            }
        }
        gameObject.transform.position += spawnOffset;
    }	
}
