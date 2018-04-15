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
	public abstract class AbstractSalesOrderHeaderRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesOrderHeaderRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesOrderHeaderModel model)
		{
			var record = new EFSalesOrderHeader();

			this.mapper.SalesOrderHeaderMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesOrderHeader>().Add(record);
			this.context.SaveChanges();
			return record.SalesOrderID;
		}

		public virtual void Update(
			int salesOrderID,
			SalesOrderHeaderModel model)
		{
			var record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.mapper.SalesOrderHeaderMapModelToEF(
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
				this.context.Set<EFSalesOrderHeader>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int salesOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID, response);
			return response;
		}

		public virtual POCOSalesOrderHeader GetByIdDirect(int salesOrderID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID, response);
			return response.SalesOrderHeaders.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesOrderHeader> GetWhereDirect(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesOrderHeaders;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesOrderHeader, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesOrderHeader> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesOrderHeaderMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesOrderHeader> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesOrderHeaderMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEF(Expression<Func<EFSalesOrderHeader, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderHeader> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>284e9b6d938020afaf5bbdd65b6bcc35</Hash>
</Codenesium>*/