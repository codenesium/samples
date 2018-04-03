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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractEmployeeDepartmentHistoryRepository(ILogger logger,
		                                                   ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFEmployeeDepartmentHistory>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, short departmentID,
		                           int shiftID,
		                           DateTime startDate,
		                           Nullable<DateTime> endDate,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  departmentID,
				            shiftID,
				            startDate,
				            endDate,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFEmployeeDepartmentHistory>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEF(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployeeDepartmentHistory> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFEmployeeDepartmentHistory, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
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

		public static void MapPOCOToEF(int businessEntityID, short departmentID,
		                               int shiftID,
		                               DateTime startDate,
		                               Nullable<DateTime> endDate,
		                               DateTime modifiedDate, EFEmployeeDepartmentHistory   efEmployeeDepartmentHistory)
		{
			efEmployeeDepartmentHistory.businessEntityID = businessEntityID;
			efEmployeeDepartmentHistory.departmentID = departmentID;
			efEmployeeDepartmentHistory.shiftID = shiftID;
			efEmployeeDepartmentHistory.startDate = startDate;
			efEmployeeDepartmentHistory.endDate = endDate;
			efEmployeeDepartmentHistory.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmployeeDepartmentHistory efEmployeeDepartmentHistory,Response response)
		{
			if(efEmployeeDepartmentHistory == null)
			{
				return;
			}
			response.AddEmployeeDepartmentHistory(new POCOEmployeeDepartmentHistory()
			{
				BusinessEntityID = efEmployeeDepartmentHistory.businessEntityID.ToInt(),
				DepartmentID = efEmployeeDepartmentHistory.departmentID,
				ShiftID = efEmployeeDepartmentHistory.shiftID,
				StartDate = efEmployeeDepartmentHistory.startDate,
				EndDate = efEmployeeDepartmentHistory.endDate,
				ModifiedDate = efEmployeeDepartmentHistory.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>c592605b6bcfb721f937bc0c48a16353</Hash>
</Codenesium>*/