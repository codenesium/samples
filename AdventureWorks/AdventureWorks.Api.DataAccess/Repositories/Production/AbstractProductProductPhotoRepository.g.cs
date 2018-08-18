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
	public abstract class AbstractProductProductPhotoRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractProductProductPhotoRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductProductPhoto>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ProductProductPhoto> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<ProductProductPhoto> Create(ProductProductPhoto item)
		{
			this.Context.Set<ProductProductPhoto>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductProductPhoto item)
		{
			var entity = this.Context.Set<ProductProductPhoto>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<ProductProductPhoto>().Attach(item);
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
			ProductProductPhoto record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductProductPhoto>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductProductPhoto>> Where(
			Expression<Func<ProductProductPhoto, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ProductProductPhoto, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ProductID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
			}
			else
			{
				return await this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ProductProductPhoto>();
			}
		}

		private async Task<ProductProductPhoto> GetById(int productID)
		{
			List<ProductProductPhoto> records = await this.Where(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>8d8b0390fa98febf191a122e1b416f09</Hash>
</Codenesium>*/