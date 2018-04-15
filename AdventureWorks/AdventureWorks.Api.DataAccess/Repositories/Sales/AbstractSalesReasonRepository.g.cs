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
	public abstract class AbstractSalesReasonRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractSalesReasonRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			SalesReasonModel model)
		{
			var record = new EFSalesReason();

			this.mapper.SalesReasonMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFSalesReason>().Add(record);
			this.context.SaveChanges();
			return record.SalesReasonID;
		}

		public virtual void Update(
			int salesReasonID,
			SalesReasonModel model)
		{
			var record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{salesReasonID}");
			}
			else
			{
				this.mapper.SalesReasonMapModelToEF(
					salesReasonID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int salesReasonID)
		{
			var record = this.SearchLinqEF(x => x.SalesReasonID == salesReasonID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFSalesReason>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int salesReasonID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID, response);
			return response;
		}

		public virtual POCOSalesReason GetByIdDirect(int salesReasonID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.SalesReasonID == salesReasonID, response);
			return response.SalesReasons.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOSalesReason> GetWhereDirect(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.SalesReasons;
		}

		private void SearchLinqPOCO(Expression<Func<EFSalesReason, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesReason> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesReasonMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFSalesReason> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.SalesReasonMapEFToPOCO(x, response));
		}

		protected virtual List<EFSalesReason> SearchLinqEF(Expression<Func<EFSalesReason, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFSalesReason> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>f900fd8bd773ee20f25cb75876578c0d</Hash>
</Codenesium>*/