namespace PPI_Core.Services.Asset
{
    using PPI_API.AssetActions.GetAssets;
    using PPI_API.AssetActions.GetAssetTypes;

    public interface IAssetService
    {
        GetAssetsResponse GetAssets();

        GetAssetTypesResponse GetAssetTypes();
    }
}