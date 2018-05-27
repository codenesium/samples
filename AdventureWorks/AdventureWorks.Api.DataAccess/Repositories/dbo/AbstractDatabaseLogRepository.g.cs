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
		protected IDALDatabaseLogMapper Mapper { get; }

		public AbstractDatabaseLogRepository(
			IDALDatabaseLogMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTODatabaseLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTODatabaseLog> Get(int databaseLogID)
		{
			DatabaseLog record = await this.GetById(databaseLogID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTODatabaseLog> Create(
			DTODatabaseLog dto)
		{
			DatabaseLog record = new DatabaseLog();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<DatabaseLog>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int databaseLogID,
			DTODatabaseLog dto)
		{
			DatabaseLog record = await this.GetById(databaseLogID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{databaseLogID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					databaseLogID,
					dto,
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

		protected async Task<List<DTODatabaseLog>> Where(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODatabaseLog> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTODatabaseLog>> SearchLinqDTO(Expression<Func<DatabaseLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODatabaseLog> response = new List<DTODatabaseLog>();
			List<DatabaseLog> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>4117c7376bcf7fc87dad830369e9c165</Hash>
</Codenesium>*/