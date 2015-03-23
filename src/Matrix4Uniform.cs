using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace GenericGamedev.OpenTKIntro
{
    sealed class Matrix4Uniform
    {
        private readonly string name;
        private Matrix4 matrix;

        public Matrix4 Matrix { get { return this.matrix; } set { this.matrix = value; } }

        public Matrix4Uniform(string name)
        {
            this.name = name;
        }

        public void Set(ShaderProgram program)
        {
            // get uniform location
            var i = program.GetUniformLocation(this.name);

            // set uniform value
            GL.UniformMatrix4(i, false, ref this.matrix);
        }
    }
}
