using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deplaceEnnemis : MonoBehaviour
{
    public float vitesseEnnemis = 0.20f;
    private Rigidbody rb;
    public float maxPosY;
    public float minPosY;

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

        //appliquation de la vitesses
        rb.velocity = vitesseInitiale * vitesseEnnemis;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 getDirection()
    {
        /*instancier une direction*/

        //point cible
        float yCible = UnityEngine.Random.Range(-1.5f,1.5f);
        Vector3 posCible = new Vector3(-5f, (Mathf.Clamp(yCible, minPosY, maxPosY)), 0f);

        return posCible;
    }
}
