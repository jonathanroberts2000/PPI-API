namespace PPI_API.AssetActions.GetAssetTypes
{
    using PPI_API.Models;
    using System.Collections.Generic;

    public class GetAssetTypesResponse
    {
        public List<AssetTypeModel> AssetTypes { get; set; }
    }
}