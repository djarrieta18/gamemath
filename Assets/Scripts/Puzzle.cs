using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum fruits{
    apple=0,
    banana=1,
    blueberry=2,
    grape=3,
    orange=4,
    pear=5,
    strawberry=6
}

public class Puzzle : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] fruits fruitsSelected;
    [SerializeField] GameObject[] fruitPref;
    [SerializeField] GameObject manzParent;
    [SerializeField] Vector2 initpos;
    [SerializeField] float spacemanz = 1;
    [SerializeField] Drag[] dragAnsw;

    [SerializeField] Sprite[] numberSprites;
    float ypos = -0.3f;
    int currenManzaNum;
    [SerializeField] Options[] options;

    //[SerializeField] GameObject popUp;


    int[] answers =new int []{

        0,
        0,
        0,

    };

    [System.Serializable]
    public struct Options
    {
        public SpriteRenderer[] digits;
        //public SpriteRenderer digitB;
    }




    void Start()
    {

        currenManzaNum = GetRanManza();

        for (int i = 0; i < currenManzaNum; i++)
        {
            if (i % 6 == 0)
            {
                ypos += 0.3f;
            }
            GameObject currManza = Instantiate(fruitPref[fruitsSelected.GetHashCode()]);
            currManza.transform.parent = manzParent.transform;
            currManza.transform.localPosition = new Vector2(initpos.x + i%6 * spacemanz, initpos.y - (ypos)); 
            
            
        }
        SetAnswers();
        for (int i = 0; i < dragAnsw.Length; i++)
        {
           
            dragAnsw[i].SetValue(answers[i] == currenManzaNum);
        }

        for (int i = 0; i < options.Length; i++)
        {
            SetOptions(answers[i].ToString("D2"), i);
        }
        SetOptions(currenManzaNum.ToString("D2"), 0);

    }

    void SetOptions(string sentence,int opt)
    {
        char[] charArr = sentence.ToCharArray();
      
        for (int i = 0; i < charArr.Length; i++)
        {
            int index = (int)Char.GetNumericValue(charArr[i]);
            options[opt].digits[i].sprite = numberSprites[index]; 

        }
        
        //for (int i = 0; i < numbers.Length; i++)
        //{
        //    Debug.Log(i+" kya "+ numbers[i]);
        //}
        //for (int i = 0; i < options.Length; i++)
        //{
        //    options[i].digitA=

        //}
    }

    void SetAnswers()
    {
        answers[0] = currenManzaNum;
        answers[1] = GetndomParam(answers);
        answers[2] = GetndomParam(answers);
    }

    int GetndomParam(int[] used)
    {
        bool repeat = true;
        int num=0;
        while (repeat)
        {
            num = GetRanManza();
            repeat = false;
            for (int i = 0; i < used.Length; i++)
            {
                if(used[i]==num)
                {
                   
                    repeat = true;
                    break;
                }
            }

        }
        return num;
    }

    int GetRanManza()
    {
        System.Random rd = new System.Random();

      int rand_num = rd.Next(1,10);
        Debug.Log(rand_num);
        return rand_num;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //public void ShowPopUp()
    //{
    //    popUp.SetActive(true);
    //}
}
