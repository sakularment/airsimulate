using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Project1
{
    //测试哈哈哈
    struct Location
    {
        public double X;
        public double Y;
        public double H;
        public Location(double x, double y, double h) { this.X = x; this.Y = y; this.H = h; }
        public string output() { return "(" + this.X + "," + this.Y + "," + this.H + ")"; }
    }
    class Plane
    {
        public string P_id;
        public double dimian_speed;
        public double kongzhong_speed;
        public double slope=0;
        public double PMH;
        public Location now_location;
        public List<Location> trajectory;
        public int fly_time;
        //航向转换为X，Y方向的线速度
        private double PMHtoX(double pmh)
        {
            return Math.Sin(pmh);
        }
        private double PMHtoY(double pmh)
        {
            return Math.Cos(pmh);
        }
        //构造函数
        //测试函数，可以根据传入的数值n来产生随机的地面速度和航向，数值n是飞机的顺序编号
        public Plane(int n)
        {
            n = n + 1;
            Random random = new Random(n);
            this.P_id = n.ToString();
            this.fly_time = 0;
            this.dimian_speed = random.Next(100, 999);
            this.kongzhong_speed = 0;
            this.PMH = Math.PI * (random.Next(0, 360) / 180.0);
            this.now_location = new Location(0, 0, 0);
            this.trajectory = new List<Location>();
            this.trajectory.Add(this.now_location);
        }
        //实际应用函数，可以根据传入的飞机参数构建一架飞机
        public Plane(string P_id, double d_s, double k_s, double PMH, double x, double y, double h)
        {
            this.fly_time = 0;
            this.P_id = P_id;
            this.dimian_speed = d_s;
            this.kongzhong_speed = k_s;
            this.PMH = PMH;
            this.now_location = new Location(x, y, h);
            this.trajectory = new List<Location>();
            this.trajectory.Add(this.now_location);
        }
        //析构函数，回收内存用
        ~Plane()
        {
        }
        //飞行执行函数
        public void Fly()
        {
            this.fly_time++;
            this.now_location.X = this.now_location.X + dimian_speed * PMHtoX(this.PMH);
            this.now_location.Y = this.now_location.Y + dimian_speed * PMHtoY(this.PMH);
            trajectory.Add(this.now_location);
        }
        //显示飞机的信息
        public string Show_information()
        {
            return this.P_id + "号飞机" + "当前位置：" + this.now_location.output() + "地面速度：" + this.dimian_speed + "航向：" + this.PMH;
        }
        //显示航线信息
        public string Show_trajectory()
        {
            string return_information = "航行轨迹：";
            foreach (Location l in this.trajectory)
            {
                return_information = return_information + l.X + "," + l.Y + "," + l.H + "|";
            }
            return return_information;
        }
    }

}
