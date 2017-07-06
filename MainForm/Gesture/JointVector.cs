﻿using Commons;
using Microsoft.Kinect;
using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using static OpenTK.Graphics.Glu;

namespace MainForm {
    public class JointVector {
        private Vector3 vector;
        private double scale;

        public float X { get => vector.X; set => vector.X = value; }
        public float Y { get => vector.Y; set => vector.Y = value; }
        public float Z { get => vector.Z; set => vector.Z = value; }

        public JointVector(CameraSpacePoint Position) {
            vector = new Vector3(Position.X, Position.Y, Position.Z);
            //scale = 10;
            scale = 100;
        }

        public JointVector() {
            vector = new Vector3();
            //scale = 15;
            scale = 150;
        }

        public JointVector(int p1, int p2, int p3) {
            vector = new Vector3(p1, p2, p3);
            //scale = 15;
            scale = 150;
        }

        /// <summary>
        /// 坐标系转换
        /// </summary>
        public void CoordinateTransform() {
            double temp = vector.X;
            vector.X = vector.Z;
            vector.Z = vector.Y;
            vector.Y = (float)temp;
        }

        public void Draw() {
            clsMaterials Materials = new clsMaterials();
            Materials.SetMaterial(MaterialType.AxisOrgin);
            IntPtr pObj = NewQuadric();
            double _SphereRadius = 0.5;
            GL.Flush();
            GL.PushMatrix();
            GL.Translate(vector.X * scale, vector.Y * scale, vector.Z * scale);
            Sphere(pObj, _SphereRadius, 10, 10);
            GL.PopMatrix();
            pObj = IntPtr.Zero;
        }
    }
}