using UnityEngine;

public class ParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
	private float curTime = 0.0f;
	private bool isActive = false;
	
	public void ActivateForTime(float time){
		var em = particle.emission;
		em.enabled = true;
		isActive = true;
		curTime = time;
	}
	private void DisableOnExpire(){
		var em = particle.emission;
		em.enabled = false;
	}
	
	private void Update(){
		if(isActive){
			if(curTime > 0.0f){
				curTime -= Time.deltaTime;
			}else{
				DisableOnExpire();
				isActive = false;
			}
		}
	}
}
