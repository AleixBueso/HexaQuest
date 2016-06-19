using UnityEngine;
using System.Collections;

public class FlotatingDamageControllerScript : MonoBehaviour {

    private static FlotatingDamageScript PopUpText;
    private static GameObject canvas;

    public static void Initialize()
    {
        canvas = GameObject.Find("Canvas");
        if(!PopUpText)
            PopUpText = Resources.Load<FlotatingDamageScript>("Prefabs/PopupText Parent");
    }

    public static void CreateFloatingText(string text, Transform location)
    {
            FlotatingDamageScript instance = Instantiate(PopUpText);
            instance.transform.SetParent(canvas.transform, false);
            instance.SetText(text);
    }
}
