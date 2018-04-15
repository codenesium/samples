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
	public abstract class AbstractErrorLogRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractErrorLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ErrorLogModel model)
		{
			var record = new EFErrorLog();

			this.mapper.ErrorLogMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFErrorLog>().Add(record);
			this.context.SaveChanges();
			return record.ErrorLogID;
		}

		public virtual void Update(
			int errorLogID,
			ErrorLogModel model)
		{
			var record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{errorLogID}");
			}
			else
			{
				this.mapper.ErrorLogMapModelToEF(
					errorLogID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int errorLogID)
		{
			var record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFErrorLog>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int errorLogID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ErrorLogID == errorLogID, response);
			return response;
		}

		public virtual POCOErrorLog GetByIdDirect(int errorLogID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ErrorLogID == errorLogID, response);
			return response.ErrorLogs.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOErrorLog> GetWhereDirect(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ErrorLogs;
		}

		private void SearchLinqPOCO(Expression<Func<EFErrorLog, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFErrorLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ErrorLogMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFErrorLog> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ErrorLogMapEFToPOCO(x, response));
		}

		protected virtual List<EFErrorLog> SearchLinqEF(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFErrorLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>64e2b3174aa09d5f5289ddf0187e54ae</Hash>
</Codenesium>*/