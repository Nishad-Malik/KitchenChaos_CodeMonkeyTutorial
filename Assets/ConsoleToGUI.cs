using UnityEngine;

public class ConsoleToGUI : MonoBehaviour
{
    //CREDIT: boysil
    //On https://discussions.unity.com/t/is-there-any-way-to-view-the-console-in-a-build/22279

    string myLog = "*begin log";
    [SerializeField] bool doShow = true;
    int kChars = 700;
    void OnEnable() { Application.logMessageReceived += Log; }
    void OnDisable() { Application.logMessageReceived -= Log; }
    void Update() { if (Input.GetKeyDown(KeyCode.Alpha0)) { doShow = !doShow; } }
    public void Log(string logString, string stackTrace, LogType type)
    {
        // for onscreen...
        myLog = myLog + " " + logString + "\n";
        if (myLog.Length > kChars) { myLog = myLog.Substring(myLog.Length - kChars); }
    }

    void OnGUI()
    {
        if (!doShow) { return; }
        GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
           new Vector3(Screen.width / 1200.0f, Screen.height / 800.0f, 1.0f));
        GUI.TextArea(new Rect(10, 10, 540, 370), myLog);
    }

}