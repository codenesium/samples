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

		public async virtual Task<VStateProvinceCountryRegion> Create(VStateProvinceCountryRegion item)
		{
			this.Context.Set<VStateProvinceCountryRegion>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VStateProvinceCountryRegion item)
		{
			var entity = this.Context.Set<VStateProvinceCountryRegion>().Local.FirstOrDefault(x => x.StateProvinceID == item.StateProvinceID);
			if (entity == null)
			{
				this.Context.Set<VStateProvinceCountryRegion>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int stateProvinceID)
		{
			VStateProvinceCountryRegion record = await this.GetById(stateProvinceID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VStateProvinceCountryRegion>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<VStateProvinceCountryRegion> ByStateProvinceIDCountryRegionCode(int stateProvinceID, string countryRegionCode)
		{
			var records = await this.Where(x => x.StateProvinceID == stateProvinceID && x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
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
    <Hash>88c9d3a058212328760b6d9bbbe40f4e</Hash>
</Codenesium>*/