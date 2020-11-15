using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossUi : MonoBehaviour
{
    public List<GameObject> bars;

    public GameObject boss;

    private int index = 0;

    private int bossHP;
    


    void Start()
    {
        bossHP = boss.GetComponent<HP>().HPcount;
    }

    // Update is called once per frame
    void Update()
    {

            if (bossHP > boss.GetComponent<HP>().HPcount && index < bars.Count)
            {
                Destroy(bars[index]);
                index++;
                bossHP = boss.GetComponent<HP>().HPcount;
            }

            if (bossHP == 0)
            {
                Destroy(boss);
                Invoke("Outro", 3);
            }
    }

    private void Outro()
    {
        SceneManager.LoadScene("Outroduction");
    }
}
