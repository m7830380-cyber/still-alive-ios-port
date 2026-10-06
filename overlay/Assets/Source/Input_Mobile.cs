namespace MEdge.Engine
{
	using TdGame;
	using UnityEngine;
	public static partial class Input_Unity
	{
#if UNITY_IOS || UNITY_ANDROID
		static int moveFingerId = -1;
		static int lookFingerId = -1;
		static Vector2 moveTouchOrigin;
		static Vector2 lookTouchPrev;

		static void SampleMobileInput(TdPlayerInput uInput, TdPlayerController controller, float dt)
		{
			for (var i = 0; i < UnityEngine.Input.touchCount; i++)
			{
				var touch = UnityEngine.Input.GetTouch(i);
				var x = touch.position.x / Screen.width;

				if (touch.phase == TouchPhase.Began)
				{
					if (x < 0.45f && moveFingerId < 0)
					{
						moveFingerId = touch.fingerId;
						moveTouchOrigin = touch.position;
					}
					else if (x > 0.55f && lookFingerId < 0)
					{
						lookFingerId = touch.fingerId;
						lookTouchPrev = touch.position;
					}
				}
			}

			if (moveFingerId >= 0)
			{
				var found = false;
				for (var i = 0; i < UnityEngine.Input.touchCount; i++)
				{
					var touch = UnityEngine.Input.GetTouch(i);
					if (touch.fingerId != moveFingerId)
						continue;
					found = true;
					if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
					{
						moveFingerId = -1;
						break;
					}

					var delta = (touch.position - moveTouchOrigin) / (Screen.height * 0.25f);
					UpdateAxisValue(ref uInput.aBaseY, Mathf.Clamp(delta.y, -1f, 1f), dt, Speed: 1f);
					UpdateAxisValue(ref uInput.aStrafe, Mathf.Clamp(delta.x, -1f, 1f), dt, Speed: 1f);
				}

				if (!found)
					moveFingerId = -1;
			}

			if (lookFingerId >= 0)
			{
				var found = false;
				for (var i = 0; i < UnityEngine.Input.touchCount; i++)
				{
					var touch = UnityEngine.Input.GetTouch(i);
					if (touch.fingerId != lookFingerId)
						continue;
					found = true;
					if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
					{
						lookFingerId = -1;
						break;
					}

					if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary)
					{
						var delta = touch.position - lookTouchPrev;
						lookTouchPrev = touch.position;
						if (delta.sqrMagnitude > 0f)
						{
							uInput.bXAxis += 1;
							uInput.bYAxis += 1;
							UpdateAxisValue(ref uInput.aMouseX, delta.x * 0.15f, dt);
							UpdateAxisValue(ref uInput.aMouseY, delta.y * 0.15f, dt);
						}
					}
				}

				if (!found)
					lookFingerId = -1;
			}

			// Bottom overlay buttons (simple regions — tune in play mode)
			if (UnityEngine.Input.touchCount > 0)
			{
				for (var i = 0; i < UnityEngine.Input.touchCount; i++)
				{
					var t = UnityEngine.Input.GetTouch(i);
					if (t.phase != TouchPhase.Began)
						continue;
					var p = t.position;
					if (p.y > Screen.height * 0.82f && p.x > Screen.width * 0.72f)
						uInput.Jump();
					if (p.y > Screen.height * 0.82f && p.x > Screen.width * 0.55f && p.x < Screen.width * 0.72f)
						uInput.Crouch();
					if (p.y > Screen.height * 0.82f && p.x > Screen.width * 0.38f && p.x < Screen.width * 0.55f)
						controller.UsePress();
				}
			}
		}
#endif
	}
}
