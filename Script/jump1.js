#pragma strict

var StartDomino:GameObject; // 紀錄要推倒的骨牌
var force:float = 4.0f; // 推力

function Start()
{
 //  Physics.gravity = Vector3(0, -98.1, 0); // 設定重力加速度
}

function Update () 
{
   if (Input.GetKeyDown(KeyCode.A))   
          // 按key A
 StartDomino.GetComponent.<Rigidbody>().AddForce(0, force, 0, ForceMode.Impulse);
 
}
