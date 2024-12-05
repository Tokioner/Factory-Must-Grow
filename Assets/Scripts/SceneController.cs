using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public void LoadScene(int id){
		SceneManager.LoadScene(id);
	}
	public void Exit(){
		Application.Quit();
	}
}
