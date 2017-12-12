using DM.MovieApi.MovieDb.Movies;
using MovieSearch;
using MovieSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF
{
	public class MovieController
	{
		MovieConverter converter = new MovieConverter(new MovieDbSettings());

		public async Task<List<MovieSearch.Movie>> GetMoviesByTitleAsync(string searchTerm)
		{
			List<MovieSearch.Movie> movies = await converter.GetMoviesByTitleAsync(searchTerm);
			return movies;
		}

		public async Task<DM.MovieApi.MovieDb.Movies.Movie> GetMovieByIdAsync(int id)
		{
			return await converter.GetMovieByIdAsync(id);
		}

		public async Task<List<string>> GetCastByIdAsync(int id)
		{
			var creditResponse = await converter.GetCastByIdAsync(id);
			List<string> cast = new List<string>();
			foreach (MovieCastMember c in creditResponse)
			{
				cast.Add(c.Name);
			}

			return cast;
		}

	}
}
