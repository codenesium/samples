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

		public virtual POCODatabaseLog Get(int databaseLogID)
		{
			return this.SearchLinqPOCO(x => x.DatabaseLogID == databaseLogID).FirstOrDefault();
		}

		public virtual List<POCODatabaseLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCODatabaseLog> Where(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODatabaseLog> SearchLinqPOCO(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODatabaseLog> response = new List<POCODatabaseLog>();
			List<EFDatabaseLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DatabaseLogMapEFToPOCO(x)));
			return response;
		}

		private List<EFDatabaseLog> SearchLinqEF(Expression<Func<EFDatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy("DatabaseLogID ASC").Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
			else
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
		}

		private List<EFDatabaseLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy("DatabaseLogID ASC").Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
			else
			{
				return this.Context.Set<EFDatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDatabaseLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>a9bd1775d612096c99156ae7e71f065b</Hash>
</Codenesium>*/