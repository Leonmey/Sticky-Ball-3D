﻿using UnityEngine;
using System.Collections;
using System;

public class MapGenerator : MonoBehaviour {

    public int width, height;
    public string seed;
    public bool useRandomSeed;

    [Range(0,100)]
    public int randomFillPercent;


    int[,] map;

    void Start()
    {
        GenerateMap();

    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GenerateMap();
        }
    }

    void GenerateMap()
    {
        map = new int[width, height];
        RandomFillMap();
        
        for(int i = 0; i < 5; i++)
        {
            SmoothMap();
        }

        int borderSize = 1;
        int[,] borderdMap = new int[width + borderSize * 2, height + borderSize * 2];

        for (int x = 0; x < borderdMap.GetLength(0); x++)
        {
            for (int y = 0; y < borderdMap.GetLength(1); y++)
            {
                if(x >= borderSize && x < width + borderSize && y >= borderSize && y < height + borderSize)
                {
                    borderdMap[x, y] = map[x - borderSize, y - borderSize];
                }
                else
                {
                    borderdMap[x, y] = 1;
                }
            }
        }
                MeshGenerator meshGen = GetComponent<MeshGenerator>();
        meshGen.GenerateMesh(borderdMap, 1);
    }

    void RandomFillMap()
    {
        if (useRandomSeed)
        {
            seed = UnityEngine.Random.Range(0f, 100f).ToString();
        }

        System.Random pseudoRandom = new System.Random(seed.GetHashCode());

        for (int x = 0; x < width; x++) {
            for (int y = 0; y < height; y++) {
                if (x == 0 || x == width - 1 || y == 0 || y == height - 1)
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (pseudoRandom.Next(0, 100) < randomFillPercent) ? 1 : 0;
                }
            }
        }
    }

    void SmoothMap()
    {
        int[,] map2 = new int[width, height];
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                int neighbourWallTiles = GetSurroundingWallCount(x, y);
                if (map2[x, y] == 1)
                {
                    if (neighbourWallTiles > 4)
                        map2[x, y] = 1;
                    else if (neighbourWallTiles <4)
                        map2[x, y] = 0;
                }
                else
                {
                    if (neighbourWallTiles >= 5)
                        map2[x, y] = 1;
                }
            }
        }
        map = map2;
    }

    int GetSurroundingWallCount(int gridX, int gridY)
    {
        int wallCount = 0;
        for (int neighbourX = gridX - 1; neighbourX <= gridX + 1; neighbourX++) {
            for (int neighbourY = gridY - 1; neighbourY <= gridY + 1; neighbourY++) {
                if(neighbourX >= 0 && neighbourX < width && neighbourY >= 0 && neighbourY < height) {
                    if (neighbourX != gridX || neighbourY != gridY) {
                        wallCount += map[neighbourX, neighbourY];
                    }
                }
                else
                {
                    wallCount++;
                }
            }
        }
        return wallCount;
    }

    void OnDrawGizmos()
    {
        //if (map != null)
        //{
        //    for (int x = 0; x < width; x++)
        //    {
        //        for (int y = 0; y < height; y++)
        //        {
        //            gizmos.color = (map[x, y] == 1) ? color.black : color.white;
        //            vector3 pos = new vector3(-width / 2 + x + 0.5f, 0, -height / 2 + y + 0.5f);
        //            gizmos.drawcube(pos, vector3.one);
        //        }
        //    }
        //}
    }
}
