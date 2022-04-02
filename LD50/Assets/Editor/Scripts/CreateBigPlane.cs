using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace LD50 {
    public static class CreateBigPlane 
    {

        [MenuItem("GameObject/3D Object/Big Plane", false, 0)]
        private static void Create() {

            var parent = Selection.activeTransform;
            var go = new GameObject("Big Plane");
            var filter = go.AddComponent<MeshFilter>();
            var renderer = go.AddComponent<MeshRenderer>();
            var size = 100;
            var vertices = new List<Vector3>();
            var triangles = new List<int>();
            var i = 0;
            for (var x = 0; x <= size; x++) {
                for (var z = 0; z <= size; z++) {
                    vertices.Add(new Vector3(x - size / 2, 0, z - size / 2));
                    if (z < size && x < size) {
                        triangles.Add(i);
                        triangles.Add(i + (size + 1) + 1);
                        triangles.Add(i + (size + 1));
                        triangles.Add(i);
                        triangles.Add(i + 1);
                        triangles.Add(i + (size + 1) + 1);
                    }
                    i++;
                }
            }
            var mesh = new Mesh() {
                vertices = vertices.ToArray(),
                triangles = triangles.ToArray()
            };
            mesh.RecalculateNormals();
            filter.mesh = mesh;
            go.transform.SetParent(parent);
        }
    }
}
