using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatePerlinNoiseLine : MonoBehaviour
{
    public int lineWight;

    //public List<Vector3> points;
    public GameObject posPre;
    public Dictionary<int, Vector3> points = new Dictionary<int, Vector3>();
    public LineRenderer line;
    public LineRenderer line1;

    public int interIndexMax = 100;

    private void Awake()
    {
        CreatePos();

        CreateLine();
    }


    //画出整数点对应数值点位
    void CreatePos()
    {
        for (int i = 0; i < lineWight; i++)
        {
            float num = Random.Range(0f, 6f);

            Vector3 pointPos = new Vector3(i, num, 0);
            GameObject go = Instantiate(posPre, this.transform);
            go.transform.position = pointPos;
            points.Add(i, pointPos);
        }
    }
    //相邻两个整数点位之间插值获取其他位置数值
    void CreateLine()
    {
        int posIndex = 0;
        int interIndex;
        line.positionCount = interIndexMax * (points.Count - 1);
        line1.positionCount = interIndexMax * (points.Count - 1);

        for (int i = 1; i < points.Count; i++)
        {
            interIndex = 0;
            while (interIndex< interIndexMax)
            {
                interIndex++;

                //线性插值
                /* 
                 float posY = points[i - 1].y + (points[i].y - points[i - 1].y) * (interIndex / (float)interIndexMax);
                 Vector3 pos = new Vector3(i - 1 + interIndex / (float)interIndexMax, posY, 0);
                 line.SetPosition(posIndex, pos);
                 posIndex++;*/

                //插值函数{\displaystyle 3t^{2}-2t^{3}}
                float posY = Mathf.Lerp(points[i - 1].y, points[i].y, InterpolationCalculation(interIndex / (float)interIndexMax));
                Vector3 pos = new Vector3((i - 1 + interIndex / (float)interIndexMax), posY, 0);
                line.SetPosition(posIndex, pos);

                //插值函数{\displaystyle 6t^{5}-15t^{4}+10t^{3}}
                float posY1 = Mathf.Lerp(points[i - 1].y, points[i].y, InterpolationCalculation1(interIndex / (float)interIndexMax));
                Vector3 pos1 = new Vector3((i - 1 + interIndex / (float)interIndexMax), posY1, 0);
                line1.SetPosition(posIndex, pos1);
                posIndex++;
            }
        }
    }

    //插值函数的计算
    float InterpolationCalculation(float num)
    {
        return 3*Mathf.Pow(num, 2)-2*Mathf.Pow(num,3);
    }

    float InterpolationCalculation1(float num)
    {
        return 6 * Mathf.Pow(num, 5) - 15 * Mathf.Pow(num, 4) + 10 * Mathf.Pow(num, 3);
    }




}
