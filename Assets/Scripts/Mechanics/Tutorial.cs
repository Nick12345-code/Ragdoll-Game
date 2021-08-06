using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject info;

    private void Start()
    {
        info.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (info.activeSelf)
            {
                info.SetActive(false);
            }
            else
            {
                info.SetActive(true);
            }
        }
    }
}
