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
	public abstract class AbstractEmployeeRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractEmployeeRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string nationalIDNumber,
		                          string loginID,
		                          Nullable<Guid> organizationNode,
		                          Nullable<short> organizationLevel,
		                          string jobTitle,
		                          DateTime birthDate,
		                          string maritalStatus,
		                          string gender,
		                          DateTime hireDate,
		                          bool salariedFlag,
		                          short vacationHours,
		                          short sickLeaveHours,
		                          bool currentFlag,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFEmployee ();

			MapPOCOToEF(0, nationalIDNumber,
			            loginID,
			            organizationNode,
			            organizationLevel,
			            jobTitle,
			            birthDate,
			            maritalStatus,
			            gender,
			            hireDate,
			            salariedFlag,
			            vacationHours,
			            sickLeaveHours,
			            currentFlag,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFEmployee>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, string nationalIDNumber,
		                           string loginID,
		                           Nullable<Guid> organizationNode,
		                           Nullable<short> organizationLevel,
		                           string jobTitle,
		                           DateTime birthDate,
		                           string maritalStatus,
		                           string gender,
		                           DateTime hireDate,
		                           bool salariedFlag,
		                           short vacationHours,
		                           short sickLeaveHours,
		                           bool currentFlag,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  nationalIDNumber,
				            loginID,
				            organizationNode,
				            organizationLevel,
				            jobTitle,
				            birthDate,
				            maritalStatus,
				            gender,
				            hireDate,
				            salariedFlag,
				            vacationHours,
				            sickLeaveHours,
				            currentFlag,
				            rowguid,
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
				this._context.Set<EFEmployee>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFEmployee> SearchLinqEF(Expression<Func<EFEmployee, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployee> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFEmployee, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployee, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmployee> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFEmployee> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, string nationalIDNumber,
		                               string loginID,
		                               Nullable<Guid> organizationNode,
		                               Nullable<short> organizationLevel,
		                               string jobTitle,
		                               DateTime birthDate,
		                               string maritalStatus,
		                               string gender,
		                               DateTime hireDate,
		                               bool salariedFlag,
		                               short vacationHours,
		                               short sickLeaveHours,
		                               bool currentFlag,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFEmployee   efEmployee)
		{
			efEmployee.businessEntityID = businessEntityID;
			efEmployee.nationalIDNumber = nationalIDNumber;
			efEmployee.loginID = loginID;
			efEmployee.organizationNode = organizationNode;
			efEmployee.organizationLevel = organizationLevel;
			efEmployee.jobTitle = jobTitle;
			efEmployee.birthDate = birthDate;
			efEmployee.maritalStatus = maritalStatus;
			efEmployee.gender = gender;
			efEmployee.hireDate = hireDate;
			efEmployee.salariedFlag = salariedFlag;
			efEmployee.vacationHours = vacationHours;
			efEmployee.sickLeaveHours = sickLeaveHours;
			efEmployee.currentFlag = currentFlag;
			efEmployee.rowguid = rowguid;
			efEmployee.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmployee efEmployee,Response response)
		{
			if(efEmployee == null)
			{
				return;
			}
			response.AddEmployee(new POCOEmployee()
			{
				BusinessEntityID = efEmployee.businessEntityID.ToInt(),
				NationalIDNumber = efEmployee.nationalIDNumber,
				LoginID = efEmployee.loginID,
				OrganizationNode = efEmployee.organizationNode,
				OrganizationLevel = efEmployee.organizationLevel,
				JobTitle = efEmployee.jobTitle,
				BirthDate = efEmployee.birthDate,
				MaritalStatus = efEmployee.maritalStatus,
				Gender = efEmployee.gender,
				HireDate = efEmployee.hireDate,
				SalariedFlag = efEmployee.salariedFlag,
				VacationHours = efEmployee.vacationHours,
				SickLeaveHours = efEmployee.sickLeaveHours,
				CurrentFlag = efEmployee.currentFlag,
				Rowguid = efEmployee.rowguid,
				ModifiedDate = efEmployee.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>1ff3f5d64d597724678c00666461999a</Hash>
</Codenesium>*/