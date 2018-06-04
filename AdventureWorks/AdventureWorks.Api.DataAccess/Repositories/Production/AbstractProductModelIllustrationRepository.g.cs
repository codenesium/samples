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
	public abstract class AbstractProductModelIllustrationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductModelIllustrationRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<ProductModelIllustration> Get(int productModelID)
		{
			return await this.GetById(productModelID);
		}

		public async virtual Task<ProductModelIllustration> Create(ProductModelIllustration item)
		{
			this.Context.Set<ProductModelIllustration>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductModelIllustration item)
		{
			var entity = this.Context.Set<ProductModelIllustration>().Local.FirstOrDefault(x => x.ProductModelID == item.ProductModelID);
			if (entity == null)
			{
				this.Context.Set<ProductModelIllustration>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productModelID)
		{
			ProductModelIllustration record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelIllustration>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductModelIllustration>> Where(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductModelIllustration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductModelIllustration>> SearchLinqEF(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelIllustration>();
		}

		private async Task<List<ProductModelIllustration>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelIllustration>();
		}

		private async Task<ProductModelIllustration> GetById(int productModelID)
		{
			List<ProductModelIllustration> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e8eb54284d7a816af07b5d870888605d</Hash>
</Codenesium>*/