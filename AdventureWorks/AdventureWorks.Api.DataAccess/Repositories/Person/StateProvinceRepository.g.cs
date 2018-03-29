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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractStateProvinceRepository(ILogger logger,
		                                       ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string stateProvinceCode,
		                          string countryRegionCode,
		                          bool isOnlyStateProvinceFlag,
		                          string name,
		                          int territoryID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFStateProvince ();

			MapPOCOToEF(0, stateProvinceCode,
			            countryRegionCode,
			            isOnlyStateProvinceFlag,
			            name,
			            territoryID,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFStateProvince>().Add(record);
			this._context.SaveChanges();
			return record.StateProvinceID;
		}

		public virtual void Update(int stateProvinceID, string stateProvinceCode,
		                           string countryRegionCode,
		                           bool isOnlyStateProvinceFlag,
		                           string name,
		                           int territoryID,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",stateProvinceID);
			}
			else
			{
				MapPOCOToEF(stateProvinceID,  stateProvinceCode,
				            countryRegionCode,
				            isOnlyStateProvinceFlag,
				            name,
				            territoryID,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int stateProvinceID)
		{
			var record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFStateProvince>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int stateProvinceID, Response response)
		{
			this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID,response);
		}

		protected virtual List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStateProvince> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFStateProvince, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFStateProvince, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFStateProvince> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFStateProvince> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int stateProvinceID, string stateProvinceCode,
		                               string countryRegionCode,
		                               bool isOnlyStateProvinceFlag,
		                               string name,
		                               int territoryID,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFStateProvince   efStateProvince)
		{
			efStateProvince.StateProvinceID = stateProvinceID;
			efStateProvince.StateProvinceCode = stateProvinceCode;
			efStateProvince.CountryRegionCode = countryRegionCode;
			efStateProvince.IsOnlyStateProvinceFlag = isOnlyStateProvinceFlag;
			efStateProvince.Name = name;
			efStateProvince.TerritoryID = territoryID;
			efStateProvince.rowguid = rowguid;
			efStateProvince.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFStateProvince efStateProvince,Response response)
		{
			if(efStateProvince == null)
			{
				return;
			}
			response.AddStateProvince(new POCOStateProvince()
			{
				StateProvinceID = efStateProvince.StateProvinceID.ToInt(),
				StateProvinceCode = efStateProvince.StateProvinceCode,
				IsOnlyStateProvinceFlag = efStateProvince.IsOnlyStateProvinceFlag,
				Name = efStateProvince.Name,
				Rowguid = efStateProvince.rowguid,
				ModifiedDate = efStateProvince.ModifiedDate.ToDateTime(),

				CountryRegionCode = new ReferenceEntity<string>(efStateProvince.CountryRegionCode,
				                                                "CountryRegions"),
				TerritoryID = new ReferenceEntity<int>(efStateProvince.TerritoryID,
				                                       "SalesTerritories"),
			});

			CountryRegionRepository.MapEFToPOCO(efStateProvince.CountryRegionRef, response);

			SalesTerritoryRepository.MapEFToPOCO(efStateProvince.SalesTerritoryRef, response);
		}
	}
}

/*<Codenesium>
    <Hash>80d6ea4be4a1e27bff5a0e7fa8fbb191</Hash>
</Codenesium>*/