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
	public abstract class AbstractVStateProvinceCountryRegionRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVStateProvinceCountryRegionRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VStateProvinceCountryRegion>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<VStateProvinceCountryRegion> Get(int stateProvinceID)
		{
			return await this.GetById(stateProvinceID);
		}

		protected async Task<List<VStateProvinceCountryRegion>> Where(
			Expression<Func<VStateProvinceCountryRegion, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VStateProvinceCountryRegion, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.StateProvinceID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<VStateProvinceCountryRegion>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VStateProvinceCountryRegion>();
			}
			else
			{
				return await this.Context.Set<VStateProvinceCountryRegion>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<VStateProvinceCountryRegion>();
			}
		}

		private async Task<VStateProvinceCountryRegion> GetById(int stateProvinceID)
		{
			List<VStateProvinceCountryRegion> records = await this.Where(x => x.StateProvinceID == stateProvinceID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>e75889118cdfdae38e58ebe7b6dba068</Hash>
</Codenesium>*/