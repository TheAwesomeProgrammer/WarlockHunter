using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class Room : ActivateObject
{
    public bool Captured { get; set; }
    public bool Fog { get; set; }
    public Texture2D FogTexture;
    public Material MeshMaterial;

    private Collider2D _collider2D;
    private List<GameObject> _playersInRoom = new List<GameObject>();
    private bool _warlockInRoom; 

    public Vector2 Center
    {
        get { return _collider2D.bounds.center; }
    }

    void Awake()
    {
        _collider2D = GetComponent<Collider2D>();
    }

    protected override void Start()
    {
        base.Start();
        Fog = true;
        ActivateTags.Add("Player");
        ActivateTags.Add("Warlock");
        DeactivateTags.Add("Player");
        DeactivateTags.Add("Warlock");
        if (GetComponent<PolygonCollider2D>() == null)
        {
            SpawnFogs();
        }
        else
        {
            SpawnFogsPolygonCollider();
        }
    }

    void SpawnFogs()
    {
        GameObject fogsObject = new GameObject("BlackFog");
        Sprite sprite = Sprite.Create(FogTexture, new Rect(0, 0, 100, 100), Vector2.zero);
        fogsObject.AddComponent<SpriteRenderer>().sprite = sprite;
        fogsObject.GetComponent<SpriteRenderer>().color = Color.black;
        fogsObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
        fogsObject.transform.localScale = _collider2D.bounds.size;
        fogsObject.transform.position = transform.position - _collider2D.bounds.size / 2 + (Vector3)_collider2D.offset;
        SetStandardStuffOnFogObject(fogsObject);
        SpawnWarlockFog(fogsObject);
    }

    void SpawnFogsPolygonCollider()
    {
        GameObject fogsObject = new GameObject("BlackFog");

        MeshFilter meshFilter = fogsObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = fogsObject.AddComponent<MeshRenderer>();
        MeshMaterial.color = Color.black;
        meshRenderer.material = MeshMaterial;
        meshRenderer.sortingLayerName = "FogOfWar";

        List<Vector3> vertices = new List<Vector3>();
        List<Vector2> uvs = new List<Vector2>();
  
        foreach (var point in GetComponent<PolygonCollider2D>().points)
        {
            vertices.Add(transform.position + (Vector3)point);
            uvs.Add((Vector2)transform.position + point);
        }

        Triangulator tr = new Triangulator(uvs.ToArray());
        int[] indices = tr.Triangulate();

        meshFilter.mesh.vertices = vertices.ToArray();
        meshFilter.mesh.uv = uvs.ToArray();
        meshFilter.mesh.triangles = indices;

        meshFilter.mesh.RecalculateNormals();
        
        fogsObject.transform.position = new Vector3(0, 0, -5);
        SetStandardStuffOnFogObject(fogsObject);
        SpawnWarlockFog(fogsObject);
    }

    void SetStandardStuffOnFogObject(GameObject fogObject)
    {
        fogObject.transform.parent = transform;
        fogObject.tag = "Fog";
        fogObject.layer = 12;
    }

    void SpawnWarlockFog(GameObject fog)
    {
        GameObject spawnedFog = Instantiate(fog, fog.transform.position, Quaternion.identity) as GameObject;
        spawnedFog.transform.parent = transform;
        spawnedFog.layer = 13;
        spawnedFog.tag = "WarlockFog";
    }

    public override void ContinousActivation(GameObject otherObject)
    {
        base.ContinousActivation(otherObject);

        if (otherObject.GetComponent<Warlock>() != null)
        {
            _warlockInRoom = true;
        }
        else if(!_playersInRoom.Contains(otherObject))
        {
            _playersInRoom.Add(otherObject);
        }

        Player player = otherObject.GetComponentInParent<Player>();
        player.CurrentRoom = this;
    }

    public override void Deactivate(GameObject otherObject)
    {
        base.Deactivate(otherObject);
        if (otherObject.GetComponent<Warlock>() != null)
        {
            _warlockInRoom = false;
        }
        else if (_playersInRoom.Contains(otherObject))
        {
            _playersInRoom.Remove(otherObject);
        }

        Player player = otherObject.GetComponentInParent<Player>();
        player.CurrentRoom = null;
    }

    void Update()
    {
        SetFog();
    }

    void SetFog()
    {
        if (_playersInRoom.Count <= 0 || Fog)
        {
            transform.FindChildByTag("Fog").GetComponent<Renderer>().enabled = true;
        }
        if (_playersInRoom.Count > 0 || !Fog)
        {
            transform.FindChildByTag("Fog").GetComponent<Renderer>().enabled = false;
        }

        if (_warlockInRoom)
        {
            transform.FindChildByTag("WarlockFog").GetComponent<Renderer>().enabled = false;
        }
        else if (!_warlockInRoom)
        {
            transform.FindChildByTag("WarlockFog").GetComponent<Renderer>().enabled = true;
        }
    }
}
