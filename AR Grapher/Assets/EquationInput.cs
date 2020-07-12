using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquationInput : MonoBehaviour {
    public string equationString;
    public string boundMinX;
    public string boundMaxX;
    public string boundMinY;
    public string boundMaxY;

    public double answer;

    public GameObject inputField;
    public GameObject minXField;
    public GameObject maxXField;
    public GameObject minYField;
    public GameObject maxYField;

    public void GetInputs() {
        equationString = inputField.GetComponent<Text>().text;
        boundMinX = minXField.GetComponent<Text>().text;
        boundMaxX = maxXField.GetComponent<Text>().text;
        boundMinY = minYField.GetComponent<Text>().text;
        boundMaxY = maxYField.GetComponent<Text>().text;
        MathParser mathParser = new MathParser();
        answer = mathParser.Parse(equationString, true);
    }

    public string[] GetEquationParameters() {
        return new string[5] {equationString, boundMinX, boundMaxX, boundMinY, boundMaxY};
    }

}
