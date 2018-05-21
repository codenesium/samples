using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PetShippingNS.Api.Contracts;

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractCountryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCountry>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCountry> Get(int id)
		{
			Country record = await this.GetById(id);

			return this.Mapper.CountryMapEFToPOCO(record);
		}

		public async virtual Task<POCOCountry> Create(
			ApiCountryModel model)
		{
			Country record = new Country();

			this.Mapper.CountryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Country>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CountryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int id,
			ApiCountryModel model)
		{
			Country record = await this.GetById(id);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{id}");
			}
			else
			{
				this.Mapper.CountryMapModelToEF(
					id,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		protected async Task<List<POCOCountry>> Where(Expression<Func<Country, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountry> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCountry>> SearchLinqPOCO(Expression<Func<Country, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountry> response = new List<POCOCountry>();
			List<Country> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CountryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Country>> SearchLinqEF(Expression<Func<Country, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Country.Id)} ASC";
			}
			return await this.Context.Set<Country>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Country>();
		}

		private async Task<List<Country>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Country.Id)} ASC";
			}

			return await this.Context.Set<Country>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Country>();
		}

		private async Task<Country> GetById(int id)
		{
			List<Country> records = await this.SearchLinqEF(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>49a60a73d1d0a87ad5f7c652b5ca04c5</Hash>
</Codenesium>*/