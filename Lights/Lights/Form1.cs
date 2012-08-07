using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK;

namespace Lights
{
    public partial class Form1 : Form
    {
        bool loaded = false;
        static float rotation_speed = 0.1f;
        float angle;
        float randomtemp= 0.0f;

        Vector4 mat_specular;
        float mat_shininess;
        Vector4 mat_diffuse;
        Vector4 mat_ambient;
        Vector4 mat_emission;

        Vector4 light0_diffuse;
        Vector4 light0_ambient;
        Vector4 light0_specular;
        Vector4 light0_spot_direction;
        float light0_spot_exponent;
        float light0_spot_cutoff;
        float light0_constant_attentuation;
        float light0_linear_attentuation;
        float light0_quadratic_attentuation;



        Vector4 light1_diffuse;
        Vector4 light1_ambient;
        Vector4 light1_specular;
        Vector4 light1_spot_direction;
        float light1_spot_exponent;
        float light1_spot_cutoff;
        float light1_constant_attentuation;
        float light1_linear_attentuation;
        float light1_quadratic_attentuation;

        Vector4 light2_diffuse;
        Vector4 light2_ambient;
        Vector4 light2_specular;
        Vector4 light2_spot_direction;
        float light2_spot_exponent;
        float light2_spot_cutoff;
        float light2_constant_attentuation;
        float light2_linear_attentuation;
        float light2_quadratic_attentuation;

        Vector4 light3_diffuse;
        Vector4 light3_ambient;
        Vector4 light3_specular;
        Vector4 light3_spot_direction;
        float light3_spot_exponent;
        float light3_spot_cutoff;
        float light3_constant_attentuation;
        float light3_linear_attentuation;
        float light3_quadratic_attentuation;


        Vector4 light4_diffuse;
        Vector4 light4_ambient;
        Vector4 light4_specular;
        Vector4 light4_spot_direction;
        float light4_spot_exponent;
        float light4_spot_cutoff;
        float light4_constant_attentuation;
        float light4_linear_attentuation;
        float light4_quadratic_attentuation;


        Vector4 light5_diffuse;
        Vector4 light5_ambient;
        Vector4 light5_specular;
        Vector4 light5_spot_direction;
        float light5_spot_exponent;
        float light5_spot_cutoff;
        float light5_constant_attentuation;
        float light5_linear_attentuation;
        float light5_quadratic_attentuation;


        Vector4 light6_diffuse;
        Vector4 light6_ambient;
        Vector4 light6_specular;
        Vector4 light6_spot_direction;
        float light6_spot_exponent;
        float light6_spot_cutoff;
        float light6_constant_attentuation;
        float light6_linear_attentuation;
        float light6_quadratic_attentuation;


        Vector4 light7_diffuse;
        Vector4 light7_ambient;
        Vector4 light7_specular;
        Vector4 light7_spot_direction;
        float light7_spot_exponent;
        float light7_spot_cutoff;
        float light7_constant_attentuation;
        float light7_linear_attentuation;
        float light7_quadratic_attentuation;


        Vector4 light0_position;
        Vector4 light1_position;
        Vector4 light2_position;
        Vector4 light3_position;
        Vector4 light4_position;
        Vector4 light5_position;
        Vector4 light6_position;
        Vector4 light7_position;

        Random ran = new Random();


        public Form1()
        {
            InitializeComponent();


        }
        //event handlers
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            //VSync Broke;
            //GraphicsContext.CurrentContext.VSync = true;
            
            //background color
            runRand();
            getAttentuation();
            
            GL.ClearColor(0,0,0,0);

            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.DepthTest);


