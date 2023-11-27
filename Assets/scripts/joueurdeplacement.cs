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
            Debug.LogError("La caméra principale n'a pas été trouvée. Assurez-vous qu'il y a une caméra principale dans la scène.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //entrée directionnles du clavier
        float saisieHorizontale = Input.GetAxis("Horizontal");
        float saisieVerticale = Input.GetAxis("Vertical");

        //direction résultante
        Vector3 direction = new Vector3( saisieHorizontale, saisieVerticale, 0f);

        //déplacer le joueur en fonction de la direction
      
        transform.Translate(direction*vitesseJoueur*Time.deltaTime,Space.World);
        if(transform.position.y > (Screen.height/2))
        {
            transform.position = new Vector3(transform.position.x, (Screen.height / 2), 0f);
        }

        //empêcher le joueur de sortir de l'écran
        limitePosition();
    }

    void limitePosition()
    {
        Vector3 coinBasGauche = mainCamera.WorldToScreenPoint(new Vector3(0, 0, 0));
        Vector3 coinHautGauche = mainCamera.WorldToScreenPoint(new Vector3(0, Screen.height, 0));
        Vector3 coinBasDroite = mainCamera.WorldToScreenPoint(new Vector3(Screen.width, 0, 0));
        Vector3 coinHautDroit = mainCamera.WorldToScreenPoint(new Vector3(Screen.width, Screen.height, 0));

        ///* méthode trouvée sur internet pour déterminer ou se trouve l'écran */

        ////dimensions de l'écran en pixels
        //float demiLargeur = Camera.main.orthographicSize * Screen.width / Screen.height;
        //float demiHauteur = Camera.main.orthographicSize;

        //// Limite la position du vaisseau -> rester à l'intérieur de l'écran
        //Vector3 positionLimite = transform.position;
        //positionLimite.x = Mathf.Clamp(positionLimite.x, -demiLargeur, demiLargeur);
        //positionLimite.z = Mathf.Clamp(positionLimite.z, -demiHauteur, demiHauteur);

        //// Appliquez la position limitée au vaisseau
        //transform.position = positionLimite;
    }
}
