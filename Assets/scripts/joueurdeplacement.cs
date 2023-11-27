using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jouerdeplacement : MonoBehaviour
{
    //variables
    public float vitesseJoueur = 1f;
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //instanciation de la camera principale
        mainCamera = Camera.main;
        if (mainCamera == null)
        {
            Debug.LogError("La cam�ra principale n'a pas �t� trouv�e. Assurez-vous qu'il y a une cam�ra principale dans la sc�ne.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //entr�e directionnles du clavier
        float saisieHorizontale = Input.GetAxis("Horizontal");
        float saisieVerticale = Input.GetAxis("Vertical");

        //direction r�sultante
        Vector3 direction = new Vector3( saisieHorizontale, saisieVerticale, 0f);

        //d�placer le joueur en fonction de la direction
      
        transform.Translate(direction*vitesseJoueur*Time.deltaTime,Space.World);
        if(transform.position.y > (Screen.height/2))
        {
            transform.position = new Vector3(transform.position.x, (Screen.height / 2), 0f);
        }

        //emp�cher le joueur de sortir de l'�cran
        limitePosition();
    }

    void limitePosition()
    {
        Vector3 coinBasGauche = mainCamera.WorldToScreenPoint(new Vector3(0, 0, 0));
        Vector3 coinHautGauche = mainCamera.WorldToScreenPoint(new Vector3(0, Screen.height, 0));
        Vector3 coinBasDroite = mainCamera.WorldToScreenPoint(new Vector3(Screen.width, 0, 0));
        Vector3 coinHautDroit = mainCamera.WorldToScreenPoint(new Vector3(Screen.width, Screen.height, 0));

        ///* m�thode trouv�e sur internet pour d�terminer ou se trouve l'�cran */

        ////dimensions de l'�cran en pixels
        //float demiLargeur = Camera.main.orthographicSize * Screen.width / Screen.height;
        //float demiHauteur = Camera.main.orthographicSize;

        //// Limite la position du vaisseau -> rester � l'int�rieur de l'�cran
        //Vector3 positionLimite = transform.position;
        //positionLimite.x = Mathf.Clamp(positionLimite.x, -demiLargeur, demiLargeur);
        //positionLimite.z = Mathf.Clamp(positionLimite.z, -demiHauteur, demiHauteur);

        //// Appliquez la position limit�e au vaisseau
        //transform.position = positionLimite;
    }
}
