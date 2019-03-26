using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Product>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.ReservedClass.StartsWith(query) ||
				                  x.Color.StartsWith(query) ||
				                  x.DaysToManufacture == query.ToInt() ||
				                  x.DiscontinuedDate == query.ToNullableDateTime() ||
				                  x.FinishedGoodsFlag == query.ToBoolean() ||
				                  x.ListPrice.ToDecimal() == query.ToDecimal() ||
				                  x.MakeFlag == query.ToBoolean() ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.Name.StartsWith(query) ||
				                  x.ProductID == query.ToInt() ||
				                  x.ProductLine.StartsWith(query) ||
				                  x.ProductModelID == query.ToNullableInt() ||
				                  x.ProductNumber.StartsWith(query) ||
				                  x.ProductSubcategoryID == query.ToNullableInt() ||
				                  x.ReorderPoint == query.ToShort() ||
				                  x.Rowguid == query.ToGuid() ||
				                  x.SafetyStockLevel == query.ToShort() ||
				                  x.SellEndDate == query.ToNullableDateTime() ||
				                  x.SellStartDate == query.ToDateTime() ||
				                  x.Size.StartsWith(query) ||
				                  x.SizeUnitMeasureCode.StartsWith(query) ||
				                  x.StandardCost.ToDecimal() == query.ToDecimal() ||
				                  x.Style.StartsWith(query) ||
				                  x.Weight == query.ToNullableDouble() ||
				                  x.WeightUnitMeasureCode.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Product> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<Product> Create(Product item)
		{
			this.Context.Set<Product>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Product item)
		{
			var entity = this.Context.Set<Product>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<Product>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productID)
		{
			Product record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Product>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_Product_Name.
		public async virtual Task<Product> ByName(string name)
		{
			return await this.Context.Set<Product>()
			       .Include(x => x.ProductModelIDNavigation)
			       .Include(x => x.ProductSubcategoryIDNavigation)
			       .Include(x => x.SizeUnitMeasureCodeNavigation)
			       .Include(x => x.WeightUnitMeasureCodeNavigation)

			       .FirstOrDefaultAsync(x => x.Name == name);
		}

		// unique constraint AK_Product_ProductNumber.
		public async virtual Task<Product> ByProductNumber(string productNumber)
		{
			return await this.Context.Set<Product>()
			       .Include(x => x.ProductModelIDNavigation)
			       .Include(x => x.ProductSubcategoryIDNavigation)
			       .Include(x => x.SizeUnitMeasureCodeNavigation)
			       .Include(x => x.WeightUnitMeasureCodeNavigation)

			       .FirstOrDefaultAsync(x => x.ProductNumber == productNumber);
		}

		// unique constraint AK_Product_rowguid.
		public async virtual Task<Product> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Product>()
			       .Include(x => x.ProductModelIDNavigation)
			       .Include(x => x.ProductSubcategoryIDNavigation)
			       .Include(x => x.SizeUnitMeasureCodeNavigation)
			       .Include(x => x.WeightUnitMeasureCodeNavigation)

			       .FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Foreign key reference to this table BillOfMaterial via componentID.
		public async virtual Task<List<BillOfMaterial>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>()
			       .Include(x => x.ComponentIDNavigation)
			       .Include(x => x.ProductAssemblyIDNavigation)
			       .Include(x => x.UnitMeasureCodeNavigation)

			       .Where(x => x.ComponentID == componentID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		// Foreign key reference to this table BillOfMaterial via productAssemblyID.
		public async virtual Task<List<BillOfMaterial>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>()
			       .Include(x => x.ComponentIDNavigation)
			       .Include(x => x.ProductAssemblyIDNavigation)
			       .Include(x => x.UnitMeasureCodeNavigation)

			       .Where(x => x.ProductAssemblyID == productAssemblyID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		// Foreign key reference to this table ProductProductPhoto via productID.
		public async virtual Task<List<ProductProductPhoto>> ProductProductPhotoesByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductProductPhoto>()
			       .Include(x => x.ProductIDNavigation)
			       .Include(x => x.ProductPhotoIDNavigation)

			       .Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
		}

		// Foreign key reference to this table ProductReview via productID.
		public async virtual Task<List<ProductReview>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductReview>()
			       .Include(x => x.ProductIDNavigation)

			       .Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductReview>();
		}

		// Foreign key reference to this table TransactionHistory via productID.
		public async virtual Task<List<TransactionHistory>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TransactionHistory>()
			       .Include(x => x.ProductIDNavigation)

			       .Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
		}

		// Foreign key reference to this table WorkOrder via productID.
		public async virtual Task<List<WorkOrder>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<WorkOrder>()
			       .Include(x => x.ProductIDNavigation)
			       .Include(x => x.ScrapReasonIDNavigation)

			       .Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrder>();
		}

		// Foreign key reference to table ProductModel via productModelID.
		public async virtual Task<ProductModel> ProductModelByProductModelID(int? productModelID)
		{
			return await this.Context.Set<ProductModel>()
			       .SingleOrDefaultAsync(x => x.ProductModelID == productModelID);
		}

		// Foreign key reference to table ProductSubcategory via productSubcategoryID.
		public async virtual Task<ProductSubcategory> ProductSubcategoryByProductSubcategoryID(int? productSubcategoryID)
		{
			return await this.Context.Set<ProductSubcategory>()
			       .SingleOrDefaultAsync(x => x.ProductSubcategoryID == productSubcategoryID);
		}

		// Foreign key reference to table UnitMeasure via sizeUnitMeasureCode.
		public async virtual Task<UnitMeasure> UnitMeasureBySizeUnitMeasureCode(string sizeUnitMeasureCode)
		{
			return await this.Context.Set<UnitMeasure>()
			       .SingleOrDefaultAsync(x => x.UnitMeasureCode == sizeUnitMeasureCode);
		}

		// Foreign key reference to table UnitMeasure via weightUnitMeasureCode.
		public async virtual Task<UnitMeasure> UnitMeasureByWeightUnitMeasureCode(string weightUnitMeasureCode)
		{
			return await this.Context.Set<UnitMeasure>()
			       .SingleOrDefaultAsync(x => x.UnitMeasureCode == weightUnitMeasureCode);
		}

		protected async Task<List<Product>> Where(
			Expression<Func<Product, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Product, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductID;
			}

			return await this.Context.Set<Product>()
			       .Include(x => x.ProductModelIDNavigation)
			       .Include(x => x.ProductSubcategoryIDNavigation)
			       .Include(x => x.SizeUnitMeasureCodeNavigation)
			       .Include(x => x.WeightUnitMeasureCodeNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Product>();
		}

		private async Task<Product> GetById(int productID)
		{
			List<Product> records = await this.Where(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>160e78216ee9893d41169afc6ff8994a</Hash>
</Codenesium>*/