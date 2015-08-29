#pragma strict

//宣告 : 使用介面模版、武器是一個遊戲物件、武器的顯示狀態(是/否)
var mySkin : GUISkin;
var myWeapon : GameObject;
var WeaponClosed : boolean = false;

//功能 : 如果關閉狀態為否(顯示中)，則按下按鈕時，關閉武器顯示
//如果果關閉狀態為是(已關閉)，則按下按鈕時，開啟武器顯示
function OnGUI()
{
   GUI.skin = mySkin;
   if((WeaponClosed == false) && (GUI.Button(Rect(10, 150, 160, 30), "關閉盾牌")))
   {
     myWeapon.active= false;
      WeaponClosed = true;
    //  var hinge : Animator;
      //hinge = myWeapon.GetComponent("Animator");
     //hinge.active = false;
   }
   
   else if((WeaponClosed == true) && (GUI.Button(Rect(10, 150, 160, 30), "開啟盾牌")))
   {
     // myWeapon.active = true;
      WeaponClosed = false;
   }
}