using Domaine.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projet.Helper
{
    public static class ExtensionMethodsTouristicPlaces
    {

        public static IEnumerable<SelectListItem> dropDownList(this IEnumerable<TouristicPlaces> tp)
        {
            return tp.OrderBy(a => a.IdTouristicPlaces).Select(a => new SelectListItem
            {
                Text = a.nameTouristicPlace,
                Value = a.IdTouristicPlaces.ToString()

            });
        }

    }
}
