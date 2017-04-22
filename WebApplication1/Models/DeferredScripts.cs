using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public static class DeferredScripts
    {
        static IList<string> paths = new List<string>();

        public static IList<string> Scripts { get; set; }

        public static void Add(string path)
        {
            if (Scripts == null)
            {
                Scripts = new List<string>();
            }

            if (!paths.Any(s => s.Equals(path, StringComparison.OrdinalIgnoreCase)))
            {
                var script = new TagBuilder("script");
                script.Attributes.Add("src", path);

                Scripts.Add(script.ToString());
                paths.Add(path);
            }
        }
    }
}