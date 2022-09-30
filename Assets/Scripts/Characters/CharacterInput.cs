using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour
{
    public bool jump;


    void Update()
    {
        ReadInput();
    }

    public virtual void ReadInput ()
    {

    }
}
