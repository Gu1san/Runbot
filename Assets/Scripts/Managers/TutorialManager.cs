using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance;
    TutorialBox[] boxes;
    int currentBoxIndex = -1;
    [SerializeField] UnityEvent nextBoxEvent;
    UnityEvent curBoxEvent;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        boxes = GetComponentsInChildren<TutorialBox>();
        nextBoxEvent ??= new UnityEvent();
        nextBoxEvent.AddListener(ShowNextBox);
        curBoxEvent ??= new UnityEvent();
        curBoxEvent.AddListener(HideBox);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            nextBoxEvent.Invoke();
            Debug.Log("Invoke");
        }
    }

    void HideBox()
    {
        //boxes[currentBoxIndex].gameObject.SetActive(false);
        Debug.Log($"Caixa {currentBoxIndex} desativada");
    }

    public void ShowNextBox()
    {
        if (boxes[currentBoxIndex + 1] != null)
        {
            boxes[currentBoxIndex + 1].gameObject.SetActive(true);
            currentBoxIndex++;
            Debug.Log($"Caixa {currentBoxIndex} ativada");
        }
    }
}
