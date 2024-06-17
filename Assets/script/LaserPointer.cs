using UnityEngine;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour
{
    public float laserRange = 100f; // 雷射射程
    public Camera playerCamera; // 玩家相機
    public LineRenderer laserLineRenderer; // 雷射線渲染器
    public Text targetNameText; // 用於顯示打到的物品名稱的UI文本

    void Start()
    {
        // 確保LineRenderer已經設置
        if (laserLineRenderer == null)
        {
            laserLineRenderer = GetComponent<LineRenderer>();
        }

        // 確保玩家相機已經設置
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        // 啟用雷射線
        laserLineRenderer.enabled = true;
        laserLineRenderer.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, laserRange))
        {
            // 雷射打到物體
            laserLineRenderer.SetPosition(1, hit.point);

            // 顯示物體名稱
            targetNameText.text = hit.collider.gameObject.name;
            Debug.Log("打到"+ hit.collider.gameObject.name);
        }
        else
        {
            // 雷射未打到物體
            laserLineRenderer.SetPosition(1, ray.origin + ray.direction * laserRange);

            // 清空物體名稱
            targetNameText.text = "";
        }
    }
}
