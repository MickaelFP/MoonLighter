using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputFields : MonoBehaviour
{
    [SerializeField] GameObject IF_Price1;
    [SerializeField] GameObject IF_Price2;
    [SerializeField] GameObject IF_Price3;
    [SerializeField] GameObject IF_Price4;

    public string input1;
    public string input2;
    public string input3;
    public string input4;

    public int price1;
    public int price2;
    public int price3;
    public int price4;

    public static InputFields Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Update()
    {
        ShowInputField();
        ConvertInputToPrice();
    }

    public void ShowInputStringValue(string parValue)
    {
        input1 = parValue;
    }
    public void ShowInputStringValue2(string parValue)
    {
        input2 = parValue;
    }
    public void ShowInputStringValue3(string parValue)
    {
        input3 = parValue;
    }
    public void ShowInputStringValue4(string parValue)
    {
        input4 = parValue;
    }

    private void ShowInputField()
    {
        if (GameManager.Instance.pSlot1ID == "Default") 
        { 
            IF_Price1.SetActive(false);
            input1 = "";
        }
        else IF_Price1.SetActive(true);

        if (GameManager.Instance.pSlot2ID == "Default") 
        { 
            IF_Price2.SetActive(false);
            input2 = "";
        }
        else IF_Price2.SetActive(true);

        if (GameManager.Instance.pSlot3ID == "Default") 
        { 
            IF_Price3.SetActive(false);
            input3 = "";
        }
        else IF_Price3.SetActive(true);

        if (GameManager.Instance.pSlot4ID == "Default") 
        { 
            IF_Price4.SetActive(false);
            input4 = "";
        }
        else IF_Price4.SetActive(true);
    }

    private void ConvertInputToPrice()
    {
        /*price1 = System.Convert.ToInt32(input1);
        price2 = System.Convert.ToInt32(input2);
        price3 = System.Convert.ToInt32(input3);
        price4 = System.Convert.ToInt32(input4);*/
        int.TryParse(input1, out price1);
        int.TryParse(input2, out price2);
        int.TryParse(input3, out price3);
        int.TryParse(input4, out price4);
    }
}
