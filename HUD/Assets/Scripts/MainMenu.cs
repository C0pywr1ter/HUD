using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingsMenu;
    public GameObject exitButton;
    public GameObject mainMenu;
    public GameObject loadingScreen;

    public TextMeshProUGUI inputText;
    public TMP_InputField inputfield;

    public TextMeshProUGUI droptext;
    public TMP_Dropdown dropdown;

    public static float musicLevelValue = 0.3f;
    public Slider musicSlider;


    bool activeMenu = true;

    public static int healthAmount;
    public static bool hideMiniMap = false;

    // Update is called once per frame
    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update()
    {
       
        UpdateMusic();
       
        
    }
    public void UpdateMusic()
    {
       
        musicLevelValue = musicSlider.value ;
     
    }
    public void InputFieldToText()
    {
        inputText.text = inputfield.text;

    }
    public void DropdownToText(int num)
    {
        droptext.text = dropdown.options[num].text;
        healthAmount = num;
        Debug.Log(num);

    }
    public void Toggle(bool state)
    {
        hideMiniMap = !state;
        Debug.Log(hideMiniMap);
    }

    public void MenuNewGame()
    {
        mainMenu.SetActive(false);
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(1);
      

    }
    public void MenuSettings()
    {
        activeMenu = !activeMenu;
        startMenu.SetActive(activeMenu);
        settingsMenu.SetActive(!activeMenu);
        

    }
    public void MenuExit()
    {
        Application.Quit();
    }
}
