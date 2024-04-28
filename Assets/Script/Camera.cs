using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; // Transform ของตัวละครที่เราต้องการให้กล้องตาม
    public float distanceFromTarget = 10f; // ระยะห่างของกล้องจาก GameObject ที่กำหนด

    void LateUpdate()
    {
        if (target != null)
        {
            // ตำแหน่งที่กล้องจะเลื่อนไป (พร้อมกับระยะทาง Z เพื่อให้กล้องมองไปที่สิ่งที่ตาม)
            Vector3 desiredPosition = target.position + new Vector3(0, 0, -distanceFromTarget);
            transform.position = desiredPosition; // ตั้งค่าตำแหน่งของกล้องให้เป็นตำแหน่งที่ต้องการ
        }
    }
}
