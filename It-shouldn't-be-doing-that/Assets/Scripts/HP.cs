using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HP : MonoBehaviour
{

    public int HPcount;
    public Text hpCountText;

    public void Start()
    {
        if(gameObject.CompareTag("Player"))
            HPcount = TotalScript.HPCount;
        if (hpCountText != null)
            hpCountText.text = HPcount + "";
    }

    public void Update()
    {
        Animator anim;
        if ((HPcount == 0) && (anim = GetComponent<Animator>()))
        {
            anim.SetBool("IsDead",true);
            Invoke("Reload", 3);
        }
    }

    private void Reload()
    {
        SceneManager.LoadScene("Level1");
    }


    private void OnDestroy()
    {
        TotalScript.HPCount = HPcount;
    }

    public void AddHp()
    {
        HPcount++;
        if(hpCountText != null)
            hpCountText.text = HPcount + "";
    }

    public void DecreaseHP() 
    {
        HPcount--;
        if (HPcount < 0) HPcount = 0;
        else GetComponent<CharacterThrow>().LetOut();
        if (hpCountText != null)
            hpCountText.text = HPcount + "";

    }
    

}
