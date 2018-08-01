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
	public abstract class AbstractProductModelProductDescriptionCultureRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductModelProductDescriptionCultureRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductModelProductDescriptionCulture>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductModelProductDescriptionCulture> Get(int productModelID)
		{
			return await this.GetById(productModelID);
		}

		public async virtual Task<ProductModelProductDescriptionCulture> Create(ProductModelProductDescriptionCulture item)
		{
			this.Context.Set<ProductModelProductDescriptionCulture>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductModelProductDescriptionCulture item)
		{
			var entity = this.Context.Set<ProductModelProductDescriptionCulture>().Local.FirstOrDefault(x => x.ProductModelID == item.ProductModelID);
			if (entity == null)
			{
				this.Context.Set<ProductModelProductDescriptionCulture>().Attach(item);
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
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelProductDescriptionCulture>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductModelProductDescriptionCulture>> Where(
			Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductModelProductDescriptionCulture, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductModelID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
			}
			else
			{
				return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductModelProductDescriptionCulture>();
			}
		}

		private async Task<ProductModelProductDescriptionCulture> GetById(int productModelID)
		{
			List<ProductModelProductDescriptionCulture> records = await this.Where(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9c39603a43b0da7fb40416a2de57b160</Hash>
</Codenesium>*/