using UnityEngine;

public class UIActivate : MonoBehaviour
{
    public GameObject canvas;
    void Start()
    {
        canvas.gameObject.SetActive(true);
    }

    
}
