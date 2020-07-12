using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquationInput : MonoBehaviour {
    public string equationString;
    public int boundMinX;
    public int boundMaxX;
    public int boundMinY;
    public int boundMaxY;

    public GameObject inputField;
    public GameObject minXField;
    public GameObject maxXField;
    public GameObject minYField;
    public GameObject maxYField;

    private const int totalPoints = 200;
    
    public void GetInputs() {
        Data.equationString = inputField.GetComponent<Text>().text;
        Data.boundMinX = Convert.ToInt32(minXField.GetComponent<Text>().text);
        Data.boundMaxX = Convert.ToInt32(maxXField.GetComponent<Text>().text);
        Data.boundMinY = Convert.ToInt32(minYField.GetComponent<Text>().text);
        Data.boundMaxY = Convert.ToInt32(maxYField.GetComponent<Text>().text);

        SceneManager.LoadScene(sceneName: "Main");
    }

    
    public int[] GetBounds() {
        return new int[5] {boundMinX, boundMaxX, boundMinY, boundMaxY, totalPoints};
    }

    public double[,,] GetValues()
    {
        equationString = Data.equationString;
        boundMinX = Data.boundMinX;
        boundMaxX = Data.boundMaxX;
        boundMinY = Data.boundMinY;
        boundMaxY = Data.boundMaxY;

        double[,,] answer = new double[totalPoints, totalPoints, 3];

        double stepX = (double) (boundMaxX - boundMinX) / totalPoints;
        double stepY = (double) (boundMaxY - boundMinY) / totalPoints;

        string equation = equationString;


        MathParser mathParser = new MathParser();
        for (int i = 0; i < totalPoints; i++)
        {
            for (int j = 0; j < totalPoints; j++)
            {
                equation = equationString.Replace("x", "(" + Convert.ToString(boundMinX + i * stepX) + ")") ;
                equation = equation.Replace("y", "(" + Convert.ToString(boundMinY + j * stepY) + ")");
                equation = equation.Replace("+-", "-");
                equation = equation.Replace("-+", "-");

                answer[i, j, 0] = boundMinX + i * stepX;
                answer[i, j, 2] = boundMinY + j * stepY;
                answer[i, j, 1] = mathParser.Parse(equation, true);

                if (j % 20 == 0) {
                    Debug.Log(answer[i,j,0] + "  " + answer[i,j,1] + "   " + answer[i,j,2]);
                }
            }
        }

        return answer;

    }

}
