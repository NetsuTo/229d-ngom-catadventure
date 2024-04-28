using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Transform �ͧ����Ф÷����ҵ�ͧ��������ͧ���
    public float distanceFromTarget = 10f; // ������ҧ�ͧ���ͧ�ҡ GameObject ����˹�

    void LateUpdate()
    {
        if (target != null)
        {
            // ���˹觷����ͧ������͹� (������Ѻ���зҧ Z ���������ͧ�ͧ价����觷����)
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -distanceFromTarget);
            transform.position = desiredPosition; // ��駤�ҵ��˹觢ͧ���ͧ����繵��˹觷���ͧ���
        }
    }
}
