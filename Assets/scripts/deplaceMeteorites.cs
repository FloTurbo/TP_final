using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class deplaceMeteorites : MonoBehaviour
{
    public float vitesseMeteorites = 0.40f;
    private Rigidbody rb;
    public float minPosX;

    private Transform pos;

    //variables explosion
    public GameObject joueur;
    public GameObject particule;

    // Start is called before the first frame update
    void Start()
    {
        //instacier le joueur;
        joueur = GameObject.FindGameObjectWithTag("Player");

        //instancier position
        pos = GetComponent<Transform>();


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

    //si il y a collision avec l'objet qui porte le scripte
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")  // si l'objet en collision est tagger comme �tant le joueur
        {
            Instantiate(particule, pos.position, Quaternion.identity); /* g�n�re l'explosion */
            GetComponent<AudioSource>().Play(); /* fait jouer un bruit d'explosion */
            Destroy(gameObject); /* d�truit l'objet qui cr�e la collision */
            Destroy(joueur);
        }

        if(other.gameObject.tag == "laser")
        {
            Instantiate(particule, pos.position, Quaternion.identity); /* g�n�re l'explosion */
            GetComponent<AudioSource>().Play(); /* fait jouer un bruit d'explosion */
            Destroy(gameObject); /* d�truit l'objet qui cr�e la collision */
        }
    }

    private Vector3 getDirection()
    {
        /*instancier une direction*/

        //point cible
        float yCible = UnityEngine.Random.Range(-2.3f, 2.3f);
        Vector3 posCible = new Vector3(-5f, yCible, 0f);

        return posCible;
    }

    // Update is called once per frame
    void Update()
    {
        if(pos.position.x < minPosX -2)
        {
            //d�tuire l'objet
            Destroy(gameObject);
        }
    }
}
