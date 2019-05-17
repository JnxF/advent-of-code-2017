namespace AdventOfCode2017.Helpers
{

    public class UnionFind
    {
        private readonly int[] _parent;  // parent[i] = parent of i
        private readonly byte[] _rank;   // rank[i] = rank of subtree rooted at i (never more than 31)
        public int Count { get; private set; }

        public UnionFind(int n)
        {
            Count = n;
            _parent = new int[n];
            _rank = new byte[n];
            for (int i = 0; i < n; ++i)
            {
                _parent[i] = i;
                _rank[i] = 0;
            }
        }


        public int Find(int p)
        {
            while (p != _parent[p])
            {
                _parent[p] = _parent[_parent[p]];
                p = _parent[p];
            }
            return p;
        }


        public void Union(int p, int q)
        {
            int rootP = Find(p);
            int rootQ = Find(q);
            if (rootP == rootQ) return;

            // make root of smaller rank point to root of larger rank
            if (_rank[rootP] < _rank[rootQ]) _parent[rootP] = rootQ;
            else if (_rank[rootP] > _rank[rootQ]) _parent[rootQ] = rootP;
            else
            {
                _parent[rootQ] = rootP;
                ++_rank[rootP];
            }
            --Count;
        }
    }
}
