using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoordinate1 : MonoBehaviour
{
    public int posNumber;

    public GameObject posPre;

    public LineRenderer line1;
    public LineRenderer line2;
    public LineRenderer line3;
    private void Awake()
    {
        Coordinate();
    }

    void Coordinate()
    {

        line1.positionCount=posNumber;
        line2.positionCount=posNumber;
        line3.positionCount = posNumber;
        for (int i = 0; i < posNumber; i++)
        {
            GameObject goX = Instantiate(posPre, this.transform);
            goX.transform.position = new Vector3(i, 0, 0);
            line1.SetPosition(i, new Vector3(i, 0, 0));

            GameObject goY = Instantiate(posPre, this.transform);
            goY.transform.position = new Vector3(0, i, 0);
            line2.SetPosition(i, new Vector3(0, i, 0));

            GameObject goZ = Instantiate(posPre, this.transform);
            goZ.transform.position = new Vector3(0, 0, i);
            line3.SetPosition(i, new Vector3(0, 0, i));
        }

        
    }
}

