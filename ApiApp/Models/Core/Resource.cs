using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiApp.Models.Core
{
    public abstract class Resource
    {
        private readonly List<Link> links = new List<Link>();

        [JsonProperty(Order = 100)]
        public IEnumerable<Link> Links { get { return links; } }

        public void AddLink(Link link)
        {
            if (link != null)
                links.Add(link);
        }

        public void AddLinks(params Link[] links)
        {
            Array.ForEach(links, link => AddLink(link));
        }
    }

    public static class Extensions
    {
        public static IQueryable<T> ForEach<T>(this IQueryable<T> queryable, Action<T> action)
        {
            var list = queryable.ToList();
            list.ForEach(action);
            return list.AsQueryable();
        }
    }
}