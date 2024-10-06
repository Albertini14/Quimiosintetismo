using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scr_Game_Manager : MonoBehaviour
{
	public int targetFrameRate = 30;
	[SerializeField] int CurrentLevel = 1;
	[SerializeField] float Goal = 3;
	[SerializeField] TextMeshProUGUI health;
	[SerializeField] TextMeshProUGUI progress;
	[SerializeField] Upgrade upgrade1;
	[SerializeField] Upgrade upgrade2;

	[SerializeField] GameObject button1;
	[SerializeField] GameObject button2;

	private void Start()
	{
		Scr_Player_Stats scr = FindObjectOfType<Scr_Player_Stats>();
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = targetFrameRate;
		scr.Level = CurrentLevel;
		scr.checkSkills();
		scr.Evolve_Goal = Goal;
		scr.txt_health = health;
		scr.txt_progress = progress;
		scr.GainXp(0);

		button1.GetComponent<Button>().onClick.AddListener(() => Onclick(upgrade1));
		button2.GetComponent<Button>().onClick.AddListener(() => Onclick(upgrade2));
	}

	public void RestartScene(){
		SceneManager.LoadScene(CurrentLevel -1 );
	}

	public void Onclick(Upgrade upgrade){
		upgrade.Buy(upgrade);
		button1.SetActive(false);
		button2.SetActive(false);
	}

	public void Onclick(Skill upgrade)
	{
		upgrade.Buy(upgrade);
		button1.SetActive(false);
		button2.SetActive(false);
	}
}
