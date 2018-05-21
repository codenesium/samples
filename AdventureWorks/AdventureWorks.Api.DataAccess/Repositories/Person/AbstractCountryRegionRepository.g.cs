using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCountryRegionRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRegionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCountryRegion> Get(string countryRegionCode)
		{
			CountryRegion record = await this.GetById(countryRegionCode);

			return this.Mapper.CountryRegionMapEFToPOCO(record);
		}

		public async virtual Task<POCOCountryRegion> Create(
			ApiCountryRegionModel model)
		{
			CountryRegion record = new CountryRegion();

			this.Mapper.CountryRegionMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<CountryRegion>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CountryRegionMapEFToPOCO(record);
		}

		public async virtual Task Update(
			string countryRegionCode,
			ApiCountryRegionModel model)
		{
			CountryRegion record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				this.Mapper.CountryRegionMapModelToEF(
					countryRegionCode,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			string countryRegionCode)
		{
			CountryRegion record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRegion>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOCountryRegion> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOCountryRegion>> Where(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRegion> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCountryRegion>> SearchLinqPOCO(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRegion> response = new List<POCOCountryRegion>();
			List<CountryRegion> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CountryRegionMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<CountryRegion>> SearchLinqEF(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegion.CountryRegionCode)} ASC";
			}
			return await this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegion>();
		}

		private async Task<List<CountryRegion>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegion.CountryRegionCode)} ASC";
			}

			return await this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CountryRegion>();
		}

		private async Task<CountryRegion> GetById(string countryRegionCode)
		{
			List<CountryRegion> records = await this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f1adedccd8f20bef12996042b08e7f53</Hash>
</Codenesium>*/