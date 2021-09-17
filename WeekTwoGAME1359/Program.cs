using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTwoGAME1359 {
    class Program {

        static void ThreeAndSeven() {

            List<int> threesAndSevens = new List<int>();

            for (int i = 37; i < 974; i++) {
                if (i < 999) {
                    if ((i / 100) % 100 == 3 || (i / 10) % 10 == 3 || i % 10 == 3) {
                        if ((i / 100) % 100 == 7 || (i / 10) % 10 == 7 || i % 10 == 7) {
                            threesAndSevens.Add(i);
                        }
                    }
                }
            }
            for (int i = 0; i < threesAndSevens.Count; i++)
                Console.WriteLine(threesAndSevens[i]);
        }

        static void MostCommonLetter() {

            string charString = "Gage";

            Dictionary<char, int> charDict = new Dictionary<char, int>();

            for (int i = 0; i < charString.Length; i++){
                Char c = Char.ToLower(charString[i]);
                if (!charDict.ContainsKey(c)) {
                    charDict.Add(c, 1);
                }
                else { charDict[c] = charDict[c] + 1; }
            }
            foreach (KeyValuePair<char, int> ele in charDict) {
                Console.WriteLine("{0} - {1}",
                            ele.Key, ele.Value);
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
                Console.WriteLine(c);
            }
        }

        static void Main(string[] args) {
            ThreeAndSeven();
            MostCommonLetter();
            EachLetterOnce();
        }
    }
}
