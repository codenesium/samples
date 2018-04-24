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
	public abstract class AbstractSalesOrderHeaderSalesReasonRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSalesOrderHeaderSalesReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			SalesOrderHeaderSalesReasonModel model)
		{
			EFSalesOrderHeaderSalesReason record = new EFSalesOrderHeaderSalesReason();

			this.Mapper.SalesOrderHeaderSalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFSalesOrderHeaderSalesReason>().Add(record);
			this.Context.SaveChanges();
			return record.SalesOrderID;
		}

		public virtual void Update(
			int salesOrderID,
			SalesOrderHeaderSalesReasonModel model)
		{
			EFSalesOrderHeaderSalesReason record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{salesOrderID}");
			}
			else
			{
				this.Mapper.SalesOrderHeaderSalesReasonMapModelToEF(
					salesOrderID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesOrderID)
		{
			EFSalesOrderHeaderSalesReason record = this.SearchLinqEF(x => x.SalesOrderID == salesOrderID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFSalesOrderHeaderSalesReason>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int salesOrderID)
		{
			return this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID);
		}

		public virtual POCOSalesOrderHeaderSalesReason GetByIdDirect(int salesOrderID)
		{
			return this.SearchLinqPOCO(x => x.SalesOrderID == salesOrderID).SalesOrderHeaderSalesReasons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOSalesOrderHeaderSalesReason> GetWhereDirect(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).SalesOrderHeaderSalesReasons;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesOrderHeaderSalesReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFSalesOrderHeaderSalesReason> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.SalesOrderHeaderSalesReasonMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFSalesOrderHeaderSalesReason> SearchLinqEF(Expression<Func<EFSalesOrderHeaderSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesOrderHeaderSalesReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>dcf9b93e3e5875142e3e409cb6143d88</Hash>
</Codenesium>*/