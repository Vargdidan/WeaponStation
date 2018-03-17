using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlay
{
    private GUIStyle textStyle;
    private string[] instructions;
    private float initialForce;
    private float backburnerForce;
    private float maxSpreadAngle;

    public void Initialize()
    {
        textStyle = new GUIStyle();
        textStyle.fontSize = 15;

        instructions = new string[] {
            "WeaponStation v0.1\n",
            "How to use:",
            "- Press B to toggle binoculars",
            "- Press W or S to adjust the barrel's pitch",
            "- Press A or D to adjust the station's yaw",
            "- Press Space to toggle fireing On/Off",
            "- Use the sliders to adjust projectile properties",
            "- Press Esc to quit"};

        initialForce = 10;
        backburnerForce = 1;
        maxSpreadAngle = 1;
    }

    public void Draw()
    {
        // Draw instructions
        GUI.Label(new Rect(5, 5, 200, 200), string.Join("\n", instructions), textStyle);
        
        // Draw slider and collect the user input for initial force
        GUI.Label(new Rect(Screen.width / 2 - 30, Screen.height - 45, 30, 30), "Initial force", textStyle);
        initialForce = GUI.HorizontalSlider(new Rect(Screen.width / 2 - 100, Screen.height - 25, 200, 200), initialForce, 0, 30);
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 15, 30, 30), initialForce.ToString("F1"), textStyle);

        // Draw slider and collect the user input for initial force
        GUI.Label(new Rect(Screen.width - 30, Screen.height - 180, 30, 30), "B\na\nc\nk\nb\nu\nr\nn", textStyle);
        backburnerForce = GUI.VerticalSlider(new Rect(Screen.width - 15, Screen.height - 215, 200, 200), backburnerForce, 0, 2);
        GUI.Label(new Rect(Screen.width - 25, Screen.height - 15, 30, 30), backburnerForce.ToString("F1"), textStyle);

        // Draw slider and collect the user input for spread angle
        GUI.Label(new Rect(20, Screen.height - 150, 30, 30), "S\np\nr\ne\na\nd", textStyle);
        maxSpreadAngle = GUI.VerticalSlider(new Rect(5, Screen.height - 215, 200, 200), maxSpreadAngle, 0, 15);
        GUI.Label(new Rect(5, Screen.height - 15, 30, 30), maxSpreadAngle.ToString("F1"), textStyle);
    }

    public float GetInitialForce() { return initialForce; }
    public float GetBackburnerForce() { return backburnerForce; }
    public float GetMaxSpreadAngle() { return maxSpreadAngle; }
}
