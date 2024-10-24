using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBoxBehaviour : MonoBehaviour
{
    public TextMeshProUGUI textComponent; // Changed "TextMeshProGUI" to "TextMeshProUGUI"
    public string[] lines;
    public float textSpeed;
    private int index;
    public bool flag = false;
    public GameObject alien;

    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1) // Changed "Lenght" to "Length"
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            if (flag == true)
            {
                Destroy(alien, 2f);
            }
        }
    }
}
