# Gaming-Data-Save-Container
How to Save Gaming Data in Binary Format with all Parameters: <br/> <br/>
Hey guys, so the code in Saveandload.cs is telling how to save RPG Gaming Data by using Serializing method 
and use binaryformate in system.io to output saving data file <br/>
if you have anthing want to add up, PLEASE LEAVE THE COMMENT! <br/>
Thank you<br/>

Example code : <br/>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class ToshiStartStatus
{
    public static int Level = 1;
    public static int ExpAmount = 0;
    public static int NextLevel = 50;
    public static int skillspoint = 0;
    public static int Statuspoint = 0;
    public static int Strength = 10;
    public static int Agility = 10;
    public static int Dexterity = 10;
    public static int Luck = 10;
    public static int Intelligence = 10;
    public static int Inspiration;
    public static int Vitality = 10;
    public static int Sprit = 10;
    public static int HitPoint;
    public static int Mana;
    public static int Attack;
    public static int Defense;
    public static int Resistance;
    public static int Magic;
    public static float CriticalRate;
    public static float EvasionRate;
    public static float AccuracyRate;
    public static int LightBeambaseDamage = 30;
    public string[] skillstype = { "Physical", "Magic" };

}

public class NeraStartStatus
{
    public static int Level;
    public static int ExpAmount;
    public static int NextLevel;
    public static int skillspoint;
    public static int Statuspoint;
    public static int Strength = 1;
    public static int Agility = 11;
    public static int Dexterity = 8;
    public static int Luck = 7;
    public static int Intelligence = 5;
    public static int affinity;
    public static int Vitality = 2;
    public static int Sprit = 8;
    public static int HitPoint = 70;
    public static int Mana = 60;
    public static int Attack = 25;
    public static int Defense = 8;
    public static int Resistance = 21;
    public static int Magic = 30;
    public static float CriticalRate = 0.01f;
    public static float EvasionRate = 0.07f;
    public static float AccuracyRate;
    public static int GunShotDamage = 28;
    public string[] skillstype = { "Agile", "Healing" };

}

public class SLIO
{
    public static List<float> SLdata = new List<float>();
    public static List<string> SLdata1 = new List<string>();

    public static void GameSaving(int Filenumber)
    {
        SLdata.Clear();
        SLdata1.Clear();
        for (int q = 1; q < 4; q++)
        {
            System.Type ty = System.Type.GetType("container" + q.ToString());
            Vector3 s = (Vector3)ty.GetField("playerposition").GetValue(null);

            if (q < 3)
            {
                SLdata.Add((int)ty.GetField("int0").GetValue(null));
                SLdata.Add((int)ty.GetField("int1").GetValue(null));
                SLdata.Add((int)ty.GetField("int2").GetValue(null));
                SLdata.Add((int)ty.GetField("int3").GetValue(null));
                SLdata.Add((int)ty.GetField("int4").GetValue(null));
                SLdata.Add((int)ty.GetField("int5").GetValue(null));
                SLdata.Add((int)ty.GetField("int6").GetValue(null));
                SLdata.Add((int)ty.GetField("int7").GetValue(null));
                SLdata.Add((int)ty.GetField("int8").GetValue(null));
                SLdata.Add((int)ty.GetField("int9").GetValue(null));
                SLdata.Add((int)ty.GetField("int10").GetValue(null));
                SLdata.Add((int)ty.GetField("int11").GetValue(null));
                SLdata.Add((int)ty.GetField("int12").GetValue(null));
                SLdata.Add((int)ty.GetField("int13").GetValue(null));
                SLdata.Add((int)ty.GetField("int14").GetValue(null));
                SLdata.Add((int)ty.GetField("int15").GetValue(null));
            }
            SLdata.Add(s.x);//16*Q +3*Q-1
            SLdata.Add(s.y);//17*Q +2*Q-1
            SLdata.Add(s.z);//18*Q +1*Q-1
        }

        for (int y = 1; y < 100; y++) {
            SLdata.Add(container4.conversationvalue[y]);// start with 41
            if(container4.conversationvalue[y] == 0)
            {
                break;
            }
        }

        SLdata1.Add(container4.Time);
        SLdata1.Add(container4.location);
        SLdata1.Add(container4.Toshi);
        if(container4.Nera != null) { SLdata1.Add(container4.Nera); }

        //for (int s = 0; s < SLdata.Count; s++)
        //{ Debug.Log(SLdata[s]); }
        //for (int x = 0; x < SLdata1.Count; x++)
       // { Debug.Log(SLdata1[x]); }

        FileStream SavingCreation = File.Create(Application.persistentDataPath + "/Saving" + Filenumber + ".dat");
        FileInfo savefileinfo = new FileInfo(Application.persistentDataPath + "/Saving" + Filenumber + ".dat");
        if (savefileinfo.Length == 0)
        {
            BinaryFormatter Bicode = new BinaryFormatter();
            Bicode.Serialize(SavingCreation, SLdata);
            Bicode.Serialize(SavingCreation, SLdata1);
        }

        SavingCreation.Close();
    }

