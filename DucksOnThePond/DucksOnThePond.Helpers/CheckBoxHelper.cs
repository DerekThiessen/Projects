using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Web.Routing;
using System.Linq;
using System.Reflection;

namespace DucksOnThePond.Helpers
{
    public static class CheckBoxHelper
    {
        public static MvcHtmlString CheckBoxListForEnum<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, IEnumerable<TEnum>>> expression)
        {
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            TagBuilder tg = new TagBuilder("div");
            string innerhtml = "";
            var model = metadata.Model as IEnumerable<TEnum>;
            foreach (var item in Enum.GetValues(typeof(TEnum)))
            {
                bool ischecked = (model == null) ? false : model.Any(x => x.ToString() == item.ToString());
                innerhtml = innerhtml + @"<div><label><input type='checkbox' name='" + metadata.PropertyName + "' id='chk" + item + ((ischecked) ? "checked='checked'" : "") + " value='" + item + "' />"+ item +"</label></div>";
            }
            tg.SetInnerText(innerhtml);
            return new MvcHtmlString(innerhtml);
        }
    }
}