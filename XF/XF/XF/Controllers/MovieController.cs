﻿using DM.MovieApi.MovieDb.Movies;
using MovieSearch;
using MovieSearch.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF.Controllers
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

		public async Task<List<MovieSearch.Movie>> GetTopRated()
		{
			List<MovieSearch.Movie> movies = await converter.GetTopRatedMoviesAsync();
			return movies;
		}

		public async Task<List<MovieSearch.Movie>> GetPopular()
		{
			List<MovieSearch.Movie> movies = await converter.GetPopularMoviesAsync();
			return movies;
		}

		public async Task<List<CastMember>> GetCastByIdAsync(int id)
		{
			List<CastMember> cast = await converter.GetCastByIdAsync(id);
			
			return cast;
		}

	}
}
