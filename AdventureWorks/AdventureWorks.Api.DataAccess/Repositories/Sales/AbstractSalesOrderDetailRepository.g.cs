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
	public abstract class AbstractSalesOrderDetailRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesOrderDetailRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesOrderDetailModel model)
		{
			var record = new EFSalesOrderDetail();

			this.mapper.SalesOrderDetailMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesOrderDetail>().Add(record);
			this.context.SaveChanges();
			return record.SalesOrderID;
		}

		public virtual void Update(
			int salesOrderID,
			SalesOrderDetailModel model)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.mapper.SalesOrderDetailMapModelToEF(
					salesOrderID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesOrderID)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesOrderDetail>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int salesOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID, response);
			return response;
		}

		public virtual POCOSalesOrderDetail GetByIdDirect(int salesOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID, response);
			return response.SalesOrderDetails.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesOrderDetail> GetWhereDirect(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesOrderDetails;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderDetail, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesOrderDetail> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesOrderDetailMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesOrderDetail> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesOrderDetailMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesOrderDetail> SearchLinqEF(Expression<Func<EFSalesOrderDetail, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderDetail> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>98260f35f5e43320d06236083abf2013</Hash>
</Codenesium>*/