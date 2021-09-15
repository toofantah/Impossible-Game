using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameRateController : MonoBehaviour
{
    public int frameRate;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = this.frameRate;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
