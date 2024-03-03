using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUIManager : MonoBehaviour
{
    [SerializeField] private GameObject musicHolder;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(musicHolder);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
