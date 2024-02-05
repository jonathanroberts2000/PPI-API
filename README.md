Run Tests:

* Para ejecutar los tests con un token valido, se recomienda ejecutar la obtención del token y el resultado del mismo, setearlo en la propiedad "BearerTokenTest" del archivo jwt.Development.json ya que el mismo tiene una duración de 2 horas.

dotnet test --filter "Categoria=Create"

dotnet test --filter "Categoria=Delete"

dotnet test --filter "Categoria=GetAssets"

dotnet test --filter "Categoria=GetAssetTypes"

dotnet test --filter "Categoria=GetOrder"

dotnet test --filter "Categoria=GetOrders"

dotnet test --filter "Categoria=GetStatus"

dotnet test --filter "Categoria=Update"

![image](https://github.com/jonathanroberts2000/PPI-API/assets/47385932/43db9a5e-6fa1-4bbc-9e1e-81edf153b6c4)
