using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUIView : MonoBehaviour
{
    public TMP_Text unitNameText;
    public TMP_Text attackForceText;
    public Button attackButton;
    public Button addBuffButton;

    [Header("Sliders")]
    public Slider hpSlider;
    public Slider armorSlider;
    public Slider vampirismSlider;

    [Header("TextCounters")]
    public TMP_Text hpCounter;
    public TMP_Text armorCounter;
    public TMP_Text vampirismCounter;


    [Header("Buffs")]
    public GameObject doubleBuffIcon;
    public TMP_Text doubleBuffRoundsLeftText;

    public GameObject ArmorSelfBuffIcon;
    public TMP_Text ArmorSelfBuffRoundsLeftText;

    public GameObject ArmorDestructionBuffIcon;
    public TMP_Text ArmorDestructionBuffRoundsLeftText;

    public GameObject VampirismSelfBuffBuffIcon;
    public TMP_Text VampirismSelfBuffRoundsLeftText;

    public GameObject VampirismDecreaseBuffIcon;
    public TMP_Text VampirismDecreaseBuffRoundsLeftText;

}
