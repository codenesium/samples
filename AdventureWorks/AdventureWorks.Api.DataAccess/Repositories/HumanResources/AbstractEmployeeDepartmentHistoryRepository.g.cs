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
	public abstract class AbstractEmployeeDepartmentHistoryRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractEmployeeDepartmentHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			EmployeeDepartmentHistoryModel model)
		{
			var record = new EFEmployeeDepartmentHistory();

			this.mapper.EmployeeDepartmentHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFEmployeeDepartmentHistory>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			EmployeeDepartmentHistoryModel model)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.mapper.EmployeeDepartmentHistoryMapModelToEF(
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
				this.context.Set<EFEmployeeDepartmentHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.EmployeeDepartmentHistories.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.EmployeeDepartmentHistories;
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployeeDepartmentHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.EmployeeDepartmentHistoryMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployeeDepartmentHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.EmployeeDepartmentHistoryMapEFToPOCO(x, response));
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>412ba977925913f35dc3ddf7efb1e33f</Hash>
</Codenesium>*/