using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public static ColorManager Instance;

    [SerializeField] private Material playerHeadMat;
    [SerializeField] private Material collectableInkMat;
    [SerializeField] private Material stampedPaperMat;
    [SerializeField] private GameObject WaterSplashGO;

    [SerializeField] private Texture[] playerHeadTextures;
    [SerializeField] private Texture[] stampedPaperTextures;

    Color redVariant = new Color(183f / 255f, 53f / 255f, 41f / 255f, 1);
    Color blueVariant = new Color(49f / 255f, 62f / 255f, 211f / 255f, 1);
    Color turquoiseVariant = new Color(66f / 255f, 183f / 255f, 144f / 255f, 1);
    Color greenVariant = new Color(51f / 255f, 190f / 255f, 87f / 255f, 1);

    private ParticleSystem.MainModule splashColor;
    private Color curColor;

    private void Awake()
    {
        Instance = this;
        splashColor = WaterSplashGO.transform.GetChild(0).GetComponent<ParticleSystem>().main;
    }

    private void Start()
    {
        collectableInkMat.color = blueVariant;
        playerHeadMat.SetTexture("_MainTex", playerHeadTextures[3]);
        stampedPaperMat.SetTexture("_MainTex", stampedPaperTextures[3]);
        splashColor.startColor = new ParticleSystem.MinMaxGradient(blueVariant);
        InkBar.Instance.SetBarColor(blueVariant);
        curColor = blueVariant;
    }

    public void SetColors(int brushColor)
    {
        SetCollectableInkColor(brushColor);
    }



    private void SetCollectableInkColor(int brushColor)
    {
        switch (brushColor)
        {
            case 0://Green variant
                collectableInkMat.color = greenVariant;
                playerHeadMat.SetTexture("_MainTex", playerHeadTextures[brushColor]);
                stampedPaperMat.SetTexture("_MainTex", stampedPaperTextures[brushColor]);
                splashColor.startColor = new ParticleSystem.MinMaxGradient(greenVariant);
                InkBar.Instance.SetBarColor(greenVariant);
                curColor = greenVariant;
                break;
            case 1://Red varint
                collectableInkMat.color = redVariant;
                playerHeadMat.SetTexture("_MainTex", playerHeadTextures[brushColor]);
                stampedPaperMat.SetTexture("_MainTex", stampedPaperTextures[brushColor]);
                splashColor.startColor = new ParticleSystem.MinMaxGradient(redVariant);
                InkBar.Instance.SetBarColor(redVariant);
                curColor = redVariant;
                break;
            case 2://Turquise variant
                collectableInkMat.color = turquoiseVariant;
                playerHeadMat.SetTexture("_MainTex", playerHeadTextures[brushColor]);
                stampedPaperMat.SetTexture("_MainTex", stampedPaperTextures[brushColor]);
                splashColor.startColor = new ParticleSystem.MinMaxGradient(turquoiseVariant);
                InkBar.Instance.SetBarColor(turquoiseVariant);
                curColor = turquoiseVariant;
                break;
            case 3://Blue variant
                collectableInkMat.color = blueVariant;
                playerHeadMat.SetTexture("_MainTex", playerHeadTextures[brushColor]);
                stampedPaperMat.SetTexture("_MainTex", stampedPaperTextures[brushColor]);
                splashColor.startColor = new ParticleSystem.MinMaxGradient(blueVariant);
                InkBar.Instance.SetBarColor(blueVariant);
                curColor = blueVariant;
                break;
        }
 
    }
     
    public Color GetCurrentColor()
    {
        return curColor;
    }
    //Set bar color
}
