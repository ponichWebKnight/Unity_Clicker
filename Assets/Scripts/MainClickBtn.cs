using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainClickBtn : MonoBehaviour
{
    public void incrementTotalCount() {
        GameManager.CookieCount += 1;
    }
}
