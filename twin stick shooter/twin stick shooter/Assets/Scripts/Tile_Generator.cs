using UnityEngine;
using System.Collections;

public class Tile_Generator : MonoBehaviour {

    public GameObject tile;
    public Material[] tileTexture;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < 29; i++)
        {
            for (int j = 0; j < 18; j++)
            {
                MakeTileAt(new Vector3(transform.position.x + (i * 2), -1.5f, transform.position.z + (j * 2)));
            }
        }
    }

    void MakeTileAt(Vector3 pos)
    {
        GameObject newGO = Instantiate(tile, pos, Quaternion.identity) as GameObject;
        newGO.GetComponent<Renderer>().material = tileTexture[Random.Range(0, tileTexture.Length)];
    }
}
