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

		public AbstractEmployeeDepartmentHistoryRepository(ILogger logger,
		                                                   ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(short departmentID,
		                          int shiftID,
		                          DateTime startDate,
		                          Nullable<DateTime> endDate,
		                          DateTime modifiedDate)
		{
			var record = new EFEmployeeDepartmentHistory ();

			MapPOCOToEF(0, departmentID,
			            shiftID,
			            startDate,
			            endDate,
			            modifiedDate, record);

			this.context.Set<EFEmployeeDepartmentHistory>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, short departmentID,
		                           int shiftID,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  departmentID,
				            shiftID,
				            startDate,
				            endDate,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
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

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOEmployeeDepartmentHistory GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.EmployeeDepartmentHistories.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOEmployeeDepartmentHistory> GetWhereDirect(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.EmployeeDepartmentHistories;
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmployeeDepartmentHistory> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmployeeDepartmentHistory> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, short departmentID,
		                               int shiftID,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               DateTime modifiedDate, EFEmployeeDepartmentHistory   efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.BusinessEntityID = businessEntityID;
			efEmployeeDepartmentHistory.DepartmentID = departmentID;
			efEmployeeDepartmentHistory.ShiftID = shiftID;
			efEmployeeDepartmentHistory.StartDate = startDate;
			efEmployeeDepartmentHistory.EndDate = endDate;
			efEmployeeDepartmentHistory.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmployeeDepartmentHistory efEmployeeDepartmentHistory,Response response)
		{
			if(efEmployeeDepartmentHistory == null)
			{
				return;
			}
			response.AddEmployeeDepartmentHistory(new POCOEmployeeDepartmentHistory()
			{
				StartDate = efEmployeeDepartmentHistory.StartDate,
				EndDate = efEmployeeDepartmentHistory.EndDate,
				ModifiedDate = efEmployeeDepartmentHistory.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efEmployeeDepartmentHistory.BusinessEntityID,
				                                            "Employees"),
				DepartmentID = new ReferenceEntity<short>(efEmployeeDepartmentHistory.DepartmentID,
				                                          "Departments"),
				ShiftID = new ReferenceEntity<int>(efEmployeeDepartmentHistory.ShiftID,
				                                   "Shifts"),
			});

			EmployeeRepository.MapEFToPOCO(efEmployeeDepartmentHistory.Employee, response);

			DepartmentRepository.MapEFToPOCO(efEmployeeDepartmentHistory.Department, response);

			ShiftRepository.MapEFToPOCO(efEmployeeDepartmentHistory.Shift, response);
		}
	}
}

/*<Codenesium>
    <Hash>5dc9e54d4f5fc4112fb552a888fcdd55</Hash>
</Codenesium>*/