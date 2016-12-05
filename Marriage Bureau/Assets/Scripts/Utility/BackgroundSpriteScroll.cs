using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackgroundSpriteScroll : MonoBehaviour {

    public float waitTime;
    public Sprite[] spriteScrollList;

    private Animator animatorComponent;
    private SpriteRenderer currentSpriteRen;
    private float waitTimeStore;
    private int spriteScrollCounter;
    private bool isCoroutineRunning;

    private IEnumerator playAnimation()
    {
        yield return new WaitForSeconds(waitTime);
        animatorComponent.enabled = true;
        animatorComponent.Play("TransitionOut");
        yield return new WaitForSeconds(animatorComponent.runtimeAnimatorController.animationClips[0].length);
        //animatorComponent.Stop();
        currentSpriteRen.sprite = spriteScrollList[spriteScrollCounter++];
        animatorComponent.Play("TransitionIn");
        yield return new WaitForSeconds(animatorComponent.runtimeAnimatorController.animationClips[1].length);
        animatorComponent.Stop();
        animatorComponent.enabled = false;
        yield return new WaitForEndOfFrame();
        isCoroutineRunning = false;
        StopCoroutine("playAnimation");
    }

    private void Start()
    {
        animatorComponent = gameObject.GetComponent<Animator>();
        currentSpriteRen = gameObject.GetComponent<SpriteRenderer>();
        StartCoroutine("playAnimation");
        isCoroutineRunning = true;
        spriteScrollCounter = 1;
    }

    private void Update()
    {
        if(!isCoroutineRunning)
        {
            StartCoroutine("playAnimation");
            isCoroutineRunning = true;
        }

        if(spriteScrollCounter >= spriteScrollList.Length)
        {
            spriteScrollCounter = 0;
        }
    }
}
