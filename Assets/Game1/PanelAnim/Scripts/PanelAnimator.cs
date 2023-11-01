using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelAnimator : MonoBehaviour {
    
	[Header ("In Animation")]

    [Tooltip("From (0,0) to (1,1), the curve used by the animation")]
	public AnimationCurve inAnim;

    [Tooltip("How long this Animation should take (Seconds)")]
	public float inAnimDuration;

    [Tooltip("What is the final position of this Animation?")]
	public Vector3 inAnimEndPosition;

	[Header("Out Animation")]

    [Tooltip("From (0,0) to (1,1), the curve used by the animation")]
	public AnimationCurve outAnim;

    [Tooltip("How long this Animation should take (Seconds)")]
	public float outAnimDuration;

    [Tooltip("What is the final position of this Animation?")]
	public Vector3 outAnimEndPosition;

	[Header("Animation Controllers")]

    [Tooltip("Should the object begin off-screen?")]
	public bool startOffScreen;

    [Tooltip("When the scene starts, should this panel animate in?")]
    public bool AnimateInOnStart;

	[Tooltip("When this object is animated and visible on screen")]
	public bool _animate = false;

    [Tooltip("The RectTransform of the UI Object")]

	private RectTransform animObject;
	public enum AnimState
	{
        none,
		into,
		outro
	}
	private AnimState animState;
	private Vector3 animStartPosition;
    private float animationStartTime;
	private float animationEndTime;

	public void Awake()
	{
		animState = AnimState.none;
	}

	
	void Start () 
    {
        animObject = GetComponent<RectTransform>();

		if(startOffScreen)
			animObject.localPosition = outAnimEndPosition;

        if (AnimateInOnStart)
        {
            animObject.localPosition = outAnimEndPosition;
            StartAnimIn();
        }
	}
	
	
	void Update () 
    {
		switch(animState)
		{
			case AnimState.into:
			{
				AnimateIn();
				break;
			}
			case AnimState.outro:
			{
				AnimateOut();
				break;
			}
			case AnimState.none:
			{
				
				break;
			}
		}
	}

    
	public void StartAnimIn()
	{
        
        animState = AnimState.none;
        animationStartTime = Time.timeSinceLevelLoad;
        animationEndTime = Time.timeSinceLevelLoad + inAnimDuration;
		animStartPosition = animObject.localPosition;
        animState = AnimState.into;
		_animate = true;
	}

    
	public void StartAnimOut()
	{
        
        animState = AnimState.none;
        animationStartTime = Time.timeSinceLevelLoad;
		animationEndTime = Time.timeSinceLevelLoad + outAnimDuration;
		animStartPosition = animObject.localPosition;
        animState = AnimState.outro;
		_animate = false;
	}

    private void AnimateIn()
	{
        
        if (animationEndTime >= Time.timeSinceLevelLoad)
        {
            
            float curveValue = inAnim.Evaluate((Time.timeSinceLevelLoad - animationStartTime) / (animationEndTime - animationStartTime));

            
            animObject.localPosition = Vector3.LerpUnclamped(animStartPosition, inAnimEndPosition, curveValue);
        }
		else
		{
			
			animObject.localPosition = inAnimEndPosition;
            animState = AnimState.none;
		}
	}

	private void AnimateOut()
	{
        
		if(animationEndTime >= Time.timeSinceLevelLoad)
		{
            
            float curveValue = inAnim.Evaluate((Time.timeSinceLevelLoad - animationStartTime) / (animationEndTime - animationStartTime));

			
            animObject.localPosition = Vector3.LerpUnclamped(animStartPosition, outAnimEndPosition, curveValue);
		}
		else
		{
			
            animObject.localPosition = outAnimEndPosition; 
			animState = AnimState.none;
		}
	}
}
