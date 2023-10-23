using System;

using System.Collections;

using System.Collections.Generic;



using System.Linq;
using TMPro;
using Unity.VisualScripting;

using UnityEngine;

public class CG_Shuffle : MonoBehaviour

{

    public List<Transform> cupList = new List<Transform>();

    public Vector2[] startingCupLoc;


    public CG_Cup[] cupColors;
    public bool debug = true;

    public GameObject thisObject;

    int[] moveCount;

   /* void GetCupList()

    {



        cupList = thisObject.gameObject.GetComponentsInChildren<Transform>().ToList();

        CupRemove(thisObject.transform);









    }
*/
    public float tableSize;

    public int posingCup;
    void CupListSetUp()

    {

        startingCupLoc = new Vector2[cupList.Count];


        cupColors = new CG_Cup[cupList.Count];

        float distance = tableSize / cupList.Count;
        Debug.Log("Distance = "+ cupList.Count);

        for (int i = 0; i < cupList.Count; i++)
        {
            startingCupLoc[i] = cupList[i].transform.localPosition;

            startingCupLoc[i].x = (distance * i - (tableSize / Mathf.Round(cupList.Count)) - ((cupList.Count-3)));
            Debug.Log(i + " x = " + (distance * i - Mathf.Round(tableSize / (cupList.Count / 2))) + "  which the min" + Mathf.Round(tableSize / (cupList.Count / 2)));

            cupColors[i] = cupList[i].GetComponent<CG_Cup>();

            if (debug)

            {

                Debug.Log(cupList[i].name);

                Debug.Log(startingCupLoc[i]);

            }



        }
        ResetPostions();
    }

    void ResetPostions()
    {
        for (int i = 0; i < cupList.Count; i++)
        {
            cupList[i].transform.localPosition = startingCupLoc[i];
        }
    }



    void CupRemove(Transform t)

    {

        if (cupList.Contains(t))

        {

            cupList.Remove(t);

            CupListSetUp();

        }

        else

        {

            Debug.Log("error 1 cup list dosent exst in the cuplist, so couldnt remove " + t.name);

        }

    }

    void CupAdd(Transform t)

    {

        if (!cupList.Contains(t))

        {

            cupList.Add(t);

            CupListSetUp();

        }

        else

        {

            Debug.Log("error 2 cup list already contents the " + t.name);

        }



    }





    float MathCupMoveCount(int c)

    {

        return (c + Mathf.Round((c - 3) / 2) * 2) * 2;

    }



    void GiveCupNumbers(int c)

    {

        float cupCount = MathCupMoveCount(c);



        float reminder = cupCount % c;

        bool runing = true;

        int loopCount = 0;



        if (reminder == 0)

        {

            runing = false;

        }



        while (runing)

        {

            loopCount++;

            if (debug)

            {

                Debug.Log("loopCount = " + loopCount);



                Debug.Log("Cup number postive findering");

            }



            reminder = (cupCount + loopCount) % c;









            if (reminder == 0)

            {

                if (debug)

                {

                    Debug.Log("Cup number postive good");

                }



                runing = false; break;

            }

            else

            {

                if (debug)

                {

                    Debug.Log("Cup number nagitve findering");

                }



                reminder = (cupCount - loopCount) % c;

            }



            if (reminder == 0)

            {

                if (debug)

                {

                    Debug.Log("Cup number Nagtive good");

                }



                loopCount *= -1;

                runing = false; break;

            }







        }

        Debug.Log("end " + loopCount);



        moveCount = new int[c];

        for (int i = 0; i < c; i++)

        {



            moveCount[i] = (int)(cupCount + loopCount) / c;

        }





        moveCount[UnityEngine.Random.Range(0, c)] += loopCount;



        if (debug)

        {

            for (int i = 0; i < c; i++)

            {

                Debug.Log("mov count" + i + " is " + moveCount[i]);

            }



        }





    }





    int[] MoveCupCalaures()

