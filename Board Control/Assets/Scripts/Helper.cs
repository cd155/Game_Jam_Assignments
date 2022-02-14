using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HelperLibrary
{
    // no repeat random
    public class RandomNoRepeat
    {
        private  List<int> avaliableChoice;

        public RandomNoRepeat(int start, int end)
        {
            avaliableChoice = GenreateDrawBox(start, end);
        }

        public int Next()
        {
            if(avaliableChoice.Count > 0)
            {
                int randomNum = Random.Range(0, avaliableChoice.Count);
                int randomVAlue = avaliableChoice[randomNum];
                avaliableChoice.RemoveAt(randomNum);
                return randomVAlue;
            }

            // better use exception
            return -1;
        }
        private List<int> GenreateDrawBox(int start, int end)
        {
            List<int> result = new List<int>();
            for (int i = start; i < end; i++)
            {
                result.Add(i);
            }
            return result;
        }
    }
}