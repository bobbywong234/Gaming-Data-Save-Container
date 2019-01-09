using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SaveandLoad
{
    public static List<float> SLdata = new List<float>();
    public static List<string> SLdata1 = new List<string>();

    public static void GameSaving(int Filenumber)
    {
        //clear list first, so make sure list can be renewed
        SLdata.Clear();
        SLdata1.Clear();

        //SLdata is list record int and float in the gaming runtime
        //SLdata and SLdata1 will record in a tree-base structure
        //from the first line list.add to lastline.add in functions
        //e.g. SLdata.Add(playercontainer1.int0); will record data into sldata[0]
                SLdata.Add(playercontainer1.int0);
                SLdata.Add(playercontainer1.int1);
                SLdata.Add(playercontainer1.int2);
                SLdata.Add(playercontainer1.int3);
                SLdata.Add(playercontainer1.int4);
                SLdata.Add(playercontainer1.int5);
                SLdata.Add(playercontainer1.int6);
                SLdata.Add(playercontainer1.int7);
                SLdata.Add(playercontainer1.int8);
                SLdata.Add(playercontainer1.int9);
                SLdata.Add(playercontainer1.int10);
                SLdata.Add(playercontainer1.int11);
                SLdata.Add(playercontainer1.int12);
                SLdata.Add(playercontainer1.int13);
              
            
            SLdata.Add(playercontainer1.playerposition.x);
            SLdata.Add(playercontainer1.playerposition.y);
            SLdata.Add(playercontainer1.playerposition.z);

        SLdata1.Add(playercontainer1.time);
        SLdata1.Add(playercontainer1.scenename);
        SLdata1.Add(playercontainer1.player1name);

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

        //check if saving file exist, if yes load data
        if (File.Exists(Application.persistentDataPath + "/Saving" + Filenumber + ".dat"))
        {
            BinaryFormatter Bicode = new BinaryFormatter();
            FileStream Loadfile = File.Open(Application.persistentDataPath + "/Saving" + Filenumber + ".dat", FileMode.Open);


            SLdata = (List<float>)Bicode.Deserialize(Loadfile);
            SLdata1 = (List<string>)Bicode.Deserialize(Loadfile);

            playercontainer1.int0 = (int)SLdata[0];
            playercontainer1.int1 = (int)SLdata[1];
            playercontainer1.int2 = (int)SLdata[2];
            playercontainer1.int3 = (int)SLdata[3];
            playercontainer1.int4 = (int)SLdata[4];
            playercontainer1.int5 = (int)SLdata[5];
            playercontainer1.int6 = (int)SLdata[6];
            playercontainer1.int7 = (int)SLdata[7];
            playercontainer1.int8 = (int)SLdata[8];
            playercontainer1.int9 = (int)SLdata[9];
            playercontainer1.int10 = (int)SLdata[10];
            playercontainer1.int11 = (int)SLdata[11];
            playercontainer1.int12 = (int)SLdata[12];
            playercontainer1.int13 = (int)SLdata[13];

            playercontainer1.playerposition.x = SLdata[14];
            playercontainer1.playerposition.y = SLdata[15];
            playercontainer1.playerposition.z = SLdata[16];


            playercontainer1.time = SLdata1[0];
            playercontainer1.scenename = SLdata1[1];
            playercontainer1.player1name = SLdata1[2];


            Loadfile.Close();
        }
    }
}

public class Player1
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
    public static int Vitality = 10;
    public static int Sprit = 10;
    public static int HitPoint; //MaxHealth
    public static int Mana; //MaxMana
    public static int Attack;
    public static int Defense;
    public static int Resistance;
    public static int Magic;
    public static float CriticalRate;
    public static float EvasionRate;
    public static float AccuracyRate;

}

public class playercontainer1 
{
    public static Vector3 playerposition;
    public static string player1name;
    public static string time;
    public static string scenename;
    public static int int0; //playerskillpoint;
    public static int int1; //playerstatuspoint;
    public static int int2;//playercurrentexp;
    public static int int3;//playerexpcap;
    public static int int4;//playercurrentlevel;
    public static int int5 = 10;//playerstrength;
    public static int int6 = 10;//playeragility;
    public static int int7 = 10;//playerdexterity;
    public static int int8 = 10;//playerluck;
    public static int int9 = 10;//playerintelligence;
    public static int int10 = 10;//playervitality;
    public static int int11 = 10;//playersprite;
    public static int int12 = 160;// playerHP;
    public static int int13 = 50;//playerMana;
}

public class NewBehaviourScript : MonoBehaviour {

    private GameObject savemenu;
    private GameObject cursor;
    private GameObject savemenuoption1;
    private GameObject loadmenuoption1;
    private GameObject loadmenu;
    private int saveandloadselectioncasenumber;

	// Use this for initialization
	void Start () {
        //gameobject find will find the gameobject name in unity
        //gameobject name could not be the same with the members name in here
        savemenu = GameObject.Find("savemenu");
        cursor = GameObject.Find("cursor");
        savemenuoption1 = GameObject.Find("savemenuoption1");
        loadmenu = GameObject.Find("loadmenu");
        loadmenuoption1 = GameObject.Find("loadmenuoption1");
	}

