using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoostClick : MonoBehaviour
{
    public GameObject Boost;
    public GameObject Cost;
    public void boostIncrement() {
        GameManager.CookieCount -= int.Parse(Cost.GetComponent<Text>().text);
        GameManager.CookieConstIncrement += int.Parse(Boost.GetComponent<Text>().text);
    }
}
