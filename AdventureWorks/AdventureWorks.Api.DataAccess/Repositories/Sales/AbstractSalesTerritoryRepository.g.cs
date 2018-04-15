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
	public abstract class AbstractSalesTerritoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesTerritoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesTerritoryModel model)
		{
			var record = new EFSalesTerritory();

			this.mapper.SalesTerritoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesTerritory>().Add(record);
			this.context.SaveChanges();
			return record.TerritoryID;
		}

		public virtual void Update(
			int territoryID,
			SalesTerritoryModel model)
		{
			var record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{territoryID}");
			}
			else
			{
				this.mapper.SalesTerritoryMapModelToEF(
					territoryID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int territoryID)
		{
			var record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesTerritory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int territoryID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.TerritoryID == territoryID, response);
			return response;
		}

		public virtual POCOSalesTerritory GetByIdDirect(int territoryID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.TerritoryID == territoryID, response);
			return response.SalesTerritories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesTerritories;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesTerritory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesTerritory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesTerritoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesTerritory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesTerritoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesTerritory> SearchLinqEF(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesTerritory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>66ed51db78d1ff2ca2e5e20e5b46b235</Hash>
</Codenesium>*/