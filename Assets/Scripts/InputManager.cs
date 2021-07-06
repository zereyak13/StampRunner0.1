using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
	public static InputManager Instance { get; private set; } = null;

	[SerializeField] float screenWorldMult = 2f;

	public bool IsTapActive { get; private set; } = false;
	public float TargetX { get; private set; } = 0f;

	#region Private Variables

	bool isTouchScreen = false;
	float startX;


	private const float platformLimit = 2f;

	#endregion

	#region MonoBehaviour

	private void Awake()
	{
		Instance = this;

		if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
		{
			isTouchScreen = true;
		}

		TargetX = 0f;
	}

	private void Update()
	{
		/*
		if (GameManager.Instance == null)
			return;

		if (GameManager.Instance.GameState != GameManager.GameStates.TapToStart
			&& !GameManager.Instance.IsGameRunning)
			return;
		*/
		if (isTouchScreen)
			CheckTouches();
		else
			CheckMouse();
	}

	#endregion

	#region Public Functions

	public void ResetInput(float userX)
	{
		TargetX = userX;
	}

	#endregion

	#region Private Functions

	void CheckMouse()
	{
		if (Input.GetMouseButtonDown(0))
		{
			startX = Input.mousePosition.x;
			IsTapActive = true;
			return;
		}

		if (Input.GetMouseButtonUp(0))
		{
			OnTouchEnd();
			return;
		}

		if (Input.GetMouseButton(0))
			UpdateTargetX(Input.mousePosition.x);
	}

	void CheckTouches()
	{
		if (Input.touchCount <= 0)
			return;

		switch (Input.touches[0].phase)
		{
			case TouchPhase.Began:
				IsTapActive = true;
				startX = Input.mousePosition.x;
				break;
			case TouchPhase.Moved:
				UpdateTargetX(Input.GetTouch(0).position.x);
				break;
			case TouchPhase.Canceled:
			case TouchPhase.Ended:
				OnTouchEnd();
				break;
		}
	}

	void UpdateTargetX(float x)
	{
		if (Mathf.Abs(x - startX) > 0.01f)
		{
			TargetX += (x - startX) * screenWorldMult / Screen.width;
			TargetX = Mathf.Clamp(TargetX
					, -platformLimit
					, platformLimit);
		}

		startX = x;
	}

	void OnTouchEnd()
	{
		IsTapActive = false;
	}

	#endregion
}