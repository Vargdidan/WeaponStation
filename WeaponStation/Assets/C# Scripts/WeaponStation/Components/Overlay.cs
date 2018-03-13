using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay : WeaponComponent
{
    GUIStyle textStyle;
    string[] instructions;

    public override void Initialize()
    {
        textStyle = new GUIStyle();
        textStyle.fontSize = 15;

        instructions = new string[] {
            "WeaponStation v0.1\n",
            "How to use:",
            "- Press B to toggle binoculars",
            "- Press W or S to adjust the barrel's pitch",
            "- Press A or D to adjust the station's yaw"};
    }

    public override void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 200, 200), string.Join("\n", instructions), textStyle);
    }
}
