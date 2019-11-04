using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class semilla : MonoBehaviour {
    public mov movjug;

    void OnDestroy()
    {
        movjug.missemillas += 1;
    }
}
