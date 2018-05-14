using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractStateProvinceRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractStateProvinceRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOStateProvince> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOStateProvince Get(int stateProvinceID)
		{
			return this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
		}

		public virtual POCOStateProvince Create(
			ApiStateProvinceModel model)
		{
			StateProvince record = new StateProvince();

			this.Mapper.StateProvinceMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<StateProvince>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.StateProvinceMapEFToPOCO(record);
		}

		public virtual void Update(
			int stateProvinceID,
			ApiStateProvinceModel model)
		{
			StateProvince record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int stateProvinceID)
		{
			StateProvince record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<StateProvince>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOStateProvince GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		public POCOStateProvince GetStateProvinceCodeCountryRegionCode(string stateProvinceCode,string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.StateProvinceCode == stateProvinceCode && x.CountryRegionCode == countryRegionCode).FirstOrDefault();
		}

		protected List<POCOStateProvince> Where(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOStateProvince> SearchLinqPOCO(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOStateProvince> response = new List<POCOStateProvince>();
			List<StateProvince> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.StateProvinceMapEFToPOCO(x)));
			return response;
		}

		private List<StateProvince> SearchLinqEF(Expression<Func<StateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
			}
			return this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<StateProvince>();
		}

		private List<StateProvince> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(StateProvince.StateProvinceID)} ASC";
			}

			return this.Context.Set<StateProvince>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<StateProvince>();
		}
	}
}

/*<Codenesium>
    <Hash>1b831991eaf5de165a7cd559b494f6c2</Hash>
</Codenesium>*/