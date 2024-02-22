using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PriceHint : MonoBehaviour
{
    public GameObject priceParentObj;
    public GameObject hintObj;

    private void Update()
    {
        if (hintObj)
        {
            hintObj.SetActive(LevelManager.Instance.waveManager.levelEnded);
        }    
    }
}
