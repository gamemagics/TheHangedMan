using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapGenerator : MonoBehaviour {

    [SerializeField] protected int width;
    [SerializeField] protected int height;

    [SerializeField] private int seed;

    [SerializeField] [Range(0, 100)] protected int maxIterationTimes;

    [SerializeField] private Grid grid;

    [SerializeField] private Tilemap[] layers;

    protected System.Random random;

    protected int[,] map;

    void Awake() {
        random = new System.Random(seed);
        Init();

        map = new int[width, height];
    }

    // Start is called before the first frame update
    void Start() {
        StartCoroutine(Genetate());
    }

    // Update is called once per frame
    void Update() {
    }

    protected virtual void Init() {
    }

    protected virtual bool Iterate() {
        return true;
    }

    protected virtual void Finish() {
    }

    private void DrawGrid() {

    }

    private IEnumerator Genetate() {
        for (int i = 0; i < maxIterationTimes; ++i) {
            if (!Iterate()) {
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        Finish();
        DrawGrid();
        yield return null;
    }
}
