using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    //sorry for terrible dependencies but we do need to release something :D
    public static int score;
    public TextMeshProUGUI score_text;
    public WitchMovement PlayerRef;
    public Slider FuelSliderRef;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FuelSliderRef.value = PlayerRef.Fuel;
        score_text.text = score.ToString();
    }
}
