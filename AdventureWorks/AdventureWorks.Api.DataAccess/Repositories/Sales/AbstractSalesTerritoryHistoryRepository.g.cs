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
	public abstract class AbstractSalesTerritoryHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesTerritoryHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesTerritoryHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesTerritoryHistory Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOSalesTerritoryHistory Create(
			ApiSalesTerritoryHistoryModel model)
		{
			SalesTerritoryHistory record = new SalesTerritoryHistory();

			this.Mapper.SalesTerritoryHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesTerritoryHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesTerritoryHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiSalesTerritoryHistoryModel model)
		{
			SalesTerritoryHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesTerritoryHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			SalesTerritoryHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesTerritoryHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSalesTerritoryHistory> Where(Expression<Func<SalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesTerritoryHistory> SearchLinqPOCO(Expression<Func<SalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesTerritoryHistory> response = new List<POCOSalesTerritoryHistory>();
			List<SalesTerritoryHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesTerritoryHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<SalesTerritoryHistory> SearchLinqEF(Expression<Func<SalesTerritoryHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritoryHistory.BusinessEntityID)} ASC";
			}
			return this.Context.Set<SalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesTerritoryHistory>();
		}

		private List<SalesTerritoryHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesTerritoryHistory.BusinessEntityID)} ASC";
			}

			return this.Context.Set<SalesTerritoryHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesTerritoryHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>a06d6ddf86233a330a00076eb4a8e238</Hash>
</Codenesium>*/