using UnityEngine;

class MyScript : MonoBehaviour

{

    public int number;

    void Start()

    {

        number = 10;

    }

    void Update()

    {

        if (number >= 0)

        {

            Debug.Log("in MyScript Update, count = " + number);

            DoSomething();

            number -= 1; // reduce number by one

        }

    }

    private void DoSomething()

    {

        Debug.Log("inside DoSomething");

        number = -1; // accidently set number to minus-1

        // other code¡K

    }

}