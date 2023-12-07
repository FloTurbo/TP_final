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
   // public GameObject projectil;

    // Start is called before the first frame update
    void Start()
    {
        //instacier le joueur; et du laser
        joueur = GameObject.FindGameObjectWithTag("Player");
        //projectil = GameObject.FindGameObjectWithTag("laser");

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
        if (other.gameObject.tag == "Player")  // si l'objet en collision est tagger comme étant le joueur
        {
            Instantiate(particule, pos.position, Quaternion.identity); /* génère l'explosion */
            //GetComponent<AudioSource>().Play(); /* fait jouer un bruit d'explosion */
            Destroy(gameObject); /* détruit l'objet qui crée la collision */
            Destroy(joueur);

            affichageEtScore.nbMeteoriteDetruites++; //incérmentation du nombre de météorietes détruites
            affichageEtScore.joueurMort = true; /* le joueur est mort */

        }

        if (other.gameObject.tag == "laser" /*|| other.gameObject.tag == "laserEnnemi"*/)
        {
            Instantiate(particule, pos.position, Quaternion.identity); /* génère l'explosion */
            //GetComponent<AudioSource>().Play(); /* fait jouer un bruit d'explosion */
            GetComponent<Rigidbody>().isKinematic = true; // désactie le rigidbody de l'objet
            Destroy(gameObject); /* détruit l'objet qui crée la collision */
            Destroy(other.gameObject);

            affichageEtScore.nbMeteoriteDetruites++; //incérmentation du nombre de météorietes détruites
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
            //détuire l'objet
            Destroy(gameObject);
        }
    }
}
