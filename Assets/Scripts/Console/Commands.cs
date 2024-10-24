using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import the TextMeshPro namespace
 

//passing command
//dd
public class Commands : MonoBehaviour
{
    public GameObject console;
    public TMP_InputField inputField; // Reference to the TextMeshPro Input Field
    bool flag = false;
    public Rigidbody2D playerRb;
    float default_number = 1;
    public Rigidbody2D tileRb;
    public GameObject tile;
    
    void Awake()
    {
        //inputField = console.GetComponent<TMP_InputField>();
        console.SetActive(false);
    }

    void Start()
    {
        tile = GameObject.FindGameObjectWithTag("Floor");
        tileRb = tile.GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        show();
        if (Input.GetKeyDown(KeyCode.Return))
        {
            
            Debug.Log(inputField.text);
            //FlyingRocksEvents otherScript = new FlyingRocksEvents();
            FlyingRocksEvents.cur_command = inputField.text;
            //ss
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {

            Debug.Log(inputField.text);
            /*FlyingRocksEvents otherScript = new FlyingRocksEvents();
            otherScript.ExecuteCommandOnsite(inputField.text);*/

            //ss
            ExecuteCommandOnsite(inputField.text);
        }
        
    }

    void show()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            flag = !flag; // Toggle the flag
            console.SetActive(flag); // Set the GameObject's active state based on the flag
        }
    }


    public void ExecuteCommandOnsite(string command)
    {
        string[] commandWords = command.ToLower().Split(' ');

        if (commandWords.Length == 0)
        {
            Debug.Log("Empty command.");
            return;
        }
        string firstWord = commandWords[0];
        string newcommand = "";
        string currentNumber = "";
        foreach (char c in firstWord)
        {
            if (char.IsDigit(c) || (c == '.') || (c == '-'))
            {
                currentNumber += c;
            }
            else
            {
                newcommand += c;
            }
        }
        if (currentNumber.Length > 0) default_number = float.Parse(currentNumber);

        Debug.Log(newcommand + " ammayi" + default_number + firstWord.ToLower());
        switch (newcommand.ToLower())
        {
            case "mypull":
                Debug.Log(default_number);
                playerRb.gravityScale = 1;
                default_number = 1;
                break;
            case "pull":
                Debug.Log(default_number);
                Physics2D.gravity = new Vector2(0f, default_number);
                default_number = 1;
                break;
            default:
                Debug.Log("Unknown command: " + newcommand);
                break;
        }
    }
    

}
