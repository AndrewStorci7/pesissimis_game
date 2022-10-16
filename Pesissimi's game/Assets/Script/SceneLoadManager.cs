using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Com.AnDr3wS7oRc1.Pesissimisgame
{
    public class SceneLoadManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene("Menu");
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}