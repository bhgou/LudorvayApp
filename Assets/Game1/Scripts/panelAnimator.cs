using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelAnimator : MonoBehaviour
{

	[Header("In Animation")]

	[Tooltip("From (0,0) to (1,1), the curve used by the animation")]
	public AnimationCurve _inAnim;

	[Tooltip("How long this Animation should take (Seconds)")]
	public float _inAnimDuration;

	[Tooltip("What is the final position of this Animation?")]
	public Vector3 _inAnimEndPosition;

	[Header("Out Animation")]

	[Tooltip("From (0,0) to (1,1), the curve used by the animation")]
	public AnimationCurve _outAnim;

	[Tooltip("How long this Animation should take (Seconds)")]
	public float _outAnimDuration;

	[Tooltip("What is the final position of this Animation?")]
	public Vector3 _outAnimEndPosition;

	[Header("Animation Controllers")]

	[Tooltip("Should the object begin off-screen?")]
	public bool _startOffScreen;

	[Tooltip("When the scene starts, should this panel animate in?")]
	public bool _AnimateInOnStart;

	//[Tooltip("When this object is animated and visible on screen")]
	public bool _animate;

	[Tooltip("The RectTransform of the UI Object")]
	private RectTransform _animObject;
	public enum AnimState
	{
		none,
		into,
		outro
	}
	private AnimState _animState;
	private Vector3 _animStartPosition;
	private float _animationStartTime;
	private float _animationEndTime;

	public void Awake()
	{
		_animState = AnimState.none;
	}


	void Start()
	{
		_animObject = GetComponent<RectTransform>();

		if (_startOffScreen)
			_animObject.localPosition = _outAnimEndPosition;

		if (_AnimateInOnStart)
		{
			_animObject.localPosition = _outAnimEndPosition;
			StartAnimIn();
		}
	}

	void Update()
	{
		switch (_animState)
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
					// do nothing
					break;
				}
		}
	}


	public void StartAnimIn()
	{

		_animState = AnimState.none;
		_animationStartTime = Time.timeSinceLevelLoad;
		_animationEndTime = Time.timeSinceLevelLoad + _inAnimDuration;
		_animStartPosition = _animObject.localPosition;
		_animState = AnimState.into;
		_animate = true;
	}


	public void StartAnimOut()
	{

		_animState = AnimState.none;
		_animationStartTime = Time.timeSinceLevelLoad;
		_animationEndTime = Time.timeSinceLevelLoad + _outAnimDuration;
		_animStartPosition = _animObject.localPosition;
		_animState = AnimState.outro;
		_animate = false;
	}

	private void AnimateIn()
	{

		if (_animationEndTime >= Time.timeSinceLevelLoad)
		{

			float curveValue = _inAnim.Evaluate((Time.timeSinceLevelLoad - _animationStartTime) / (_animationEndTime - _animationStartTime));

			_animObject.localPosition = Vector3.LerpUnclamped(_animStartPosition, _inAnimEndPosition, curveValue);
		}
		else
		{
			_animObject.localPosition = _inAnimEndPosition;
			_animState = AnimState.none;
		}
	}

	private void AnimateOut()
	{

		if (_animationEndTime >= Time.timeSinceLevelLoad)
		{

			float curveValue = _inAnim.Evaluate((Time.timeSinceLevelLoad - _animationStartTime) / (_animationEndTime - _animationStartTime));


			_animObject.localPosition = Vector3.LerpUnclamped(_animStartPosition, _outAnimEndPosition, curveValue);
		}
		else
		{

			_animObject.localPosition = _outAnimEndPosition;
			_animState = AnimState.none;
		}
	}
}