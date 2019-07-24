using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class Plane
{
    const int vertsPerSquare = 6;

    public static VertexPositionColor[] Generate(int planeWidth, int planeDepth, int resolution, Color? color1, Color? color2)
    {
        color1 = color1 ?? Color.Red;
        color2 = color2 ?? Color.Green;

        var totalWidthVerts = planeWidth * resolution;
        var totalDepthVerts = planeDepth * resolution;
        var totalNumVertices = totalWidthVerts * totalDepthVerts * vertsPerSquare;
        var vertices = new VertexPositionColor[totalNumVertices];

        var quadIndex = 0;
        for (int y = 0; y < totalDepthVerts; y++)
        {
            for (int x = 0; x < totalWidthVerts; x++)
            {
                vertices[(quadIndex * vertsPerSquare) + 0].Position = new Vector3(x, y, 0);
                vertices[(quadIndex * vertsPerSquare) + 0].Color = color1.Value;

                vertices[(quadIndex * vertsPerSquare) + 1].Position = new Vector3(x, y + 1, 0);
                vertices[(quadIndex * vertsPerSquare) + 1].Color = color1.Value;

                vertices[(quadIndex * vertsPerSquare) + 2].Position = new Vector3(x + 1, y + 1, 0);
                vertices[(quadIndex * vertsPerSquare) + 2].Color = color1.Value;

                vertices[(quadIndex * vertsPerSquare) + 3].Position = vertices[(quadIndex * vertsPerSquare) + 2].Position;
                vertices[(quadIndex * vertsPerSquare) + 3].Color = color2.Value;

                vertices[(quadIndex * vertsPerSquare) + 4].Position = new Vector3(x + 1, y, 0);
                vertices[(quadIndex * vertsPerSquare) + 4].Color = color2.Value;

                vertices[(quadIndex * vertsPerSquare) + 5].Position = vertices[(quadIndex * vertsPerSquare) + 0].Position;
                vertices[(quadIndex * vertsPerSquare) + 5].Color = color2.Value;

                quadIndex++;
            }
        }
        return vertices;
    }

    public static VertexPositionNormalTexture[] Generate(int planeWidth, int planeDepth, int resolution)
    {
        var totalWidthVerts = planeWidth * resolution;
        var totalDepthVerts = planeDepth * resolution;
        var totalNumVertices = totalWidthVerts * totalDepthVerts * vertsPerSquare;
        var vertices = new VertexPositionNormalTexture[totalNumVertices];

        

        return null;
    }
}