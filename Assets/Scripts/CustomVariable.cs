using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomVariable
{
    private string variableName;
    private int variableValue;

    public CustomVariable(string n)
    {
        variableName = n;
        variableValue = 0;
    }
    public CustomVariable(string n, int v)
    {
        variableName = n;
        variableValue = v;
    }

    public string Name
    {
        get { return (variableName); }
        set { variableName = value; }
    }
    public int Value
    {
        get { return (variableValue); }
        set { variableValue = value; }
    }
}
