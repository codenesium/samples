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

		// unique constraint AK_StateProvince_Name.
		public async virtual Task<StateProvince> ByName(string name)
		{
			return await this.Context.Set<StateProvince>().FirstOrDefaultAsync(x => x.Name == name);
		}

		// unique constraint AK_StateProvince_rowguid.
		public async virtual Task<StateProvince> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<StateProvince>().FirstOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		// unique constraint AK_StateProvince_StateProvinceCode_CountryRegionCode.
		public async virtual Task<StateProvince> ByStateProvinceCodeCountryRegionCode(string stateProvinceCode, string countryRegionCode)
		{
			return await this.Context.Set<StateProvince>().FirstOrDefaultAsync(x => x.StateProvinceCode == stateProvinceCode && x.CountryRegionCode == countryRegionCode);
		}

		// Foreign key reference to this table Address via stateProvinceID.
		public async virtual Task<List<Address>> AddressesByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Address>().Where(x => x.StateProvinceID == stateProvinceID).AsQueryable().Skip(offset).Take(limit).ToListAsync<Address>();
		}

		protected async Task<List<StateProvince>> Where(
			Expression<Func<StateProvince, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<StateProvince, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.StateProvinceID;
			}

			return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<StateProvince>();
		}

		private async Task<StateProvince> GetById(int stateProvinceID)
		{
			List<StateProvince> records = await this.Where(x => x.StateProvinceID == stateProvinceID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>be0a2e712b5634dd5a30a33227cc03f6</Hash>
</Codenesium>*/