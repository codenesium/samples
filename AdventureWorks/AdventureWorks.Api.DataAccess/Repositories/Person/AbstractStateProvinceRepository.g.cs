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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractStateProvinceRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string stateProvinceCode,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			string name,
			int territoryID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = new EFStateProvince();

			MapPOCOToEF(
				0,
				stateProvinceCode,
				countryRegionCode,
				isOnlyStateProvinceFlag,
				name,
				territoryID,
				rowguid,
				modifiedDate,
				record);

			this.context.Set<EFStateProvince>().Add(record);
			this.context.SaveChanges();
			return record.StateProvinceID;
		}

		public virtual void Update(
			int stateProvinceID,
			string stateProvinceCode,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			string name,
			int territoryID,
			Guid rowguid,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{stateProvinceID}");
			}
			else
			{
				MapPOCOToEF(
					stateProvinceID,
					stateProvinceCode,
					countryRegionCode,
					isOnlyStateProvinceFlag,
					name,
					territoryID,
					rowguid,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int stateProvinceID)
		{
			var record = this.SearchLinqEF(x => x.StateProvinceID == stateProvinceID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFStateProvince>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int stateProvinceID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID, response);
			return response;
		}

		public virtual POCOStateProvince GetByIdDirect(int stateProvinceID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.StateProvinceID == stateProvinceID, response);
			return response.StateProvinces.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOStateProvince> GetWhereDirect(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.StateProvinces;
		}

		private void SearchLinqPOCO(Expression<Func<EFStateProvince, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStateProvince> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFStateProvince> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFStateProvince> SearchLinqEF(Expression<Func<EFStateProvince, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFStateProvince> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int stateProvinceID,
			string stateProvinceCode,
			string countryRegionCode,
			bool isOnlyStateProvinceFlag,
			string name,
			int territoryID,
			Guid rowguid,
			DateTime modifiedDate,
			EFStateProvince efStateProvince)
		{
			efStateProvince.SetProperties(stateProvinceID.ToInt(), stateProvinceCode, countryRegionCode, isOnlyStateProvinceFlag, name, territoryID.ToInt(), rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFStateProvince efStateProvince,
			Response response)
		{
			if (efStateProvince == null)
			{
				return;
			}

			response.AddStateProvince(new POCOStateProvince(efStateProvince.StateProvinceID.ToInt(), efStateProvince.StateProvinceCode, efStateProvince.CountryRegionCode, efStateProvince.IsOnlyStateProvinceFlag, efStateProvince.Name, efStateProvince.TerritoryID.ToInt(), efStateProvince.Rowguid, efStateProvince.ModifiedDate.ToDateTime()));

			CountryRegionRepository.MapEFToPOCO(efStateProvince.CountryRegion, response);

			SalesTerritoryRepository.MapEFToPOCO(efStateProvince.SalesTerritory, response);
		}
	}
}

/*<Codenesium>
    <Hash>84def476e82b74237242ef5b2b819e09</Hash>
</Codenesium>*/