    public static void LoadingGame(int Filenumber)
    {
        if (File.Exists(Application.persistentDataPath + "/Saving" + Filenumber + ".dat"))
        {
            BinaryFormatter Bicode = new BinaryFormatter();
            FileStream Loadfile = File.Open(Application.persistentDataPath + "/Saving" + Filenumber + ".dat", FileMode.Open);


            SLdata = (List<float>)Bicode.Deserialize(Loadfile); 
            SLdata1 = (List<string>)Bicode.Deserialize(Loadfile);
            //Debug.Log(SLdata.Count);
            //for (int s = 0; s < SLdata.Count; s++)
            //{ Debug.Log(SLdata[s]); }
            //for (int x = 0; x < SLdata1.Count; x++)
           // { Debug.Log(SLdata1[x]); }

            for (int q = 1; q < 3; q++)
            {
                System.Type ty = System.Type.GetType("container" + q.ToString());
                ty.GetField("int0").SetValue(null,(int)SLdata[0+19*(q-1)]);
                ty.GetField("int1").SetValue(null, (int)SLdata[1 + 19 * (q - 1)]);
                ty.GetField("int2").SetValue(null, (int)SLdata[2 + 19 * (q - 1)]);
                ty.GetField("int3").SetValue(null, (int)SLdata[3 + 19 * (q - 1)]);
                ty.GetField("int4").SetValue(null, (int)SLdata[4 + 19 * (q - 1)]);
                ty.GetField("int5").SetValue(null, (int)SLdata[5 + 19 * (q - 1)]);
                ty.GetField("int6").SetValue(null, (int)SLdata[6 + 19 * (q - 1)]);
                ty.GetField("int7").SetValue(null, (int)SLdata[7 + 19 * (q - 1)]);
                ty.GetField("int8").SetValue(null, (int)SLdata[8 + 19 * (q - 1)]);
                ty.GetField("int9").SetValue(null, (int)SLdata[9 + 19 * (q - 1)]);
                ty.GetField("int10").SetValue(null, (int)SLdata[10 + 19 * (q - 1)]);
                ty.GetField("int11").SetValue(null, (int)SLdata[11 + 19 * (q - 1)]);
                ty.GetField("int12").SetValue(null, (int)SLdata[12 + 19 * (q - 1)]);
                ty.GetField("int13").SetValue(null, (int)SLdata[13 + 19 * (q - 1)]);
                ty.GetField("int14").SetValue(null, (int)SLdata[14 + 19 * (q - 1)]);
                ty.GetField("int15").SetValue(null, (int)SLdata[15 + 19 * (q - 1)]);
            }

            container1.playerposition= new Vector3(
                      SLdata[16],
                       SLdata[17],
                       SLdata[18]);

            container2.playerposition = new Vector3(
                      SLdata[16*2+3],
                       SLdata[17*2+2],
                       SLdata[18*2+1]);

            container3.playerposition = new Vector3(
                      SLdata[38],
                       SLdata[39],
                       SLdata[40]);

            for (int a = 1; a < 100; a++) {
                container4.conversationvalue[a] = (int) SLdata[40 + a];
                if((int)SLdata[40 + a] == 0)
                {
                    break;
                }
            }

            container4.Time = SLdata1[0];
            container4.location = SLdata1[1];
            container4.Toshi = SLdata1[2];
            if (container4.Nera != null) { container4.Nera = SLdata1[3]; }

            Loadfile.Close();
        }
    }
}

