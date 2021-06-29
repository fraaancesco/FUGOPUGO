using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
public class InputManager : Singleton<InputManager>
{

    public Dictionary<string, KeyCode> controls = new Dictionary<string, KeyCode>();
    
    [HideInInspector]
    public bool listening = false;

    [HideInInspector]
    public string control_name = "";

    public List<Button> buttons;
    private string filePathSetting;
    protected override void OnAwake()
    {
        _persistent = false;
        filePathSetting = Path.Combine(Application.persistentDataPath, "InputSettings.json");
        LoadSettings();

        buttons = new List<Button>(controls.Count);
        GetReferenceButtonsOfUI();       
    }

    public void GetReferenceButtonsOfUI()
    {
        GameObject InputMenu = GameObject.Find("Canvas").transform.GetChild(6).gameObject;

        foreach (Transform c in InputMenu.transform.GetComponentsInChildren<Transform>()[0])
        {
            if (c.name.Contains("Button"))
            {
                buttons.Add(c.GetComponent<Button>());

                int index = c.GetChild(0).gameObject.name.IndexOf("Button");
                string name = c.GetChild(0).gameObject.name.Remove(index);

                c.GetChild(0).GetComponent<Text>().text = controls[name].ToString();
            }
        }
    }

    void PrintDictionary()
    {
        foreach (KeyValuePair<string,KeyCode> s in controls)
        {
            //Debug.Log("Dict:");
            Debug.Log(s);
        }
    }


    bool SearchKeyOnDictionary(KeyCode key)
    {
        foreach (KeyValuePair<string, KeyCode> s in controls)
        {
            if(s.Value == key)
            {
                Debug.Log("The key is assigned");
                return false;
            }
        }
        Debug.Log("Key changed");
        return true;
    }
    public void ChangeControls(string control)
    {
        listening = true;

        control_name = control;
        foreach (KeyCode key in System.Enum.GetValues(typeof(KeyCode)))
        {
            if(Input.GetKeyDown(key))
            {
                bool result = SearchKeyOnDictionary(key);
                if (result) 
                {
                
                   // Debug.Log("Prima era "+ controls[control_name]);
                    controls[control_name] = key;
                    ChangeSettings(controls);
                    listening = false;
                  //  Debug.Log("Modificato diventa " + controls[control_name]);
                    foreach (Button button in buttons)
                    {
                     //   Debug.Log(button.name +" ==" + control_name + "Button");
                        if (button.name == control_name + "Button")
                        {
                       
                            button.GetComponentsInChildren<Text>()[0].text = key.ToString();
                        }
                    }
                }
                break;
            }
        }
    }

    public void LoadSettings()
    {
        if (File.Exists(filePathSetting) is true)
         {
            string json = File.ReadAllText(filePathSetting);
            controls = JsonConvert.DeserializeObject<Dictionary<string,KeyCode>>(json);
           // PrintDictionary();
           // print(json);
            
        }
        else if (!File.Exists(filePathSetting))
        {
        // Default Input
            controls.Add("forward", KeyCode.W);
            controls.Add("backward", KeyCode.S);
            controls.Add("left", KeyCode.A);
            controls.Add("right", KeyCode.D);
            controls.Add("jump", KeyCode.Space);
            controls.Add("crounched", KeyCode.DownArrow);
            controls.Add("pause", KeyCode.Escape);
            string json = JsonConvert.SerializeObject(controls, Formatting.Indented);
            File.WriteAllText(filePathSetting, json);
        }
    }


    public void ChangeSettings(Dictionary<string, KeyCode> _controls)
    {
        string json = JsonConvert.SerializeObject(_controls, Formatting.Indented);
        File.WriteAllText(filePathSetting, json);
    }

    private void Update()
    {
        if(listening)
        {
            ChangeControls(control_name);
           // printDictionary();
        }
    }
}
