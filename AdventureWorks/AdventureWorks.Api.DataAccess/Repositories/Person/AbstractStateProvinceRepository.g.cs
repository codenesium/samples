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
		protected IDALStateProvinceMapper Mapper { get; }

		public AbstractStateProvinceRepository(
			IDALStateProvinceMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOStateProvince>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOStateProvince> Get(int stateProvinceID)
		{
			StateProvince record = await this.GetById(stateProvinceID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOStateProvince> Create(
			DTOStateProvince dto)
		{
			StateProvince record = new StateProvince();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<StateProvince>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int stateProvinceID,
			DTOStateProvince dto)
		{
			StateProvince record = await this.GetById(stateProvinceID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{stateProvinceID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					stateProvinceID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOStateProvince> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<DTOStateProvince> GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			var records = await this.SearchLinqDTO(x => x.StateProvinceCode == stateProvinceCode && x.CountryRegionCode == countryRegionCode);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOStateProvince>> Where(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOStateProvince> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOStateProvince>> SearchLinqDTO(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOStateProvince> response = new List<DTOStateProvince>();
			List<StateProvince> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>d29cc73f2684441a1cba505bdb0a58ab</Hash>
</Codenesium>*/