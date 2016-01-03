using UnityEngine;
using System.Collections;

public class pickupBehaviour : MonoBehaviour {
    private Rigidbody rb;
    public float sizeValue;
    private PlayerController player;


    void OnCollisionEnter(Collision other)
    {
        if(gameObject.CompareTag("Pickup") && other.gameObject.CompareTag("Player"))
        {
            float mass = rb.mass;
            transform.parent = other.gameObject.transform;
            other.gameObject.GetComponent<Rigidbody>().mass += mass;
            Destroy(rb);

            player = other.gameObject.GetComponent<PlayerController>();
            player.SizeValue = sizeValue;

            //gameObject.GetComponent<Collider>().enabled = false;
        }
        else if(gameObject.CompareTag("resetSize") && other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            player.removeChildren();
            Destroy(gameObject);
            player.SizeValue = -player.SizeValue;
        }
        else if (gameObject.CompareTag("levelDown") && other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerController>();
            player.removeChildren();
            Destroy(gameObject);
            player.shrink();
        }
    }

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
