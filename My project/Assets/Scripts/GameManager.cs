using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;
    private void Awake()
    {
        if(GameManager.Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
     
        SceneManager.sceneLoaded += LoadState;
        DontDestroyOnLoad(gameObject);
    }
    // Resources
    public List<Sprite> playerSprites;
    public List<Sprite> weaponSprites;
    public List<int> weaponPrices;
    public List<int> xpTable;

    // References
    public Player player;
    // public weapon

    // Logic
    public int money;
    public int experience;
    // Save State
    public void SaveState()
    {
        string s = "";
        s +="0" + "|";
        s +=money.ToString() + "|";
        s += experience.ToString() + "|";
        s +="0";

        PlayerPrefs.SetString("SaveState", s);
    }
    public void LoadState(Scene sc, LoadSceneMode mode)
    {
        
        if (!PlayerPrefs.HasKey("SaveState"))
            return;

        string[] data = PlayerPrefs.GetString("SaveState").Split('|');

        // Change player skin
        money = int.Parse(data[1]);
        experience = int.Parse(data[2]);
        // change the weapon level?


        Debug.Log("LoadState");
    }
}
