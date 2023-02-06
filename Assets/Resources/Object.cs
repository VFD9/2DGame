using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Object : MonoBehaviour, Interface
{
	protected string Name;
	protected int Hp;
	protected int Atk;
	protected Animator ObjectAnim;
	public GameObject _Object;

	// ���� ���� �Լ� Initialize(), Progress(), Release()
	public abstract void Initialize();
	public abstract void Progress();
	public abstract void Release();
}
