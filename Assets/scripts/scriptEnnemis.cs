using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class deplaceEnnemis : MonoBehaviour
{
    public float vitesseEnnemis = 0.20f;
    private Rigidbody rb;
    public float maxPosY;
    public float minPosY;
    public float minPosX = -5f;

    private Transform pos;

    //varaible pour tirer
    public GameObject viseur1;
    public GameObject viseur2;
    public GameObject projectil;
    public float vitesseProjectil;
    public float frequenceTir = 4f;
    private float frequenceActuelle;
    private bool peuTirer;

    //varaibles pour la destruction
    public GameObject particule;

    // Start is called before the first frame update
    void Start()
    {
        //instanciation de fréquences actuelle
        frequenceActuelle = frequenceTir;


        //instancier la position
        pos = GetComponent<Transform>();

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
        if (pos.position.x < minPosX - 2)
        {
            //détuire l'objet
            Destroy(gameObject);
        }

        //appel de la méthode qui les fait tirer
        tire();
    }

    //si il y a collision avec l'objet qui porte le scripte
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "laser")  // si l'objet en collision est tagger comme étant le joueur
        {
            Instantiate(particule, GetComponent<Transform>().position, Quaternion.identity); /* génère l'explosion */
            //GetComponent<AudioSource>().Play(); /* fait jouer un bruit d'explosion */
            Destroy(gameObject); /* détruit le vaisseau */
            Destroy(other.gameObject); /* détuite l'objet avec lequel il est entré en collision */

            affichageEtScore.nbVaisseauxDetruits++; //incérmentation du nombre de vaisseaux détruites

        }

        if (other.gameObject.tag == "Player")  // si l'objet en collision est tagger comme étant le joueur
        {
            Instantiate(particule, GetComponent<Transform>().position, Quaternion.identity); /* génère l'explosion */
            //GetComponent<AudioSource>().Play(); /* fait jouer un bruit d'explosion */
            Destroy(gameObject); /* détruit le vaisseau */
            Destroy(other.gameObject);  /* détuite l'objet avec lequel il est entré en collision */

            affichageEtScore.nbVaisseauxDetruits++; //incérmentation du nombre de vaisseaux détruites
            affichageEtScore.joueurMort = true; /* le joueur est mort */
        }
    }

    private Vector3 getDirection()
    {
        /*instancier une direction*/

        //point cible
        float yCible = UnityEngine.Random.Range(-1.5f,1.5f);
        Vector3 posCible = new Vector3(-5f, (Mathf.Clamp(yCible, minPosY, maxPosY)), 0f);

        return posCible;
    }

    //fonction pour tirer
    private void tire()
    {
        frequenceTir += Time.deltaTime;

        //vérifier si la fréquence de tir es supérieur à celle autorisé
        if (frequenceTir > frequenceActuelle)
        {
            peuTirer = true;

        }

        //vériier si il peut tirer
        if (peuTirer)
        {

            peuTirer = false;
            frequenceTir = 0f; /* resset de la féquence de tir */

            //instancier et donner une vitesse à la position du viseur 1
            GameObject munition1 = (GameObject)Instantiate(projectil, viseur1.transform.position, Quaternion.identity); /* cée le projectil */
            munition1.GetComponent<Rigidbody>().AddForce(new Vector3(-1f, 0f, 0f) * vitesseProjectil);
            //munition1.GetComponent<AudioSource>().Play(); /* active le sond */

            //instancier et donner une vitesse à la position du viseur 1
            GameObject munition2 = (GameObject)Instantiate(projectil, viseur2.transform.position, Quaternion.identity); /* cée le projectil */
            munition2.GetComponent<Rigidbody>().AddForce((new Vector3(-1f, 0f, 0f) * vitesseProjectil));
            //munition.GetComponent<AudioSource>().Play(); /* active le sond */

        }
    }
}
    