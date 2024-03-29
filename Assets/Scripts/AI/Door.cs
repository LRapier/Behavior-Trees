using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public bool unlocked;
    public bool angry;
    public Menu thing;
    public GameObject reset;

    public void Start()
    {
        thing = FindAnyObjectByType<Menu>();
        unlocked = thing.unlocked.isOn;
        angry = thing.angry.isOn;
        Invoke("Reset", 3f);
    }

    public void Open()
    {
        if (unlocked && angry)
        {
            GetComponent<Animator>().Play("UnlockAngry");
            Invoke("End", 1f);
        }
        else if (unlocked && !angry)
        {
            GetComponent<Animator>().Play("UnlockNoAngry");
            Invoke("End", 1f);
        }
        else if (!unlocked && angry)
        {
            GetComponent<Animator>().Play("LockAngry");
            Invoke("End", 1f);
        }
        else
        {
            GetComponent<Animator>().Play("LockNoAngry");
            Invoke("End", 1f);
        }
    }

    void End()
    {
        GetComponent<Animator>().enabled = false;
    }

    void Reset()
    {
        reset.SetActive(true);
        reset.GetComponent<Button>().onClick.AddListener(thing.Load);
    }
}
