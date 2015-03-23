using OpenTK.Graphics.OpenGL;

namespace GenericGamedev.OpenTKIntro
{
    sealed class VertexAttribute
    {
        private readonly string name;
        private readonly int size;
        private readonly VertexAttribPointerType type;
        private readonly bool normalize;
        private readonly int stride;
        private readonly int offset;

        public VertexAttribute(string name, int size, VertexAttribPointerType type,
            int stride, int offset, bool normalize = false)
        {
            this.name = name;
            this.size = size;
            this.type = type;
            this.stride = stride;
            this.offset = offset;
            this.normalize = normalize;
        }

        public void Set(ShaderProgram program)
        {
            // get location of attribute from shader program
            int index = program.GetAttributeLocation(this.name);

            // enable and set attribute
            GL.EnableVertexAttribArray(index);
            GL.VertexAttribPointer(index, this.size, this.type,
                this.normalize, this.stride, this.offset);
        }
    }
}
