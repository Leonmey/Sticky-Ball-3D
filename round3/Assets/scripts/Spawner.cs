using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private float rndNbr;
    public int minNum;
    public int maxNum;    
    public Transform[] prefab;
    public GameObject plane;

    public void Spawn()
    {
        for (int i = 0; i < 3; i++)
        {
            float rndX, rndZ;

            rndX = Random.Range(-plane.transform.localScale.x, plane.transform.localScale.x);
            rndZ = Random.Range(-plane.transform.localScale.z, plane.transform.localScale.z);

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
