using UnityEngine;
using System.Collections;

public class WeaponActions : MonoBehaviour {

	public Weapon weapon;

	void Start () {}

	void Update () {
		Vector3 forward = weapon.rayCaster.transform.TransformDirection (Vector3.forward) * weapon.range;
		Debug.DrawRay (weapon.rayCaster.transform.position, forward, Color.green);
		RaycastHit hit;
		Recoil ();
		if (Input.GetKeyDown (KeyCode.R) && weapon.ammoReserve >= 1 && weapon.ammoInClip < weapon.clipSize) {
			StartCoroutine(Reload ());
		}
		if (weapon.type == Weapon.weaponType.semi && Input.GetMouseButtonDown (0) && weapon.ammoInClip >= 1) {
			weapon.ammoInClip --;
			weapon.muzzleFlash.Stop ();
			weapon.fireSound.Stop ();
			weapon.muzzleFlash.Play ();
			weapon.fireSound.Play ();
			if (Physics.Raycast (weapon.rayCaster.transform.position, forward, out hit, weapon.range)) {
				Instantiate (weapon.bullethole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
			}
			weapon.recoil += Time.deltaTime/(60/weapon.RPM);
		}
		if (weapon.type == Weapon.weaponType.auto && Input.GetMouseButton (0) && weapon.ammoInClip >= 1) {
			int aIC = (int)weapon.ammoInClip;
			weapon.ammoInClip -= Time.deltaTime/(60/weapon.RPM);
			if (aIC == (int)weapon.ammoInClip + 1) {
				weapon.muzzleFlash.Stop ();
				weapon.fireSound.Stop ();
				weapon.muzzleFlash.Play ();
				weapon.fireSound.Play ();
				if (Physics.Raycast (weapon.rayCaster.transform.position, forward, out hit, weapon.range))  {
					Instantiate (weapon.bullethole, hit.point, Quaternion.FromToRotation (Vector3.up, hit.normal));
				}
				weapon.recoil += Time.deltaTime/(60/weapon.RPM);
			}
		}
	}

	void OnGUI() {
		GUILayout.Label("Weapon : " + weapon.name);
		GUILayout.Label("Ammo in Clip : " + (int)weapon.ammoInClip);
		GUILayout.Label("Ammo in Reserve : " + (int)weapon.ammoReserve);
	}
		

	IEnumerator Reload() {
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
		weapon.reloadSound.Stop ();
	}

	void Recoil() {
		if (weapon.recoil > 0) {
			var maxRecoil = Quaternion.Euler(weapon.maxRecoilX+Random.Range( -5, 5), weapon.maxRecoilY+Random.Range(-5, 5), 0);
			weapon.model.transform.localRotation = Quaternion.Slerp(weapon.model.transform.localRotation, maxRecoil, Time.deltaTime*weapon.recoilRate);
			weapon.model.transform.localEulerAngles = new Vector3(weapon.model.transform.localEulerAngles.x, weapon.model.transform.localEulerAngles.y, weapon.model.transform.localEulerAngles.z);
			weapon.recoil -= Time.deltaTime/(60/weapon.RPM);
		}
		else
		{
			weapon.recoil = 0;
			var minRecoil = Quaternion.Euler(0, 0, 0);
			weapon.model.transform.localRotation = Quaternion.Slerp(weapon.model.transform.localRotation, Quaternion.identity, Time.deltaTime*weapon.recoilRate);
			weapon.model.transform.localEulerAngles = new Vector3(weapon.model.transform.localEulerAngles.x, weapon.model.transform.localEulerAngles.y, weapon.model.transform.localEulerAngles.z);
		}
	}

}

[System.Serializable]
public class Weapon {
	public string name;
	public GameObject model;
	public AudioSource fireSound;
	public AudioSource reloadSound;
	public ParticleSystem muzzleFlash;
	public GameObject rayCaster;
	public GameObject bullethole;
	public enum weaponAmmo {pistol = 0, shotgun = 1, autorifle = 2};
	public weaponAmmo ammo;
	public enum weaponType {semi = 0, auto = 1};
	public weaponType type;
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
}