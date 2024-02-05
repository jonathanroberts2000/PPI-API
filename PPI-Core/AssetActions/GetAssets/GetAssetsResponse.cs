namespace PPI_API.AssetActions.GetAssets
{
    using PPI_API.Models;
    using System.Collections.Generic;

    public class GetAssetsResponse
    {
        public List<AssetModel> Assets { get; set; }
    }
}