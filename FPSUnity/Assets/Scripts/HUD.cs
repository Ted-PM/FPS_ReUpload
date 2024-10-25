using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI bulletText;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateWaveUI(int wave)
    {
        waveText.SetText("Wave: " + wave);

    }

    public void UpdateAmoUI(int amo)
    {
        //if (amo <= 0)
        //{
        //    bulletText.SetText("Bullets: " + amo);
        //}

        bulletText.SetText("Bullets: " + amo);
    }
    
}
