using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
[ExecuteInEditMode]
public class CameraGrid : MonoBehaviour
{
    public bool RuleOfThirds = true;
    public bool CenterLine = true;
    public Material mat;

    void OnPostRender()
    {
        if (!mat)
        {
            Debug.LogError("Please Assign a material on the inspector");
            return;
        }

        GL.PushMatrix();
        mat.SetPass(0);
        GL.LoadPixelMatrix();
        GL.Color(Color.yellow);

        GL.Begin(GL.LINES);

        if (RuleOfThirds)
        {
            GL.Vertex3(0, Screen.height / 3, 0);
            GL.Vertex3(Screen.width, Screen.height / 3, 0);

            GL.Vertex3(0, (Screen.height / 3) * 2, 0);
            GL.Vertex3(Screen.width, (Screen.height / 3) * 2, 0);


            GL.Vertex3(Screen.width / 3, 0, 0);
            GL.Vertex3(Screen.width / 3, Screen.height, 0);

            GL.Vertex3((Screen.width / 3) * 2, 0, 0);
            GL.Vertex3((Screen.width / 3) * 2, Screen.height, 0); 
        }


        if (CenterLine)
        {
            GL.Vertex3(Screen.width / 2, 0, 0);
            GL.Vertex3(Screen.width / 2, Screen.height, 0);

            GL.Vertex3(0, Screen.height / 2, 0);
            GL.Vertex3(Screen.width, Screen.height / 2, 0); 
        }

        GL.End();
        GL.PopMatrix();
    }
}
