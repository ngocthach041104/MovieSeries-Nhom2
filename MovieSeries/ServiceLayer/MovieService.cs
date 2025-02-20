using Pj.CoreLayer.Entities;
using Pj.RepositoryLayer.Interfaces;
using Pj.ServiceLayer.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pj.ServiceLayer.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<Movie>> GetAllMoviesAsync()
        {
            return await _movieRepository.GetAllAsync();
        }

        public async Task<Movie> GetMovieByIdAsync(int id)
        {
            return await _movieRepository.GetByIdAsync(id);
        }

        public async Task AddMovieAsync(Movie movie)
        {
            // Có thể thêm logic kiểm tra/validate (vd: trùng tiêu đề) tại đây
            await _movieRepository.AddAsync(movie);
        }

        public async Task UpdateMovieAsync(Movie movie)
        {
            await _movieRepository.UpdateAsync(movie);
        }

        public async Task DeleteMovieAsync(int id)
        {
            await _movieRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetTopRatedMoviesWithSpAsync(int topCount)
        {
            return await _movieRepository.GetTopRatedMoviesWithSpAsync(topCount);
        }

        public bool AddMovie(Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
