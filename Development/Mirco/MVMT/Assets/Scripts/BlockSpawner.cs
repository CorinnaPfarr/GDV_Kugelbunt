using UnityEngine;

public class BlockSpawner : CameraMVMT {

    //List of SpawnPoints.
    public Transform[] spawnPoints;  

    //Referenz zum Gameobejct/Blöcke, die gespawnt werden sollen
    public GameObject blockPrefab;

    public Vector3 spawnOffset = new Vector3(0, 0, 50);
   

    
    private float timeToSpawn = 2;
    public float timeBetweenWaves = 1;

    private void Update()
    {
        //Spawne die erste Welle Blocks nach 2s und dann alle 2s danach weitere Wellen 
        if (Time.time >= timeToSpawn) //Time.time ist die Zeit nach dem das Spiel gestartet wurde
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
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

                //if (player.postition == spawnPoints[i].position)
                //{
                //    SpawnBlocks;  
                //}
                }
            }

        }	
}
