namespace PPI_Data.UnitOfWork.Repositories.Rule
{
    using Dapper;
    using PPI_Model.Models;
    using Microsoft.Data.SqlClient;
    using PPI_API.UnitOfWork.Commons;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;

    public class RuleRepository : IRuleRepository
    {
        private readonly string cs;

        public RuleRepository(IConfiguration configuration)
        {
            cs = configuration.GetConnectionString("PPI");
        }

        public IEnumerable<ErrorModel> GetErrorMessages()
        {
            using SqlConnection connection = new(cs);
            IEnumerable<ErrorModel> result = connection.Query<ErrorModel>(Queries.GetErrorMessagesQuery);

            return result;
        }
    }
}