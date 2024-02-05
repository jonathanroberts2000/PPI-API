namespace PPI_API.UnitOfWork.Commons
{
    public static class Queries
    {
        internal const string GetOrdersByAccountIdQuery = @"EXEC dbo.GetOrdersByAccountId {0}";

        internal const string GetOrderByIdQuery = @"EXEC dbo.GetOrderById {0}";

        internal const string InsertOrderQuery = @"EXEC dbo.InsertOrder {0}, {1}, {2}, {3}, {4}, {5}, '{6}', {7}";

        internal const string UpdateOrderQuery = @"UPDATE dbo.Orders
                                                    SET StatusId = {0}
                                                WHERE Id = {1}";

        internal const string DeleteOrderQuery = @"DELETE
                                                    FROM dbo.Orders
                                                WHERE Id = {0}";

        internal const string GetOrderStatusQuery = @"EXEC dbo.GetOrderStatus";

        internal const string GetExistsOrderQuery = @"SELECT CASE WHEN
                                                        (EXISTS(
                                                            SELECT 
                                                                Id
                                                            FROM dbo.Orders (NOLOCK)
                                                            WHERE Id = {0}
                                                        ))
                                                        THEN 1
                                                        ELSE 0
                                                        END";

        internal const string GetExistsAccountQuery = @"SELECT CASE WHEN
                                                            (EXISTS(
                                                                SELECT
                                                                    AccountId
                                                                FROM dbo.Users (NOLOCK)
                                                                WHERE AccountId = {0}
                                                            ))
                                                            THEN 1
                                                            ELSE 0
                                                            END";

        internal const string GetAssetTypeIdQuery = @"SELECT
                                                    AssetTypeId
                                                FROM dbo.Assets (NOLOCK)
                                                WHERE Id = {0}";

        internal const string GetAssetPriceQuery = @"SELECT
                                                    UnitPrice
                                                FROM dbo.Assets (NOLOCK)
                                                WHERE Id = {0}";

        internal const string GetAssetIdsQuery = @"SELECT
                                                  Id
                                                FROM dbo.Assets (NOLOCK)";

        internal const string GetAssetsQuery = @"EXEC dbo.GetAssets";

        internal const string GetAssetTypesQuery = @"EXEC dbo.GetAssetTypes";

        internal const string GetExistsUserQuery = @"EXEC dbo.GetExistsUser '{0}', '{1}'";

        internal const string GetErrorMessagesQuery = @"EXEC dbo.GetErrorMessages";
    }
}