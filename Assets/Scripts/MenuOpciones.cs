using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuOpciones : MonoBehaviour
{

    public void EmpezarJuego (string Nivel)

    {

        SceneManager.LoadScene(Nivel);


    }



    public void Salir() {

        Application.Quit();
        Debug.Log("Cierre");



    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
