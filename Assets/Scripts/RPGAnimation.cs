using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGAnimation
{
    private GameObject subject;
    private Vector2 endPos;
    private string animationTitle;
    private float duration;
    private RPGAnimation next;
    private float count;
    private Vector2 startPos;

    public RPGAnimation(Vector2 eP, string aT, float d)
    {
        subject = null;
        animationTitle = aT;
        endPos = eP;
        duration = d;
        next = null;
    }
    public RPGAnimation(Vector2 eP, string aT, float d, RPGAnimation n)
    {
        subject = null;
        endPos = eP;
        animationTitle = aT;
        duration = d;
        next = n;
    }
    public RPGAnimation(GameObject s, RPGAnimation baseAnimation)
    {
        subject = s;
        endPos = baseAnimation.endPos;
        animationTitle = baseAnimation.animationTitle;
        duration = baseAnimation.duration;
        next = baseAnimation.next;
        count = 0;
        startPos = new Vector2(subject.transform.position.x, subject.transform.position.y);
    }

    public RPGAnimation GetNextAnimation()
    {
        return(next);
    }

    public bool Animate(float time)
    {
        count += time;
        subject.transform.position = Vector3.Lerp(startPos, endPos, time / duration);
        Animator subjectAnimator = subject.GetComponent<Animator>();
        if (subjectAnimator != null)
        {
            subjectAnimator.SetTrigger(animationTitle);
        }
        return (count >= duration);
    }
}
