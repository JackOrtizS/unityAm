using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumBalas : MonoBehaviour
{
    public int numBalas;

    // Start is called before the first frame update
    void Start()
    {
        numBalas = UnityEngine.Random.Range(-10, 10);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