    // Update is called once per frame
    void Update()
    {

        //initial player's ability

        //MaxHealth
        Player1.HitPoint = 100;
        //This player1's MaxHP you can add formula here based on vitality and player's level.
        //Please make sure hitpoint is over 160, which is int13 in playercontainer1
        //int13 is the characters actual hitpoint. 
        //you can change members name in each class if you like.

        //MaxMana
        //add formula here

        //Defenseup
        //add formula here

        //Attackup
        //add formula here

        //Resistanceup
        //add formula here

        //MagicAttack
        //add formula here

        //Accuracy Rate
        //add formula here

        //CR
        //add formula here

        //ER 
        //add formula here

        //instatiate savemenu
        //make sure all needed child object is in the savemenu when you make it as prefe
        //Canvas could be you main menu
        //Resources.load will load prefe in Resources folder
        //make sure you created Resources folder in Asset folder when you execute this code
        //this selection functionality can be applied for keyboard input and controller input
        //the code below is focuse on keyboard input

        if (Input.GetKeyDown("w"))
        {
            saveandloadselectioncasenumber -= 1;
            if (saveandloadselectioncasenumber < 0)
            {
                saveandloadselectioncasenumber = 0;
            }
        }
        if (Input.GetKeyDown("s"))
        {
            saveandloadselectioncasenumber += 1;
            if (saveandloadselectioncasenumber > 1)
            {
                saveandloadselectioncasenumber = 1;
            }
        }

        switch (saveandloadselectioncasenumber)
        {
            case 0: //save functionility
                if (Input.GetKeyDown("return"))
                {

                    GameObject save = Instantiate(Resources.Load("savemenu"), GameObject.Find("Canvas").transform) as GameObject;
                    save.name = "savemenu";//makesure there are no (clone) inculded in gameobject's name
                    savemenu = GameObject.Find("savemenu");
                    cursor.transform.localPosition = savemenuoption1.transform.localPosition;
                }

                break;

            case 1:
                if (Input.GetKeyDown("return"))
                {

                    GameObject load = Instantiate(Resources.Load("loadmenu"), GameObject.Find("Canvas").transform) as GameObject;
                    load.name = "loadmenu";//makesure there are no (clone) inculded in gameobject's name
                    loadmenu = GameObject.Find("loadmenu");
                    cursor.transform.localPosition = loadmenuoption1.transform.localPosition;
                }
                break;
        }



        //check whether savemenu has been instatiate and whether cursor is on the samemenuoption1 localposition

        if (savemenu != null && cursor.transform.localPosition == savemenuoption1.transform.localPosition)
        {
            if (Input.GetKeyDown("return"))
            {
                playercontainer1.int2 = Player1.ExpAmount;//Toshi's current exp, 0=>current exp
                playercontainer1.int3 = Player1.NextLevel;//Toshi's nextlevelcap, 4 => Next Level
                playercontainer1.int4 = Player1.Level;//Toshi's curret level, 3=>curret level
                playercontainer1.int0 = Player1.skillspoint;//Toshi's curret skill points, 1=> skill points
                playercontainer1.int1 = Player1.Statuspoint;//Toshi's current status points, 2=> status points

                //toshiStatus
                playercontainer1.int5 = Player1.Strength;
                playercontainer1.int6 = Player1.Agility;
                playercontainer1.int7 = Player1.Dexterity;
                playercontainer1.int8 = Player1.Luck;
                playercontainer1.int9 = Player1.Intelligence;
                playercontainer1.int10 = Player1.Vitality;
                playercontainer1.int11 = Player1.Sprit;
                playercontainer1.int12 = ToshiStartStatus.HitPoint;
                playercontainer1.int13 = ToshiStartStatus.Mana;


                //savingfileinfo
                //this savinginfo can used for display savefile info on savemenuoption1's child object
                //especially in text component 
                //this file info can be applied to text component in OnEnable method when savemenu instatiated
                playercontainer1.player1name = "Player1";
                playercontainer1.time = System.DateTime.Now.TimeOfDay.ToString();
                playercontainer1.scenename = SceneManager.GetActiveScene().name;

                //Characters Position
                if (GameObject.Find("Player1") == null) { }
                else
                { playercontainer1.playerposition = GameObject.Find("player").transform.position; }

                SLIO.GameSaving(1); // 1 in here represent savinfile number
            }

            if (Input.GetKeyDown("escape")) { Destroy(savemenu); }
        }

        if (loadmenu != null && cursor.transform.localPosition == loadmenuoption1.transform.localPosition)
        {
            if (Input.GetKeyDown("return"))
            {
                Player1.ExpAmount = playercontainer1.int2; //Toshi's current exp, 0=>current exp
                Player1.NextLevel =playercontainer1.int3;//Toshi's nextlevelcap, 4 => Next Level
                Player1.Level =playercontainer1.int4 ;//Toshi's curret level, 3=>curret level
                Player1.skillspoint =playercontainer1.int0 ;//Toshi's curret skill points, 1=> skill points
                Player1.Statuspoint =playercontainer1.int1 ;//Toshi's current status points, 2=> status points

                //toshiStatus
                Player1.Strength =playercontainer1.int5 ;
                Player1.Agility =playercontainer1.int6 ;
                Player1.Dexterity =playercontainer1.int7 ;
                Player1.Luck =playercontainer1.int8 ;
                Player1.Intelligence =playercontainer1.int9 ;
                Player1.Vitality =playercontainer1.int10 ;
                Player1.Sprit =playercontainer1.int11 ;
                ToshiStartStatus.HitPoint =playercontainer1.int12 ;
                ToshiStartStatus.Mana =playercontainer1.int13 ;

                //Characters Position
                if (GameObject.Find("Player1") == null) { }
                else
                { GameObject.Find("player").transform.position = playercontainer1.playerposition; }

                SLIO.LoadingGame(1); // 1 in here represent savinfile number
                Destroy(loadmenu);
            }
        }
    }
}
