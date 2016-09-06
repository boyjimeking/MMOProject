using UnityEngine;
using System.Collections;

public class AbstractMonoBehaviour : MonoBehaviour 
{
	void Awake () 
	{
		OnAwake ();
	}

	protected virtual void OnAwake ()
	{
	}
	
	void Update () 
	{
		OnUpdate ();
	}

	protected virtual void OnUpdate ()
	{
	}

}
