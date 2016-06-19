using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FlotatingDamageScript : MonoBehaviour {
    public Animator animator;
    private Text DamageText;

    void OnEnable()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length);
        DamageText = animator.GetComponent<Text>();

    }

    public void SetText(string text)
    {
        DamageText.text = text;
    }
}
