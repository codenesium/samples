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
	public abstract class AbstractVProductAndDescriptionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVProductAndDescriptionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VProductAndDescription>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<VProductAndDescription> Get(string cultureID)
		{
			return await this.GetById(cultureID);
		}

		public async virtual Task<VProductAndDescription> Create(VProductAndDescription item)
		{
			this.Context.Set<VProductAndDescription>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VProductAndDescription item)
		{
			var entity = this.Context.Set<VProductAndDescription>().Local.FirstOrDefault(x => x.CultureID == item.CultureID);
			if (entity == null)
			{
				this.Context.Set<VProductAndDescription>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string cultureID)
		{
			VProductAndDescription record = await this.GetById(cultureID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VProductAndDescription>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<VProductAndDescription> ByCultureIDProductID(string cultureID, int productID)
		{
			var records = await this.Where(x => x.CultureID == cultureID && x.ProductID == productID);

			return records.FirstOrDefault();
		}

		protected async Task<List<VProductAndDescription>> Where(
			Expression<Func<VProductAndDescription, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VProductAndDescription, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.CultureID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<VProductAndDescription>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VProductAndDescription>();
			}
			else
			{
				return await this.Context.Set<VProductAndDescription>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<VProductAndDescription>();
			}
		}

		private async Task<VProductAndDescription> GetById(string cultureID)
		{
			List<VProductAndDescription> records = await this.Where(x => x.CultureID == cultureID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>440d4ffbf03be9a54082559f59d29119</Hash>
</Codenesium>*/