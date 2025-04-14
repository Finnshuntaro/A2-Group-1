using UnityEngine;
using TMPro;

public class NumberTextGoUp : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    int counter;

    public void ButtonPressed()
    {
        counter++;
        numberText.text = counter + "";
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
