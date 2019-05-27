using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(AudioSource))]

public class InitialCredits : MonoBehaviour {
	public Graphic backgroundImage, companyLogo, extraImage, gameLogo, gameDescription,loadingText;
	public int sceneToGo;
	public string sceneToGoText;
	[Range(0,10)]
	public float timeToWait,fadeTime;
	public AudioClip audiocompanyLogo;
	void Start () {
		Vector4 newcolor;
		Camera.main.clearFlags = CameraClearFlags.SolidColor;
		newcolor = new Vector4(Camera.main.backgroundColor.r,Camera.main.backgroundColor.g,Camera.main.backgroundColor.b,0);
		Camera.main.backgroundColor = newcolor;
		newcolor = new Vector4(backgroundImage.color.r,backgroundImage.color.g,backgroundImage.color.b,1);
		backgroundImage.color = newcolor;
		newcolor = new Vector4 (companyLogo.color.r, companyLogo.color.g, companyLogo.color.b,1);
		companyLogo.color = newcolor;
		newcolor = new Vector4 (extraImage.color.r, extraImage.color.g, extraImage.color.b,1);
		extraImage.color = newcolor;
		newcolor = new Vector4(gameLogo.color.r,gameLogo.color.g,gameLogo.color.b,1);
		gameLogo.color = newcolor;
		backgroundImage.CrossFadeAlpha (0f, 0f, true);
		companyLogo.CrossFadeAlpha (0f, 0f, true);
		extraImage.CrossFadeAlpha (0f, 0f, true);		
		gameLogo.CrossFadeAlpha (0f, 0f, true);
		gameDescription.CrossFadeAlpha (0f, 0f, true);
		loadingText.gameObject.SetActive(false);
		StartCoroutine (Begin());
	}

	IEnumerator Begin(){
		// companyLogo loop
		yield return new WaitForSeconds(0.001f);
		backgroundImage.CrossFadeAlpha (1f, fadeTime, true);
		companyLogo.CrossFadeAlpha (1f, fadeTime, true);
		yield return new WaitForSeconds(fadeTime);

		if (GetComponent<AudioSource> ()) GetComponent<AudioSource> ().PlayOneShot (audiocompanyLogo);
		yield return new WaitForSeconds(timeToWait);

		companyLogo.CrossFadeAlpha (0f, fadeTime, true);
		extraImage.CrossFadeAlpha (1f, fadeTime, true);
		yield return new WaitForSeconds(fadeTime);
		extraImage.CrossFadeAlpha (0f, fadeTime, true);
		backgroundImage.CrossFadeAlpha (0f, fadeTime, true);
		yield return new WaitForSeconds(fadeTime);

		// gamelogo loop
		yield return new WaitForSeconds(fadeTime);
		backgroundImage.CrossFadeAlpha (1f, fadeTime, true);
		gameLogo.CrossFadeAlpha (1f, fadeTime, true);
		gameDescription.CrossFadeAlpha (1f, fadeTime, true);
		yield return new WaitForSeconds(fadeTime);
		yield return new WaitForSeconds(timeToWait);
		backgroundImage.CrossFadeAlpha (0f, fadeTime, true);
		gameLogo.CrossFadeAlpha (0f, fadeTime, true);
		gameDescription.CrossFadeAlpha (0f, fadeTime, true);
		yield return new WaitForSeconds(fadeTime);
		loadingText.gameObject.SetActive(true);
		//SceneManager.LoadSceneAsync(sceneToGo);
		SceneManager.LoadScene(sceneToGoText);
	}
}
