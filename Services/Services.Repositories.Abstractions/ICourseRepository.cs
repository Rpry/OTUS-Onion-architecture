using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;

namespace Services.Repositories.Abstractions
{
    /// <summary>
    /// Интерфейс репозитория работы с уроками
    /// </summary>
    public interface ICourseRepository: IRepository<Course, int>
    {
        /// <summary>
        /// Получить постраничный список
        /// </summary>
        /// <param name="page">номер страницы</param>
        /// <param name="itemsPerPage">объем страницы</param>
        /// <returns> Список курсов</returns>
        Task<List<Course>> GetPagedAsync(int page, int itemsPerPage);
    }
}
