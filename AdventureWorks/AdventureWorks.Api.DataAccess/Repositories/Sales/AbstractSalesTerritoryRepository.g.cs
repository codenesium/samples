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

		public virtual List<POCOSalesTerritory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesTerritory Get(int territoryID)
		{
			return this.SearchLinqPOCO(x => x.TerritoryID == territoryID).FirstOrDefault();
		}

		public virtual POCOSalesTerritory Create(
			ApiSalesTerritoryModel model)
		{
			SalesTerritory record = new SalesTerritory();

			this.Mapper.SalesTerritoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesTerritory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesTerritoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int territoryID,
			ApiSalesTerritoryModel model)
		{
			SalesTerritory record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();
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
			SalesTerritory record = this.SearchLinqEF(x => x.TerritoryID == territoryID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTerritory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOSalesTerritory GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCOSalesTerritory> Where(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesTerritory> SearchLinqPOCO(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTerritory> response = new List<POCOSalesTerritory>();
			List<SalesTerritory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesTerritoryMapEFToPOCO(x)));
			return response;
		}

		private List<SalesTerritory> SearchLinqEF(Expression<Func<SalesTerritory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritory.TerritoryID)} ASC";
			}
			return this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesTerritory>();
		}

		private List<SalesTerritory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritory.TerritoryID)} ASC";
			}

			return this.Context.Set<SalesTerritory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesTerritory>();
		}
	}
}

/*<Codenesium>
    <Hash>6c74900ad60b0ff5cca84fc9ab3866ba</Hash>
</Codenesium>*/