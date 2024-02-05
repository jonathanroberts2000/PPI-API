namespace PPI_Data.UnitOfWork.Repositories.Rule
{
    using PPI_Model.Models;
    using System.Collections.Generic;

    public interface IRuleRepository
    {
        IEnumerable<ErrorModel> GetErrorMessages();
    }
}