    {

        bool running = true;

        List<int> cupMoveMax2 = moveCount.ToList();





        int[] cupMovesInstance;

        cupMovesInstance = new int[2];

        cupMovesInstance[0] = -1;

        cupMovesInstance[1] = -1;



        while (running)

        {

            if (cupMoveMax2.Count == 2) { running = false; break; }



            cupMoveMax2.Remove(cupMoveMax2.Min());



        }







        for (int i = 0; i < cupMoveMax2.Count; i++)

        {



            //Debug.Log("cupsMoving " + cupMoveMax2[i]);

            //cupMovesInstance[i] = cupMoveMax2[i];



            // a list for possable cup that can move



            //void DebugOutWords()

            //{

            //    Debug.Log("moveOption.Count" + moveOption.Count);

            //    Debug.Log("i is not negative its" + i);

            //    for (int j = 0; j < moveOption.Count; j++)

            //    {

            //        Debug.Log(j + "   " + moveOption[j]);

            //    }

            //    Debug.Log("moveOption.Count) " + moveOption.Count);

            //}

            //Debug.Log("test log 1 ");





            List<int> moveOption = new List<int>();

            for (int j = 0; j < moveCount.Length; j++)

            {



                if (moveCount[j] == cupMoveMax2[i])

                {

                    if (debug) { }

                    //Debug.Log(j + " error 3 " + !cupMovesInstance.Contains(j));

                    if (!cupMovesInstance.Contains(j))

                    {

                        //Debug.Log(j + " is  j added");

                        moveOption.Add(j);







                    }

                }



            }

            //Debug.Log("error 3");

            // if (debug) { DebugOutWords(); }



            //Debug.Log("moveOption-2 =" + i);

            /*Debug.Log("moveOption0 =" + moveOption.Count);

            Debug.Log("moveOption1 = " + moveOption[0]);

            */

            //Debug.Log(moveOption + " moveOption    " + moveOption[0] + "   " + moveOption[1]);



            cupMovesInstance[i] = moveOption[index: UnityEngine.Random.Range(0, moveOption.Count)];









        }



        Debug.Log("First " + cupMovesInstance[0] + "     second " + cupMovesInstance[1]);





        return cupMovesInstance;

    }



    IEnumerator CupSwaperLoop(float duration)

    {

        Debug.Log("loopstart");



        int loopCount = -1;

        foreach (int cup in moveCount) { loopCount += cup; }





        //float duration1 = duration/(3/2);

        loopCount /= 2;

        //int loopCount = 10;

        bool runing = true;

        Debug.Log("loop " + loopCount);



        for (int i = 0; i <= loopCount; i++)

        {



            string s = "start: ";

            for (int j = 0; j < cupList.Count; j++)

            {

                s += moveCount[j] + " ";

            }

            Debug.Log(s);





            CupSwaper(duration / loopCount);


            yield return new WaitForSeconds(duration / loopCount);

            Debug.Log("loop " + i);

            s = "end: ";

            for (int j = 0; j < cupList.Count; j++)

            {

                s += moveCount[j] + " ";

            }

            Debug.Log(s);





        }

    }
    bool revalCup = true;
    IEnumerator StartRound(float duration)

    {
        cupColors[cupWithBall].ballUnderThis = true;


        RoundNumber += 1;


        ResetPostions();
        GiveCupNumbers(cupList.Count);


        // this funstion is to reavel the cup with the ball under
        if (revalCup)
        {
            

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            for (int i = 0; i < cupList.Count; i++)
            {
                cupColors[i].showTime = true;
            }
            
            yield return new WaitForSeconds(0.25f);
        }

        StartCoroutine(CupSwaperLoop(duration));


        // this funstion is to reavel the cup with the ball under
        if (revalCup)
        {

            statues.text = "wait";

            yield return new WaitForSeconds(duration+0.5f);
            for (int i = 0; i < cupList.Count; i++)
            {
                cupColors[i].showTime = false;
                
            }
            statues.text = "Guess";

            for (int i = 0; i < cupList.Count; i++)
            {
                cupColors[i].selectTime = true;
            }

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }

            for (int i = 0; i < cupList.Count; i++)
            {
                cupColors[i].selectTime = false;
            }



            yield return new WaitForSeconds(1);

            while (!Input.GetKeyDown(KeyCode.Space))
            {
                yield return null;
            }


            for (int i = 0; i < cupList.Count; i++)
            {
                cupColors[i].ballSelected = false;
                cupColors[i].ballUnderThis = false;
            }


            yield return new WaitForSeconds(1);
        }

