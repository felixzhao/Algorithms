using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NearestCommonAncestors
{
    public class Tarjan
    {
        static int[] f = new int[10001];
        static int[] r = new int[10001];
        static int[] indegree = new int[10001]; //保存每个节点的入度
        static int[] visit = new int[10001];
        static int[] ancestor = new int[10001];
        static List<int>[] tree = new List<int>[10001];
        static List<int>[] Qes = new List<int>[10001];

        public void Doit()
        {
            int cnt;
            int n;
            cnt = Convert.ToInt32(Console.ReadLine());
            while (cnt != 0)
            {
                n = Convert.ToInt32(Console.ReadLine());
                init(n);
                int s, t;
                for (int i = 1; i < n; i++)
                {
                    var temp = Console.ReadLine().Split(' ');
                    s = Convert.ToInt32(temp[0]);
                    t = Convert.ToInt32(temp[1]);

                    tree[s].Add(t);
                    indegree[t]++;
                }
                //这里可以输入多组询问
                var temp1 = Console.ReadLine().Split(' ');
                s = Convert.ToInt32(temp1[0]);
                t = Convert.ToInt32(temp1[1]);
                //相当于询问两次
                Qes[s].Add(t);
                Qes[t].Add(s);
                for (int i = 1; i <= n; i++)
                {
                    //寻找根节点
                    if (indegree[i] == 0)
                    {
                        LCA(i);
                        break;
                    }
                }
                cnt--;
            }

            Console.ReadKey();
        }

        private void init(int n)
        {
            for (int i = 1; i <= n; i++)
            {

                r[i] = 1;
                f[i] = i;
                indegree[i] = 0;
                visit[i] = 0;
                ancestor[i] = 0;
                tree[i] = new List<int>();
                Qes[i] = new List<int>();
            }
        }

        private void LCA(int u)
        {
            ancestor[u] = u;
            int size = tree[u].Count();
            for (int i = 0; i < size; i++)
            {
                LCA(tree[u][i]);
                Union(u, tree[u][i]);
                ancestor[find(u)] = u;
            }
            visit[u] = 1;
            size = Qes[u].Count();
            for (int i = 0; i < size; i++)
            {
                //如果已经访问了问题节点,就可以返回结果了.
                if (visit[Qes[u][i]] == 1)
                {
                    Console.WriteLine(ancestor[find(Qes[u][i])]);
                    return;
                }
            }
        }

        /// <summary>
        /// 查找函数，并压缩路径
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static int find(int n)
        {
            if (f[n] == n)
                return n;
            else
                f[n] = find(f[n]);
            return f[n];
        }

        /// <summary>
        /// 合并函数，如果属于同一分支则返回0，成功合并返回1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        private int Union(int x, int y)
        {
            int a = find(x);
            int b = find(y);
            if (a == b)
                return 0;
            //相等的话,x向y合并
            else if (r[a] <= r[b])
            {
                f[a] = b;
                r[b] += r[a];
            }
            else
            {
                f[b] = a;
                r[a] += r[b];
            }
            return 1;

        }
    }
}
