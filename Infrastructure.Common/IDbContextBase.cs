using System.Data;
using System.Data.Common;
using System.Linq.Expressions;

namespace YACEE.WEB.Abstraction.Interfaces
{
    public interface IDbContextBase
    {
        Task<int> AddAsync<T>(T item, CancellationToken cancellationToken = default) where T : class;

        Task<int> UpdateAsync<T>(Expression<Func<T, T>> updateExpression, Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken = default) where T : class;

        Task<int> DeleteAsync<T>(Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken= default) where T : class;

        Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>>? filterExpression = null, CancellationToken cancellationToken = default) where T : class;

        Task<IList<T>?> ToListAsync<T>(Expression<Func<T, bool>>? filterExpression = null, CancellationToken cancellationToken = default) where T : class;

        Task<bool> ExecuteProcedureAsync(string procedureName, CancellationToken cancellationToken = default, params DbParameter[] argumetns);

        Task<T?> ExecuteSqlAsync<T>(string sql, object? args = null, CancellationToken cancellationToken = default) where T : class;

        Task<int> ExecuteSqlAsync(string sql, object? args = null, CancellationToken cancellationToken = default);

        IDbTransaction CreateTransaction();
    }
}
