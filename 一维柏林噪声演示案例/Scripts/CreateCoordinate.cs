using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCoordinate : MonoBehaviour
{
    public int widght;
    public int height;

    public GameObject posPre;

    public LineRenderer line1;
    public LineRenderer line2;
    private void Awake()
    {
        Createmap();
    }

    void Createmap()
    {

        line1.positionCount=widght;
        line2.positionCount=height;
        for (int i = 0; i < widght; i++)
        {
            GameObject go = Instantiate(posPre, this.transform);
            go.transform.position = new Vector3(i, 0, 0);
            line1.SetPosition(i, new Vector3(i, 0, 0));
        }

        for (int j = 1; j < height+1; j++)
        {
            GameObject go = Instantiate(posPre, this.transform);
            go.transform.position = new Vector3(0, j, 0);
            line2.SetPosition(j-1, new Vector3(0, j-1, 0));
        }
    }
}
