using Domaine.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Projet.Helper
{
    public static class ExtensionMethodsevents
    {
        public static IEnumerable<SelectListItem> ToSelectListItems(
               this IEnumerable<TouristicPlaces> touristicPlaces)
        {
            return
                touristicPlaces.OrderBy(tour => tour.nameTouristicPlace)
                      .Select(tour =>
                          new SelectListItem
                          {
                              //     Selected = (prod.ProducteurId == selectedId),
                              Text = tour.nameTouristicPlace,
                              Value = tour.IdTouristicPlaces.ToString()
                          });
        }




        public static IEnumerable<SelectListItem> ToSelectListItem(
                 this IEnumerable<string> genres)
        {
            return
                genres.OrderBy(genre => genre)
                      .Select(genre =>
                          new SelectListItem
                          {

                              Text = genre,
                              Value = genre
                          });
        }

    }
}