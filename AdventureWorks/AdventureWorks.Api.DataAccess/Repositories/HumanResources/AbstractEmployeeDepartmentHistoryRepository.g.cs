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
	public abstract class AbstractEmployeeDepartmentHistoryRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractEmployeeDepartmentHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOEmployeeDepartmentHistory> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOEmployeeDepartmentHistory Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOEmployeeDepartmentHistory Create(
			ApiEmployeeDepartmentHistoryModel model)
		{
			EmployeeDepartmentHistory record = new EmployeeDepartmentHistory();

			this.Mapper.EmployeeDepartmentHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EmployeeDepartmentHistory>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.EmployeeDepartmentHistoryMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiEmployeeDepartmentHistoryModel model)
		{
			EmployeeDepartmentHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.EmployeeDepartmentHistoryMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			EmployeeDepartmentHistory record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EmployeeDepartmentHistory>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public List<POCOEmployeeDepartmentHistory> GetDepartmentID(short departmentID)
		{
			return this.SearchLinqPOCO(x => x.DepartmentID == departmentID);
		}
		public List<POCOEmployeeDepartmentHistory> GetShiftID(int shiftID)
		{
			return this.SearchLinqPOCO(x => x.ShiftID == shiftID);
		}

		protected List<POCOEmployeeDepartmentHistory> Where(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOEmployeeDepartmentHistory> SearchLinqPOCO(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOEmployeeDepartmentHistory> response = new List<POCOEmployeeDepartmentHistory>();
			List<EmployeeDepartmentHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.EmployeeDepartmentHistoryMapEFToPOCO(x)));
			return response;
		}

		private List<EmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeeDepartmentHistory.BusinessEntityID)} ASC";
			}
			return this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EmployeeDepartmentHistory>();
		}

		private List<EmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(EmployeeDepartmentHistory.BusinessEntityID)} ASC";
			}

			return this.Context.Set<EmployeeDepartmentHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EmployeeDepartmentHistory>();
		}
	}
}

/*<Codenesium>
    <Hash>2dc8d68d02959e2f733e8ce81f903abe</Hash>
</Codenesium>*/