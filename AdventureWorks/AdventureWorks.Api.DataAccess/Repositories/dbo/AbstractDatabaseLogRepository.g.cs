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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDatabaseLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			DatabaseLogModel model)
		{
			EFDatabaseLog record = new EFDatabaseLog();

			this.Mapper.DatabaseLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFDatabaseLog>().Add(record);
			this.Context.SaveChanges();
			return record.DatabaseLogID;
		}

		public virtual void Update(
			int databaseLogID,
			DatabaseLogModel model)
		{
			EFDatabaseLog record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{databaseLogID}");
			}
			else
			{
				this.Mapper.DatabaseLogMapModelToEF(
					databaseLogID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int databaseLogID)
		{
			EFDatabaseLog record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFDatabaseLog>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int databaseLogID)
		{
			return this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID);
		}

		public virtual POCODatabaseLog GetByIdDirect(int databaseLogID)
		{
			return this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID).DatabaseLogs.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCODatabaseLog> GetWhereDirect(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).DatabaseLogs;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFDatabaseLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.DatabaseLogMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFDatabaseLog> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.DatabaseLogMapEFToPOCO(x, response));
			return response;
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
    <Hash>12fc0ec3f7986a215da9d43c634f7e52</Hash>
</Codenesium>*/