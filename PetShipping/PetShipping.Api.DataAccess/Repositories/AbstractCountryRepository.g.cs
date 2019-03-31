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

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractCountryRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCountryRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
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
				                  x.Name.StartsWith(query),
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

		// Foreign key reference to this table CountryRequirement via countryId.
		public async virtual Task<List<CountryRequirement>> CountryRequirementsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<CountryRequirement>()
			       .Include(x => x.CountryIdNavigation)

			       .Where(x => x.CountryId == countryId).AsQueryable().Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
		}

		// Foreign key reference to this table Destination via countryId.
		public async virtual Task<List<Destination>> DestinationsByCountryId(int countryId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Destination>()
			       .Include(x => x.CountryIdNavigation)

			       .Where(x => x.CountryId == countryId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Destination>();
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
    <Hash>b236261e9ce17a891d2963aa17ca9e98</Hash>
</Codenesium>*/