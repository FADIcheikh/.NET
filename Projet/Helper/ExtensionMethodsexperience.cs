using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projet.Helper
{
    public static class ExtensionMethodsexperience
    {

        //Liste déroulante
        public static IEnumerable<SelectListItem> ToSelectItem(this IEnumerable<String> TS)
        {
            return TS.OrderBy(type => TS)
                  .Select(type =>
                  new SelectListItem
                  {
                      Text = type,
                      Value = type
                  });
        }
    }
}
