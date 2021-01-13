using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeScript : MonoBehaviour
{
    public Text text;
    public GameObject goManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SetTiem();
        }
    }
    public void SetTiem() {
        goManager.GetComponent<GameManagerScript>().fTimeSec = float.Parse(text.text);
        goManager.GetComponent<GameManagerScript>().fCurSec = float.Parse(text.text);
    }
}
