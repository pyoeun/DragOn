using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice_Dragon : MonoBehaviour
{
    Dragon _dragon;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 클릭시
        {
            GameObject selectedObj = null;
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition); //레이캐스트로 오브제트 판단
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f);
            if (hit.collider != null)
            {
                GameObject clickObj = hit.collider.gameObject;
                selectedObj = clickObj;
            }
            if(selectedObj.tag == "Dragon")
            {
                _dragon = selectedObj.GetComponent<Dragon>();
                MainSingleton.dragon = _dragon;
                Choice.ChoiceD();
            }
        }
    }
}
