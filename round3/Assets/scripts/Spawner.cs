using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private float rndNbr;
    private float scaleMultiplier = 5f;
    public int numSpawn;
    public int minNum;
    public int maxNum;    
    public Transform[] prefab;
    public GameObject plane;

    public void Spawn()
    {
        for (int i = 0; i < numSpawn/3; i++)
        {
            float rndX, rndZ;

            rndX = Random.Range(-plane.transform.localScale.x * scaleMultiplier, plane.transform.localScale.x * scaleMultiplier);
            rndZ = Random.Range(-plane.transform.localScale.z * scaleMultiplier, plane.transform.localScale.z * scaleMultiplier);

            Object.Instantiate(prefab[0], new Vector3(rndX, 2, rndZ), transform.rotation);
        }

        for (int i = 0; i < numSpawn; i++)
        {
            float rndX, rndZ;
            print(-plane.transform.localScale.x);
            print(plane.transform.localScale.x);
            rndX = Random.Range(-plane.transform.localScale.x * scaleMultiplier, plane.transform.localScale.x * scaleMultiplier);
            rndZ = Random.Range(-plane.transform.localScale.z * scaleMultiplier, plane.transform.localScale.z * scaleMultiplier);
            print(rndX);
            print(rndZ);

            rndNbr = Random.Range(minNum, maxNum);
            Object.Instantiate(prefab[(int)rndNbr], new Vector3(rndX,2,rndZ), transform.rotation);
        }
    }


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
