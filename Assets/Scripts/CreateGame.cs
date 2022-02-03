using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using System.Numerics;
using UnityEngine.SceneManagement;




public class CreateGame : MonoBehaviour
{
    private int chose;

    private Sprite Chose;
    private Sprite EnemyChose;
    public Sprite Krestik;
    public Sprite Nolik;
    public Sprite Pustoi;
    public Canvas canvasPole;

    public Text win;
    public Text lose;


    private int _countMove = 0;

    public List<Button> cells = new List<Button>();



    
    void Start()
    {
        win.enabled = false;
        lose.enabled = false;
        canvasPole.enabled = false;
    }
    void Update()
    {
        _countMove = 0;
        if (Play.chose == 1)
        {
            Chose = Krestik;
            EnemyChose = Nolik;
            canvasPole.enabled = true;
        }
        if (Play.chose == 2)
        {
            Chose = Nolik;
            EnemyChose = Krestik;
            canvasPole.enabled = true;
        }

        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].GetComponent<Image>().sprite != Pustoi)
            {
                _countMove++;
            }
        }
        if (_countMove == cells.Count)
        {
            Chose = null;
            canvasPole.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void OnClick(int number)
    {
        if (cells[number].image.overrideSprite == Pustoi)
        {
            cells[number].GetComponent<Image>().sprite = Chose;
        }
        if (VictoryCheck(Chose) == true)
        {
            win.enabled = true;
            canvasPole.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        EnemyMove();
    }



    private void EnemyMove()
    {
        
        int index;
        List<int> freeMoves = new List<int>();
        for (int i = 0; i < cells.Count; i++)
        {
            if (cells[i].GetComponent<Image>().sprite == Pustoi)
            {
                freeMoves.Add(i);
            }
        }

        index = UnityEngine.Random.Range(0, freeMoves.Count);
        cells[freeMoves[index]].GetComponent<Image>().sprite = EnemyChose;
        if (VictoryCheck(EnemyChose) == true)
        {
            lose.enabled = true;
            canvasPole.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private bool VictoryCheck(Sprite check)
    {
        if (cells[0].GetComponent<Image>().sprite == check && cells[1].GetComponent<Image>().sprite == check&& cells[2].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[3].GetComponent<Image>().sprite == check && cells[4].GetComponent<Image>().sprite == check && cells[5].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[6].GetComponent<Image>().sprite == check && cells[7].GetComponent<Image>().sprite == check && cells[8].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[0].GetComponent<Image>().sprite == check && cells[3].GetComponent<Image>().sprite == check && cells[6].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[1].GetComponent<Image>().sprite == check && cells[4].GetComponent<Image>().sprite == check && cells[7].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[2].GetComponent<Image>().sprite == check && cells[5].GetComponent<Image>().sprite == check && cells[8].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[0].GetComponent<Image>().sprite == check && cells[4].GetComponent<Image>().sprite == check && cells[8].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        if (cells[2].GetComponent<Image>().sprite == check && cells[4].GetComponent<Image>().sprite == check && cells[6].GetComponent<Image>().sprite == check)
        {
            return true;
        }
        return false;
    }
}
