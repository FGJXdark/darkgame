using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour {

	public int sizeX = 30;
	public int sizeZ = 30;

	public int depth;

	public float scale = 20f;
	Terrain terrain;

	// Use this for initialization
	void Start () {
		terrain = GetComponent<Terrain>();
		terrain.terrainData = GenerateTerrain(terrain.terrainData);
	}
	
	TerrainData GenerateTerrain(TerrainData terrainData){
		terrainData.heightmapResolution = sizeX + 1;
		terrainData.size = new Vector3(sizeX, sizeZ, depth);
		terrainData.SetHeights(0, 0, GenerateHeights());
		return terrainData;
	}

	float[,] GenerateHeights(){
		float[,] heights = new float[sizeX, sizeZ];
		for(int i = 0; i < sizeX; i++){
			for(int j = 0; j < sizeZ; j++){
				heights[i, j] = CalculateHeight(i, j);
			}
		}
		return heights;
	}

	float CalculateHeight(int x, int y){
		float xCoordinate = (float)x / sizeX * scale;
		float yCoordinate = (float)y / sizeZ * scale;

		return Mathf.PerlinNoise(xCoordinate, yCoordinate);
	}
}
