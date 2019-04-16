using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileMapManager : MonoBehaviour
{
    [SerializeField]
    private Tilemap obstacleMap;
    [SerializeField]
    private Tile obstacle;

    private int maxX=10;
    private int maxY=10;

    private void Awake()
    {
       
        
        for(int i = -maxX; i<=maxX; i++)
        {
            for (int j = -maxY; i <= maxY; i++)
            {
                if(i == maxX || j == maxY || i == -maxX || j == -maxY)
                {
                    Vector3Int currCell = obstacleMap.WorldToCell(new Vector3Int(i,j,0));
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
