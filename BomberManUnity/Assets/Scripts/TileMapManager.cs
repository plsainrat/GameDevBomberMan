using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private GameObject blockPrefab;
    [SerializeField]
    private Tilemap obstacleMap;
    [SerializeField]
    private Tile obstacle;

    private int maxX=10;
    private int maxY=10;

    private void Awake()
    {
        Vector3Int currCell;

        for (int i = -maxX; i<=maxX; i++)
        {
            for (int j = -maxY; j <= maxY; j++)
            {
                currCell = obstacleMap.WorldToCell(new Vector3Int(i, j, 0));

                if (i%2 == 0 && j % 2 == 0){
                    
                    obstacleMap.SetTile(currCell, obstacle);
                }
                else
                {
                    if ((i > -maxX && i < maxX && j > -maxY && j < maxY) && (i > -maxX + 2 && i < maxX - 2 || j > -maxY + 2 && j < maxY - 2))
                    {
                        if (Random.Range(0, 10) < 8)
                        {
                            Instantiate(blockPrefab, currCell + new Vector3(0.5f, 0.5f, 0), Quaternion.identity);
                        }
                    }
                }


                if(i == maxX || j == maxY || i == -maxX || j == -maxY)
                {
                   
                    obstacleMap.SetTile(currCell, obstacle);
                }
            }
        }


    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
