using UnityEngine;
using System.Collections;

public class WeaponActions : MonoBehaviour {

	public Weapon weapon;
	public GameObject[] weapons = new GameObject[3];

	void Start () {
		weapons [0].SetActive (true);
		weapons [1].SetActive (false);
		weapons [2].SetActive (false);
	}//Start

	void Update () {
		Vector3 forward = weapon.rayCaster.transform.TransformDirection (Vector3.forward) * weapon.range;
		Debug.DrawRay (weapon.rayCaster.transform.position, forward, Color.green);
		RaycastHit hit;
		Recoil ();

		if (Input.GetKeyDown (KeyCode.C)) {
			if (weapons [0].activeSelf == true) {
				weapons [0].SetActive (false);
				weapons [1].SetActive (true);
			}
			else if (weapons [1].activeSelf == true) {
				weapons [1].SetActive (false);
				weapons [2].SetActive (true);
			}
			else {
				weapons [2].SetActive (false);
				weapons [0].SetActive (true);
			}
		}//weapon switching

		if (Input.GetKeyDown (KeyCode.R) || Input.GetMouseButtonDown (0)) {
			StopCoroutine ("Reload");
		}//stop reloading

		if (Input.GetKeyDown (KeyCode.R) && weapon.ammoReserve >= 1 && weapon.ammoInClip < weapon.clipSize) {
			StartCoroutine ("Reload");
		}//reloading

		if (weapon.mode == Weapon.fireMode.semi && Input.GetMouseButtonDown (0) && weapon.ammoInClip >= 1) {
			weapon.ammoInClip --;
			weapon.muzzleFlash.Stop ();
			weapon.fireSound.Stop ();
			weapon.muzzleFlash.Play ();
			weapon.fireSound.Play ();
			if (Physics.Raycast (weapon.rayCaster.transform.position, forward, out hit, weapon.range)) {
				if (hit.transform.tag == "Enemy") {
					weapon.bloodSplatter.transform.position = hit.point;
					weapon.bloodSplatter.Play ();
					EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth> ();
					if (enemyHealth != null) {
						enemyHealth.TakeDamage (weapon.DPB);
					}
				}
				else {
					Instantiate (weapon.bullethole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
				}
			}
			weapon.recoil += Time.deltaTime/(60/weapon.RPM);
		}//firing semi

		if (weapon.mode == Weapon.fireMode.auto && Input.GetMouseButton (0) && weapon.ammoInClip >= 1) {
			int aIC = (int)weapon.ammoInClip;
			weapon.ammoInClip -= Time.deltaTime/(60/weapon.RPM);
			if (aIC == (int)weapon.ammoInClip + 1) {
				weapon.muzzleFlash.Stop ();
				weapon.fireSound.Stop ();
				weapon.muzzleFlash.Play ();
				weapon.fireSound.Play ();
				if (Physics.Raycast (weapon.rayCaster.transform.position, forward, out hit, weapon.range)) {
					if (hit.transform.tag == "Enemy") {
						weapon.bloodSplatter.transform.position = hit.point;
						weapon.bloodSplatter.Play ();
						EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth> ();
						if (enemyHealth != null) {
							enemyHealth.TakeDamage (weapon.DPB);
						}
					}
					else {
						Instantiate (weapon.bullethole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
					}
				}
				weapon.recoil += Time.deltaTime/(60/weapon.RPM);
			}
		}//firing auto
	}//Update

	void OnGUI() {
		GUILayout.Label("Weapon : " + weapon.name);
		GUILayout.Label("Ammo in Clip : " + (int)weapon.ammoInClip);
		GUILayout.Label("Ammo in Reserve : " + (int)weapon.ammoReserve);
	}//OnGUI

	IEnumerator Reload() {
		if (weapon.type == Weapon.weaponType.shotgun) {
			for (int i = 0; weapon.ammoInClip != weapon.clipSize; i++) {
				weapon.reloadSound.Play ();
				yield return new WaitForSeconds (weapon.reloadTime);
				weapon.ammoReserve--;
				weapon.ammoInClip++;
			}
		}
		else {
			weapon.reloadSound.Play ();
			yield return new WaitForSeconds (weapon.reloadTime);
			if (weapon.ammoReserve >= weapon.clipSize) {
				weapon.ammoReserve -= (weapon.clipSize - weapon.ammoInClip);
				weapon.ammoInClip = weapon.clipSize;
			}
			else if (weapon.ammoReserve + weapon.ammoInClip > weapon.clipSize) {
				weapon.ammoReserve -= (weapon.clipSize - weapon.ammoInClip);
				weapon.ammoInClip = weapon.clipSize;
			}
			else {
				weapon.ammoInClip += weapon.ammoReserve;
				weapon.ammoReserve = 0;
			}
		}
	}//Reload

	void Recoil() {
		if (weapon.recoil > 0) {
			var maxRecoil = Quaternion.Euler(weapon.maxRecoilX+Random.Range( -5, 5), weapon.maxRecoilY+Random.Range(-5, 5), 0);
			transform.localRotation = Quaternion.Slerp(transform.localRotation, maxRecoil, Time.deltaTime*weapon.recoilRate);
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
			weapon.recoil -= Time.deltaTime/(60/weapon.RPM);
		}
		else
		{
			weapon.recoil = 0;
			transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.identity, Time.deltaTime*weapon.recoilRate);
			transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
		}
	}//Recoil

}//WeaponActions

[System.Serializable]
public class Weapon {
	public string name;
	public AudioSource fireSound;
	public AudioSource reloadSound;
	public ParticleSystem muzzleFlash;
	public ParticleSystem bloodSplatter;
	public GameObject rayCaster;
	public GameObject bullethole;
	public enum weaponType {pistol = 0, shotgun = 1, autorifle = 2};
	public weaponType type;
	public enum fireMode {semi = 0, auto = 1};
	public fireMode mode;
	public int DPB = 0;
	public float RPM = 0;
	public float clipSize = 0;
	public float ammoInClip = 0;
	public float reloadTime = 0;
	public float range = 0;
	public float recoil = 0;
	public float recoilRate = 0;
	public float maxRecoilX = 0;
	public float maxRecoilY = 0;
	public float ammoReserve = 0;
}//Weapon