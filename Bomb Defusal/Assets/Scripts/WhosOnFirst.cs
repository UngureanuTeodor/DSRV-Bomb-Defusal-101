using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WhosOnFirst : MonoBehaviour {

    public TextMesh button_0;
    public TextMesh button_1;
    public TextMesh button_2;
    public TextMesh button_3;
    public TextMesh button_4;
    public TextMesh button_5;
    public TextMesh screen;

    string dictionaryTitle;
    public static int solvedModule_buttonIndex;
    public static bool gameSolved = false;

    List<WOF_Screen> screens = new List<WOF_Screen>();
    List<WOF_Button> buttons = new List<WOF_Button>();

    void PopulateScreens() {
        WOF_Screen screen;
        
        screen = new WOF_Screen("YES", 2);
        screens.Add(screen);
        screen = new WOF_Screen("FIRST", 1);
        screens.Add(screen);
        screen = new WOF_Screen("DISPLAY", 5);
        screens.Add(screen);
        screen = new WOF_Screen("OKAY", 1);
        screens.Add(screen);
        screen = new WOF_Screen("SAYS", 5);
        screens.Add(screen);
        screen = new WOF_Screen("NOTHING", 2);
        screens.Add(screen);
        screen = new WOF_Screen("", 4);
        screens.Add(screen);
        screen = new WOF_Screen("BLANK", 3);
        screens.Add(screen);
        screen = new WOF_Screen("NO", 5);
        screens.Add(screen);
        screen = new WOF_Screen("LED", 2);
        screens.Add(screen);
        screen = new WOF_Screen("LEAD", 5);
        screens.Add(screen);
        screen = new WOF_Screen("READ", 3);
        screens.Add(screen);
        screen = new WOF_Screen("RED", 3);
        screens.Add(screen);
        screen = new WOF_Screen("REED", 4);
        screens.Add(screen);
        screen = new WOF_Screen("LEED", 4);
        screens.Add(screen);
        screen = new WOF_Screen("HOLD ON", 5);
        screens.Add(screen);
        screen = new WOF_Screen("YOU", 3);
        screens.Add(screen);
        screen = new WOF_Screen("YOU ARE", 5);
        screens.Add(screen);
        screen = new WOF_Screen("YOUR", 3);
        screens.Add(screen);
        screen = new WOF_Screen("YOU'RE", 3);
        screens.Add(screen);
        screen = new WOF_Screen("UR", 0);
        screens.Add(screen);
        screen = new WOF_Screen("THERE", 5);
        screens.Add(screen);
        screen = new WOF_Screen("THEY'RE", 4);
        screens.Add(screen);
        screen = new WOF_Screen("THEIR", 3);
        screens.Add(screen);
        screen = new WOF_Screen("THEY ARE", 2);
        screens.Add(screen);
        screen = new WOF_Screen("SEE", 5);
        screens.Add(screen);
        screen = new WOF_Screen("C", 1);
        screens.Add(screen);
        screen = new WOF_Screen("CEE", 5);
        screens.Add(screen);
    }

    void PopulateButtons() {
        WOF_Button button;
        List<string> dictionary;

        dictionary = new List<string>();
        dictionary.Add("YES");
        dictionary.Add("OKAY");
        dictionary.Add("WHAT");
        dictionary.Add("MIDDLE");
        dictionary.Add("LEFT");
        dictionary.Add("PRESS");
        dictionary.Add("RIGHT");
        dictionary.Add("BLANK");
        dictionary.Add("READY");
        dictionary.Add("NO");
        dictionary.Add("FIRST");
        dictionary.Add("UHHH");
        dictionary.Add("NOTHING");
        dictionary.Add("WAIT");
        button = new WOF_Button("READY", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("LEFT");
        dictionary.Add("OKAY");
        dictionary.Add("YES");
        dictionary.Add("MIDDLE");
        dictionary.Add("NO");
        dictionary.Add("RIGHT");
        dictionary.Add("NOTHING");
        dictionary.Add("UHHH");
        dictionary.Add("WAIT");
        dictionary.Add("READY");
        dictionary.Add("BLANK");
        dictionary.Add("WHAT");
        dictionary.Add("PRESS");
        dictionary.Add("FIRST");
        button = new WOF_Button("FIRST", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("BLANK");
        dictionary.Add("UHHH");
        dictionary.Add("WAIT");
        dictionary.Add("FIRST");
        dictionary.Add("WHAT");
        dictionary.Add("READY");
        dictionary.Add("RIGHT");
        dictionary.Add("YES");
        dictionary.Add("NOTHING");
        dictionary.Add("LEFT");
        dictionary.Add("PRESS");
        dictionary.Add("OKAY");
        dictionary.Add("NO");
        dictionary.Add("MIDDLE");
        button = new WOF_Button("NO", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("WAIT");
        dictionary.Add("RIGHT");
        dictionary.Add("OKAY");
        dictionary.Add("MIDDLE");
        dictionary.Add("BLANK");
        dictionary.Add("PRESS");
        dictionary.Add("READY");
        dictionary.Add("NOTHING");
        dictionary.Add("NO");
        dictionary.Add("WHAT");
        dictionary.Add("LEFT");
        dictionary.Add("UHHH");
        dictionary.Add("YES");
        dictionary.Add("FIRST");
        button = new WOF_Button("BLANK", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UHHH");
        dictionary.Add("RIGHT");
        dictionary.Add("OKAY");
        dictionary.Add("MIDDLE");
        dictionary.Add("YES");
        dictionary.Add("BLANK");
        dictionary.Add("NO");
        dictionary.Add("PRESS");
        dictionary.Add("LEFT");
        dictionary.Add("WHAT");
        dictionary.Add("WAIT");
        dictionary.Add("FIRST");
        dictionary.Add("NOTHING");
        dictionary.Add("READY");
        button = new WOF_Button("NOTHING", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("OKAY");
        dictionary.Add("RIGHT");
        dictionary.Add("UHHH");
        dictionary.Add("MIDDLE");
        dictionary.Add("FIRST");
        dictionary.Add("WHAT");
        dictionary.Add("PRESS");
        dictionary.Add("READY");
        dictionary.Add("NOTHING");
        dictionary.Add("YES");
        dictionary.Add("LET");
        dictionary.Add("BLANK");
        dictionary.Add("NO");
        dictionary.Add("WAIT");
        button = new WOF_Button("YES", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UHHH");
        dictionary.Add("WHAT");
        dictionary.Add("LEFT");
        dictionary.Add("NOTHING");
        dictionary.Add("READY");
        dictionary.Add("BLANK");
        dictionary.Add("MIDDLE");
        dictionary.Add("NO");
        dictionary.Add("OKAY");
        dictionary.Add("FIRST");
        dictionary.Add("WAIT");
        dictionary.Add("YES");
        dictionary.Add("PRESS");
        dictionary.Add("RIGHT");
        button = new WOF_Button("WHAT", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("READY");
        dictionary.Add("NOTHING");
        dictionary.Add("LEFT");
        dictionary.Add("WHAT");
        dictionary.Add("OKAY");
        dictionary.Add("YES");
        dictionary.Add("RIGHT");
        dictionary.Add("NO");
        dictionary.Add("PRESS");
        dictionary.Add("BLANK");
        dictionary.Add("UHHH");
        dictionary.Add("MIDDLE");
        dictionary.Add("WAIT");
        dictionary.Add("FIRST");
        button = new WOF_Button("UHHH", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("RIGHT");
        dictionary.Add("LEFT");
        dictionary.Add("FIRST");
        dictionary.Add("NO");
        dictionary.Add("MIDDLE");
        dictionary.Add("YES");
        dictionary.Add("BLANK");
        dictionary.Add("WHAT");
        dictionary.Add("UHHH");
        dictionary.Add("WAIT");
        dictionary.Add("PRESS");
        dictionary.Add("READY");
        dictionary.Add("OKAY");
        dictionary.Add("NOTHING");
        button = new WOF_Button("LEFT", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YES");
        dictionary.Add("NOTHING");
        dictionary.Add("READY");
        dictionary.Add("PRESS");
        dictionary.Add("NO");
        dictionary.Add("WAIT");
        dictionary.Add("WHAT");
        dictionary.Add("RIGHT");
        dictionary.Add("MIDDLE");
        dictionary.Add("LEFT");
        dictionary.Add("UHHH");
        dictionary.Add("BLANK");
        dictionary.Add("OKAY");
        dictionary.Add("FIRST");
        button = new WOF_Button("RIGHT", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("BLANK");
        dictionary.Add("READY");
        dictionary.Add("OKAY");
        dictionary.Add("WHAT");
        dictionary.Add("NOTHING");
        dictionary.Add("PRESS");
        dictionary.Add("NO");
        dictionary.Add("WAIT");
        dictionary.Add("LEFT");
        dictionary.Add("MIDDLE");
        dictionary.Add("RIGHT");
        dictionary.Add("FIRST");
        dictionary.Add("UHHH");
        dictionary.Add("YES");
        button = new WOF_Button("MIDDLE", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("MIDDLE");
        dictionary.Add("NO");
        dictionary.Add("FIRST");
        dictionary.Add("YES");
        dictionary.Add("UHHH");
        dictionary.Add("NOTHING");
        dictionary.Add("WAIT");
        dictionary.Add("OKAY");
        dictionary.Add("LEFT");
        dictionary.Add("READY");
        dictionary.Add("BLANK");
        dictionary.Add("PRESS");
        dictionary.Add("WHAT");
        dictionary.Add("RIGHT");
        button = new WOF_Button("OKAY", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UHHH");
        dictionary.Add("NO");
        dictionary.Add("BLANK");
        dictionary.Add("OKAY");
        dictionary.Add("YES");
        dictionary.Add("LEFT");
        dictionary.Add("FIRST");
        dictionary.Add("PRESS");
        dictionary.Add("WHAT");
        dictionary.Add("WAIT");
        dictionary.Add("NOTHING");
        dictionary.Add("READY");
        dictionary.Add("RIGHT");
        dictionary.Add("MIDDLE");
        button = new WOF_Button("WAIT", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("RIGHT");
        dictionary.Add("MIDDLE");
        dictionary.Add("YES");
        dictionary.Add("READY");
        dictionary.Add("PRESS");
        dictionary.Add("OKAY");
        dictionary.Add("NOTHING");
        dictionary.Add("UHHH");
        dictionary.Add("BLANK");
        dictionary.Add("LEFT");
        dictionary.Add("FIRST");
        dictionary.Add("WHAT");
        dictionary.Add("NO");
        dictionary.Add("WAIT");
        button = new WOF_Button("PRESS", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("SURE");
        dictionary.Add("YOU ARE");
        dictionary.Add("YOUR");
        dictionary.Add("YOU'RE");
        dictionary.Add("NEXT");
        dictionary.Add("UH HUH");
        dictionary.Add("UR");
        dictionary.Add("HOLD");
        dictionary.Add("WHAT");
        dictionary.Add("YOU");
        dictionary.Add("UH UH");
        dictionary.Add("LIKE");
        dictionary.Add("DONE");
        dictionary.Add("U");
        button = new WOF_Button("YOU", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YOUR");
        dictionary.Add("NEXT");
        dictionary.Add("LIKE");
        dictionary.Add("UH HUH");
        dictionary.Add("WHAT");
        dictionary.Add("DONE");
        dictionary.Add("UH UH");
        dictionary.Add("HOLD");
        dictionary.Add("YOU");
        dictionary.Add("U");
        dictionary.Add("YOU'RE");
        dictionary.Add("SURE");
        dictionary.Add("UR");
        dictionary.Add("YOU ARAE");
        button = new WOF_Button("YOU ARE", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UH UH");
        dictionary.Add("YOU ARE");
        dictionary.Add("UH HUH");
        dictionary.Add("YOUR");
        dictionary.Add("NEXT");
        dictionary.Add("UR");
        dictionary.Add("SURE");
        dictionary.Add("U");
        dictionary.Add("YOU'RE");
        dictionary.Add("YOU");
        dictionary.Add("WHAT");
        dictionary.Add("HOLD");
        dictionary.Add("LIKE");
        dictionary.Add("DONE");
        button = new WOF_Button("YOUR", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YOU");
        dictionary.Add("YOU'RE");
        dictionary.Add("UR");
        dictionary.Add("NEXT");
        dictionary.Add("UH UH");
        dictionary.Add("YOU ARE");
        dictionary.Add("U");
        dictionary.Add("YOUR");
        dictionary.Add("WHAT");
        dictionary.Add("UH HUH");
        dictionary.Add("SURE");
        dictionary.Add("DONE");
        dictionary.Add("LIKE");
        dictionary.Add("HOLD");
        button = new WOF_Button("YOU'RE", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("DONE");
        dictionary.Add("U");
        dictionary.Add("UR");
        dictionary.Add("UH HUH");
        dictionary.Add("WHAT");
        dictionary.Add("SURE");
        dictionary.Add("YOUR");
        dictionary.Add("HOLD");
        dictionary.Add("YOU'RE");
        dictionary.Add("LIKE");
        dictionary.Add("NEXT");
        dictionary.Add("UH UH");
        dictionary.Add("YOU ARE");
        dictionary.Add("YOU");
        button = new WOF_Button("UR", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UH HUH");
        dictionary.Add("SURE");
        dictionary.Add("NEXT");
        dictionary.Add("WHAT");
        dictionary.Add("YOU'RE");
        dictionary.Add("UR");
        dictionary.Add("UH UH");
        dictionary.Add("DONE");
        dictionary.Add("U");
        dictionary.Add("YOU");
        dictionary.Add("LIKE");
        dictionary.Add("HOLD");
        dictionary.Add("YOU ARE");
        dictionary.Add("YOUR");
        button = new WOF_Button("U", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UH HUH");
        dictionary.Add("YOUR");
        dictionary.Add("YOU ARE");
        dictionary.Add("YOU");
        dictionary.Add("DONE");
        dictionary.Add("HOLD");
        dictionary.Add("UH UH");
        dictionary.Add("NEXT");
        dictionary.Add("SURE");
        dictionary.Add("LIKE");
        dictionary.Add("YOU'RE");
        dictionary.Add("UR");
        dictionary.Add("U");
        dictionary.Add("WHAT");
        button = new WOF_Button("UH HUH", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("UR");
        dictionary.Add("U");
        dictionary.Add("YOU ARE");
        dictionary.Add("YOU'RE");
        dictionary.Add("NEXT");
        dictionary.Add("UH UH");
        dictionary.Add("DONE");
        dictionary.Add("YOU");
        dictionary.Add("UH HUH");
        dictionary.Add("LIKE");
        dictionary.Add("YOUR");
        dictionary.Add("SURE");
        dictionary.Add("HOLD");
        dictionary.Add("WHAT");
        button = new WOF_Button("UH UH", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YOU");
        dictionary.Add("HOLD");
        dictionary.Add("YOU'RE");
        dictionary.Add("YOUR");
        dictionary.Add("U");
        dictionary.Add("DONE");
        dictionary.Add("UH UH");
        dictionary.Add("LIKE");
        dictionary.Add("YOU ARE");
        dictionary.Add("UH HUH");
        dictionary.Add("UR");
        dictionary.Add("NEXT");
        dictionary.Add("WHAT");
        dictionary.Add("SURE");
        button = new WOF_Button("WHAT", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("SURE");
        dictionary.Add("UH HUH");
        dictionary.Add("NEXT");
        dictionary.Add("WHAT");
        dictionary.Add("YOUR");
        dictionary.Add("UH");
        dictionary.Add("YOU'RE");
        dictionary.Add("HOLD");
        dictionary.Add("LIKE");
        dictionary.Add("YOU");
        dictionary.Add("U");
        dictionary.Add("YOU ARE");
        dictionary.Add("UH UH");
        dictionary.Add("DONE");
        button = new WOF_Button("DONE", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("WHAT");
        dictionary.Add("UH HUH");
        dictionary.Add("UH UH");
        dictionary.Add("YOUR");
        dictionary.Add("HOLD");
        dictionary.Add("SURE");
        dictionary.Add("NEXT");
        dictionary.Add("LIKE");
        dictionary.Add("DONE");
        dictionary.Add("YOU ARE");
        dictionary.Add("UR");
        dictionary.Add("YOU'RE");
        dictionary.Add("U");
        dictionary.Add("YOU");
        button = new WOF_Button("NEXT", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YOU ARE");
        dictionary.Add("U");
        dictionary.Add("DONE");
        dictionary.Add("UH UH");
        dictionary.Add("YOU");
        dictionary.Add("UR");
        dictionary.Add("SURE");
        dictionary.Add("WHAT");
        dictionary.Add("YOU'RE");
        dictionary.Add("NEXT");
        dictionary.Add("HOLD");
        dictionary.Add("UH HUH");
        dictionary.Add("YOUR");
        dictionary.Add("LIKE");
        button = new WOF_Button("HOLD", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YOU ARE");
        dictionary.Add("DONE");
        dictionary.Add("LIKE");
        dictionary.Add("YOU'RE");
        dictionary.Add("YOU");
        dictionary.Add("HOLD");
        dictionary.Add("UH HUH");
        dictionary.Add("UR");
        dictionary.Add("SURE");
        dictionary.Add("U");
        dictionary.Add("WHAT");
        dictionary.Add("NEXT");
        dictionary.Add("YOUR");
        dictionary.Add("UH UH");
        button = new WOF_Button("SURE", dictionary);
        buttons.Add(button);

        dictionary = new List<string>();
        dictionary.Add("YOU'RE");
        dictionary.Add("NEXT");
        dictionary.Add("U");
        dictionary.Add("UR");
        dictionary.Add("HOLD");
        dictionary.Add("DONE");
        dictionary.Add("UH UH");
        dictionary.Add("WHAT");
        dictionary.Add("UH HUH");
        dictionary.Add("YOU");
        dictionary.Add("LIKE");
        dictionary.Add("SURE");
        dictionary.Add("YOU ARE");
        dictionary.Add("YOUR");
        button = new WOF_Button("LIKE", dictionary);
        buttons.Add(button);
    }

    void Init() {
        PopulateScreens();
        PopulateButtons();
    }

    void GenerateRandomScreen()
    {
        int randomColumn = Random.Range(0, screens.Count);
        // Iau textul si il afisez in interfata
        screen.text = screens[randomColumn].GetName();

        // Tin minte pozitia pe care ma uit ca sa stiu care buton ma afecteaza
        switch (screens[randomColumn].GetPosition()) {
            case 0: {
                    dictionaryTitle = button_0.text;
                    break;

                }
            case 1:
                {
                    dictionaryTitle = button_1.text;
                    break;

                }
            case 2:
                {
                    dictionaryTitle = button_2.text;
                    break;

                }
            case 3:
                {
                    dictionaryTitle = button_3.text;
                    break;

                }
            case 4:
                {
                    dictionaryTitle = button_4.text;
                    break;

                }
            case 5:
                {
                    dictionaryTitle = button_5.text;
                    break;

                }
        }
    }

    void GenerateRandomButtons() {
        List<int> buttonsKeys = new List<int>();

        for (int i = 0; i < buttons.Count; i++) {
            buttonsKeys.Add(i);
        }

        int randomColumn = Random.Range(0, buttonsKeys.Count);
        // Iau textul si il afisez in interfata
        button_0.text = buttons[randomColumn].GetName();
        buttonsKeys.RemoveAt(randomColumn);

        randomColumn = Random.Range(0, buttonsKeys.Count);
        // Iau textul si il afisez in interfata
        button_1.text = buttons[buttonsKeys[randomColumn]].GetName();
        buttonsKeys.RemoveAt(randomColumn);

        randomColumn = Random.Range(0, buttonsKeys.Count);
        // Iau textul si il afisez in interfata
        button_2.text = buttons[buttonsKeys[randomColumn]].GetName();
        buttonsKeys.RemoveAt(randomColumn);

        randomColumn = Random.Range(0, buttonsKeys.Count);
        // Iau textul si il afisez in interfata
        button_3.text = buttons[buttonsKeys[randomColumn]].GetName();
        buttonsKeys.RemoveAt(randomColumn);

        randomColumn = Random.Range(0, buttonsKeys.Count);
        // Iau textul si il afisez in interfata
        button_4.text = buttons[buttonsKeys[randomColumn]].GetName();
        buttonsKeys.RemoveAt(randomColumn);

        randomColumn = Random.Range(0, buttonsKeys.Count);
        // Iau textul si il afisez in interfata
        button_5.text = buttons[buttonsKeys[randomColumn]].GetName();
        buttonsKeys.RemoveAt(randomColumn);
    }

    void GetCorrectWord() {
        string button_0_text = button_0.text;
        string button_1_text = button_1.text;
        string button_2_text = button_2.text;
        string button_3_text = button_3.text;
        string button_4_text = button_4.text;
        string button_5_text = button_5.text;

        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetName() == dictionaryTitle) {
                for (int j = 0; j < buttons[i].GetDictionary().Count; j++) {
                    if (buttons[i].GetDictionary()[j] == button_0_text)
                    {
                        solvedModule_buttonIndex = 0;
                        return;
                    }
                    else if (buttons[i].GetDictionary()[j] == button_1_text)
                    {
                        solvedModule_buttonIndex = 1;
                        return;
                    }
                    else if (buttons[i].GetDictionary()[j] == button_2_text)
                    {
                        solvedModule_buttonIndex = 2;
                        return;
                    }
                    else if (buttons[i].GetDictionary()[j] == button_3_text)
                    {
                        solvedModule_buttonIndex = 3;
                        return;
                    }
                    else if (buttons[i].GetDictionary()[j] == button_4_text)
                    {
                        solvedModule_buttonIndex = 4;
                        return;
                    }
                    else if (buttons[i].GetDictionary()[j] == button_5_text)
                    {
                        solvedModule_buttonIndex = 5;
                        return;
                    }
                }
            }
        }
    }

    // Use this for initialization
    void Start () {
        Init();
        GenerateRandomButtons();
        GenerateRandomScreen();
        GetCorrectWord();

        Debug.Log(solvedModule_buttonIndex);

        button_0.GetComponent<Button>().onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        //Output this to console when Button1 or Button3 is clicked
        Debug.Log("You have clicked the button!");
    }
	
	// Update is called once per frame
	void Update () {
	}
}
