namespace PPI_API.UnitOfWork.Repositories.Asset
{
    using PPI_API.Models;
    using System.Collections.Generic;

    public interface IAssetRepository
    {
        int GetAssetType(int assetId);

        decimal GetAssetPrice(int assetId);

        IEnumerable<AssetModel> GetAssets();

        IEnumerable<AssetTypeModel> GetAssetTypes();

        IEnumerable<int> GetAssetIds();
    }
}