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

		public AbstractCountryRegionRepository(ILogger logger,
		                                       ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFCountryRegion ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this.context.Set<EFCountryRegion>().Add(record);
			this.context.SaveChanges();
			return record.CountryRegionCode;
		}

		public virtual void Update(string countryRegionCode, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.CountryRegionCode == countryRegionCode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",countryRegionCode);
			}
			else
			{
				MapPOCOToEF(countryRegionCode,  name,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(string countryRegionCode)
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

		public virtual void GetById(string countryRegionCode, Response response)
		{
			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode,response);
		}

		protected virtual List<EFCountryRegion> SearchLinqEF(Expression<Func<EFCountryRegion, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCountryRegion> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFCountryRegion, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOCountryRegion> GetWhereDirect(Expression<Func<EFCountryRegion, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CountryRegions;
		}
		public virtual POCOCountryRegion GetByIdDirect(string countryRegionCode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.CountryRegionCode == countryRegionCode,response);
			return response.CountryRegions.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFCountryRegion, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCountryRegion> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCountryRegion> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(string countryRegionCode, string name,
		                               DateTime modifiedDate, EFCountryRegion   efCountryRegion)
		{
			efCountryRegion.CountryRegionCode = countryRegionCode;
			efCountryRegion.Name = name;
			efCountryRegion.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCountryRegion efCountryRegion,Response response)
		{
			if(efCountryRegion == null)
			{
				return;
			}
			response.AddCountryRegion(new POCOCountryRegion()
			{
				CountryRegionCode = efCountryRegion.CountryRegionCode,
				Name = efCountryRegion.Name,
				ModifiedDate = efCountryRegion.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>421853748cd02d65041cf79a0af31aea</Hash>
</Codenesium>*/