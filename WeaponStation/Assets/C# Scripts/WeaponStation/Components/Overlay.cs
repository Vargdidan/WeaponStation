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
            "- Press W or S to adjust the pitch of the barrel",
            "- Press A or D to adjust the yaw of the station"};
    }

    public override void OnGUI()
    {
        GUI.Label(new Rect(5, 5, 200, 200), string.Join("\n", instructions), textStyle);
    }
}
