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
	public abstract class AbstractStateProvinceRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStateProvinceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOStateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOStateProvince> Get(int stateProvinceID)
		{
			StateProvince record = await this.GetById(stateProvinceID);

			return this.Mapper.StateProvinceMapEFToPOCO(record);
		}

		public async virtual Task<POCOStateProvince> Create(
			ApiStateProvinceModel model)
		{
			StateProvince record = new StateProvince();

			this.Mapper.StateProvinceMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<StateProvince>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.StateProvinceMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int stateProvinceID,
			ApiStateProvinceModel model)
		{
			StateProvince record = await this.GetById(stateProvinceID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{stateProvinceID}");
			}
			else
			{
				this.Mapper.StateProvinceMapModelToEF(
					stateProvinceID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
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

		public async Task<POCOStateProvince> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<POCOStateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			var records = await this.SearchLinqPOCO(x => x.StateProvinceCode == stateProvinceCode && x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOStateProvince>> Where(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStateProvince> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOStateProvince>> SearchLinqPOCO(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStateProvince> response = new List<POCOStateProvince>();
			List<StateProvince> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.StateProvinceMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<StateProvince>> SearchLinqEF(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
			}
			return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StateProvince>();
		}

		private async Task<List<StateProvince>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
			}

			return await this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<StateProvince>();
		}

		private async Task<StateProvince> GetById(int stateProvinceID)
		{
			List<StateProvince> records = await this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>65b3187d313a77caebcbf39c95e341e3</Hash>
</Codenesium>*/