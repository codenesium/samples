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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractErrorLogRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOErrorLog Get(int errorLogID)
		{
			return this.SearchLinqPOCO(x => x.ErrorLogID == errorLogID).FirstOrDefault();
		}

		public virtual POCOErrorLog Create(
			ApiErrorLogModel model)
		{
			ErrorLog record = new ErrorLog();

			this.Mapper.ErrorLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ErrorLog>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ErrorLogMapEFToPOCO(record);
		}

		public virtual void Update(
			int errorLogID,
			ApiErrorLogModel model)
		{
			ErrorLog record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int errorLogID)
		{
			ErrorLog record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ErrorLog>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOErrorLog> Where(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOErrorLog> SearchLinqPOCO(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOErrorLog> response = new List<POCOErrorLog>();
			List<ErrorLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ErrorLogMapEFToPOCO(x)));
			return response;
		}

		private List<ErrorLog> SearchLinqEF(Expression<Func<ErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ErrorLog.ErrorLogID)} ASC";
			}
			return this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ErrorLog>();
		}

		private List<ErrorLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ErrorLog.ErrorLogID)} ASC";
			}

			return this.Context.Set<ErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ErrorLog>();
		}
	}
}

/*<Codenesium>
    <Hash>85686d39fc43314eb1899d9d1b0bb0b3</Hash>
</Codenesium>*/