using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject blockPrefab;
    public int x;
    public int z;
    public Vector2[] blocks;

    void Start()
    {
        blocks = new Vector2[x*z];

        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < z; j++)
            {
                GameObject blockObject = Instantiate(blockPrefab, new Vector3(i, 0, j), Quaternion.identity);
                blocks[i] = new Vector2(blockObject.transform.position.x, blockObject.transform.position.z);
                blockObject.name = "Block(" + i + "," + j + ")";
                BlockScript block = blockObject.GetComponent<BlockScript>();
                block.blockPos = new Vector2(i, j);
                blockObject.transform.parent = transform;
            }
        }
    }

    void Update()
    {
        
    }
}
