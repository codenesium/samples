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
	public abstract class AbstractAddressRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractAddressRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Address>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Address> Get(int addressID)
		{
			return await this.GetById(addressID);
		}

		public async virtual Task<Address> Create(Address item)
		{
			this.Context.Set<Address>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Address item)
		{
			var entity = this.Context.Set<Address>().Local.FirstOrDefault(x => x.AddressID == item.AddressID);
			if (entity == null)
			{
				this.Context.Set<Address>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int addressID)
		{
			Address record = await this.GetById(addressID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Address>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Address> ByRowguid(Guid rowguid)
		{
			return await this.Context.Set<Address>().SingleOrDefaultAsync(x => x.Rowguid == rowguid);
		}

		public async virtual Task<Address> ByAddressLine1AddressLine2CityStateProvinceIDPostalCode(string addressLine1, string addressLine2, string city, int stateProvinceID, string postalCode)
		{
			return await this.Context.Set<Address>().SingleOrDefaultAsync(x => x.AddressLine1 == addressLine1 && x.AddressLine2 == addressLine2 && x.City == city && x.StateProvinceID == stateProvinceID && x.PostalCode == postalCode);
		}

		public async virtual Task<List<Address>> ByStateProvinceID(int stateProvinceID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.StateProvinceID == stateProvinceID, limit, offset);
		}

		protected async Task<List<Address>> Where(
			Expression<Func<Address, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Address, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.AddressID;
			}

			return await this.Context.Set<Address>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Address>();
		}

		private async Task<Address> GetById(int addressID)
		{
			List<Address> records = await this.Where(x => x.AddressID == addressID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>6bd57549b238cd46c0769b1adaa4650c</Hash>
</Codenesium>*/