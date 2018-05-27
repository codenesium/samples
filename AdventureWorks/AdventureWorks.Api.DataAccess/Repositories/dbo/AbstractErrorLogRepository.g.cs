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
	public abstract class AbstractErrorLogRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALErrorLogMapper Mapper { get; }

		public AbstractErrorLogRepository(
			IDALErrorLogMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOErrorLog> Get(int errorLogID)
		{
			ErrorLog record = await this.GetById(errorLogID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOErrorLog> Create(
			DTOErrorLog dto)
		{
			ErrorLog record = new ErrorLog();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ErrorLog>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int errorLogID,
			DTOErrorLog dto)
		{
			ErrorLog record = await this.GetById(errorLogID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{errorLogID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					errorLogID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int errorLogID)
		{
			ErrorLog record = await this.GetById(errorLogID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ErrorLog>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOErrorLog>> Where(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOErrorLog> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOErrorLog>> SearchLinqDTO(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOErrorLog> response = new List<DTOErrorLog>();
			List<ErrorLog> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ErrorLog>> SearchLinqEF(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ErrorLog.ErrorLogID)} ASC";
			}
			return await this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ErrorLog>();
		}

		private async Task<List<ErrorLog>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ErrorLog.ErrorLogID)} ASC";
			}

			return await this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ErrorLog>();
		}

		private async Task<ErrorLog> GetById(int errorLogID)
		{
			List<ErrorLog> records = await this.SearchLinqEF(x => x.ErrorLogID == errorLogID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>30dc0d6a05e71b31d17c939688e2d31f</Hash>
</Codenesium>*/