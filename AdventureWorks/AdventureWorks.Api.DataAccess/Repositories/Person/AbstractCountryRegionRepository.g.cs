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
	public abstract class AbstractCountryRegionRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCountryRegionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCountryRegion> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCountryRegion Get(string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
		}

		public virtual POCOCountryRegion Create(
			ApiCountryRegionModel model)
		{
			CountryRegion record = new CountryRegion();

			this.Mapper.CountryRegionMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<CountryRegion>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CountryRegionMapEFToPOCO(record);
		}

		public virtual void Update(
			string countryRegionCode,
			ApiCountryRegionModel model)
		{
			CountryRegion record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			string countryRegionCode)
		{
			CountryRegion record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CountryRegion>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOCountryRegion GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOCountryRegion> Where(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCountryRegion> SearchLinqPOCO(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCountryRegion> response = new List<POCOCountryRegion>();
			List<CountryRegion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CountryRegionMapEFToPOCO(x)));
			return response;
		}

		private List<CountryRegion> SearchLinqEF(Expression<Func<CountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegion.CountryRegionCode)} ASC";
			}
			return this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CountryRegion>();
		}

		private List<CountryRegion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CountryRegion.CountryRegionCode)} ASC";
			}

			return this.Context.Set<CountryRegion>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CountryRegion>();
		}
	}
}

/*<Codenesium>
    <Hash>a322b39360ca4ed1dbdb1b40f81eb317</Hash>
</Codenesium>*/