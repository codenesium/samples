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
	public abstract class AbstractEmployeePayHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmployeePayHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOEmployeePayHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOEmployeePayHistory Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOEmployeePayHistory Create(
			ApiEmployeePayHistoryModel model)
		{
			EmployeePayHistory record = new EmployeePayHistory();

			this.Mapper.EmployeePayHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EmployeePayHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.EmployeePayHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiEmployeePayHistoryModel model)
		{
			EmployeePayHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.EmployeePayHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EmployeePayHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmployeePayHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOEmployeePayHistory> Where(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOEmployeePayHistory> SearchLinqPOCO(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployeePayHistory> response = new List<POCOEmployeePayHistory>();
			List<EmployeePayHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.EmployeePayHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<EmployeePayHistory> SearchLinqEF(Expression<Func<EmployeePayHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeePayHistory.BusinessEntityID)} ASC";
			}
			return this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EmployeePayHistory>();
		}

		private List<EmployeePayHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeePayHistory.BusinessEntityID)} ASC";
			}

			return this.Context.Set<EmployeePayHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EmployeePayHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>9a59e0f403abccd58d1bd898dd443fd3</Hash>
</Codenesium>*/