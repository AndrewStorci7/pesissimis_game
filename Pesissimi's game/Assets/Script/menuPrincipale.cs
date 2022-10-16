using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuPrincipale : MonoBehaviour
{
    public GUIStyle stilebtn;
    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnGUI() {
        GUILayout.BeginArea(new Rect(Screen.width/2-250, Screen.height/2-250, 500, 500));
        GUILayout.Button("Unisciti a partita", stilebtn);
        GUILayout.Button("Crea partita", stilebtn);
        GUILayout.Button("Impostazioni", stilebtn);
        GUILayout.Button("Riconoscimenti", stilebtn);
        GUILayout.Button("Esci", stilebtn);
        GUILayout.EndArea();
    }
}
