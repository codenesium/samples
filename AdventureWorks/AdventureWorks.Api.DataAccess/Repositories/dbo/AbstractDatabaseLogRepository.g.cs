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

		public virtual List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCODatabaseLog Get(int databaseLogID)
		{
			return this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();
		}

		public virtual POCODatabaseLog Create(
			ApiDatabaseLogModel model)
		{
			DatabaseLog record = new DatabaseLog();

			this.Mapper.DatabaseLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<DatabaseLog>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.DatabaseLogMapEFToPOCO(record);
		}

		public virtual void Update(
			int databaseLogID,
			ApiDatabaseLogModel model)
		{
			DatabaseLog record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();
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
			DatabaseLog record = this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DatabaseLog>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCODatabaseLog> Where(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODatabaseLog> SearchLinqPOCO(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODatabaseLog> response = new List<POCODatabaseLog>();
			List<DatabaseLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DatabaseLogMapEFToPOCO(x)));
			return response;
		}

		private List<DatabaseLog> SearchLinqEF(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
			}
			return this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<DatabaseLog>();
		}

		private List<DatabaseLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
			}

			return this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<DatabaseLog>();
		}
	}
}

/*<Codenesium>
    <Hash>63a372b3f0fea505a92981af609b38c4</Hash>
</Codenesium>*/