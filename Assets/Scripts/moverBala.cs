using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moverBala : MonoBehaviour
{
    public float velocidad = 10.0f;
    public Vector3 direccion;

    public void Inicializar(Vector3 direccion)
    {
        this.direccion = direccion.normalized;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
    }


}
