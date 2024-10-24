using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingRocksEvents : MonoBehaviour
{
    public static string cur_command = "";
    public Rigidbody2D tileRb;
    public GameObject tile;
    public bool flag = false;
    //mmm

    [Header("default_number")]
    public float default_number = 1;   

    void Start()
    {
        tile = GameObject.FindGameObjectWithTag("Floor");
        tileRb = tile.GetComponent<Rigidbody2D>();
        

    }

    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Keypad1)) { 
            flag = !flag; 

        }
        
    }
    private void OnMouseDown()
    {
        if ( flag == true)
        {
            ExecuteCommandOnSpecified(cur_command);
        }
    }
    


     public void ExecuteCommandOnSpecified(string command)
     {
            switch (command.ToLower())
            {
                case "force":
                    Debug.Log("Exe");
                    tileRb.AddForce(new Vector3(10f, 0f, 0f));
                    //gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(10f, 0f, 0f));
                    //transform.Translate(new Vector3(transform.position.x + 5, transform.position.y + 5, transform.position.z));

                    break;
                case "destroy":
                    Destroy(gameObject);
                    break;
            

            default:
                    Debug.Log("Unknown command: " + command);
                    break;
            }
     }






    /*
    public  void ExecuteCommandOnsite(string command)
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
            if (char.IsDigit(c) || (c == '.') || (c == '-')) {
                currentNumber += c;
            }
            else
            {
                newcommand += c;
            }
        }
        if( currentNumber.Length > 0 ) default_number = float.Parse(currentNumber); 

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
    }*/

}