            GL.Enable(EnableCap.ColorMaterial);
            SetupViewport();
            Render();
            Application.Idle += Application_Idle; // press TAB twice after +=
        }
        void Application_Idle(object sender, EventArgs e)
        {
            while (glControl1.IsIdle)
            {
                
                Render();
            }
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Idle -= Application_Idle;

            base.OnClosing(e);
        }
        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            SetupViewport();
            glControl1.Invalidate();
        }
        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            Render();
        }
        //Methods
        private void SetupViewport()
        {
            int w = glControl1.Width;
            int h = glControl1.Height;
            GL.Viewport(0, 0, w, h);

            double aspect_ratio = w / (double)h;

            OpenTK.Matrix4 perspective = OpenTK.Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)aspect_ratio, 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }
        private void Render()
        {
            if (!loaded) // Play nice
                return;

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Specular, mat_specular);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Shininess, mat_shininess);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Emission, mat_emission);
            GL.Material(MaterialFace.FrontAndBack, MaterialParameter.Diffuse, mat_diffuse);

            GL.Light(LightName.Light0, LightParameter.ConstantAttenuation, light0_constant_attentuation);
            GL.Light(LightName.Light0, LightParameter.LinearAttenuation, light0_linear_attentuation);
            GL.Light(LightName.Light0, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light1, LightParameter.ConstantAttenuation, light1_constant_attentuation);
            GL.Light(LightName.Light1, LightParameter.LinearAttenuation, light1_linear_attentuation);
            GL.Light(LightName.Light1, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light2, LightParameter.ConstantAttenuation, light2_constant_attentuation);
            GL.Light(LightName.Light2, LightParameter.LinearAttenuation, light2_linear_attentuation);
            GL.Light(LightName.Light2, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light3, LightParameter.ConstantAttenuation, light3_constant_attentuation);
            GL.Light(LightName.Light3, LightParameter.LinearAttenuation, light3_linear_attentuation);
            GL.Light(LightName.Light3, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light4, LightParameter.ConstantAttenuation, light4_constant_attentuation);
            GL.Light(LightName.Light4, LightParameter.LinearAttenuation, light4_linear_attentuation);
            GL.Light(LightName.Light4, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light5, LightParameter.ConstantAttenuation, light5_constant_attentuation);
            GL.Light(LightName.Light5, LightParameter.LinearAttenuation, light5_linear_attentuation);
            GL.Light(LightName.Light5, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light6, LightParameter.ConstantAttenuation, light6_constant_attentuation);
            GL.Light(LightName.Light6, LightParameter.LinearAttenuation, light6_linear_attentuation);
            GL.Light(LightName.Light6, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);

            GL.Light(LightName.Light7, LightParameter.ConstantAttenuation, light7_constant_attentuation);
            GL.Light(LightName.Light7, LightParameter.LinearAttenuation, light7_linear_attentuation);
            GL.Light(LightName.Light7, LightParameter.QuadraticAttenuation, light0_quadratic_attentuation);


            GL.Light(LightName.Light0, LightParameter.Diffuse, light0_diffuse);
            GL.Light(LightName.Light0, LightParameter.Ambient, light0_ambient);
            GL.Light(LightName.Light0, LightParameter.Specular, light0_specular);
            GL.Light(LightName.Light0, LightParameter.Position, light0_position);
            GL.Light(LightName.Light0, LightParameter.SpotDirection, light0_spot_direction);
            GL.Light(LightName.Light0, LightParameter.SpotExponent, light0_spot_exponent);
            GL.Light(LightName.Light0, LightParameter.SpotCutoff, light0_spot_cutoff);

            GL.Light(LightName.Light1, LightParameter.Diffuse, light1_diffuse);
            GL.Light(LightName.Light1, LightParameter.Ambient, light1_ambient);
            GL.Light(LightName.Light1, LightParameter.Specular, light1_specular);
            GL.Light(LightName.Light1, LightParameter.Position, light1_position);
            GL.Light(LightName.Light1, LightParameter.SpotDirection, light1_spot_direction);
            GL.Light(LightName.Light1, LightParameter.SpotExponent, light1_spot_exponent);
            GL.Light(LightName.Light1, LightParameter.SpotCutoff, light1_spot_cutoff);

            GL.Light(LightName.Light2, LightParameter.Diffuse, light2_diffuse);
            GL.Light(LightName.Light2, LightParameter.Ambient, light2_ambient);
            GL.Light(LightName.Light2, LightParameter.Specular, light2_specular);
            GL.Light(LightName.Light2, LightParameter.Position, light2_position);
            GL.Light(LightName.Light2, LightParameter.SpotDirection, light2_spot_direction);
            GL.Light(LightName.Light2, LightParameter.SpotExponent, light2_spot_exponent);
            GL.Light(LightName.Light2, LightParameter.SpotCutoff, light2_spot_cutoff);

            GL.Light(LightName.Light3, LightParameter.Diffuse, light3_diffuse);
            GL.Light(LightName.Light3, LightParameter.Ambient, light3_ambient);
            GL.Light(LightName.Light3, LightParameter.Specular, light3_specular);
            GL.Light(LightName.Light3, LightParameter.Position, light3_position);
            GL.Light(LightName.Light3, LightParameter.SpotDirection, light3_spot_direction);
            GL.Light(LightName.Light3, LightParameter.SpotExponent, light3_spot_exponent);
            GL.Light(LightName.Light3, LightParameter.SpotCutoff, light3_spot_cutoff);

            GL.Light(LightName.Light4, LightParameter.Diffuse, light4_diffuse);
            GL.Light(LightName.Light4, LightParameter.Ambient, light4_ambient);
            GL.Light(LightName.Light4, LightParameter.Specular, light4_specular);
            GL.Light(LightName.Light4, LightParameter.Position, light4_position);
            GL.Light(LightName.Light4, LightParameter.SpotDirection, light4_spot_direction);
            GL.Light(LightName.Light4, LightParameter.SpotExponent, light4_spot_exponent);
            GL.Light(LightName.Light4, LightParameter.SpotCutoff, light4_spot_cutoff);

            GL.Light(LightName.Light5, LightParameter.Diffuse, light5_diffuse);
            GL.Light(LightName.Light5, LightParameter.Ambient, light5_ambient);
            GL.Light(LightName.Light5, LightParameter.Specular, light5_specular);
            GL.Light(LightName.Light5, LightParameter.Position, light5_position);
            GL.Light(LightName.Light5, LightParameter.SpotDirection, light5_spot_direction);
            GL.Light(LightName.Light5, LightParameter.SpotExponent, light5_spot_exponent);
            GL.Light(LightName.Light5, LightParameter.SpotCutoff, light5_spot_cutoff);

            GL.Light(LightName.Light6, LightParameter.Diffuse, light6_diffuse);
            GL.Light(LightName.Light6, LightParameter.Ambient, light6_ambient);
            GL.Light(LightName.Light6, LightParameter.Specular, light6_specular);
            GL.Light(LightName.Light6, LightParameter.Position, light6_position);
            GL.Light(LightName.Light6, LightParameter.SpotDirection, light6_spot_direction);
            GL.Light(LightName.Light6, LightParameter.SpotExponent, light6_spot_exponent);
            GL.Light(LightName.Light6, LightParameter.SpotCutoff, light6_spot_cutoff);

            GL.Light(LightName.Light7, LightParameter.Diffuse, light7_diffuse);
            GL.Light(LightName.Light7, LightParameter.Ambient, light7_ambient);
            GL.Light(LightName.Light7, LightParameter.Specular, light7_specular);
            GL.Light(LightName.Light7, LightParameter.Position, light7_position);
            GL.Light(LightName.Light7, LightParameter.SpotDirection, light7_spot_direction);
            GL.Light(LightName.Light7, LightParameter.SpotExponent, light7_spot_exponent);
            GL.Light(LightName.Light7, LightParameter.SpotCutoff, light7_spot_cutoff);


            Matrix4 lookat = Matrix4.LookAt(0, 5, 5, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);

            angle += rotation_speed;
            GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
            DrawCube();

            
            //Thread.Sleep(1);
            glControl1.SwapBuffers();
        }
        private void DrawCube()
        {
            GL.Begin(BeginMode.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-0.75f, -0.75f, -0.75f);
            GL.Vertex3(-0.75f, 0.75f, -0.75f);
            GL.Vertex3(0.75f, 0.75f, -0.75f);
            GL.Vertex3(0.75f, -0.75f, -0.75f);

            GL.Color3(Color.Silver);
            GL.Vertex3(-0.75f, -0.75f, -0.75f);
            GL.Vertex3(0.75f, -0.75f, -0.75f);
            GL.Vertex3(0.75f, -0.75f, 0.75f);
            GL.Vertex3(-0.75f, -0.75f, 0.75f);

            GL.Color3(Color.Silver);

            GL.Vertex3(-0.75f, -0.75f, -0.75f);
            GL.Vertex3(-0.75f, -0.75f, 0.75f);
            GL.Vertex3(-0.75f, 0.75f, 0.75f);
            GL.Vertex3(-0.75f, 0.75f, -0.75f);

            GL.Color3(Color.Silver);
            GL.Vertex3(-0.75f, -0.75f, 0.75f);
            GL.Vertex3(0.75f, -0.75f, 0.75f);
            GL.Vertex3(0.75f, 0.75f, 0.75f);
            GL.Vertex3(-0.75f, 0.75f, 0.75f);

            GL.Color3(Color.Silver);
            GL.Vertex3(-0.75f, 0.75f, -0.75f);
            GL.Vertex3(-0.75f, 0.75f, 0.75f);
            GL.Vertex3(0.75f, 0.75f, 0.75f);
            GL.Vertex3(0.75f, 0.75f, -0.75f);

            GL.Color3(Color.Silver);
            GL.Vertex3(0.75f, -0.75f, -0.75f);
            GL.Vertex3(0.75f, 0.75f, -0.75f);
            GL.Vertex3(0.75f, 0.75f, 0.75f);
            GL.Vertex3(0.75f, -0.75f, 0.75f);

            GL.End();
        }
        float rand()
        {
           
            float temp= (float)(ran.Next(-10000, 10000))/10000;
            if (temp == randomtemp)
            {
                rand();
            }
            Console.WriteLine(temp);
            return temp;
        }
        void runRand()
        {
            if (checkBox17.Checked)
            {
                mat_specular = new Vector4(rand(), rand(), rand(), rand());
                mat_shininess = rand() * 100;
                mat_diffuse = new Vector4(rand(), rand(), rand(), rand());
                mat_ambient = new Vector4(rand(), rand(), rand(), rand());
                mat_emission = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox9.Checked)
            {
                light0_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light0_ambient = new Vector4(rand(), rand(), rand(), rand());
                light0_specular = new Vector4(rand(), rand(), rand(), rand());
                light0_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light0_spot_exponent = rand();
                light0_spot_cutoff = rand() * 200;
                light0_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox10.Checked)
            {
                light1_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light1_ambient = new Vector4(rand(), rand(), rand(), rand());
                light1_specular = new Vector4(rand(), rand(), rand(), rand());
                light1_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light1_spot_exponent = rand();
                light1_spot_cutoff = rand() * 200;
                light1_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox11.Checked)
            {
                light2_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light2_ambient = new Vector4(rand(), rand(), rand(), rand());
                light2_specular = new Vector4(rand(), rand(), rand(), rand());
                light2_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light2_spot_exponent = rand();
                light2_spot_cutoff = rand() * 200;
                light2_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox12.Checked)
            {
            light3_diffuse = new Vector4(rand(), rand(), rand(), rand());
            light3_ambient = new Vector4(rand(), rand(), rand(), rand());
            light3_specular = new Vector4(rand(), rand(), rand(), rand());
            light3_spot_direction = new Vector4(rand(), rand(), rand(), rand());
            light3_spot_exponent = rand();
            light3_spot_cutoff = rand() * 200;
            light3_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox13.Checked)
            {
                light4_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light4_ambient = new Vector4(rand(), rand(), rand(), rand());
                light4_specular = new Vector4(rand(), rand(), rand(), rand());
                light4_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light4_spot_exponent = rand();
                light4_spot_cutoff = rand() * 200;
                light4_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox14.Checked)
            {
                light5_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light5_ambient = new Vector4(rand(), rand(), rand(), rand());
                light5_specular = new Vector4(rand(), rand(), rand(), rand());
                light5_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light5_spot_exponent = rand();
                light5_spot_cutoff = rand() * 200;
                light5_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox15.Checked)
            {
                light6_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light6_ambient = new Vector4(rand(), rand(), rand(), rand());
                light6_specular = new Vector4(rand(), rand(), rand(), rand());
                light6_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light6_spot_exponent = rand();
                light6_spot_cutoff = rand() * 200;
                light6_position = new Vector4(rand(), rand(), rand(), rand());
            }
            if (checkBox16.Checked)
            {
                light7_diffuse = new Vector4(rand(), rand(), rand(), rand());
                light7_ambient = new Vector4(rand(), rand(), rand(), rand());
                light7_specular = new Vector4(rand(), rand(), rand(), rand());
                light7_spot_direction = new Vector4(rand(), rand(), rand(), rand());
                light7_spot_exponent = rand();
                light7_spot_cutoff = rand() * 200;
                light7_position = new Vector4(rand(), rand(), rand(), rand());
            }
       
        }
        void getAttentuation()
        {
            light0_constant_attentuation = float.Parse(textBox1.Text);
            light0_linear_attentuation = float.Parse(textBox2.Text);
            light0_quadratic_attentuation= float.Parse(textBox3.Text);

            light1_constant_attentuation = float.Parse(textBox6.Text);
            light1_linear_attentuation = float.Parse(textBox5.Text);
            light1_quadratic_attentuation = float.Parse(textBox4.Text);
            
            light2_constant_attentuation = float.Parse(textBox9.Text);
            light2_linear_attentuation = float.Parse(textBox8.Text);
            light2_quadratic_attentuation = float.Parse(textBox7.Text);

            light3_constant_attentuation = float.Parse(textBox12.Text);
            light3_linear_attentuation = float.Parse(textBox11.Text);
            light3_quadratic_attentuation = float.Parse(textBox10.Text);

            light4_constant_attentuation = float.Parse(textBox15.Text);
            light4_linear_attentuation = float.Parse(textBox14.Text);
            light4_quadratic_attentuation = float.Parse(textBox13.Text);

            light5_constant_attentuation = float.Parse(textBox18.Text);
            light5_linear_attentuation = float.Parse(textBox17.Text);
            light5_quadratic_attentuation = float.Parse(textBox16.Text);

            light6_constant_attentuation = float.Parse(textBox21.Text);
            light6_linear_attentuation = float.Parse(textBox20.Text);
            light6_quadratic_attentuation = float.Parse(textBox19.Text);

            light7_constant_attentuation = float.Parse(textBox24.Text);
            light7_linear_attentuation = float.Parse(textBox23.Text);
            light7_quadratic_attentuation = float.Parse(textBox22.Text);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                GL.Enable(EnableCap.Light0);
            }
            else 
            {
                GL.Disable(EnableCap.Light0);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                GL.Enable(EnableCap.Light1);
            }
            else 
            {
                GL.Disable(EnableCap.Light1);
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                GL.Enable(EnableCap.Light2);
            }
            else
            {
                GL.Disable(EnableCap.Light2);
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                GL.Enable(EnableCap.Light3);
            }
            else
            {
                GL.Disable(EnableCap.Light3);
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                GL.Enable(EnableCap.Light4);
            }
            else
            {
                GL.Disable(EnableCap.Light4);
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                GL.Enable(EnableCap.Light5);
            }
            else
            {
                GL.Disable(EnableCap.Light5);
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                GL.Enable(EnableCap.Light6);
            }
            else
            {
                GL.Disable(EnableCap.Light6);
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked)
            {
                GL.Enable(EnableCap.Light7);
            }
            else
            {
                GL.Disable(EnableCap.Light7);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            runRand();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getAttentuation();
        }
    }
}
