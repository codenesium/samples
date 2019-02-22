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

namespace CADNS.Api.DataAccess
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

		public virtual Task<List<Address>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Address1.StartsWith(query) ||
				                  x.Address2.StartsWith(query) ||
				                  x.City.StartsWith(query) ||
				                  x.Id == query.ToInt() ||
				                  x.State.StartsWith(query) ||
				                  x.Zip.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Address> Get(int id)
		{
			return await this.GetById(id);
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
			var entity = this.Context.Set<Address>().Local.FirstOrDefault(x => x.Id == item.Id);
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
			int id)
		{
			Address record = await this.GetById(id);

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

		// Foreign key reference to this table Call via addressId.
		public async virtual Task<List<Call>> CallsByAddressId(int addressId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Call>()
			       .Include(x => x.AddressIdNavigation)
			       .Where(x => x.AddressId == addressId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Call>();
		}

		protected async Task<List<Address>> Where(
			Expression<Func<Address, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Address, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Address>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Address>();
		}

		private async Task<Address> GetById(int id)
		{
			List<Address> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>518d2466ced46fa1ff409a3dee7126ec</Hash>
</Codenesium>*/