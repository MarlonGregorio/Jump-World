using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CameraFollow: MonoBehaviour {

  public GameObject target;
  public float screen;
  private Transform t;
  private bool willLock;
  private int lockCounter;
  public Vector3 minCameraPosition;
  public Vector3 maxCameraPosition;
  public static bool camExists;
  [Space]
  public int currentZone;
  public float smoothSpeed;

  void Awake() {
    var cam = GetComponent < Camera > ();
    screen = Screen.height;
    cam.orthographicSize = 72;

    if (screen == 900) {
      cam.orthographicSize = 75;
    }
  }

  // Use this for initialization
  void Start() {
    Application.targetFrameRate = 60;

    if (!camExists) {
      camExists = true;
      DontDestroyOnLoad(transform.gameObject);
    } else {
      Destroy(gameObject);
    }
  }

  // Update is called once per frame
  void FixedUpdate() {
    t = target.transform;
    if (target != null) {
      Vector3 desiredPos = t.position - new Vector3(0, -18.03648 f, 10);
      Vector3 smoothedPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed);
      transform.position = smoothedPos;
      transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPosition.x, maxCameraPosition.x),
        Mathf.Clamp(transform.position.y, minCameraPosition.y, maxCameraPosition.y),
        Mathf.Clamp(transform.position.z, minCameraPosition.z, maxCameraPosition.z));
    }
  }
}