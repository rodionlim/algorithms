using System.Collections.Generic;

namespace Dictionary
{
    class CustomDictionary
    {
        // Hash Table : Chaining
        LinkedList<KeyValuePair>[] items;
        readonly int size;
        private class KeyValuePair
        {
            public int k;
            public string v;
            public KeyValuePair(int key, string val)
            {
                k = key;
                v = val;
            }
        }

        public CustomDictionary(int s)
        {
            items = new LinkedList<KeyValuePair>[s];
            size = s;
        }

        public void Put(int k, string val)
        {
            var entry = GetEntry(k);
            if (entry != null)
            {
                entry.v = val;
                return;
            }

            GetOrCreateBucket(k).AddLast(new KeyValuePair(k, val));
        }

        public string Get(int k)
        {
            var entry = GetEntry(k);
            return (entry != null) ? entry.v : string.Empty;
        }

        public void Remove(int k)
        {
            var entry = GetEntry(k);
            if (entry != null) GetBucket(k).Remove(entry);
        }

        private KeyValuePair GetEntry(int k)
        {
            var bucket = GetBucket(k);
            if (bucket != null)
            {
                foreach (var node in bucket)
                    if (node.k == k)
                        return node;
            }
            return null;
        }

        private int GetHashIndex(int k)
        {
            return k % size;
        }

        private LinkedList<KeyValuePair> GetBucket(int k)
        {
            return items[GetHashIndex(k)];
        }

        private LinkedList<KeyValuePair> GetOrCreateBucket(int k)
        {
            var index = GetHashIndex(k);
            if (items[index] == null)
                items[index] = new LinkedList<KeyValuePair>();

            return items[index];
        }
    }
}
