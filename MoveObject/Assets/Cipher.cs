using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cipher : MonoBehaviour
{

    public int shiftValue = 3;
    public string text;
    [SerializeField]
    string cipheredText;

    // Update is called once per frame
    void Update()
    {
        if (text != null)
        {
            var characters = text.ToCharArray();
            for (int i = 0; i < characters.Length; i++)
            {
                characters[i] = (char)((int)characters[i] * shiftValue);
            }
            cipheredText = new string(characters);
        }
    }
}