[System.Serializable]
public class container1 //toshi
{
    public static Vector3 playerposition;
    public static int int0; //playerskillpoint;
    public static int int1; //playerstatuspoint;
    public static int int2;//playercurrentexp;
    public static int int3;//playerexpcap;
    public static int int4;//playerlevel;
    public static int int5;//Toshi's option amount for knowing himselef better - affecting true ending
    public static int int6 =10;//playerstrength;
    public static int int7 =10;//playeragility;
    public static int int8=10;//playerdexterity;
    public static int int9=10;//playerluck;
    public static int int10=10;//playerintelligence;
    public static int int11;//playerinsipiration;
    public static int int12=10;//playervitality;
    public static int int13=10;//playersprite;
    public static int int14 = 160;// playerHP;
    public static int int15 = 50;//playerMana;
    public static int[] Skillset = new int[35]; //0=>means didn't learnt the skill, 1 means learnt the skill
    public static int[] Weaponskillenforcement = new int[35]; //0=>means didn't enhance the weaponslot, 1 means enhanced
}

[System.Serializable]
public class container2 //Nera
{
    public static Vector3 playerposition;
    public static int int0; //playerskillpoint;
    public static int int1; //playerstatuspoint;
    public static int int2;//playercurrentexp;
    public static int int3;//playerexpcap;
    public static int int4;//playerlevel;
    public static int int5;//Nera's Affinity Level - affecting true ending
    public static int int6 = 1;//playerstrength;
    public static int int7 =11;//playeragility;
    public static int int8 = 8;//playerdexterity;
    public static int int9 = 7;//playerluck;
    public static int int10 = 5;//playerintelligence;
    public static int int11;//playerdivinity;
    public static int int12 =2;//playervitality;
    public static int int13=8;//playersprite;
    public static int int14;// playerHP;
    public static int int15;//playerMana;
    public static int[] Skillset = new int[35]; //0=>means didn't learnt the skill, 1 means learnt the skill
    public static int[] Weaponskillenforcement = new int[35]; //0=>means didn't enhance the weaponslot, 1 means enhanced
}

[System.Serializable]
public class container3 //balder
{
    public static Vector3 playerposition;
}

[System.Serializable]
public class container4 //Tasks, Time, Location
{
    public static string Time;
    public static string location;
    public static string Toshi;
    public static string Nera;

    public static int[] TasksProgress = new int[35]; 
    public static int[] conversationvalue = new int[100];
}

[System.Serializable]
public class container5//Inventory
{
    public static int[] itemnumber = new int[100];
    public static int[] itemID = new int[100];
}

public class GlowingMagic : MonoBehaviour {

    private Vector3 StatusOption;
    private Vector3 SystemOption;
    public static int i;
    public static int t;
    private GameObject optionobject1;
    private GameObject optionobject2;
    private GameObject optionobject3;
    public static GameObject option1;
    public static GameObject option2;
    public static GameObject option3;
    private GameObject uicursor;
    private GameObject GamingUI;
    private GameObject Toshi;
    //private GameObject balder;
    private GameObject UIselection;
    private GameObject SubMenuSelect;

    public static GameObject savemenu;
    private GameObject SaveSlot1;
    private GameObject SaveSlot2;
    private GameObject SaveSlot3;
    private GameObject SaveSlot4;
    private GameObject SaveSlot5;
    private GameObject SaveSlot6;
    private GameObject SaveSlot7;

    public static int SLSelectionCaseNumber;
    public static bool enableSLmenu;

    public static Scene CurrentScene;

    void Awake()
    {
        optionobject1 = GameObject.Find("Tilte1");
        optionobject2 = GameObject.Find("ChildTilte-1");
        optionobject3 = GameObject.Find("ChildTilte-2");
        option1 = GameObject.Find("option1");
        option2 = GameObject.Find("option2");
        option3 = GameObject.Find("option3");
        uicursor = GameObject.Find("Selection-UI");
        GamingUI = GameObject.Find("Menu-GamingUI");
        //balder = GameObject.Find("ConversationObj2");
        UIselection = GameObject.Find("Selection-UI");
        savemenu = GameObject.Find("SaveMenu");
        SaveSlot1 = GameObject.Find("SaveSlot1");
        SaveSlot2 = GameObject.Find("SaveSlot2");
        SaveSlot3 = GameObject.Find("SaveSlot3");
        SaveSlot4 = GameObject.Find("SaveSlot4");
        SaveSlot5 = GameObject.Find("SaveSlot5");
        SaveSlot6 = GameObject.Find("SaveSlot6");
        SaveSlot7 = GameObject.Find("SaveSlot7");
        Toshi = GameObject.Find("Toshi");
        SubMenuSelect = GameObject.Find("SubMenuSelection");
    }