        cupColors[cupWithBall].ballUnderThis = false;
        AddNewCupPrefab();
        statues.text = "press K";
        statuesBool = false;


    }

    int cupWithBall;


    void CupSwaper(float duration)

    {



        int[] movingCups = MoveCupCalaures();

        Vector2 newStartLoction = startingCupLoc[movingCups[1]];



        StartCoroutine(MoveCupSwap(cupList[movingCups[0]], startingCupLoc[movingCups[0]], startingCupLoc[movingCups[1]], duration));

        StartCoroutine(MoveCupSwap(cupList[movingCups[1]], startingCupLoc[movingCups[1]], startingCupLoc[movingCups[0]], duration));

        startingCupLoc[movingCups[1]] = startingCupLoc[movingCups[0]];

        startingCupLoc[movingCups[0]] = newStartLoction;

        for (int i = 0; i < movingCups.Length; i++)

        {

            moveCount[movingCups[i]] -= 1;

        }

    }



    IEnumerator MoveCupSwap(Transform t, Vector2 startLoc, Vector2 endLoc, float duration, bool topOrBotton = true)

    {

        //Debug.Log("Cup beign spawping");

        Vector2 distance = (endLoc - startLoc) / 2;

        if (topOrBotton)

        {

            distance.y += 2;

        }

        else { distance.y -= 2; }



        StartCoroutine(MoveToTarget(t, startLoc + distance, duration / 2));



        yield return new WaitForSeconds(duration / 2);

        StartCoroutine(MoveToTarget(t, endLoc, duration / 2));

    }

















    IEnumerator MoveToTarget(Transform t, Vector2 target, float duration)

    {

        float timeElapsed = 0;

        Vector3 startingPos = t.localPosition;



        while (timeElapsed < duration)

        {

            t.localPosition = Vector2.Lerp(startingPos, target, timeElapsed / duration);

            timeElapsed += Time.deltaTime;

            yield return null;

        }







        t.localPosition = target;

    }





















    // Start is called before the first frame update

    void Start()

    {
        
        statuesBool = false;
        cupWithBall = 1;
        AddNewCupPrefab();
        AddNewCupPrefab();
 

        CupListSetUp();
        Debug.Log(cupList);



        GiveCupNumbers(cupList.Count);
        tableSize = 17f;

        ResetPostions();

        RoundNumber = 0;

    }



    public TextMeshProUGUI statues;

    public TextMeshProUGUI roundTextNumber;
    int RoundNumber;
    bool statuesBool;

    public GameObject cupPrefab;
    void AddNewCupPrefab()
    {
        CupAdd(Instantiate(cupPrefab).transform);
    }
    // Update is called once per frame

    void Update()

    {

        roundTextNumber.text = RoundNumber.ToString();


        if (Input.GetKeyDown(KeyCode.G))

        {

            string s = "start: ";

            for (int i = 0; i < cupList.Count; i++)

            {

                s += moveCount[i] + " ";

            }

            Debug.Log(s);

            CupSwaper(1f);



            s = "end: ";

            for (int i = 0; i < cupList.Count; i++)

            {

                s += moveCount[i] + " ";

            }

            Debug.Log(s);







        }


        



        if (Input.GetKeyDown(KeyCode.K) && !statuesBool)

        {

            statuesBool = true;
            statues.text = "Press space";
            StartCoroutine(StartRound(1f));



        }


        if (Input.GetKeyDown(KeyCode.C) && !statuesBool)

        {

            AddNewCupPrefab();



        }

    }



    

}