using DM.MovieApi.MovieDb.Genres;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MovieSearch
{
	public class Movie
	{
		private readonly string POSTER_URL = "http://image.tmdb.org/t/p/original";

		public int Id { get; set; }
		public string Title { get; set; }
		public int Year { get; set; }
		public List<string> ListCast { get; set; }
		public string Cast { get; set; }
		public string Poster { get; set; }
		public string Backdrop { get; set; }
		public List<string> ListGenres { get; set; }
		public string Genres { get; set; }
		public int? Runtime { get; set; }
		public string Description { get; set; }
		public string Tagline { get; set; }
		public ImageSource PosterImageSource => ImageSource.FromUri(CastStringToUri(this.Poster));
		public ImageSource BackdropImageSource => ImageSource.FromUri(CastStringToUri(this.Backdrop));

		public string GetStringedGenres()
		{
			string stringedGenres = "";
			foreach (string g in ListGenres)
			{
				if (stringedGenres != "")
				{
					stringedGenres += ", ";
				}
				stringedGenres += g;
			}
			return stringedGenres;
		}

		public string CastToString() // pun intended
		{
			string castMembers = "";
			for (int i = 0; i < ListCast.Count && i < 3; i++)
			{
				if (i != 0)
				{
					castMembers += ", ";
				}
				castMembers += ListCast[i];
			}
			return castMembers;
		}

		public Uri CastStringToUri(string path)
		{
			Uri.TryCreate(POSTER_URL + path, UriKind.Absolute, out Uri returnUri);
			return returnUri;
		}
	}
}