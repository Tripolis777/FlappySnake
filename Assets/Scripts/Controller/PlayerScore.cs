using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class PlayerScore : MonoBehaviour
{
    [SerializeField] private Text m_TextScore;
   
    private int m_CurrentScore;

    private void Awake()
    {
        Assert.IsNotNull(m_TextScore);
        m_CurrentScore = 0;
        m_TextScore.text = m_CurrentScore.ToString();
    }

    public void ChangeScore(int amount)
    {
        m_CurrentScore += amount;
        m_TextScore.text = m_CurrentScore.ToString();
    }

}
