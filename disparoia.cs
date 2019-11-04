using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparoia : MonoBehaviour {
    public GameObject bala;
    public float cont;

	void Update () {
        cont += 1 * Time.deltaTime;
        if (cont >= 2)
        {
            Instantiate(bala, this.transform.position, bala.transform.rotation);
            cont = 0;
        }

	}
}
