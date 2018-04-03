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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractCountryRegionRepository(ILogger logger,
		                                       ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual string Create(string name,
		                             DateTime modifiedDate)
		{
			var record = new EFCountryRegion ();

			MapPOCOToEF(String.Empty, name,
			            modifiedDate, record);

			this._context.Set<EFCountryRegion>().Add(record);
			this._context.SaveChanges();
			return record.countryRegionCode;
		}

		public virtual void Update(string countryRegionCode, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.countryRegionCode == countryRegionCode).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",countryRegionCode);
			}
			else
			{
				MapPOCOToEF(countryRegionCode,  name,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(string countryRegionCode)
		{
			var record = this.SearchLinqEF(x => x.countryRegionCode == countryRegionCode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFCountryRegion>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(string countryRegionCode, Response response)
		{
			this.SearchLinqPOCO(x => x.countryRegionCode == countryRegionCode,response);
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
			efCountryRegion.countryRegionCode = countryRegionCode;
			efCountryRegion.name = name;
			efCountryRegion.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCountryRegion efCountryRegion,Response response)
		{
			if(efCountryRegion == null)
			{
				return;
			}
			response.AddCountryRegion(new POCOCountryRegion()
			{
				CountryRegionCode = efCountryRegion.countryRegionCode,
				Name = efCountryRegion.name,
				ModifiedDate = efCountryRegion.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>532d70b4325e7422d3de5d748e90bb41</Hash>
</Codenesium>*/