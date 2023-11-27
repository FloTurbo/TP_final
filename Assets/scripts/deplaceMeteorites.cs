using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplaceMeteorites : MonoBehaviour
{
    public float vitesseMeteorites = 0.40f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        //instancitation de rb
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            Debug.LogError("Le GameObject doit avoir un composant Rigidbody pour utiliser ce script.");
        }

        //vitesse initiale
        Vector3 vitesseInitiale = getDirection();

        //appliquation de la vitesse
        rb.velocity = vitesseInitiale * vitesseMeteorites;
    }

    private Vector3 getDirection()
    {
        /*instancier une direction*/

        //point cible
        float yCible = UnityEngine.Random.Range(-2.3f, 2.3f);
        Vector3 posCible = new Vector3(-2.3f, yCible, 0f);

        return posCible;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
