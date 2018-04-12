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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractEmployeeDepartmentHistoryRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			short departmentID,
			int shiftID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate)
		{
			var record = new EFEmployeeDepartmentHistory();

			MapPOCOToEF(
				0,
				departmentID,
				shiftID,
				startDate,
				endDate,
				modifiedDate,
				record);

			this.context.Set<EFEmployeeDepartmentHistory>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			short departmentID,
			int shiftID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				MapPOCOToEF(
					businessEntityID,
					departmentID,
					shiftID,
					startDate,
					endDate,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFEmployeeDepartmentHistory>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.EmployeeDepartmentHistories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.EmployeeDepartmentHistories;
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployeeDepartmentHistory> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployeeDepartmentHistory> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int businessEntityID,
			short departmentID,
			int shiftID,
			DateTime startDate,
			Nullable<DateTime> endDate,
			DateTime modifiedDate,
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.SetProperties(businessEntityID.ToInt(), departmentID, shiftID, startDate, endDate, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFEmployeeDepartmentHistory efEmployeeDepartmentHistory,
			Response response)
		{
			if (efEmployeeDepartmentHistory == null)
			{
				return;
			}

			response.AddEmployeeDepartmentHistory(new POCOEmployeeDepartmentHistory(efEmployeeDepartmentHistory.BusinessEntityID.ToInt(), efEmployeeDepartmentHistory.DepartmentID, efEmployeeDepartmentHistory.ShiftID, efEmployeeDepartmentHistory.StartDate, efEmployeeDepartmentHistory.EndDate, efEmployeeDepartmentHistory.ModifiedDate.ToDateTime()));

			EmployeeRepository.MapEFToPOCO(efEmployeeDepartmentHistory.Employee, response);

			DepartmentRepository.MapEFToPOCO(efEmployeeDepartmentHistory.Department, response);

			ShiftRepository.MapEFToPOCO(efEmployeeDepartmentHistory.Shift, response);
		}
	}
}

/*<Codenesium>
    <Hash>a7e54c6bdcd93aa235ae453e44540818</Hash>
</Codenesium>*/