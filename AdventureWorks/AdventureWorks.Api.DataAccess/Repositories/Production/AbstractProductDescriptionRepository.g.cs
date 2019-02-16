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
	public abstract class AbstractProductDescriptionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductDescriptionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductDescription>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Description.StartsWith(query) ||
				                  x.ModifiedDate == query.ToDateTime() ||
				                  x.ProductDescriptionID == query.ToInt() ||
				                  x.Rowguid == query.ToGuid(),
				                  limit,
				                  offset);
			}
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

		// unique constraint AK_ProductDescription_rowguid.
		public async virtual Task<ProductDescription> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<ProductDescription>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		protected async Task<List<ProductDescription>> Where(
			Expression<Func<ProductDescription, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductDescription, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductDescriptionID;
			}

			return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductDescription>();
		}

		private async Task<ProductDescription> GetById(int productDescriptionID)
		{
			List<ProductDescription> records = await this.Where(x => x.ProductDescriptionID == productDescriptionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fac73f0525471198e84f39e79c102733</Hash>
</Codenesium>*/