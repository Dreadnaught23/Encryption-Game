using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InputField : MonoBehaviour
{
    //by Abid Garda Maulana....................//

    //mengambil reverensi tombol 
    [SerializeField] private Enkripsi enkripsi;
    [SerializeField] private Dekripsi dekripsi;

    private TMP_InputField inputField;

    //inisiasi array char yaitu 26 huruf
    private char[] chipperMapping;

    //Key untuk enkripsi dan dekripsi
    private int keyChar = +3;
    private int reverseKeyChar = -3;
    private void Awake()
    {
        //mengambil komponen input text
        inputField = GetComponent<TMP_InputField>();
        
    }

    private void Start()
    {
        //membuat listener button
        Button enkripsiBt = enkripsi.transform.Find("Enkripsi").GetComponent<Button>();
        enkripsiBt.onClick.AddListener( () =>
        {
            DoEnkripsi();
        });

        Button dekripsiBt = dekripsi.transform.Find("Dekripsi").GetComponent<Button>();
        dekripsiBt.onClick.AddListener(DoDekripsi);
    }

    private void DoEnkripsi()
    {
        // Pakai penamaan ASCII untuk urutan abjad jadi tidak perlu di tulis manual
        chipperMapping = new char[26];
        for(int i=0; i < chipperMapping.Length; i++)
        {
            //Memasukkan rumus modulus untuk enkripsi
            chipperMapping[i] = (char)('a' + (i + keyChar + 26) % 26); 
        }

        string inputText = inputField.text.ToLower();//convert ke lowercase
        string encryptedText = EncryptDecryptText(inputText);
        inputField.text = encryptedText;
    }

    private void DoDekripsi()
    {
        chipperMapping = new char[26];
        for(int i=0;i < chipperMapping.Length; i++)
        {
            //Memasukkan rumus modulus untuk dekripsi
            chipperMapping[i] =(char)('a' + (i + reverseKeyChar + 26) % 26);
        }

        string inputText = inputField.text.ToLower();
        string decryptedtext = EncryptDecryptText(inputText);
        inputField.text = decryptedtext;
    }

    private string EncryptDecryptText(string inputText)
    {
        // Create a StringBuilder to store the encrypted text
        System.Text.StringBuilder encryptedText = new System.Text.StringBuilder();

        // Encrypt each character in the input text
        foreach (char c in inputText)
        {
            // Check if the character is a lowercase letter
            if (c >= 'a' && c <= 'z')
            {
                // Encrypt the character using the substitution cipher
                int index = c - 'a'; // Get the index of the character in the alphabet
                encryptedText.Append(chipperMapping[index]); // Append the corresponding cipher character
            }
            else
            {
                // If the character is not a lowercase letter, keep it unchanged
                encryptedText.Append(c);
            }
        }

        // Return the encrypted text as a string
        return encryptedText.ToString();
    }
}
