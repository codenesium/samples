using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public partial interface IProductRepository
	{
		Task<Product> Create(Product item);

		Task Update(Product item);

		Task Delete(int productID);

		Task<Product> Get(int productID);

		Task<List<Product>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<Product> ByName(string name);

		Task<Product> ByProductNumber(string productNumber);

		Task<Product> ByRowguid(Guid rowguid);

		Task<List<BillOfMaterial>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0);

		Task<List<BillOfMaterial>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductProductPhoto>> ProductProductPhotoesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<ProductReview>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<TransactionHistory>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<List<WorkOrder>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0);

		Task<ProductModel> ProductModelByProductModelID(int? productModelID);

		Task<ProductSubcategory> ProductSubcategoryByProductSubcategoryID(int? productSubcategoryID);

		Task<UnitMeasure> UnitMeasureBySizeUnitMeasureCode(string sizeUnitMeasureCode);

		Task<UnitMeasure> UnitMeasureByWeightUnitMeasureCode(string weightUnitMeasureCode);
	}
}

/*<Codenesium>
    <Hash>58a57b22149049bb7c1351ce96e96b0e</Hash>
</Codenesium>*/