using LinqToDB;
using LinqToDB.Data;
using Microsoft.Extensions.Logging;
using System.Data;
using System.Data.Common;
using System.Linq.Expressions;
using YACEE.WEB.Abstraction.Interfaces;

namespace Infrastructure.Common
{
    public class DbContextBase<TContext> : DataConnection, IDbContextBase where TContext : IDataContext
    {
        private readonly ILogger<TContext> _logger;

        public DbContextBase(ILogger<TContext> logger, 
            DataOptions<TContext> options) : base(options.Options)
        {
            _logger = logger;
        }

        public async Task<int> AddAsync<T>(T item, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                return await this.InsertAsync(item, token: cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to add property of type:<{typeof(T)}>");
            }

            return -1;
        }

        public IDbTransaction CreateTransaction()
        {
            return new BasicTransaction(this);
        }

        public async Task<int> DeleteAsync<T>(Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                return await this.DeleteAsync(filterExpression, token: cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to delete records of type<{typeof(T)}>, {filterExpression}");
            }

            return -1;
        }

        public async Task<bool> ExecuteProcedureAsync(string procedureName, CancellationToken cancellationToken = default, params DbParameter[] arguments)
        {
            try
            {
                var args = arguments.Select(x => new DataParameter(x.ParameterName, x.Value))
                    .ToArray();

                await this.ExecuteProcAsync(procedureName, cancellationToken, args);

                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"Failed to execute procedure:{procedureName}");
            }

            return false;
        }

        public async Task<T?> ExecuteSqlAsync<T>(string sql, object? args = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                return await this.ExecuteAsync<T>(sql, cancellationToken, args);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to execute sql");
            }

            return null;
        }

        public async Task<int> ExecuteSqlAsync(string sql, object? args = null, CancellationToken cancellationToken = default)
        {
            try
            {
                return await this.ExecuteAsync(sql, cancellationToken, args);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "Failed to execute sql");
            }

            return -1;
        }

        public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>>? filterExpression = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                if (filterExpression == null)
                    return await this.GetTable<T>()
                            .FirstOrDefaultAsync(cancellationToken);
                else
                    return await this.GetTable<T>()
                        .FirstOrDefaultAsync(filterExpression, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to find record of type<{typeof(T)}>, {filterExpression}");
            }

            return null;
        }

        public async Task<IList<T>?> ToListAsync<T>(Expression<Func<T, bool>>? filterExpression = null, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                if (filterExpression == null)
                    return await this.GetTable<T>()
                            .ToListAsync(cancellationToken);
                else
                    return await this.GetTable<T>()
                        .Where(filterExpression)
                        .ToListAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to find record of type<{typeof(T)}>, {filterExpression}");
            }

            return null;
        }

        public async Task<int> UpdateAsync<T>(Expression<Func<T, T>> updateExpression, Expression<Func<T, bool>> filterExpression, CancellationToken cancellationToken = default) where T : class
        {
            try
            {
                return await this.GetTable<T>()
                    .Where(filterExpression)
                    .UpdateAsync(updateExpression, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Failed to update record<{typeof(T)}>, {updateExpression}");
            }

            return -1;
        }
    }
}
