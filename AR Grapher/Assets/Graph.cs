using UnityEngine;
using System;

public class Graph : MonoBehaviour
{

    public Transform pointPrefab;

    public GameObject stage;

    int counter = 0;

    void Awake()
    {

        EquationInput equationInput = new EquationInput();
        double[,,] points = equationInput.GetValues();
        int[] bounds = equationInput.GetBounds();

        for (int i = 0; i < bounds[4]; i++) {
    
            for (int j = 0; j < bounds[4]; j++) {
                    Transform point = Instantiate(pointPrefab);
                    
                    
                    point.localPosition = new Vector3 ((float)((double)points[i,j,0]/100),(float)((double)points[i,j,1]/100),(float)((double)points[i,j,2]/100));
                    double totalHeight = Data.boundMaxY-Data.boundMinY;
                    double diff = points[i,j,1]-Data.boundMinY;
                    double percent = (double) diff/totalHeight;

                    point.transform.parent = stage.transform;
                    point.GetComponent<Renderer>().material.SetColor("_Color", new Color((float)(1*percent),0,(float) (1-percent),1));
            }
        }
    }
}