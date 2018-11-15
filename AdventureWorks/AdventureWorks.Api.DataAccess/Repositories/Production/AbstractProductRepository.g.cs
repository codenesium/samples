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

		public virtual Task<List<Product>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<Product> ByName(string name)
		{
			return await this.Context.Set<Product>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<Product> ByProductNumber(string productNumber)
		{
			return await this.Context.Set<Product>().SingleOrDefaultAsync(x => x.ProductNumber == productNumber);
		}

		public async virtual Task<Product> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Product>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		public async virtual Task<List<BillOfMaterial>> BillOfMaterialsByProductAssemblyID(int productAssemblyID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>().Where(x => x.ProductAssemblyID == productAssemblyID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		public async virtual Task<List<BillOfMaterial>> BillOfMaterialsByComponentID(int componentID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>().Where(x => x.ComponentID == componentID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		public async virtual Task<List<ProductReview>> ProductReviewsByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductReview>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductReview>();
		}

		public async virtual Task<List<TransactionHistory>> TransactionHistoriesByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TransactionHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
		}

		public async virtual Task<List<WorkOrder>> WorkOrdersByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<WorkOrder>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrder>();
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

			return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Product>();
		}

		private async Task<Product> GetById(int productID)
		{
			List<Product> records = await this.Where(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e612ea59a3476162eead67fb432e9424</Hash>
</Codenesium>*/