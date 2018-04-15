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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesPersonQuotaHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesPersonQuotaHistoryModel model)
		{
			var record = new EFSalesPersonQuotaHistory();

			this.mapper.SalesPersonQuotaHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesPersonQuotaHistory>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			SalesPersonQuotaHistoryModel model)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.mapper.SalesPersonQuotaHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesPersonQuotaHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOSalesPersonQuotaHistory GetByIdDirect(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.SalesPersonQuotaHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesPersonQuotaHistory> GetWhereDirect(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesPersonQuotaHistories;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesPersonQuotaHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesPersonQuotaHistoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesPersonQuotaHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesPersonQuotaHistoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEF(Expression<Func<EFSalesPersonQuotaHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesPersonQuotaHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>15da2781db9cff6cf1adf52efa213d1d</Hash>
</Codenesium>*/