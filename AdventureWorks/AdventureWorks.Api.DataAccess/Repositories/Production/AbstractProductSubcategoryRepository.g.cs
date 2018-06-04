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
	public abstract class AbstractProductSubcategoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductSubcategoryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<ProductSubcategory> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<ProductSubcategory>> Where(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductSubcategory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductSubcategory>> SearchLinqEF(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}
			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductSubcategory>();
		}

		private async Task<List<ProductSubcategory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}

			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductSubcategory>();
		}

		private async Task<ProductSubcategory> GetById(int productSubcategoryID)
		{
			List<ProductSubcategory> records = await this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f5d84a092c084e00d3fab47a9053a689</Hash>
</Codenesium>*/