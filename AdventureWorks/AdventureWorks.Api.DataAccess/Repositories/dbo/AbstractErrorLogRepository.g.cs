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
		protected IObjectMapper Mapper { get; }

		public AbstractErrorLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOErrorLog>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOErrorLog> Get(int errorLogID)
		{
			ErrorLog record = await this.GetById(errorLogID);

			return this.Mapper.ErrorLogMapEFToPOCO(record);
		}

		public async virtual Task<POCOErrorLog> Create(
			ApiErrorLogModel model)
		{
			ErrorLog record = new ErrorLog();

			this.Mapper.ErrorLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ErrorLog>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ErrorLogMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int errorLogID,
			ApiErrorLogModel model)
		{
			ErrorLog record = await this.GetById(errorLogID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{errorLogID}");
			}
			else
			{
				this.Mapper.ErrorLogMapModelToEF(
					errorLogID,
					model,
					record);
				this.Context.SaveChangesAsync();
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

		protected async Task<List<POCOErrorLog>> Where(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOErrorLog> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOErrorLog>> SearchLinqPOCO(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOErrorLog> response = new List<POCOErrorLog>();
			List<ErrorLog> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ErrorLogMapEFToPOCO(x)));
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
    <Hash>069ce7786ce13beac319ac4f1a33f957</Hash>
</Codenesium>*/