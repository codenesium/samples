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

		public virtual string Create(
			CountryRegionModel model)
		{
			var record = new EFCountryRegion();

			this.Mapper.CountryRegionMapModelToEF(
				default (string),
				model,
				record);

			this.Context.Set<EFCountryRegion>().Add(record);
			this.Context.SaveChanges();
			return record.CountryRegionCode;
		}

		public virtual void Update(
			string countryRegionCode,
			CountryRegionModel model)
		{
			var record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
			if (record == null)
			{
				throw new Exception($"Unable to find id:{countryRegionCode}");
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
			var record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCountryRegion>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode);
		}

		public virtual POCOCountryRegion GetByIdDirect(string countryRegionCode)
		{
			return this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode).CountryRegions.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).CountryRegions;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFCountryRegion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CountryRegionMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			List<EFCountryRegion> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CountryRegionMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFCountryRegion> SearchLinqEF(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCountryRegion> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>45d133b839a45cb0001b2a87c26562fc</Hash>
</Codenesium>*/