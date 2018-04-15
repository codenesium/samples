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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractCountryRegionRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(
			CountryRegionModel model)
		{
			var record = new EFCountryRegion();

			this.mapper.CountryRegionMapModelToEF(
				default (string),
				model,
				record);

			this.context.Set<EFCountryRegion>().Add(record);
			this.context.SaveChanges();
			return record.CountryRegionCode;
		}

		public virtual void Update(
			string countryRegionCode,
			CountryRegionModel model)
		{
			var record = this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{countryRegionCode}");
			}
			else
			{
				this.mapper.CountryRegionMapModelToEF(
					countryRegionCode,
					model,
					record);
				this.context.SaveChanges();
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
				this.context.Set<EFCountryRegion>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(string countryRegionCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode, response);
			return response;
		}

		public virtual POCOCountryRegion GetByIdDirect(string countryRegionCode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode, response);
			return response.CountryRegions.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CountryRegions;
		}

		private void SearchLinqPOCO(Expression<Func<EFCountryRegion, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCountryRegion> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CountryRegionMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCountryRegion> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CountryRegionMapEFToPOCO(x, response));
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
    <Hash>201c1413f52ad707a5e501adaa7f0e5e</Hash>
</Codenesium>*/