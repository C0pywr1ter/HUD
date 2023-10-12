using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI text;
    public TMP_InputField input;

    public TextMeshProUGUI playerNameUI;
    public TextMeshProUGUI IDNumberUI;
    public TextMeshProUGUI playersShipNameUI;

    public TMP_Dropdown dropdown;
    public TextMeshProUGUI dropdownText;

    public Toggle toggle;
    public TextMeshProUGUI toggleText;

    string captainName = "Tayler Derden";
    string shipName = "Mayhem";
    int captainID = 3476;


    void Start()
    {
      
        // input.onValueChanged.AddListener(delegate { InputFieldToText("Hallo"); });
        input.onEndEdit.AddListener((someMethod) => { InputFieldToText(captainName, captainID, shipName); });

    }


    void Update()
    {
        
    }
    public void OnToggledChanged(bool state)
    {
        toggleText.enabled = state;
    }
    public void DropdownToText(int num)
    {
        dropdownText.text = dropdown.options[num].text;
    }
    public void InputFieldToText(string captain, int id, string ship)
    {
        playerNameUI.text = captain;
        IDNumberUI.text = id.ToString();
        playersShipNameUI.text = ship;


    }
   
}
