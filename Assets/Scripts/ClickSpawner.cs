using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSpawner : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    Vector3 spawningPosition = Vector3.zero;

    private Transform _selection;

    public GameObject[] prefabs; //Prefabs to spawn
    int selectedPrefab = 0;
    public float Raydistance = 0f;

    public static int treeNumber;

    int tokens;
    void Start()
    {
        if (prefabs.Length == 0)
        {
            Debug.LogError("You haven't assigned any Prefabs to spawn");
        }

        tokens = PlayerPrefs.GetInt("Tokens", tokens);
    }
    private void Update()
    {

        
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }
        if ( tokens > 0)
        {
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Raydistance))
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
                        Vector3 objPosition = hit.transform.position;
                        Vector3 objColliderCenter = hit.collider.bounds.center;
                        //Debug.Log($"Found: {hit.transform.name} | Position: {objPosition} | ColliderCenter: {objColliderCenter}");
                    }

                    _selection = selection;

                    //this piece of code spawns a tree in the position of the box underneath, then changes the tag of the box
                    if (Input.GetMouseButtonDown(0))
                    {
                        GameObject gameObject = Instantiate(prefabs[selectedPrefab], spawningPosition, Quaternion.identity);
                        hit.transform.gameObject.tag = "Untagged";
                        tokens--;
                        treeNumber++;
                        PlayerPrefs.SetInt("treeNumber", treeNumber);
                        PlayerPrefs.SetInt("Tokens", tokens);
                        PlayerPrefs.SetFloat("x" + treeNumber, spawningPosition.x);
                        PlayerPrefs.SetFloat("y" + treeNumber, spawningPosition.y);
                        PlayerPrefs.SetFloat("z" + treeNumber, spawningPosition.z);
                        PlayerPrefs.Save();
                        




                    }


                }

            }
        }
    }

    public void InstantiateTrees()
    {

    }
}
