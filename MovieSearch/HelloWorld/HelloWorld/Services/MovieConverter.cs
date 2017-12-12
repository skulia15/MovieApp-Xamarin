using DM.MovieApi;
using DM.MovieApi.ApiResponse;
using DM.MovieApi.MovieDb.Genres;
using DM.MovieApi.MovieDb.Movies;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MovieSearch.Services
{
	public class MovieConverter : IMovieConverter
	{
		IApiMovieRequest movieApi;

		public MovieConverter(IMovieDbSettings settings)
		{
			MovieDbFactory.RegisterSettings(settings);
			movieApi = MovieDbFactory.Create<IApiMovieRequest>().Value;
		}

		public async Task<List<Movie>> GetMoviesByTitleAsync(string title)
		{
			List<MovieInfo> movieInfos = new List<MovieInfo>();

			if (title != null && title != "")
			{
				var titleResponse = await movieApi.SearchByTitleAsync(title);
				movieInfos = GetMoviesFromResponse(titleResponse);
			}
			List<Movie> movies = new List<Movie>();
			foreach(MovieInfo movie in movieInfos)
			{
				List<string> genres = GetGenres(movie);
				movies.Add(new Movie
				{
					Id = movie.Id,
					Title = movie.Title,
					Year = movie.ReleaseDate.Year,
					ListCast = null,
					Poster = movie.PosterPath,
					Backdrop = movie.BackdropPath,
					ListGenres = genres,
					Description = movie.Overview,
					Tagline = null,
					Runtime = null

				});
			}
			return movies;
		}

		public async Task<DM.MovieApi.MovieDb.Movies.Movie> GetMovieByIdAsync(int id)
		{
			List<MovieInfo> movies = new List<MovieInfo>();

			var idResponse = await movieApi.FindByIdAsync(id);
			return idResponse.Item;
		}

		private List<MovieInfo> GetMoviesFromResponse(ApiSearchResponse<MovieInfo> response)
		{
			List<MovieInfo> movies = new List<MovieInfo>();
			foreach (MovieInfo m in response.Results)
			{
				movies.Add(m);
				//var movie = await GetMovieFromMovieInfo(m);
				//movies.Add(movie);
			}
			return movies;
		}

		public async Task<IReadOnlyList<MovieCastMember>> GetCastByIdAsync(int id)
		{
			var creditResponse = await movieApi.GetCreditsAsync(id);
			return creditResponse.Item.CastMembers;
		}

		private static List<string> GetGenres(MovieInfo m)
		{
			List<string> genres = new List<string>();
			foreach (Genre g in m.Genres)
			{
				genres.Add(g.Name);
			};
			return genres;
		}

		//	public async Task<List<Movie>> GetTopRatedMoviesAsync()
		//	{
		//		var topRated = await movieApi.GetTopRatedAsync();
		//		var movies = GetMoviesFromResponse(topRated);
		//		return movies;
		//	}

		//	public async Task<Movie> GetMovieFromMovieInfo(MovieInfo movie)
		//	{
		//		var creditResponse = await movieApi.GetCreditsAsync(movie.Id);
		//		var movieResponse = await movieApi.FindByIdAsync(movie.Id);
		//		List<string> cast = GetCast(creditResponse);
		//		List<string> genres = GetGenres(movie);

		//		Movie newMovie = new Movie
		//		{
		//			Title = movie.Title,
		//			Year = movie.ReleaseDate.Year,
		//			ListCast = cast,
		//			Poster = movie.PosterPath,
		//			Backdrop = movie.BackdropPath,
		//			ListGenres = genres,
		//			Description = movie.Overview,
		//			Tagline = movieResponse.Item.Tagline,
		//			Runtime = movieResponse.Item.Runtime
		//		};
		//		newMovie.Cast = newMovie.CastToString();
		//		newMovie.Genres = newMovie.GetStringedGenres();

		//		return newMovie;
		//	}


		//	private static List<string> GetCast(ApiQueryResponse<MovieCredit> creditResponse)
		//	{
		//		List<string> cast = new List<string>();
		//		foreach (MovieCastMember c in creditResponse.Item.CastMembers)
		//		{
		//			cast.Add(c.Name);
		//		}

		//		return cast;
		//	}
		//}
	}
}