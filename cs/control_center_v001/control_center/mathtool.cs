using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace control_center
{
    public class Quaternion
    {
        public double[] quat = new double[4];
        public Quaternion()
        {
            //Quaternion quaternion = new Quaternion();
        }
        public Quaternion(double[] elmes)
        {
            this.quat = elmes;
        }
        public double this[int i]
        {
            set { this.quat[i] = value; }
            get { return this.quat[i]; }
        }
        public Quaternion(double W, double X, double Y, double Z)
        {
            quat[0] = W; quat[1] = X; quat[2] = Y; quat[3] = Z;
        }
        public Quaternion(double W, Vector3 X)
        {
            quat[0] = W; quat[1] = X[0]; quat[2] = X[1]; quat[3] = X[2];
        }
        public Quaternion conjugation(Quaternion q)
        {
            return new Quaternion(quat[0], -quat[1], -quat[2], -quat[3]);
        }
        public static Quaternion operator +(Quaternion q1, Quaternion q2)
        {
            double nw = q1[0] + q2[0];
            double nx = q1[1] + q2[1];
            double ny = q1[2] + q2[2];
            double nz = q1[3] + q2[3];
            return new Quaternion(nw, nx, ny, nz);
        }
        public static Quaternion operator ^(Quaternion q1, Quaternion q2)
        {
            double nw = q1[0] * q2[0] - q1[1] * q2[1] - q1[2] * q2[2] - q1[3] * q2[3];
            double nx = q1[0] * q2[1] + q1[1] * q2[0] + q1[2] * q2[3] - q1[3] * q2[2];
            double ny = q1[0] * q2[2] + q1[2] * q2[0] + q1[3] * q2[1] - q1[1] * q2[3];
            double nz = q1[0] * q2[3] + q1[3] * q2[0] + q1[1] * q2[2] - q1[2] * q2[1];

            return new Quaternion(nw, nx, ny, nz);
        }
        public static double operator *(Quaternion q1, Quaternion q2)
        {
            double ans;

            ans = q1[0] * q2[0] + q1[1] * q2[1] + q1[2] * q2[2] + q1[3] * q2[3];

            return ans;
        }
        public static Quaternion operator /(Quaternion q1, double a)
        {
            double nw = q1[0] / a;
            double nx = q1[1] / a;
            double ny = q1[2] / a;
            double nz = q1[3] / a;
            return new Quaternion(nw, nx, ny, nz);
        }
        public static Quaternion operator *(Quaternion q1, double a)
        {
            double nw = q1[0] * a;
            double nx = q1[1] * a;
            double ny = q1[2] * a;
            double nz = q1[3] * a;
            return new Quaternion(nw, nx, ny, nz);
        }
        public Quaternion Normalization(Quaternion quat)
        {
            Quaternion ans = new Quaternion(0, 0, 0, 0);
            double norm;

            norm = quat[0] * quat[0] + quat[1] * quat[1] + quat[2] * quat[2] + quat[3] * quat[3];
            if (norm <= 0.0)
            {
                return ans;
            }

            norm = 1.0 / Math.Sqrt(norm);
            quat[0] *= norm;
            quat[1] *= norm;
            quat[2] *= norm;
            quat[3] *= norm;

            ans[0] = quat[0];
            ans[1] = quat[1];
            ans[2] = quat[2];
            ans[3] = quat[3];

            return ans;
        }           
        public Quaternion MakeQuatanion(double t ,double x ,double y,double z)
        {
            Quaternion ans = new Quaternion(0.0,0.0,0.0,0.0);
            double norm;
            double cos, sin;

            norm = x * x + y * y + z * z;
            if (norm <= 0.0)
            {
                return ans;
            }

            //norm = 1.0 / Math.Sqrt(norm + t * t);
            x *= norm;
            y *= norm;
            z *= norm;

            cos = Math.Cos(t / 2.0);
            sin = Math.Sin(t / 2.0);

            ans[0] = cos;
            ans[1] = sin * x;
            ans[2] = sin * y;
            ans[3] = sin * z;

            return ans;
        }
        public Quaternion MakeQuatanion2(double r, double p, double y)
        {
            Quaternion ans = new Quaternion(0.0, 0.0, 0.0, 0.0);
            double s_r = Math.Sin(r);
            double c_r = Math.Cos(r);
            double s_p = Math.Sin(p);
            double c_p = Math.Cos(p);
            double s_y = Math.Sin(y);
            double c_y = Math.Cos(y);
            double[,] dcm = new double[3, 3];
            double[] q_sqrt = new double[4];
            dcm[0, 0] =  c_p * c_y;
            dcm[0, 1] =  c_p * s_y;
            dcm[0, 2] = -s_p;
            dcm[1, 0] = -c_r * s_y + s_r * s_p * c_y;
            dcm[1, 1] =  c_r * c_y + s_r * s_p * s_y;
            dcm[1, 2] =  s_r * c_p;
            dcm[2, 0] =  s_r * s_y + c_r * s_p * c_y;
            dcm[2, 1] = -s_r * c_y + c_r * s_p * s_y;
            dcm[2, 2] =  c_r * c_p;
            q_sqrt[0] = Math.Sqrt(1 + dcm[0, 0] - dcm[1, 1] - dcm[2, 2])*0.5;
            q_sqrt[1] = Math.Sqrt(1 - dcm[0, 0] + dcm[1, 1] - dcm[2, 2])*0.5;
            q_sqrt[2] = Math.Sqrt(1 - dcm[0, 0] - dcm[1, 1] + dcm[2, 2])*0.5;
            q_sqrt[3] = Math.Sqrt(1 + dcm[0, 0] + dcm[1, 1] + dcm[2, 2])*0.5;
            double max_q_sqrt = 0;
            int max_q_num = 0;
            for(int i = 0; i < 4; i++)
            {
                if (max_q_sqrt < q_sqrt[i])
                {
                    max_q_sqrt = q_sqrt[i];
                    max_q_num = i;
                }
            }
            switch (max_q_num) {

                case 0:
                    q_sqrt[1] = 0.25 / q_sqrt[0] * (dcm[0, 1] + dcm[1, 0]);
                    q_sqrt[2] = 0.25 / q_sqrt[0] * (dcm[0, 2] + dcm[2, 0]);
                    q_sqrt[3] = 0.25 / q_sqrt[0] * (dcm[1, 2] - dcm[2, 1]);
                    break;
                case 1:
                    q_sqrt[0] = 0.25 / q_sqrt[1] * (dcm[0, 1] + dcm[1, 0]);
                    q_sqrt[2] = 0.25 / q_sqrt[1] * (dcm[2, 1] + dcm[1, 2]);
                    q_sqrt[3] = 0.25 / q_sqrt[1] * (dcm[2, 0] - dcm[0, 2]);
                    break;
                case 2:
                    q_sqrt[0] = 0.25 / q_sqrt[2] * (dcm[2, 0] + dcm[0, 2]);
                    q_sqrt[1] = 0.25 / q_sqrt[2] * (dcm[2, 1] + dcm[1, 2]);
                    q_sqrt[3] = 0.25 / q_sqrt[2] * (dcm[0, 1] - dcm[1, 0]);
                    break;
                case 3:
                    q_sqrt[0] = 0.25 / q_sqrt[3] * (dcm[1, 2] - dcm[2, 1]);
                    q_sqrt[1] = 0.25 / q_sqrt[3] * (dcm[2, 0] - dcm[0, 2]);
                    q_sqrt[2] = 0.25 / q_sqrt[3] * (dcm[0, 1] - dcm[1, 0]);
                    break;
                default:
                    q_sqrt[1] = 0.25 / q_sqrt[0] * (dcm[0, 1] + dcm[1, 0]);
                    q_sqrt[2] = 0.25 / q_sqrt[0] * (dcm[0, 2] + dcm[2, 0]);
                    q_sqrt[3] = 0.25 / q_sqrt[0] * (dcm[1, 2] - dcm[2, 1]);
                    break;

            }

            ans[0] = q_sqrt[3];
            ans[1] = q_sqrt[0];
            ans[2] = q_sqrt[1];
            ans[3] = q_sqrt[2];

            return ans;
        }
        public Quaternion Rotation(Quaternion q,Quaternion x, Quaternion q_star)
        {
            Quaternion ans = new Quaternion(0, 0, 0, 0);
            ans = q ^ x;
            ans = ans ^ q_star;

            return ans;
        }
        public Quaternion Deribative(double[] quat, Quaternion x)
        {
            Quaternion ans = new Quaternion(0,0,0,0);

//                ans.x[0] = quat[0] * x.x[0] - quat[1] * x.x[1] - quat[2] * x.x[2] - quat[3] * x.x[3];
//                ans.x[1] = quat[1] * x.x[0] + quat[0] * x.x[1] + quat[3] * x.x[2] - quat[2] * x.x[3];
//                ans.x[2] = quat[2] * x.x[0] - quat[3] * x.x[1] + quat[0] * x.x[2] + quat[1] * x.x[3];
//                ans.x[3] = quat[3] * x.x[0] + quat[2] * x.x[1] - quat[1] * x.x[2] + quat[0] * x.x[3];



            ans[0] = 0.5 * (                - quat[0] * x[1] - quat[1] * x[2] - quat[2] * x[3]);
            ans[1] = 0.5 * ( quat[0] * x[0]                  + quat[2] * x[2] - quat[1] * x[3]);
            ans[2] = 0.5 * ( quat[1] * x[0] - quat[2] * x[1]                  + quat[0] * x[3]);
            ans[3] = 0.5 * ( quat[2] * x[0] + quat[1] * x[1] - quat[0] * x[2]                 );

            return ans;
        }
    }
    public class Vector3
    {
        public double[] vector3 = new double[3];
        public Vector3()
        {
            //Vector3 vector = new Vector3();
        }
        public Vector3(double[] elems)
        {
            this.vector3 = elems;
        }
        public double this[int i]
        {
            set { this.vector3[i] = value; }
            get { return this.vector3[i]; }
        }
        public static double operator ^(Vector3 x, Vector3 y)
        {
            double norm1, norm2;
            double ans = 0;

            norm1 = x[0] * x[0] + x[1] * x[1] + x[2] * x[2];
            norm2 = y[0] * y[0] + y[1] * y[1] + y[2] * y[2];

            if (norm1 <= 0 || norm2 <= 0)
            {
                return ans;
            }

            ans = x[0] * y[0] + x[1] * y[1] + x[2] * y[2];

            return ans;
        }
        public static Vector3 operator *(Vector3 x, Vector3 y)
        {
            Vector3 ans = new Vector3();
            ans[0] = x[1] * y[2] - x[2] * y[1];
            ans[1] = x[2] * y[0] - x[0] * y[2];
            ans[2] = x[0] * y[1] - x[1] * y[0];

            return ans;
        }
        public static Vector3 operator *(double x, Vector3 y)
        {
            Vector3 ans = new Vector3();
            ans[0] = x * y[0];
            ans[1] = x * y[1];
            ans[2] = x * y[2];

            return ans;
        }
        public static Vector3 operator /(Vector3 x, double y)
        {
            Vector3 ans = new Vector3();
            ans[0] = x[0] / y;
            ans[1] = x[1] / y;
            ans[2] = x[2] / y;

            return ans;
        }
        public static Vector3 operator +(Vector3 x, Vector3 y)
        {
            Vector3 ans = new Vector3();
            ans[0] = x[0] + y[0];
            ans[1] = x[1] + y[1];
            ans[2] = x[2] + y[2];

            return ans;
        }
        public static Vector3 operator -(Vector3 x, Vector3 y)
        {
            Vector3 ans = new Vector3();
            ans[0] = x[0] - y[0];
            ans[1] = x[1] - y[1];
            ans[2] = x[2] - y[2];

            return ans;
        }
        public static Vector3 operator *(Vector3 x, Matrix y)
        {
            Vector3 ans = new Vector3();
            ans[0] = x[1] * y[2, 0] - x[2] * y[1, 0];
            ans[1] = x[2] * y[0, 0] - x[0] * y[2, 0];
            ans[2] = x[0] * y[1, 0] - x[1] * y[0, 0];

            return ans;
        }
        public Vector3 ToVector3(Matrix x)
        {
            Vector3 ans = new Vector3();
            int i;
            int n, m;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);

            if (n == 3 && m == 1)
            {
                for (i = 0; i < 3; i++)
                {
                    ans[i] = x[i, 0];
                }
            }
            else
            {
                //エラー
            }

            return ans;
        }
    }
    public class Matrix
    {
        public double[,] matrix;
        public Matrix(int line, int row)
        {
            this.matrix = new double[line, row];
        }
        public Matrix(double[,] elems)
        {
            this.matrix = elems;
        }
        public Matrix(Matrix x, Matrix y , int num)
        {
            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);
            int l = y.matrix.GetLength(0);
            int o = y.matrix.GetLength(1);

            switch (num)
            {
                case 1:
                    if (n == l)
                    {
                        this.matrix = new double[n, m + o];
                        for (int i = 0; i < n; i++)
                        {
                            for (int j = 0; j < m + o; j++)
                            {
                                if(j < m)  matrix[i, j] = x[i, j];
                                else if (j < m + o) matrix[i, j] = y[i, j - m];
                            }
                        }
                    }
                    else
                    {
                        //エラー
                    }
                    break;
                case 2:
                    if (m == o)
                    {
                        this.matrix = new double[n + l, m];
                        for (int i = 0; i < n + l; i++)
                        {
                            for (int j = 0; j < m; j++)
                            {
                                if (i < n) matrix[i, j] = x[i, j];
                                else if (i < n + l) matrix[i, j] = y[i - n,j];
                            }
                        }
                    }
                    else
                    {
                        //エラー
                    }
                    break;
            }
        }
        public double this[int i, int j]
        {
            set { this.matrix[i, j] = value; }
            get { return this.matrix[i, j]; }
        }
        public static Matrix operator *(Matrix x, Matrix y)
        {
            int i, j, k;
            int n, m, l, o;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);
            l = y.matrix.GetLength(0);
            o = y.matrix.GetLength(1);

            Matrix ans = new Matrix(n, o);

            if (m == l)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < o; j++)
                    {
                        ans[i, j] = 0;
                        for (k = 0; k < l; k++)
                        {
                            ans[i, j] = ans[i,j] + x[i, k] * y[k, j];
                        }
                    }
                }
            }
            else
            {
                return ans;//エラーの場合
            }
            return ans;
        }
        public static Matrix operator +(Matrix x, Matrix y)
        {
            int i, j;
            int n, m, l, o;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);
            l = y.matrix.GetLength(0);
            o = y.matrix.GetLength(1);

            var ans = new Matrix(n, m);

            if (n == l && m == o)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        ans[i, j] = x[i, j] + y[i, j];
                    }
                }
            }
            else
            {
                //エラーコード
                return ans;
            }
            return ans;
        }
        public static Matrix operator -(Matrix x, Matrix y)
        {
            int i, j;
            int n, m, l, o;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);
            l = y.matrix.GetLength(0);
            o = y.matrix.GetLength(1);

            var ans = new Matrix(n, m);

            if (n == l && m == o)
            {
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < m; j++)
                    {
                        ans[i, j] = x[i, j] - y[i, j];
                    }
                }
            }
            else
            {
                //エラーコード
                return ans;
            }
            return ans;
        }
        public static Matrix operator *(double a, Matrix x)
        {
            int i, j;
            int n, m;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);

            var ans = new Matrix(n, m);

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    ans[i, j] = a * x[i, j];
                }
            }
            return ans;
        }
        public static Matrix operator /(double a, Matrix x)
        {
            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);
            Matrix ans = new Matrix(n,m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ans[i, j] = a / x[i, j];
                }
            }
            return ans;
        }
        public static Matrix operator *(Matrix x, Vector3 y)
        {
            int i, j;
            int n, m, l;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);
            l = y.vector3.GetLength(0);

            Matrix ans = new Matrix(m, 1);

            if (m == l)
            {
                for (i = 0; i < n; i++)
                {
                    ans[i, 0] = 0;
                    for (j = 0; j < m; j++)
                    {
                        ans[i, 0] += x[i, j] * y[j];
                    }
                }
            }
            return ans;
        }
        public void initialize(Matrix x)
        {
            int i, j;
            int n, m;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    x[i, j] = 0.0;
                }
            }
        }
        public void copy(Matrix x, Matrix y)
        {
            int i, j;
            int n, m;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    y[i, j] = x[i, j];
                }
            }

        }
        public double det(Matrix x)
        {
            int i, j, k;
            int n, m;
            double ans = 1.0, buf = 0;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);
            
            Matrix a = new Matrix(n, m);
            
            if (n == m)
            {
                copy(x, a);
                //三角行列を作成
                for (i = 0; i < n; i++)
                {
                    if (a[i, i] == 0)
                    {
                        for (int r = i + 1; r < n; r++)
                        {
                            if (a[i, r] != 0)
                            {
                                a = line_trans(a, i, r);
                                break;
                            }
                        }
                        if (a[i, i] == 0)
                        {
                            ans = 0;
                            return ans;
                        }
                    }
                    buf = 1.0 / a[i,i];
                    for (j = 0; j < n; j++)
                    {
                        if (i < j)
                        {
                            for (k = 0; k < n; k++)
                            {
                                a[j,k] -= a[i,k] * a[j,i] * buf;
                            }
                        }
                    }
                }
                //対角部分の積
                for (i = 0; i < n; i++)
                {
                    ans *= a[i,i];
                }
            }
            else
            {
                ans = 0;
                return ans;
            }
            return ans;
        }
        public Matrix rotational_matrix_x(double a)
        {
            Matrix Rx = new Matrix(3,3);
            Rx[0, 0] = 1;   Rx[0, 1] = 0;            Rx[0, 2] = 0;
            Rx[1, 0] = 0;   Rx[1, 1] =  Math.Cos(a); Rx[1, 2] = Math.Sin(a);
            Rx[2, 0] = 0;   Rx[2, 1] = -Math.Sin(a); Rx[2, 2] = Math.Cos(a);
            return Rx;
        }
        public Matrix rotational_matrix_y(double a)
        {
            Matrix Ry = new Matrix(3, 3);
            Ry[0, 0] = Math.Cos(a); Ry[0, 1] = 0; Ry[0, 2] = -Math.Sin(a);
            Ry[1, 0] = 0;           Ry[1, 1] = 1; Ry[1, 2] =  0;
            Ry[2, 0] = Math.Sin(a); Ry[2, 1] = 0; Ry[2, 2] =  Math.Cos(a);
            return Ry;
        }
        public Matrix rotational_matrix_z(double a)
        {
            Matrix Rz = new Matrix(3, 3);
            Rz[0, 0] =  Math.Cos(a);    Rz[0, 1] = Math.Sin(a); Rz[0, 2] = 0;
            Rz[1, 0] = -Math.Sin(a);    Rz[1, 1] = Math.Cos(a); Rz[1, 2] = 0;
            Rz[2, 0] =  0;              Rz[2, 1] = 0;           Rz[2, 2] = 1;
            return Rz;
        }
        public Matrix inverse(Matrix x)
        {
            double buf;
            double judge;
            int i, j, k;
            int n, m;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);

            Matrix a = new Matrix(n, m);
            Matrix ans = new Matrix(n, m);

            judge = det(x);
            copy(x, a);

            if (judge == 0)
            { 
                //エラー
            }
            else
            {
                //単位行列を作る
                for (i = 0; i < n; i++)
                {
                    for (j = 0; j < n; j++)
                    {
                        if (i == j) ans[i, j] = 1.0;
                        else ans[i, j] = 0.0;
                    }
                }
                //掃き出し法
                for (i = 0; i < n; i++)
                {
                    if (a[i, i] == 0)
                    {
                        for (int r = i + 1; r < n; r++)
                        {
                            if (a[i, r] != 0)
                            {
                                a = line_trans(a, i, r);
                                ans = line_trans(a, i, r);
                                break;
                            }
                        }
                    }
                    buf = 1 / a[i,i];
                    for (j = 0; j < n; j++)
                    {
                        a[i,j] *= buf;
                        ans[i,j] *= buf;
                    }
                    for (j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            buf = a[j,i];
                            for (k = 0; k < n; k++)
                            {
                                a[j,k] -= a[i,k] * buf;
                                ans[j,k] -= ans[i,k] * buf;
                            }
                        }
                    }
                }
            }
            return ans;
        }
        public Matrix transposition(Matrix x)
        {
            int i, j;
            int n, m;

            n = x.matrix.GetLength(0);
            m = x.matrix.GetLength(1);

            Matrix ans = new Matrix(m, n);

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    ans[i, j] = x[j, i];
                }
            }
            return ans;
        }
        public Matrix outer_product(Vector3 x)
        {
            Matrix ans = new Matrix(3,3);

            ans[0, 0] =   0.0;
            ans[0, 1] = -x[2];
            ans[0, 2] =  x[1];
            ans[1, 0] =  x[2];
            ans[1, 1] =   0.0;
            ans[1, 2] = -x[0];
            ans[2, 0] = -x[1];
            ans[2, 1] =  x[0];
            ans[2, 2] =   0.0;

            return ans;
        }
        public Matrix Tomatrix(Vector3 x)
        {
            Matrix ans = new Matrix(3, 1);
            ans[0, 0] = x[0];
            ans[1, 0] = x[1];
            ans[2, 0] = x[2];

            return ans;
        }
        public Matrix Tomatrix(double[,] x)
        {
            int n = x.GetLength(0);
            int m = x.GetLength(1);

            Matrix ans = new Matrix(n,m);

            for(int i = 0;i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ans[i, j] = x[i, j];
                }
            }
            return ans;
        }
        public double[,] Tomatdouble(Matrix x)
        {
            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);
            double[,] ans = new double[n, m];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    ans[i, j] = x[i, j];
                }
            }
            return ans;
        }
        public double Todouble(Matrix x)
        {
            double ans = 0;
            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);

            if (n == 1 && m == 1)
            {
                ans = x[0, 0];
            }
            return ans;
        }
        public double nolm_2(Matrix x)
        {
            double ans = 0;

            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);

            if (m == 1)
            {
                for (int i = 0; i < n; i++)
                {
                    ans += Math.Pow(x[i, 0], 2);
                }
            }
            else
            {
                //エラー
            }

            ans = Math.Sqrt(ans);
            
            return ans;
        }
        public Matrix line_trans(Matrix x, int a, int b)
        {
            //aとbを置換
            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);

            Matrix ans = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (i == a) ans[i, j] = x[b, j];
                    else if (i == b) ans[i, j] = x[a, j];
                    else ans[i, j] = x[i, j];
                }
            }
            return ans;
        }
        public Matrix row_trans(Matrix x, int a, int b)
        {
            //aとbを置換
            int n = x.matrix.GetLength(0);
            int m = x.matrix.GetLength(1);

            Matrix ans = new Matrix(n, m);

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (j == a) ans[i, j] = x[i, b];
                    else if (j == b) ans[i, j] = x[i, a];
                    else ans[i, j] = x[i, j];
                }
            }
            return ans;
        }
/*        public override string ToString()
        {
            string str = "(";
            for (var i = 0; i < Matrix.GetLength(0); i++)        // GetLength(0)は行数
            {
                str += "(";
                for (var j = 0; j < Matrix.GetLength(1); j++)   // GetLength(1)は列数
                {
                    str += Matrix[i, j] + ", ";
                }
                str = str.TrimEnd(new char[] { ',', ' ' });
                str += "), ";
            }
            str = str.TrimEnd(new char[] { ',', ' ' });
            str += ")";
            return str;
        }*/

    }
}
