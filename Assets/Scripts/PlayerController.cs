using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables

    // Movimiento jugador
    public float speed;
    private Rigidbody rb;
    private Vector3 posicion;

    // Partículas
    public Transform particulas;
    private ParticleSystem systemaParticulas;
    

    // Sonido
    public AudioSource audioRecoleccion;
    public AudioSource audioRecoleccion2;
    

    //Puntaje
    private int puntaje;


    //Tiempo
    private bool metaAlcanzada = false;
    private float tiempoTranscurrido = 0f;


    //Contador puntos recolectados

    private int contador;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        systemaParticulas = particulas.GetComponent<ParticleSystem>();
        systemaParticulas.Stop();
       
        audioRecoleccion = GetComponent<AudioSource>();
        puntaje=0;
        contador=0;
    }

    // Update is called once per frame
    void Update()
    {
        // Update

        if (!metaAlcanzada)
    {
        tiempoTranscurrido += Time.deltaTime;
    }
            

    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movimiento * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Recolectable"))
        {
            // Si es recolectable
            other.gameObject.SetActive(false);
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            systemaParticulas = particulas.GetComponent<ParticleSystem>();
            systemaParticulas.Play();
            audioRecoleccion.Play();
            contador++;
            puntaje++;
            Debug.Log("Ganas un punto. Puntaje actual: " + puntaje);
            if(contador ==32){

            Debug.Log($"Tiempo total: {tiempoTranscurrido}");
            }
           
        }
        else if (other.gameObject.CompareTag("NoRecolectable"))
        {
            
            other.gameObject.SetActive(false);
            systemaParticulas.Play();


            audioRecoleccion2.Play();
            puntaje--;
            Debug.Log("Pierdes un punto. Puntaje actual: " + puntaje);
        }


      else if (other.gameObject.CompareTag("Trampa")) {
    transform.position = new Vector3(-246, 90, 26);
}

        else if (other.gameObject.CompareTag("Meta")) {
            metaAlcanzada = true;
        Debug.Log($"Tiempo total: {tiempoTranscurrido}");
}

    } // Cierre de la función OnTriggerEnter
} // Cierre de la clase PlayerController
