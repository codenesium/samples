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
	public class CountryRequirementRepository : AbstractRepository, ICountryRequirementRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public CountryRequirementRepository(
			ILogger<ICountryRequirementRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.CountryIdNavigation == null || x.CountryIdNavigation.Name == null?false : x.CountryIdNavigation.Name.StartsWith(query)) ||
				                  (x.Details == null?false : x.Details.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<CountryRequirement> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CountryRequirement> Create(CountryRequirement item)
		{
			this.Context.Set<CountryRequirement>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CountryRequirement item)
		{
			var entity = this.Context.Set<CountryRequirement>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CountryRequirement>().Attach(item);
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
			CountryRequirement record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRequirement>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table Country via countryId.
		public async virtual Task<Country> CountryByCountryId(int countryId)
		{
			return await this.Context.Set<Country>()
			       .SingleOrDefaultAsync(x => x.Id == countryId);
		}

		protected async Task<List<CountryRequirement>> Where(
			Expression<Func<CountryRequirement, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CountryRequirement, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CountryRequirement>()
			       .Include(x => x.CountryIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
		}

		private async Task<CountryRequirement> GetById(int id)
		{
			List<CountryRequirement> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b71569817f96f143a1a0763aad88a51f</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/