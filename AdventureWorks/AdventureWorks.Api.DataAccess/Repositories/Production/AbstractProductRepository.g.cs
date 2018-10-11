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

		public async Task<Product> ByName(string name)
		{
			return await this.Context.Set<Product>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async Task<Product> ByProductNumber(string productNumber)
		{
			return await this.Context.Set<Product>().SingleOrDefaultAsync(x => x.ProductNumber == productNumber);
		}

		public async virtual Task<List<BillOfMaterial>> BillOfMaterials(int productAssemblyID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<BillOfMaterial>().Where(x => x.ProductAssemblyID == productAssemblyID).AsQueryable().Skip(offset).Take(limit).ToListAsync<BillOfMaterial>();
		}

		public async virtual Task<List<ProductCostHistory>> ProductCostHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductCostHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductCostHistory>();
		}

		public async virtual Task<List<ProductInventory>> ProductInventories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductInventory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductInventory>();
		}

		public async virtual Task<List<ProductListPriceHistory>> ProductListPriceHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductListPriceHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductListPriceHistory>();
		}

		public async virtual Task<List<ProductProductPhoto>> ProductProductPhotoes(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductProductPhoto>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
		}

		public async virtual Task<List<ProductReview>> ProductReviews(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductReview>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductReview>();
		}

		public async virtual Task<List<TransactionHistory>> TransactionHistories(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TransactionHistory>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<TransactionHistory>();
		}

		public async virtual Task<List<WorkOrder>> WorkOrders(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<WorkOrder>().Where(x => x.ProductID == productID).AsQueryable().Skip(offset).Take(limit).ToListAsync<WorkOrder>();
		}

		// Reference foreign key. Reference Table=ProductDocument. First table=products. Second table=products
		public async virtual Task<List<Product>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.ProductDocuments
			              join products in this.Context.Products on
			              refTable.ProductID equals products.ProductID
			              where refTable.ProductID == productID
			              select products).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Product>> Where(
			Expression<Func<Product, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Product, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Product>();
			}
			else
			{
				return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Product>();
			}
		}

		private async Task<Product> GetById(int productID)
		{
			List<Product> records = await this.Where(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fe9447faa10a3ec152150a19cf1df8eb</Hash>
</Codenesium>*/