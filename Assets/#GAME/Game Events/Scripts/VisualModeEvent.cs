using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Visual Mode Event", menuName = "ScriptableObjects/Visual Mode Event", order = 1)]

public class VisualModeEvent : ScriptableObject
{
	public enum VisualMode
    {
		visualSprite,
		visual3D
    }
	
	private List<VisualModeEventListener> listeners =
		new List<VisualModeEventListener>();

	public void Raise(VisualMode mode)
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners[i].OnEventRaised(mode);
	}

	public void RegisterListener(VisualModeEventListener listener)
	{ listeners.Add(listener); }

	public void UnregisterListener(VisualModeEventListener listener)
	{ listeners.Remove(listener); }
}

