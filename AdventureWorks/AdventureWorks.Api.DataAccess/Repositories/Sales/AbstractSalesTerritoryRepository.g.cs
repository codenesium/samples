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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTerritoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SalesTerritoryModel model)
		{
			EFSalesTerritory record = new EFSalesTerritory();

			this.Mapper.SalesTerritoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSalesTerritory>().Add(record);
			this.Context.SaveChanges();
			return record.TerritoryID;
		}

		public virtual void Update(
			int territoryID,
			SalesTerritoryModel model)
		{
			EFSalesTerritory record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{territoryID}");
			}
			else
			{
				this.Mapper.SalesTerritoryMapModelToEF(
					territoryID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int territoryID)
		{
			EFSalesTerritory record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSalesTerritory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int territoryID)
		{
			return this.SearchLinqPOCO(x => x.TerritoryID == territoryID);
		}

		public virtual POCOSalesTerritory GetByIdDirect(int territoryID)
		{
			return this.SearchLinqPOCO(x => x.TerritoryID == territoryID).SalesTerritories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesTerritory> GetWhereDirect(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SalesTerritories;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesTerritory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesTerritoryMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesTerritory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesTerritoryMapEFToPOCO(x, response));
			return response;
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
    <Hash>07e905ce89daf58e45303337307a4e09</Hash>
</Codenesium>*/