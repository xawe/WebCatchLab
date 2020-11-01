using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using WebCatch.EntityModel;

namespace WebCatch
{
    /// <summary>
    /// Search for specified links in URL
    /// </summary>
    public class LinkSolver
    {
        /// <summary>
        /// Search for specified expression links in url
        /// </summary>
        /// <param name="url">URL where need find links</param>
        /// <param name="expression">Regex to find link</param>
        /// <returns>Returns a List<References></Links></returns>
        public List<EntityModel.References> FindLinks(string url, string expression)
        {
            string html = this.GetHtmlFromUrl(url);
            return ExtractLinks(html, expression);
        }


        private List<EntityModel.References> ExtractLinks(string html, string expression)
        {
            var linkReferences = new List<EntityModel.References>();
            MatchCollection linkMatch = Regex.Matches(html, expression);            

            BuildReferences(linkReferences, linkMatch);

            return linkReferences;
        }

        private static int BuildReferences(List<References> linkReferences, MatchCollection linkMatch)
        {
            int counter = 0;
            foreach (Match match in linkMatch)
            {
                counter++;
                string link = match.Groups[0].Value;
                if (link.StartsWith("http"))
                {
                    linkReferences.Add(new EntityModel.References
                    {
                        Id = counter,
                        Url = link
                    });
                }
            }

            return counter;
        }

        private string GetHtmlFromUrl(string url)
        {
            WebClient wc = new WebClient();
            return wc.DownloadString(url);
        }
    }
}
