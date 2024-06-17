using UnityEngine;
using UnityEngine.UI;

public class LaserPointer : MonoBehaviour
{
    public float laserRange = 100f; // �p�g�g�{
    public Camera playerCamera; // ���a�۾�
    public LineRenderer laserLineRenderer; // �p�g�u��V��
    public Text targetNameText; // �Ω���ܥ��쪺���~�W�٪�UI�奻

    void Start()
    {
        // �T�OLineRenderer�w�g�]�m
        if (laserLineRenderer == null)
        {
            laserLineRenderer = GetComponent<LineRenderer>();
        }

        // �T�O���a�۾��w�g�]�m
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

        // �ҥιp�g�u
        laserLineRenderer.enabled = true;
        laserLineRenderer.SetPosition(0, ray.origin);

        if (Physics.Raycast(ray, out hit, laserRange))
        {
            // �p�g���쪫��
            laserLineRenderer.SetPosition(1, hit.point);

            // ��ܪ���W��
            targetNameText.text = hit.collider.gameObject.name;
            Debug.Log("����"+ hit.collider.gameObject.name);
        }
        else
        {
            // �p�g�����쪫��
            laserLineRenderer.SetPosition(1, ray.origin + ray.direction * laserRange);

            // �M�Ū���W��
            targetNameText.text = "";
        }
    }
}
