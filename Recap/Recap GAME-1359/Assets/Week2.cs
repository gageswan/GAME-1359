using System; 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Week2 : MonoBehaviour {

    static void ThreeAndSeven() {

        List<int> threesAndSevens = new List<int>();

        for (int i = 36; i < 974; i++) {
            if (i < 999) {
                if ((i / 100) % 100 == 3 || (i / 10) % 10 == 3 || i % 10 == 3) {
                    if ((i / 100) % 100 == 7 || (i / 10) % 10 == 7 || i % 10 == 7) {
                        threesAndSevens.Add(i);
                    }
                }
            }
        }
        for (int i = 0; i < threesAndSevens.Count; i++)
            Debug.Log(threesAndSevens[i]);
    }

    static void MostCommonLetter() {

        string charString = "Gage";

        Dictionary<char, int> charDict = new Dictionary<char, int>();

        for (int i = 0; i < charString.Length; i++) {
            Char c = Char.ToLower(charString[i]);
            if (!charDict.ContainsKey(c)) {
                charDict.Add(c, 1);
            }
            else { charDict[c] = charDict[c] + 1; }
        }
        foreach (KeyValuePair<char, int> ele in charDict) {
            Debug.Log(ele.Key + " - " + ele.Value);
        }
    }

    static void EachLetterOnce() {

        string charString = "Gage";

        List<char> charList = new List<char>();

        for (int i = 0; i < charString.Length; i++) {
            Char c = Char.ToLower(charString[i]);
            if (!charList.Contains(c)) {
                charList.Add(c);
            }
        }
        foreach (Char c in charList) {
            Debug.Log(c);
        }
    }

    void Awake() {
        ThreeAndSeven();
        MostCommonLetter();
        EachLetterOnce();
    }
}


