using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";   
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    static Vector3 spawningPosition = Vector3.zero;

    private Transform _selection;

    // Update is called once per frame
    private void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null; 
        }
        
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if  (Physics.Raycast(ray, out hit, 2))
        {
            
            var selection = hit.transform;
            if (selection.CompareTag(selectableTag))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    
                    selectionRenderer.material = highlightMaterial;
                    spawningPosition = hit.transform.position;
                    Vector3 objColliderCenter = hit.collider.bounds.center;
                    Debug.Log($"Found: {hit.transform.name} | Position: {spawningPosition} | ColliderCenter: {objColliderCenter}");
                }

                _selection = selection;
            }
            

        }
    }
}
