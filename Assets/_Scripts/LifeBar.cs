using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour
{
    Image image;
    public Life targetLife;

    private void Awake()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = targetLife.amount / 300;
    }
}
