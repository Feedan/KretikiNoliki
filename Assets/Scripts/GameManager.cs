using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject _playingField;
    private Sprite Chose;
    private Sprite EnemyChose;
    public Sprite Krestik;
    public Sprite Nolik;
    public Sprite Pustoi;
    

    public Text win;
    public Text lose;

    public static int chose;


    public List<Button> cells = new List<Button>();

    private void Start()
    {
        _playingField.SetActive(false);
    }

    public void StartGame(int role)
    {
        if (role == 1)
        {
            Chose = Krestik;
            EnemyChose = Nolik;
            _playingField.SetActive(true);
        }
        if (role == 2)
        {
            Chose = Nolik;
            EnemyChose = Krestik;
            _playingField.SetActive(true);
        }
    }

    public void OnClick(int number)
    {
        if (cells[number].image.overrideSprite == Pustoi)
        {
            cells[number].GetComponent<Image>().sprite = Chose;
            EnemyMove();
        }
        if (VictoryCheck(Chose) == true)
        {
            Debug.Log("Ты победил");
            win.enabled = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
            Debug.Log("Ты проиграл");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private bool VictoryCheck(Sprite check)
    {
        if (cells[0].GetComponent<Image>().sprite == check && cells[1].GetComponent<Image>().sprite == check && cells[2].GetComponent<Image>().sprite == check)
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
