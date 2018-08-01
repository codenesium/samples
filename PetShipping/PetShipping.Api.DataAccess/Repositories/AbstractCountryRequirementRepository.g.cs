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
	public abstract class AbstractCountryRequirementRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCountryRequirementRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CountryRequirement>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
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

		public async virtual Task<Country> GetCountry(int countryId)
		{
			return await this.Context.Set<Country>().SingleOrDefaultAsync(x => x.Id == countryId);
		}

		protected async Task<List<CountryRequirement>> Where(
			Expression<Func<CountryRequirement, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CountryRequirement, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
			}
			else
			{
				return await this.Context.Set<CountryRequirement>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<CountryRequirement>();
			}
		}

		private async Task<CountryRequirement> GetById(int id)
		{
			List<CountryRequirement> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f420d653477acd220837db4e5a604534</Hash>
</Codenesium>*/