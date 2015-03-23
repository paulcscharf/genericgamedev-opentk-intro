using OpenTK.Graphics.OpenGL;

namespace GenericGamedev.OpenTKIntro
{
    sealed class Shader
    {
        private readonly int handle;

        public int Handle { get { return this.handle; } }

        public Shader(ShaderType type, string code)
        {
            // create shader object
            this.handle = GL.CreateShader(type);

            // set source and compile shader
            GL.ShaderSource(this.handle, code);
            GL.CompileShader(this.handle);
        }
    }
}
