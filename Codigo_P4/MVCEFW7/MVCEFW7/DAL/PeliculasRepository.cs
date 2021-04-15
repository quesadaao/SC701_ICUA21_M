using MVCEFW7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCEFW7.DAL
{
    public class PeliculasRepository
    {
        public List<Pelicula> GetPeliculas(){
            var list = new List<Pelicula>();
            Pelicula pelicula = new Pelicula { Titulo = "Dragon Ball", EstaEnCartelera = false, Genero = "Anime" };
            list.Add(pelicula);
            pelicula = new Pelicula { Titulo = "Shazam", EstaEnCartelera = true, Genero = "DC" };
            list.Add(pelicula);
            pelicula = new Pelicula { Titulo = "<b>Movie WWE</b>", EstaEnCartelera = true, Genero = "Acccion" };
            list.Add(pelicula);

            return list;
        }

        public List<SelectListItem> GetData() {

            var listado = new List<SelectListItem>() {
                                new SelectListItem(){ Text = "House", Value = "1"},
                                new SelectListItem(){ Text = "Roots", Value ="2"},
                                new SelectListItem(){ Text = "Trova", Value ="3", Disabled = true}
                                                    };

            return listado;
        }
    }
}