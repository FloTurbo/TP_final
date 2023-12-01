using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class laser : MonoBehaviour
{
    //variables de postions
    public float minPosX = -5;
    public float maxPosX = 5;

    private Transform pos;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //instancier varaibles
        pos = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //v�rifier si la position 
        if (pos.position.x < minPosX - 2 || pos.position.x > maxPosX +2)
        {
            //d�tuire l'objet
            Destroy(gameObject);
        }
    }
}
