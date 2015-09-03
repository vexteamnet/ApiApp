using System;

namespace ApiApp.Models.Core
{
    /// <summary>
    /// Base class for links
    /// </summary>
    public abstract class Link
    {
        public string Rel { get; private set; }
        public string Href { get; private set; }
        public string Title { get; private set; }

        public Link(string relation, string href, string title = null)
        {
            if (string.IsNullOrEmpty(relation))
                throw new ArgumentNullException(nameof(relation));
            if (string.IsNullOrEmpty(href))
                throw new ArgumentNullException(nameof(href));

            Rel = relation;
            Href = href;
            Title = title;
        }
    }

    public class GetLink : Link
    {
        public const string _Relation = "get";

        public GetLink(string href, string title = null) : base (_Relation, href, title) { }
    }
}