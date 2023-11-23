using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoardManager))]
public class BoardView : MonoBehaviour
{

    [SerializeField] private Mesh _cube;
    [SerializeField] private Material _material;
    private Matrix4x4[] _instData = new Matrix4x4[200];
    private GraphicsBuffer _colorBuffer;

    private void InitBuffer()
    {
        _colorBuffer = new GraphicsBuffer(GraphicsBuffer.Target.Structured, _instData.Length, sizeof(float) * 4);

        var colorArray = new Vector4[_instData.Length];
        for(int i = 0; i < colorArray.Length; i++)
        {
            colorArray[i] = new Vector4(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
        }

        _colorBuffer.SetData(colorArray);
        colorArray = null;
    }

    private void Start() 
    {

        InitBuffer();
        
        for(int i = 0; i < _instData.Length; i++)
        {

            int row = i % 10;
            int col = i / 10;

            _instData[i] = Matrix4x4.identity;

            _instData[i].SetTRS(new Vector3(row * 2f, col * 2f, 0f),
                                Quaternion.identity,
                                Vector3.one);
        }

    }

    private void Update() 
    {
        _material.SetBuffer("_ColorBuffer", _colorBuffer);
        RenderParams rp = new RenderParams(_material);
        Graphics.RenderMeshInstanced(rp, _cube, 0, _instData);
    }

    private void OnDestroy() {
        _colorBuffer.Release();   
    }
}
