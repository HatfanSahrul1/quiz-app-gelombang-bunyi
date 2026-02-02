using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ScriptableObject untuk menampung array Sprite
[CreateAssetMenu(fileName = "MateriContainer", menuName = "QuizApp/MateriContainer", order = 1)]
public class MateriContainer : ScriptableObject
{
	[SerializeField]
	private Sprite[] sprites;

	// Getter untuk mengambil Sprite berdasarkan index
	public Sprite GetSprite(int index)
	{
		if (sprites == null || index < 0 || index >= sprites.Length)
			return null;
		return sprites[index];
	}

	// Getter untuk mengambil semua Sprite
	public Sprite[] GetAllSprites()
	{
		return sprites;
	}
}
