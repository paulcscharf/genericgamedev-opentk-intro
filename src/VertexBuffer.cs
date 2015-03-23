using System;
using OpenTK.Graphics.OpenGL;

namespace GenericGamedev.OpenTKIntro
{
    sealed class VertexBuffer<TVertex>
        where TVertex : struct // vertices must be structs so we can copy them to GPU memory easily
    {
        private readonly int vertexSize;
        private TVertex[] vertices = new TVertex[4];

        private int count;

        private readonly int handle;

        public VertexBuffer(int vertexSize)
        {
            this.vertexSize = vertexSize;

            // generate the actual Vertex Buffer Object
            this.handle = GL.GenBuffer();
        }

        public void AddVertex(TVertex v)
        {
            // resize array if too small
            if(this.count == this.vertices.Length)
                Array.Resize(ref this.vertices, this.count * 2);
            // add vertex
            this.vertices[count] = v;
            this.count++;
        }

        public void Bind()
        {
            // make this the active array buffer
            GL.BindBuffer(BufferTarget.ArrayBuffer, this.handle);
        }

        public void BufferData()
        {
            // copy contained vertices to GPU memory
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(this.vertexSize * this.count),
                this.vertices, BufferUsageHint.StreamDraw);
        }

        public void Draw()
        {
            // draw buffered vertices as triangles
            GL.DrawArrays(PrimitiveType.Triangles, 0, this.count);
        }
    }
}
