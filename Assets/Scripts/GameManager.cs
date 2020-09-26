using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static int CookieCount;
    public static int CookieConstIncrement;
    public GameObject CookieDisplay;
    public GameObject CoinsPerSecond;
    public int InternalCookie;
    private int DelayAmount = 1;
    protected float Timer;
    
    public GameObject HandBoostPanel;
    public GameObject HandBoostCost;
    public GameObject PickaxeBoostPanel;
    public GameObject PickaxeBoostCost;
    public GameObject GnomeBoostPanel;
    public GameObject GnomeBoostCost;
    public GameObject MineBoostPanel;
    public GameObject MineBoostCost;

    // Update is called once per frame
    void Start() {
        CookieCount = PlayerPrefs.GetInt("CookieCount", 0);
        CookieConstIncrement = PlayerPrefs.GetInt("CookieConstIncrement", 0);
    }
    void Update()
    {
        Timer += Time.deltaTime;
 
        if (Timer >= DelayAmount)
        {
            Timer = 0f;
            CookieCount += CookieConstIncrement;
        }
        PlayerPrefs.SetInt("CookieCount", CookieCount);
        PlayerPrefs.SetInt("CookieConstIncrement", CookieConstIncrement);
        InternalCookie = CookieCount;
        CookieDisplay.GetComponent<Text>().text = InternalCookie.ToString();
        CoinsPerSecond.GetComponent<Text>().text = "Coins per second " + CookieConstIncrement.ToString();
        checkBoostAvailable(HandBoostPanel, HandBoostCost);
        checkBoostAvailable(PickaxeBoostPanel, PickaxeBoostCost);
        checkBoostAvailable(GnomeBoostPanel, GnomeBoostCost);
        checkBoostAvailable(MineBoostPanel, MineBoostCost);
    }

    private void checkBoostAvailable(GameObject Boost, GameObject Cost) {
        int cost = int.Parse(Cost.GetComponent<Text>().text);
        if (InternalCookie >= cost) {
            Text[] texts = Boost.gameObject.GetComponentsInChildren<Text>();
            for (int i = 0; i <= (texts.Length - 1); i++) {
                Text text = texts[i];
                Color32 textColor = text.color;
                textColor.a = 255;
                text.color = textColor;
            }
            Image img = Boost.gameObject.GetComponentsInChildren<Image>()[0];
            Color32 imgColor = img.color;
            imgColor.a = 255;
            img.color = imgColor;
            Button btn = Boost.gameObject.GetComponentsInChildren<Button>()[0];
            btn.interactable = true;
        } else {
            Text[] texts = Boost.gameObject.GetComponentsInChildren<Text>();
            for (int i = 0; i <= (texts.Length - 1); i++) {
                Text text = texts[i];
                Color32 textColor = text.color;
                textColor.a = 100;
                text.color = textColor;
            }
            Image img = Boost.gameObject.GetComponentsInChildren<Image>()[0];
            Color32 imgColor = img.color;
            imgColor.a = 100;
            img.color = imgColor;
            Button btn = Boost.gameObject.GetComponentsInChildren<Button>()[0];
            btn.interactable = false;
        }
    }
}