    // Use this for initialization
    void Start () {
        SystemOption = new Vector3(-287f, -40f, 0);
        StatusOption = new Vector3(-421f, 147f, 0);
        t = 1;
        i = 1;
    }
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(Application.persistentDataPath);
        //Debug.Log(SLIO.SLmethodinteger.Capacity);
        //Debug.Log(container1.playerposition);
        //Debug.Log(SubMenuSelection.loaded);
       // Debug.Log(t);
        if (UIActivation.i == 1)
        {
            option1.GetComponent<Animator>().SetBool("Open", true);
            option2.GetComponent<Animator>().SetBool("Open", true);
            if (optionobject3.GetComponent<TextMeshProUGUI>().text == "")
            {
                option3.GetComponent<Animator>().SetBool("Open", false);
            }
            else
            {
                option3.GetComponent<Animator>().SetBool("Open", true);
            }

            if (option1.transform.localPosition.x == 391f)
            {
                UIselection.GetComponent<RawImage>().color = new Color32(255,255,255,255);
                UIselection.GetComponent<Animator>().enabled = true;
            }
            else {
                UIselection.GetComponent<RawImage>().color = new Color32(255, 255, 255, 0);
                UIselection.GetComponent<Animator>().enabled = false;
            }

            if (GamingUI.GetComponent<Canvas>().enabled == true)
            {

                if (enableSLmenu == false && StatusMenu.StatusTile.GetComponent<Text>().enabled == false)
                {
                    if (Input.GetKeyDown("a"))
                    {
                        i -= 1;
                        if (i < 1) { i = 1; }
                        t = 1;
                    }
                    if (Input.GetKeyDown("d"))
                    {
                        i += 1;
                        if (i > 2) { i = 2; }
                        t = 1;
                    }

                    if (Input.GetKeyDown("w"))
                    {
                        t -= 1;
                        if (t < 1) { t = 1; }  
                    }
                    if (Input.GetKeyDown("s"))
                    {
                        //t += 1;
                        if (optionobject3.GetComponent<TextMeshProUGUI>().text != "")
                        {
                            t += 1;
                            if (t > 2) { t = 2; }
                        }
                        else
                        {
                            t = 1;
                        }
                    }
                }
            }
            else if (UIActivation.i == 0)
            {
                option1.GetComponent<Animator>().SetBool("Open", false);
                option2.GetComponent<Animator>().SetBool("Open", false);
                option3.GetComponent<Animator>().SetBool("Open", false);
            }

            switch (i)
            {
                case 1:
                    gameObject.GetComponent<RectTransform>().localPosition = StatusOption;
                    optionobject1.GetComponent<TextMeshProUGUI>().text = "Status";
                    optionobject2.GetComponent<TextMeshProUGUI>().text = "Toshi";
                    if (GameObject.Find("Nera") == null)
                    { optionobject3.GetComponent<TextMeshProUGUI>().text = ""; }
                    else
                    { optionobject3.GetComponent<TextMeshProUGUI>().text = "Nera"; }
                    option1.GetComponent<Animator>().SetBool("Cycle", false);
                    option2.GetComponent<Animator>().SetBool("Cycle", false);
                    if (optionobject3.GetComponent<TextMeshProUGUI>().text == "")
                    { option3.GetComponent<Animator>().SetBool("NoOption", true); }
                    else
                    {
                        option3.GetComponent<Animator>().SetBool("Cycle", false);
                        option3.GetComponent<Animator>().SetBool("NoOption", false);
                    }
                    break;
                case 2:
                    gameObject.GetComponent<RectTransform>().localPosition = SystemOption;
                    optionobject1.GetComponent<TextMeshProUGUI>().text = "System";
                    optionobject2.GetComponent<TextMeshProUGUI>().text = "Save";
                    optionobject3.GetComponent<TextMeshProUGUI>().text = "Load";
                    option1.GetComponent<Animator>().SetBool("Cycle", true);
                    option2.GetComponent<Animator>().SetBool("Cycle", true);
                    if (GameObject.Find("Nera") == null)
                    {
                        option3.GetComponent<Animator>().SetBool("Cycle", false);
                        option3.GetComponent<Animator>().SetBool("NoOption", false);
                    }
                    else
                    {
                        option3.GetComponent<Animator>().SetBool("Cycle", true);
                        option3.GetComponent<Animator>().SetBool("NoOption", false);
                    }
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

            switch (t)
            {
                case 1:
                    uicursor.transform.localPosition = option2.transform.localPosition;
                    if (i==2)
                    {
                        if (SubMenuSelect.transform.localPosition.y == 200f|
                            SubMenuSelect.transform.localPosition.y == 120f|
                            SubMenuSelect.transform.localPosition.y == 40f|
                            SubMenuSelect.transform.localPosition.y == -40f|
                            SubMenuSelect.transform.localPosition.y == -120f|
                            SubMenuSelect.transform.localPosition.y == -200f|
                             SubMenuSelect.transform.localPosition.y == -280f)
                        {
                            if (savemenu.transform.localPosition.y == 280f)
                            {
                                if (Input.GetKeyDown("return"))
                                {
                                    container1.int2 = ToshiStartStatus.ExpAmount;//Toshi's current exp, 0=>current exp
                                    container1.int3 = ToshiStartStatus.NextLevel;//Toshi's nextlevelcap, 4 => Next Level
                                    container1.int4 = ToshiStartStatus.Level;//Toshi's curret level, 3=>curret level
                                    container1.int0 = ToshiStartStatus.skillspoint;//Toshi's curret skill points, 1=> skill points
                                    container1.int1 = ToshiStartStatus.Statuspoint;//Toshi's current status points, 2=> status points
                                    container1.playerposition = Toshi.transform.position;

                                    //toshiStatus
                                    container1.int6 = ToshiStartStatus.Strength;
                                    container1.int7 = ToshiStartStatus.Agility;
                                    container1.int8 = ToshiStartStatus.Dexterity;
                                    container1.int9 = ToshiStartStatus.Luck;
                                    container1.int10 = ToshiStartStatus.Intelligence;
                                    container1.int11 = ToshiStartStatus.Inspiration;
                                    container1.int12 = ToshiStartStatus.Vitality;
                                    container1.int13 = ToshiStartStatus.Sprit;
                                    container1.int14 = ToshiStartStatus.HitPoint;
                                    container1.int15 = ToshiStartStatus.Mana;

                                    container4.conversationvalue[1] = Scene1.i;//openscene
                                    container4.conversationvalue[2] = Scene2.i;//meetbalder

                                    //savingfileinfo
                                    container4.Toshi = "Toshi";
                                    if (GameObject.Find("Nera") == null)
                                    { container4.Nera = "Nera"; }
                                    container4.Time = System.DateTime.Now.TimeOfDay.ToString();
                                    container4.location = SceneManager.GetActiveScene().name;

                                    //Characters Position
                                    if (GameObject.Find("Nera") == null) { }
                                    else
                                    { container2.playerposition = GameObject.Find("Nera").transform.position; }
                                    if (GameObject.Find("ConversationObj2") == null) { }
                                    else
                                    { container3.playerposition = GameObject.Find("ConversationObj2").transform.position; }
                                    SLIO.GameSaving(SLSelectionCaseNumber);
                                }
                            }
                            
                        }

                        if (enableSLmenu == false)
                        {
                            if (Input.GetKeyDown("return"))
                            {
                                option1.GetComponent<Animator>().SetBool("NewMenu2", true);
                                option2.GetComponent<Animator>().SetBool("NewMenu2", true);
                                option3.GetComponent<Animator>().SetBool("NewMenu", true);
                                savemenu.GetComponent<Animator>().SetBool("ShowTitle", true);
                                SaveSlot1.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot2.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot3.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot4.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot5.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot6.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot7.GetComponent<Animator>().SetBool("GETIN", true);
                                SLSelectionCaseNumber = 1;
                                enableSLmenu = true;
                            }
                        }

                        if (Input.GetKeyDown("escape"))
                        {
                            option1.GetComponent<Animator>().SetBool("NewMenu2", false);
                            option2.GetComponent<Animator>().SetBool("NewMenu2", false);
                            option3.GetComponent<Animator>().SetBool("NewMenu", false);
                            savemenu.GetComponent<Animator>().SetBool("ShowTitle", false);
                            SaveSlot1.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot2.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot3.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot4.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot5.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot6.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot7.GetComponent<Animator>().SetBool("GETIN", false);
                            SLSelectionCaseNumber = 8;
                            SubMenuSelect.GetComponent<RawImage>().color = new Color32(255, 255, 255, 0);
                            enableSLmenu = false;
                        }
                    }
                        break;

                case 2:
                    if (option3.GetComponent<RawImage>().color == new Color32(255, 255, 255, 255))
                    { uicursor.transform.localPosition = option3.transform.localPosition; }
                    if (i==2)
                    {

                        if (SubMenuSelect.transform.localPosition.y == 200f |
                            SubMenuSelect.transform.localPosition.y == 120f |
                            SubMenuSelect.transform.localPosition.y == 40f |
                            SubMenuSelect.transform.localPosition.y == -40f |
                            SubMenuSelect.transform.localPosition.y == -120f |
                            SubMenuSelect.transform.localPosition.y == -200f |
                             SubMenuSelect.transform.localPosition.y == -280f)
                        {
                            if (savemenu.transform.localPosition.y == 280f)
                            {
                                if (Input.GetKeyDown("return"))
                                {
                                    SLIO.LoadingGame(SLSelectionCaseNumber);
                                    Toshi.transform.position = container1.playerposition;
                                    ToshiStartStatus.ExpAmount = container1.int2; //Toshi's current exp, 0=>current exp
                                    ToshiStartStatus.NextLevel = container1.int3;//Toshi's nextlevelcap, 4 => Next Level
                                    ToshiStartStatus.Level = container1.int4;//Toshi's curret level, 3=>curret level
                                    ToshiStartStatus.skillspoint = container1.int0;//Toshi's curret skill points, 1=> skill points
                                    ToshiStartStatus.Statuspoint = container1.int1;//Toshi's current status points, 2=> status points

                                    //toshiStatus
                                    ToshiStartStatus.Strength = container1.int6;
                                    ToshiStartStatus.Agility = container1.int7;
                                    ToshiStartStatus.Dexterity = container1.int8;
                                    ToshiStartStatus.Luck =container1.int9 ;
                                    ToshiStartStatus.Intelligence = container1.int10;
                                    ToshiStartStatus.Inspiration = container1.int11;
                                    ToshiStartStatus.Vitality = container1.int12;
                                    ToshiStartStatus.Sprit = container1.int13;
                                    ToshiStartStatus.HitPoint = container1.int14;
                                    ToshiStartStatus.Mana = container1.int15;

                                    if (GameObject.Find("Nera") == null) { }
                                    else
                                    { GameObject.Find("Nera").transform.position = container2.playerposition; }
                                    if (GameObject.Find("ConversationObj2") == null) { }
                                    else
                                    { GameObject.Find("ConversationObj2").transform.position = container3.playerposition; }

                                    Scene1.i = container4.conversationvalue[1];//openscene
                                    Scene2.i = container4.conversationvalue[2];//meetbalder

                                    if (container4.conversationvalue[t] == 1)
                                    {
                                        if (GameObject.Find("ConversationObj" + t.ToString()) == null) { }
                                        else
                                        {
                                            Destroy(GameObject.Find("ConversationObj" + t.ToString()));
                                            Instantiate(Resources.Load("ConversationPref/ConversationObj" + t.ToString()) as GameObject);
                                        }
                                    }
                                }
                            }
                        }

                        if (enableSLmenu == false)
                        {
                            if (Input.GetKeyDown("return"))
                            {
                                option1.GetComponent<Animator>().SetBool("NewMenu2", true);
                                option2.GetComponent<Animator>().SetBool("NewMenu2", true);
                                option3.GetComponent<Animator>().SetBool("NewMenu", true);
                                savemenu.GetComponent<Animator>().SetBool("ShowTitle", true);
                                SaveSlot1.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot2.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot3.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot4.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot5.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot6.GetComponent<Animator>().SetBool("GETIN", true);
                                SaveSlot7.GetComponent<Animator>().SetBool("GETIN", true);
                                SLSelectionCaseNumber = 1;
                                enableSLmenu = true;
                            }
                        }

                        if (Input.GetKeyDown("escape"))
                        {
                            option1.GetComponent<Animator>().SetBool("NewMenu2", false);
                            option2.GetComponent<Animator>().SetBool("NewMenu2", false);
                            //option1.GetComponent<Animator>().SetBool("NewMenu", false);
                            //option2.GetComponent<Animator>().SetBool("NewMenu", false);
                            option3.GetComponent<Animator>().SetBool("NewMenu", false);
                            savemenu.GetComponent<Animator>().SetBool("ShowTitle", false);
                            SaveSlot1.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot2.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot3.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot4.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot5.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot6.GetComponent<Animator>().SetBool("GETIN", false);
                            SaveSlot7.GetComponent<Animator>().SetBool("GETIN", false);
                            SLSelectionCaseNumber = 8;
                            SubMenuSelect.GetComponent<RawImage>().color = new Color32(255, 255, 255, 0);
                            enableSLmenu = false;
                        }
                    }
                    break;
                case 3:
                    break;
            }

            gameObject.transform.eulerAngles += new Vector3(0, 0, 30f * Time.deltaTime);
        }
	}
}
