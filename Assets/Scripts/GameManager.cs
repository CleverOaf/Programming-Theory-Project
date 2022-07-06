using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameManager : MonoBehaviour
{
    public Camera GameCamera;
    public GameObject Marker;

    private TextMeshProUGUI infoText;
    private Animal m_Selected = null;

    private void Start()
    {
        Marker.SetActive(false);
        infoText = GameObject.Find("Info Text").GetComponent<TextMeshProUGUI>();
    }

    public void HandleSelection()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            //the collider could be children of the animal, so we make sure to check in the parent
            var animal = hit.collider.GetComponentInParent<Animal>();
            m_Selected = animal;
            
            if (m_Selected != null)
            {
                infoText.text = animal.Info;
            }
        }
    }

    public void HandleAction()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            m_Selected.GoTo(hit.point);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleSelection();
        }
        else if (m_Selected != null && Input.GetMouseButtonDown(1))
        {
            //right click give order to the unit
            HandleAction();
        }

        if (Input.GetKeyDown(KeyCode.V))
        {
            m_Selected.Vocalize();
        }

        MarkerHandling();
    }

    // Handle displaying the marker above the unit that is currently selected (or hiding it if no unit is selected)
    void MarkerHandling()
    {
        if (m_Selected == null && Marker.activeInHierarchy)
        {
            Marker.SetActive(false);
            Marker.transform.SetParent(null);
        }
        else if (m_Selected != null && Marker.transform.parent != m_Selected.transform)
        {
            Marker.SetActive(true);
            Marker.transform.SetParent(m_Selected.transform, true);
            Marker.transform.localPosition = Vector3.zero;
            Marker.transform.localRotation = Quaternion.identity;
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
