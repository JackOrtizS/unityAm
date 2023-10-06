using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using TMPro;
using System;
using Microsoft.Win32;

public class NewBehaviourScript : MonoBehaviour
{
    public int val = 0;
    public float velocidad = 0f;
    public GameObject obj1;
    public GameObject obj2;
    public GameObject obj3;

    //Audio
    public AudioClip sonido;
    private AudioSource reproductor;

    public AudioClip sonido2;
    private AudioSource reproductor2;

    public AudioClip sonido3;
    private AudioSource reproductor3;

    private TextMeshProUGUI lblBalas;
    public int numBalas;


    // Start is called before the first frame update
    void Start()
    {
        lblBalas = GameObject.Find("lblBalas").GetComponent<TextMeshProUGUI>();
        numBalas = PlayerPrefs.GetInt("numBalas", 10);
        lblBalas.text = $"Balas:{numBalas}";

        reproductor2 = GetComponent<AudioSource>();
        reproductor3 = GetComponent<AudioSource>();


        for (int i = 0; i <= 10; i++)
        {
            var x = UnityEngine.Random.Range(-25f, 3.2f);
            var y = 1.6f;
            var z = UnityEngine.Random.Range(-25f, -7f);

            var posicion = new Vector3(x,y,z);
        
            Instantiate(obj3, posicion, Quaternion.identity);
            reproductor = GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");
        float s = Input.GetAxis("Jump");

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            s = -1;
        }

        Vector3 movimiento = new Vector3(mh, s, mv);

        transform.Translate(movimiento * velocidad * Time.deltaTime);

        
        //Objeto Cubo
        if (Input.GetKeyDown(KeyCode.P))
        {
            Instantiate(obj1, transform.position + transform.forward, Quaternion.identity);
        }

        //Objeto bala
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            if(numBalas > 0)
            {
                var objBala = Instantiate(obj2, transform.position + transform.forward * 2, Quaternion.identity);

                objBala.GetComponent<moverBala>().Inicializar(transform.forward);

                Destroy(objBala, 10);

                numBalas -=1;

                lblBalas.text = $"Balas:{numBalas}";

                PlayerPrefs.SetInt("numBalas", numBalas);
                PlayerPrefs.Save();
                reproductor.PlayOneShot(sonido);
            } 
        }
    }
    private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.tag == "Balas")
            {
                numBalas += collision.gameObject.GetComponent<NumBalas>().numBalas;
            lblBalas.text = $"Balas: {numBalas}";
            PlayerPrefs.SetInt("numBalas", numBalas);
            PlayerPrefs.Save();

            Destroy(collision.gameObject);
            val = numBalas;
            if(val >= 0){
                reproductor2.PlayOneShot(sonido2);
            }else{
                reproductor3.PlayOneShot(sonido3);

            }


            }
            
        }
    
}