using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    private float rndNbr;
    private float scaleMultiplier = 5f;
    public GameObject cube;
    public GameObject cylinder;
    public GameObject resetter;
    public GameObject levelDown;
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

            rndNbr = Random.Range(0, minNum);
            Transform temp = (Transform)Instantiate(prefab[(int)rndNbr], new Vector3(rndX, 2, rndZ), transform.rotation);
            switch ((int)rndNbr)
            {
                case 0:
                    temp.transform.parent = resetter.transform;
                    break;
                case 1:
                    temp.transform.parent = levelDown.transform;
                    break;
            }
        }

        for (int i = 0; i < numSpawn; i++)
        {
            float rndX, rndZ;

            rndX = Random.Range(-plane.transform.localScale.x * scaleMultiplier, plane.transform.localScale.x * scaleMultiplier);
            rndZ = Random.Range(-plane.transform.localScale.z * scaleMultiplier, plane.transform.localScale.z * scaleMultiplier);

            rndNbr = Random.Range(minNum, maxNum);
            Transform temp = (Transform)Instantiate(prefab[(int)rndNbr], new Vector3(rndX, 2, rndZ), transform.rotation);
            switch ((int)rndNbr)
            {
                case 2:
                    temp.transform.parent = cube.transform;
                    break;
                case 3:
                    temp.transform.parent = cylinder.transform;
                    break;
            }
        }
    }


	// Use this for initialization
	void Start () {
        Spawn();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
