using LinqToDB.Data;
using System.Data;

namespace Infrastructure.Common
{
    public class BasicTransaction : IDbTransaction
    {
        public IDbConnection? Connection => _dataConnection.Connection;

        public IsolationLevel IsolationLevel => IsolationLevel.Unspecified;

        private readonly DataConnection _dataConnection;

        private readonly DataConnectionTransaction _dcTransaction;

        public BasicTransaction(DataConnection dataConnection)
        {
            _dataConnection = dataConnection;

            _dcTransaction = dataConnection.BeginTransaction(IsolationLevel);
        }

        public void Commit()
        {
            _dcTransaction.Commit();
        }

        public void Dispose()
        {
            _dcTransaction?.Dispose();
        }

        public void Rollback()
        {
            _dcTransaction.Rollback();
        }
    }
}
