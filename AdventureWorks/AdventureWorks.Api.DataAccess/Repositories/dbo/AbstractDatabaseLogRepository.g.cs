using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDatabaseLogRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDatabaseLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCODatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCODatabaseLog> Get(int databaseLogID)
		{
			DatabaseLog record = await this.GetById(databaseLogID);

			return this.Mapper.DatabaseLogMapEFToPOCO(record);
		}

		public async virtual Task<POCODatabaseLog> Create(
			ApiDatabaseLogModel model)
		{
			DatabaseLog record = new DatabaseLog();

			this.Mapper.DatabaseLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<DatabaseLog>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.DatabaseLogMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int databaseLogID,
			ApiDatabaseLogModel model)
		{
			DatabaseLog record = await this.GetById(databaseLogID);

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

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int databaseLogID)
		{
			DatabaseLog record = await this.GetById(databaseLogID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<DatabaseLog>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCODatabaseLog>> Where(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODatabaseLog> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCODatabaseLog>> SearchLinqPOCO(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODatabaseLog> response = new List<POCODatabaseLog>();
			List<DatabaseLog> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.DatabaseLogMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<DatabaseLog>> SearchLinqEF(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
			}
			return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DatabaseLog>();
		}

		private async Task<List<DatabaseLog>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(DatabaseLog.DatabaseLogID)} ASC";
			}

			return await this.Context.Set<DatabaseLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<DatabaseLog>();
		}

		private async Task<DatabaseLog> GetById(int databaseLogID)
		{
			List<DatabaseLog> records = await this.SearchLinqEF(x => x.DatabaseLogID == databaseLogID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c4c427cc9c423bd4a0066630167ff0d4</Hash>
</Codenesium>*/