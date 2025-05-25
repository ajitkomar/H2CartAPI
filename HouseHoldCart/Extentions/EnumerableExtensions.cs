namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static async IAsyncEnumerable<TResult> Foreach<TSource, TResult>(this IEnumerable<TSource> items, Func<TSource, Task<TResult>> func)
        {
            foreach (var item in items)
            {
                yield return await func(item);
            }
        }

        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (action == null)
                throw new ArgumentNullException(nameof(action));

            foreach (TSource item in source) { action(item); }
        }

        public static (IEnumerable<TSource>, IEnumerable<TSource>) Split<TSource>(
            this IEnumerable<TSource> source,
            Predicate<TSource> predicate)
        {
            var result = source.ToLookup(item => predicate(item));
            return (result[true], result[false]);
        }

        public static Dictionary<string, TSource> ToCaseInsensitiveDictionary<TSource>(this IEnumerable<TSource> items, Func<TSource, string> keySelector)
        {
            return items.ToDictionary(keySelector, StringComparer.InvariantCultureIgnoreCase);
        }

        public static Dictionary<string, TElement> ToCaseInsensitiveDictionary<TSource, TElement>(
            this IEnumerable<TSource> items,
            Func<TSource, string> keySelector,
            Func<TSource, TElement> elementSelector)
        {
            return items.ToDictionary(keySelector, elementSelector, StringComparer.InvariantCultureIgnoreCase);
        }

        public static Dictionary<string, TSource> ToCaseInsensitiveDictionary<TSource>(
            this IEnumerable<KeyValuePair<string, TSource>> items)
        {
            return items.ToDictionary(_ => _.Key, _ => _.Value, StringComparer.InvariantCultureIgnoreCase);
        }

        public static IEnumerable<TTarget> Distinct<TSource, TTarget>(
            this IEnumerable<TSource> items,
            Func<TSource, TTarget> itemSelector)
        {
            return items.Select(itemSelector).Distinct();
        }

        public static void Add<TKey, TValue>(
            this Dictionary<TKey, List<TValue>> items,
            TKey key,
            TValue value)
            where TKey : notnull
        {
            if (!items.ContainsKey(key))
                items[key] = new List<TValue>();

            items[key].Add(value);
        }

        public static void AddRange<TKey, TValue>(
            this Dictionary<TKey, List<TValue>> items,
            TKey key,
            IEnumerable<TValue> values)
            where TKey : notnull
        {
            if (!items.ContainsKey(key))
                items[key] = new List<TValue>();

            items[key].AddRange(values);
        }

        public static async Task<IEnumerable<TResult>> AggregateAsync<TResult>(
            this IEnumerable<Task<TResult>> taskItems)
        {
            var results = new List<TResult>();
            foreach (var taskItem in taskItems)
                results.Add(await taskItem);
            return results;
        }

        public static async Task<TAccumulate> AggregateAsync<TSource, TAccumulate>(
            this IEnumerable<Task<TSource>> source,
            TAccumulate seed,
            Action<TAccumulate, TSource> action) where TAccumulate : class
        {
            foreach (var itemTask in source)
                action(seed, await itemTask);
            return seed;
        }
    }
}
