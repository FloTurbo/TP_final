using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class jouerdeplacement : MonoBehaviour
{
    //variables
    public float vitesseJoueur = 2f;
    public float maxPosX;
    public float minPosX;
    public float maxPosY;
    public float minPosY;
    private Camera mainCamera;

    Transform deplacement;

    //varaible pour tirer
    public GameObject viseur;
    public GameObject projectil;
    public float vitesseProjectil;
    public float frequenceTir = 0.35f;
    private float frequenceActuelle;
    private bool peuTirer;
    //public AudioSource soundFire;

    // Start is called before the first frame update
    void Start()
    {
        //instanciation de fréquences actuelle
        frequenceActuelle = frequenceTir;

        //instanciation de dépalcement
        deplacement = GetComponent<Transform>();

        //instanciation de la camera principale
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("La caméra principale n'a pas été trouvée. Assurez-vous qu'il y a une caméra principale dans la scène.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //entrée directionnles du clavier
        float posX = Input.GetAxis("Horizontal");
        float posY = Input.GetAxis("Vertical");

        //direction résultante
        Vector3 nouvellePos = new Vector3 ( posX, posY, 0f);

        //effectuer le d.
        //éplacement
        deplacement.Translate(nouvellePos * vitesseJoueur * Time.deltaTime);
        deplacement.position = new Vector3(Mathf.Clamp(deplacement.position.x, minPosX, maxPosX), Mathf.Clamp(deplacement.position.y, minPosY, maxPosY), deplacement.position.z);

        //appel de la fonction tire
        tire();
    }

    //fonction pour tirer
    private void tire()
    {
        frequenceTir += Time.deltaTime;

        //vérifier si la fréquence de tir es supérieur à celle autorisé
        if( frequenceTir > frequenceActuelle)
        {
            peuTirer = true;

        }

        //vériier si il peut tirer
        if (peuTirer && Input.GetMouseButtonDown(0))
        {

            peuTirer = false;
            frequenceTir = 0f; /* resset de la féquence de tir */

            //instancier et donner une vitesse à la position;
            GameObject munition = (GameObject)Instantiate(projectil, viseur.transform.position, Quaternion.identity); /* cée le projectil */
            munition.GetComponent<Rigidbody>().AddForce((viseur.transform.position - transform.position) * vitesseProjectil);
            munition.GetComponent<AudioSource>().Play(); /* active le sond */

     
            
        }
    }
     

}
