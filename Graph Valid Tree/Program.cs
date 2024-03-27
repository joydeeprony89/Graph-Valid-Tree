using System;
using System.Collections;
using System.Collections.Generic;

namespace lintcode
{
    class Solution
    {
        /**
         * @param n: An integer
         * @param edges: a list of undirected edges
         * @return: true if it's a valid tree, or false
         */

        // https://www.lintcode.com/problem/178/?fromId=222&_from=collection
        public bool ValidTree(int n, int[][] edges)
        {
            /*if(edges == null || edges.Length == 0) {
                if(n == 1) return true;
                else if(n > 1) return false;
            }*/
            var adj = new Dictionary<int, List<int>>();
            for (int i = 0; i < n; i++)
            {
                adj.Add(i, new List<int>());
            }
            foreach (var edge in edges)
            {
                var source = edge[0];
                var destination = edge[1];

                adj[source].Add(destination);
                adj[destination].Add(source);
            }
            var visited = new HashSet<int>();

            bool HasCycle(int source, int prev)
            {
                if (visited.Contains(source)) return true;
                visited.Add(source);
                foreach (var nei in adj[source])
                {
                    if (nei == prev) continue;
                    if (HasCycle(nei, source)) return true;
                }
                return false;
            }

            return !HasCycle(0, -1) && visited.Count == n;
        }
    }
}