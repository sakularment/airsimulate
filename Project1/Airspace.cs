using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Project1
{
    class Airspace
    {
        public Plane[] aircrafts;
        public int world_time;
        public int num=0;
        public int size=10;
        public Airspace(int size) {
            this.world_time = 0;
            this.size = size;
            this.aircrafts=new Plane[this.size];
            //aircrafts=new ArrayList();
        }
        //添加新飞机
        public bool Add_newaircrafts() {
            if (num == size)
            {
                return false;
            }
            Plane temp=new Plane(num);
            aircrafts[num] = temp;
            num++;
            Console.WriteLine("一架飞机已经创建");
            return true;
        }
        //批量添加新飞机 调用添加Add_newaircrafts()方法
        public bool Add_newaircrafts(int n) {
            if (n + num > size) { Console.WriteLine("太多了"); return false; }
            else {
                for (int i = 0; i < n; i++) { this.Add_newaircrafts(); }
            }
            return true;
        }
        //时间经过函数
        public bool Time_go() {
            this.world_time++;
            for (int i = 0; i < this.num; i++){
                this.aircrafts[i].Fly();
            }
            return true;
        }
        //度过一段时间,调用了n次上面的函数 测试函数
        public bool Time_go(int n) {
            for (int i = 0; i < n; i++) {
                this.Time_go();
            }
            return true;
        }
        //显示空域中所有飞机的信息
        public string Show_allinformation()
        {
            string info="";
            for (int i=0;i<this.num;i++){
                info = info + this.aircrafts[i].Show_information()+"\n";
            }
            return info;
        }
        //显示空域所有飞机的轨迹
        public string Show_alltra() {
            string info = "";
            foreach (Plane x in this.aircrafts)
            {
                info = info + x.Show_trajectory()+"\n";
            }
            return info;
        }
        //主体函数
        static void Main(string[] args){
            Console.Write("输入空域中可容纳的飞机数量：");
            string s1 = Console.ReadLine();
            Airspace asp = new Airspace(int.Parse(s1));
            while (true)
            {
                Console.Write(">>");
                string s = Console.ReadLine();
                if (s == "exit") { break; }
                    //新建飞机指令
                else if (s == "new") { string s2 = Console.ReadLine(); asp.Add_newaircrafts(int.Parse(s2)); }
                    //显示飞机信息指令
                else if (s == "info") { Console.WriteLine(asp.Show_allinformation()); }
                //时间流逝指令
                else if (s == "go") { string s2 = Console.ReadLine(); asp.Time_go(int.Parse(s2)); Console.WriteLine("时间流逝了"+s2+"秒，现在是第" + asp.world_time + "秒"); }
                    //显示飞机轨迹指令
                else if (s == "trac") { Console.WriteLine(asp.aircrafts[0].Show_trajectory()); }
                    //报错
                else { Console.WriteLine("无效的指令,输入help获取指令集");}
            }
        }
    }
}
