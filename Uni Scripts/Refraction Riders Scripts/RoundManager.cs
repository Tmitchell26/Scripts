using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

namespace SAE
{
    public class RoundManager : MonoBehaviour
    {

        public List<GameObject> playerList;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Debug.Log(playerList.Count);

            if (playerList.Count == 1)
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}