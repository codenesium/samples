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
	public abstract class AbstractSalesPersonQuotaHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesPersonQuotaHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOSalesPersonQuotaHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOSalesPersonQuotaHistory Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOSalesPersonQuotaHistory Create(
			ApiSalesPersonQuotaHistoryModel model)
		{
			SalesPersonQuotaHistory record = new SalesPersonQuotaHistory();

			this.Mapper.SalesPersonQuotaHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SalesPersonQuotaHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.SalesPersonQuotaHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiSalesPersonQuotaHistoryModel model)
		{
			SalesPersonQuotaHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.SalesPersonQuotaHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			SalesPersonQuotaHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SalesPersonQuotaHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOSalesPersonQuotaHistory> Where(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOSalesPersonQuotaHistory> SearchLinqPOCO(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSalesPersonQuotaHistory> response = new List<POCOSalesPersonQuotaHistory>();
			List<SalesPersonQuotaHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.SalesPersonQuotaHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<SalesPersonQuotaHistory> SearchLinqEF(Expression<Func<SalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPersonQuotaHistory.BusinessEntityID)} ASC";
			}
			return this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesPersonQuotaHistory>();
		}

		private List<SalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SalesPersonQuotaHistory.BusinessEntityID)} ASC";
			}

			return this.Context.Set<SalesPersonQuotaHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<SalesPersonQuotaHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>bdaa93e2721390153fd9173b9e876dd7</Hash>
</Codenesium>*/