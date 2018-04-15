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
	public abstract class AbstractDatabaseLogRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractDatabaseLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			DatabaseLogModel model)
		{
			var record = new EFDatabaseLog();

			this.mapper.DatabaseLogMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFDatabaseLog>().Add(record);
			this.context.SaveChanges();
			return record.DatabaseLogID;
		}

		public virtual void Update(
			int databaseLogID,
			DatabaseLogModel model)
		{
			var record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{databaseLogID}");
			}
			else
			{
				this.mapper.DatabaseLogMapModelToEF(
					databaseLogID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int databaseLogID)
		{
			var record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFDatabaseLog>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int databaseLogID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID, response);
			return response;
		}

		public virtual POCODatabaseLog GetByIdDirect(int databaseLogID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID, response);
			return response.DatabaseLogs.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.DatabaseLogs;
		}

		private void SearchLinqPOCO(Expression<Func<EFDatabaseLog, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDatabaseLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.DatabaseLogMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDatabaseLog> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.DatabaseLogMapEFToPOCO(x, response));
		}

		protected virtual List<EFDatabaseLog> SearchLinqEF(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDatabaseLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>26d5214fe21977bf1e5a031dd1c90cba</Hash>
</Codenesium>*/