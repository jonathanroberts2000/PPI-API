namespace PPI_API.UnitOfWork.Repositories.Asset
{
    using Dapper;
    using PPI_API.Models;
    using Microsoft.Data.SqlClient;
    using PPI_API.UnitOfWork.Commons;
    using System.Collections.Generic;
    using Microsoft.Extensions.Configuration;

    public class AssetRepository : IAssetRepository
    {
        private readonly string cs;

        public AssetRepository(IConfiguration configuration)
        {
            cs = configuration.GetConnectionString("PPI");
        }

        public int GetAssetType(int assetId)
        {
            string query = string.Format(Queries.GetAssetTypeIdQuery, assetId);

            using SqlConnection connection = new(cs);
            int result = connection.QuerySingle<int>(query);

            return result;
        }

        public decimal GetAssetPrice(int assetId)
        {
            string query = string.Format(Queries.GetAssetPriceQuery, assetId);

            using SqlConnection connection = new(cs);
            decimal result = connection.QuerySingle<decimal>(query);

            return result;
        }

        public IEnumerable<AssetModel> GetAssets()
        {
            using SqlConnection connection = new(cs);
            IEnumerable<AssetModel> result = connection.Query<AssetModel>(Queries.GetAssetsQuery);

            return result;
        }

        public IEnumerable<AssetTypeModel> GetAssetTypes()
        {
            using SqlConnection connection = new(cs);
            IEnumerable<AssetTypeModel> result = connection.Query<AssetTypeModel>(Queries.GetAssetTypesQuery);

            return result;
        }

        public IEnumerable<int> GetAssetIds()
        {
            using SqlConnection connection = new(cs);
            IEnumerable<int> result = connection.Query<int>(Queries.GetAssetIdsQuery);

            return result;
        }
    }
}