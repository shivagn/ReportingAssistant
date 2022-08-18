using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ReportingAssistant.HtmlHelpers
{
    public static class HtmlFile
    {
        public static HtmlString File(this HtmlHelper htmlHelper, string name, string className)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type", "file");
            tag.MergeAttribute("name", name);
            tag.MergeAttribute("class", className);

            return MvcHtmlString.Create(tag.ToString(TagRenderMode.SelfClosing));
        }
    }
}