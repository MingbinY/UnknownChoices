using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OutcomeController : MonoBehaviour
{
    void OnTriggerEnter(){
        //为玩家添加数值

        gameObject.SetActive(false);
    }

}
