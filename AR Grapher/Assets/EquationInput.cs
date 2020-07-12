using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    double[,,] answer = new double[totalPoints, totalPoints, 3];

    public void GetInputs() {
        equationString = inputField.GetComponent<Text>().text;
        boundMinX = Convert.ToInt32(minXField.GetComponent<Text>().text);
        boundMaxX = Convert.ToInt32(maxXField.GetComponent<Text>().text);
        boundMinY = Convert.ToInt32(minYField.GetComponent<Text>().text);
        boundMaxY = Convert.ToInt32(maxYField.GetComponent<Text>().text);

        GetValues();
    }


    public string[] GetEquationParameters() {
        return new string[5] {equationString, Convert.ToString(boundMinX), Convert.ToString(boundMaxX), Convert.ToString(boundMinY), Convert.ToString(boundMaxY)};
    }

    public void GetValues()
    {
        double stepX = (double) (boundMaxX - boundMinX) / totalPoints;
        double stepY = (double) (boundMaxY - boundMinY) / totalPoints;

        string equation;


        MathParser mathParser = new MathParser();

        for (int i = 0; i < totalPoints; i++)
        {
            for (int j = 0; j < totalPoints; j++)
            {
                equation = equationString.Replace("x", Convert.ToString(boundMinX + i * stepX));
                equation = equation.Replace("y", Convert.ToString(boundMinY + j * stepY));
                equation = equation.Replace("+-", "-");
                equation = equation.Replace("-+", "-");

                answer[i, j, 0] = boundMinX + i * stepX;
                answer[i, j, 1] = boundMinY + i * stepY;
                answer[i, j, 2] = mathParser.Parse(equation, true);
            }
        }

    }

}
