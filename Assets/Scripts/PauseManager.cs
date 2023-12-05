using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject PausePanel;

    void Update()
    {
        
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        
    }

    // You can call this method from a UI button's OnClick event
    public void Continue()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }
}
