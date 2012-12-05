using System.Collections.Generic;
using Elmah;

namespace ElmahViewer.Models
{
    public class SqlErrorLogFactory:IErrorLogFactory
    {
        private readonly string _connectionStringName;

        public SqlErrorLogFactory():this("Elmah")
        {
        }

        public SqlErrorLogFactory(string connectionStringName)
        {
            _connectionStringName = connectionStringName;
        }

        public ErrorLog Create(string applicationId)
        {
            var config = new Dictionary<string, string> { { "applicationName", applicationId }, { "connectionStringName", _connectionStringName } };
            var log = new SqlErrorLog(config);
            return log;
        }
    }
}