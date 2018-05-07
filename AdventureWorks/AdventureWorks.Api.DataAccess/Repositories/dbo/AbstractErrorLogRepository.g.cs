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

		public virtual int Create(
			ErrorLogModel model)
		{
			EFErrorLog record = new EFErrorLog();

			this.Mapper.ErrorLogMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFErrorLog>().Add(record);
			this.Context.SaveChanges();
			return record.ErrorLogID;
		}

		public virtual void Update(
			int errorLogID,
			ErrorLogModel model)
		{
			EFErrorLog record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();
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
			EFErrorLog record = this.SearchLinqEF(x => x.ErrorLogID == errorLogID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFErrorLog>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOErrorLog Get(int errorLogID)
		{
			return this.SearchLinqPOCO(x => x.ErrorLogID == errorLogID).FirstOrDefault();
		}

		public virtual List<POCOErrorLog> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOErrorLog> Where(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOErrorLog> SearchLinqPOCO(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOErrorLog> response = new List<POCOErrorLog>();
			List<EFErrorLog> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ErrorLogMapEFToPOCO(x)));
			return response;
		}

		private List<EFErrorLog> SearchLinqEF(Expression<Func<EFErrorLog, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy("ErrorLogID ASC").Skip(skip).Take(take).ToList<EFErrorLog>();
			}
			else
			{
				return this.Context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFErrorLog>();
			}
		}

		private List<EFErrorLog> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy("ErrorLogID ASC").Skip(skip).Take(take).ToList<EFErrorLog>();
			}
			else
			{
				return this.Context.Set<EFErrorLog>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFErrorLog>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>94cb2c1381b9597abd161daa23628ae5</Hash>
</Codenesium>*/