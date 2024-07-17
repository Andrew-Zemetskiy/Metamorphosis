using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlLayout : MonoBehaviour
{
	//настройка схемы управления
	public InputField forward;
	public InputField back;
	public InputField left;
	public InputField right;
	private void Start()
	{
		//стандартная раскладка управления
		forward.text = PlayerPrefs.GetString("Key-forward");
		back.text = PlayerPrefs.GetString("Key-back");
		left.text = PlayerPrefs.GetString("Key-left");
		right.text = PlayerPrefs.GetString("Key-right");
	}
	public void SetKey() //установка новой раскладки
	{
		PlayerPrefs.SetString("Key-forward", forward.text); //вперед
		PlayerPrefs.SetString("Key-back", back.text);   //назад
		PlayerPrefs.SetString("Key-left", left.text);   //влево
		PlayerPrefs.SetString("Key-right", right.text); //вправо
	}
	public void ResetKey() //сброс к стандартной
	{
		PlayerPrefs.SetString("Key-forward", "w");
		PlayerPrefs.SetString("Key-back", "s"); 
		PlayerPrefs.SetString("Key-left", "a");  
		PlayerPrefs.SetString("Key-right", "d");

		forward.text = PlayerPrefs.GetString("Key-forward");
		back.text = PlayerPrefs.GetString("Key-back");
		left.text = PlayerPrefs.GetString("Key-left");
		right.text = PlayerPrefs.GetString("Key-right");
		SetKey();
	}
}
