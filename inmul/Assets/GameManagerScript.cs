using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManagerScript : MonoBehaviour
{
    [System.Serializable]
    public class ImgName {
        public Sprite spTexture;
        public string sName;
    }

    [SerializeField] public List<ImgName> listImgName = new List<ImgName>();

    public Text text;
    public Image img;
    public GameObject goMain;
    public GameObject goGame;
    public GameObject goTemp;
    public GameObject goCan;
    public Text textSec;

    private bool isOpen;
    public float fTimeSec;
    public float fCurSec;
    private bool isStop;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = true;
        isStop = false;
        Nextbtn();
        fCurSec = fTimeSec;
    }

    // Update is called once per frame
    void Update()
    {
        if (goGame.activeInHierarchy) {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Nextbtn();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                returnMain();
            }
            if (fCurSec > 0 && !isStop)
            {
                fCurSec -= Time.deltaTime;
                textSec.text = "" + Mathf.Round(fCurSec * 10f) / 10f;
            }
            else
            {
                isOpen = true;
                isStop = true;
                goTemp.SetActive(true);
            }
        }
    }
    public void Nextbtn() {
        if (listImgName.Count == 0 && isOpen)
        {
            goGame.SetActive(false);
            goCan.SetActive(true);
            Invoke("End", 2f);
        }

        if (isOpen)
        {
            fCurSec = fTimeSec;
            isOpen = false;
            isStop = false;
            int ran = Random.Range(0, listImgName.Count);
            img.sprite = listImgName[ran].spTexture;
            text.text = listImgName[ran].sName;
            listImgName.RemoveAt(ran);
            goTemp.SetActive(false);
        }
        else {
            isOpen = true;
            isStop = true;
            goTemp.SetActive(true);
        }

    }
    public void startBtn() {
        goMain.SetActive(false);
        goGame.SetActive(true);
    }
    public void returnMain() {
        goGame.SetActive(false);
        goMain.SetActive(true);
    }
    public void End() {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
