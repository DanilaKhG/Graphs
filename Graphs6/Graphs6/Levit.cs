using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Graphs6
{
    public static class LevitAlgorithm
    {
        public static Tuple<int[],bool> LevitFindShortestPath(this IGraph graph, int sourceVertex)
        {
            int n = graph.VertexCount();
            int[] dist = new int[n];
            for (int i = 0; i < n; i++)
            {
                dist[i] = 100000;
            }
            dist[sourceVertex] = 0;

            int[] queueKind = new int[n];
            queueKind[sourceVertex] = 1;

            Queue<int> m0 = new Queue<int>(); //необработ. вершины
            Queue<int> m1 = new Queue<int>(); //очеред. на обработ.
            Queue<int> m1Priority = new Queue<int>(); //предположительно обработ. вершины
            Queue<int> m2 = new Queue<int>();

            m1.Enqueue(sourceVertex); //начальная верш. добавляется в m1, все остальные в m0

            for (int i = 0; i < n; i++)
            {
                if (i != sourceVertex)
                {
                    m0.Enqueue(i);
                }
            }

            while (m1.Count > 0 || m1Priority.Count > 0)
            {
                int v = m1Priority.Count > 0 ? m1Priority.Dequeue() : m1.Dequeue();

                m2.Enqueue(v);

                foreach ((int, int, int) u in graph.ListOfEdges(v))
                {
                    //Проверяем, к какой очереди принадлежит вершина
                    if (m0.Contains(u.Item2)) //Если След. вершина принадлежит м0
                    {
                        dist[u.Item2] = dist[v] + u.Item3; //расстояние до след. вершины равно расстоянию до текущ. верш. и расстоянию между ними
                        m0 = new Queue<int>(m0.Where(k => k != u.Item2));
                        m1.Enqueue(u.Item2); //добавляем вершину в m1
                    }
                    if (m1.Contains(u.Item2)) //Если След. вершина принадлежит м1
                    {
                        dist[u.Item2] = System.Math.Min(dist[u.Item2], dist[v] + u.Item3);
                        //расстояние до след. вершины равно минимальному между расстоянию до след.верш. и (расстоянию до текущ. верш. и расстоянию между ними)
                    }
                    if (m2.Contains(u.Item2) && dist[u.Item2] > dist[v] + u.Item3) //Если След. вершина принадлежит м2 и расстояние до след.верш. больше суммы расстояний до текущ.верш. и расстоянию между ними
                    {
                        dist[u.Item2] = dist[v] + u.Item3; //расстояние до след. верш. равно сумме расстояний до текущ. верш. и расстоянию между ними
                        m2 = new Queue<int>(m2.Where(k => k != u.Item2));
                        m1Priority.Enqueue(u.Item2);
                    }
                }
            }
            var edges = graph.ListOfEdges();
            var negative = edges.Any(e => dist[e.Item1] + e.Item3 < dist[e.Item2]);
            return Tuple.Create(dist,negative);

        } 
    }

      
}
