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

namespace TicketingCRMNS.Api.DataAccess
{
	public class CountryRepository : AbstractRepository, ICountryRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public CountryRepository(
			ILogger<ICountryRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Country>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Country> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Country> Create(Country item)
		{
			this.Context.Set<Country>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Country item)
		{
			var entity = this.Context.Set<Country>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Country>().Attach(item);
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
			Country record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Country>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Province via countryId.
		public async virtual Task<List<Province>> ProvincesByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Province>()
			       .Include(x => x.CountryIdNavigation)

			       .Where(x => x.CountryId == countryId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Province>();
		}

		protected async Task<List<Country>> Where(
			Expression<Func<Country, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Country, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Country>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Country>();
		}

		private async Task<Country> GetById(int id)
		{
			List<Country> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>25ba37d2b2fd6cc9723db6876dcd96ee</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/