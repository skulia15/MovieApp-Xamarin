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
			List<Movie> movies = ConvertToMovie(movieInfos);
			return movies;
		}

		private static List<Movie> ConvertToMovie(List<MovieInfo> movieInfos)
		{
			List<Movie> movies = new List<Movie>();
			foreach (MovieInfo movie in movieInfos)
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

		public async Task<List<Movie>> GetTopRatedMoviesAsync()
		{
			var topRated = await movieApi.GetTopRatedAsync();
			var movies = GetMoviesFromResponse(topRated);
			return ConvertToMovie(movies);
		}

		public async Task<List<Movie>> GetPopularMoviesAsync()
		{
			var popular = await movieApi.GetPopularAsync();
			var movies = GetMoviesFromResponse(popular);
			return ConvertToMovie(movies);
		}

	}
}