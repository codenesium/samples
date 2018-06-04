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
	public abstract class AbstractProductDescriptionRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductDescriptionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<ProductDescription> Get(int productDescriptionID)
		{
			return await this.GetById(productDescriptionID);
		}

		public async virtual Task<ProductDescription> Create(ProductDescription item)
		{
			this.Context.Set<ProductDescription>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductDescription item)
		{
			var entity = this.Context.Set<ProductDescription>().Local.FirstOrDefault(x => x.ProductDescriptionID == item.ProductDescriptionID);
			if (entity == null)
			{
				this.Context.Set<ProductDescription>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productDescriptionID)
		{
			ProductDescription record = await this.GetById(productDescriptionID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductDescription>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductDescription>> Where(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductDescription> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductDescription>> SearchLinqEF(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDescription.ProductDescriptionID)} ASC";
			}
			return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDescription>();
		}

		private async Task<List<ProductDescription>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDescription.ProductDescriptionID)} ASC";
			}

			return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDescription>();
		}

		private async Task<ProductDescription> GetById(int productDescriptionID)
		{
			List<ProductDescription> records = await this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>06065b77f455b309ca4ae068a43476b8</Hash>
</Codenesium>*/