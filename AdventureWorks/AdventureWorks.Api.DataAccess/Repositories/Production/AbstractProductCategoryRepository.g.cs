using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractProductCategoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductCategoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<ProductCategory> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<ProductCategory>> Where(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductCategory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductCategory>> SearchLinqEF(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}
			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCategory>();
		}

		private async Task<List<ProductCategory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}

			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCategory>();
		}

		private async Task<ProductCategory> GetById(int productCategoryID)
		{
			List<ProductCategory> records = await this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>edba58d5a2f8ddd5ee46b5ef1cedd6ae</Hash>
</Codenesium>*/