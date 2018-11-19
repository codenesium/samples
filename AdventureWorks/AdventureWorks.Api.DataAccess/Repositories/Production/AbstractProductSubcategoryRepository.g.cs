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
	public abstract class AbstractProductSubcategoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductSubcategoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductSubcategory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductSubcategory> Get(int productSubcategoryID)
		{
			return await this.GetById(productSubcategoryID);
		}

		public async virtual Task<ProductSubcategory> Create(ProductSubcategory item)
		{
			this.Context.Set<ProductSubcategory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductSubcategory item)
		{
			var entity = this.Context.Set<ProductSubcategory>().Local.FirstOrDefault(x => x.ProductSubcategoryID == item.ProductSubcategoryID);
			if (entity == null)
			{
				this.Context.Set<ProductSubcategory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productSubcategoryID)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductSubcategory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_ProductSubcategory_Name.
		public async virtual Task<ProductSubcategory> ByName(string name)
		{
			return await this.Context.Set<ProductSubcategory>().SingleOrDefaultAsync(x => x.Name == name);
		}

		// unique constraint AK_ProductSubcategory_rowguid.
		public async virtual Task<ProductSubcategory> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<ProductSubcategory>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Foreign key reference to this table Product via productSubcategoryID.
		public async virtual Task<List<Product>> ProductsByProductSubcategoryID(int productSubcategoryID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Product>().Where(x => x.ProductSubcategoryID == productSubcategoryID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Product>();
		}

		protected async Task<List<ProductSubcategory>> Where(
			Expression<Func<ProductSubcategory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductSubcategory, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductSubcategoryID;
			}

			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductSubcategory>();
		}

		private async Task<ProductSubcategory> GetById(int productSubcategoryID)
		{
			List<ProductSubcategory> records = await this.Where(x => x.ProductSubcategoryID == productSubcategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e6152ab06280e7758b969af93f5070a1</Hash>
</Codenesium>*/