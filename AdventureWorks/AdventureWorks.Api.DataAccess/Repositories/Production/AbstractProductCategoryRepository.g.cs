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
	public abstract class AbstractProductCategoryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductCategoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductCategory>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductCategory> Get(int productCategoryID)
		{
			return await this.GetById(productCategoryID);
		}

		public async virtual Task<ProductCategory> Create(ProductCategory item)
		{
			this.Context.Set<ProductCategory>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductCategory item)
		{
			var entity = this.Context.Set<ProductCategory>().Local.FirstOrDefault(x => x.ProductCategoryID == item.ProductCategoryID);
			if (entity == null)
			{
				this.Context.Set<ProductCategory>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productCategoryID)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCategory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// unique constraint AK_ProductCategory_Name.
		public async virtual Task<ProductCategory> ByName(string name)
		{
			return await this.Context.Set<ProductCategory>().SingleOrDefaultAsync(x => x.Name == name);
		}

		// unique constraint AK_ProductCategory_rowguid.
		public async virtual Task<ProductCategory> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<ProductCategory>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// Foreign key reference to this table ProductSubcategory via productCategoryID.
		public async virtual Task<List<ProductSubcategory>> ProductSubcategoriesByProductCategoryID(int productCategoryID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<ProductSubcategory>().Where(x => x.ProductCategoryID == productCategoryID).AsQueryable().Skip(offset).Take(limit).ToListAsync<ProductSubcategory>();
		}

		protected async Task<List<ProductCategory>> Where(
			Expression<Func<ProductCategory, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductCategory, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductCategoryID;
			}

			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductCategory>();
		}

		private async Task<ProductCategory> GetById(int productCategoryID)
		{
			List<ProductCategory> records = await this.Where(x => x.ProductCategoryID == productCategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1c7b36c274c7f4902a990f5bb085b2cb</Hash>
</Codenesium>*/