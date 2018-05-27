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
		protected IDALCountryRegionMapper Mapper { get; }

		public AbstractCountryRegionRepository(
			IDALCountryRegionMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCountryRegion>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCountryRegion> Get(string countryRegionCode)
		{
			CountryRegion record = await this.GetById(countryRegionCode);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCountryRegion> Create(
			DTOCountryRegion dto)
		{
			CountryRegion record = new CountryRegion();

			this.Mapper.MapDTOToEF(
				default (string),
				dto,
				record);

			this.Context.Set<CountryRegion>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			string countryRegionCode,
			DTOCountryRegion dto)
		{
			CountryRegion record = await this.GetById(countryRegionCode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					countryRegionCode,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOCountryRegion> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOCountryRegion>> Where(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCountryRegion> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCountryRegion>> SearchLinqDTO(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCountryRegion> response = new List<DTOCountryRegion>();
			List<CountryRegion> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>25cbbe77b51200a3f5dae1656ca51055</Hash>
</Codenesium>*/