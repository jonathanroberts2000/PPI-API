namespace PPI_Core.Services.Asset
{
    using System.Linq;
    using PPI_API.UnitOfWork;
    using PPI_API.AssetActions.GetAssets;
    using PPI_API.AssetActions.GetAssetTypes;

    public class AssetService : IAssetService
    {
        private readonly IUnitOfWork unitOfWork;

        public AssetService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public GetAssetsResponse GetAssets()
        {
            return new()
            {
                Assets = unitOfWork.Asset.GetAssets().ToList()
            };
        }

        public GetAssetTypesResponse GetAssetTypes()
        {
            return new()
            {
                AssetTypes = unitOfWork.Asset.GetAssetTypes().ToList()
            };
        }
    }
}