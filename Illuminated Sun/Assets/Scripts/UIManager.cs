using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _soulText;

    public void UpdateSoulDisplay(int souls)
    {
        _soulText.text = "Souls: " + souls;
    }

}
