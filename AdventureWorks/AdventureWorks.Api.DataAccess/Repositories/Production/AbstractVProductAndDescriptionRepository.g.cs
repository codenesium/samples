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
    <Hash>0d10906cd64fda12d0b3b2ac217030b7</Hash>
</Codenesium>*/