using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class BeerBottle : MonoBehaviour
{
    public List<Rigidbody> allParts = new List<Rigidbody>();

    public void Shatter()
    {
        foreach(Rigidbody part in allParts)
        {
            part.isKinematic = false;
        }
    }
}
