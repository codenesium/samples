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
	public abstract class AbstractStateProvinceRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractStateProvinceRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<StateProvince>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<StateProvince> Get(int stateProvinceID)
		{
			return await this.GetById(stateProvinceID);
		}

		public async virtual Task<StateProvince> Create(StateProvince item)
		{
			this.Context.Set<StateProvince>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(StateProvince item)
		{
			var entity = this.Context.Set<StateProvince>().Local.FirstOrDefault(x => x.StateProvinceID == item.StateProvinceID);
			if (entity == null)
			{
				this.Context.Set<StateProvince>().Attach(item);
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
			StateProvince record = await this.GetById(stateProvinceID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<StateProvince>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<StateProvince> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async Task<StateProvince> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
		{
			var records = await this.Where(x => x.StateProvinceCode == stateProvinceCode && x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}

		public async virtual Task<List<Address>> Addresses(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Address>().Where(x => x.StateProvinceID == stateProvinceID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Address>();
		}

		protected async Task<List<StateProvince>> Where(
			Expression<Func<StateProvince, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<StateProvince, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.StateProvinceID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<StateProvince>();
			}
			else
			{
				return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<StateProvince>();
			}
		}

		private async Task<StateProvince> GetById(int stateProvinceID)
		{
			List<StateProvince> records = await this.Where(x => x.StateProvinceID == stateProvinceID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0d182926aeeab5e50e07411448b29048</Hash>
</Codenesium>*/