using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour {
    
    private Rigidbody rb;
    private float sizeValue;
    public GameObject spawnerObject;
    private Spawner spawner;

    public float speed;
    public float criticalMass;
    
    public float SizeValue
    {
        get
        {
            return sizeValue;
        }

        set
        {
            sizeValue += value;
            if (sizeValue >= criticalMass)
            {
                spawner.Spawn();
                removeChildren();
                
                transform.localScale = transform.localScale * (float)1.2;
                sizeValue = 0;
            }
        }
    }

    public void removeChildren()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in transform) children.Add(child.gameObject);
        if (children.Count > 0)
        {
            children.ForEach(child => Destroy(child));
        }
    }

    public void shrink()
    {
        transform.localScale = transform.localScale * (float)0.75;
        sizeValue = 0;
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = spawnerObject.GetComponent<Spawner>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }
}
