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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractEmployeeRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFEmployee>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
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
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
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
				this.context.Set<EFEmployee>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
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

		public virtual List<POCOEmployee > GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Employees;
		}
		public virtual POCOEmployee GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.Employees.FirstOrDefault();
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
			efEmployee.BusinessEntityID = businessEntityID;
			efEmployee.NationalIDNumber = nationalIDNumber;
			efEmployee.LoginID = loginID;
			efEmployee.OrganizationNode = organizationNode;
			efEmployee.OrganizationLevel = organizationLevel;
			efEmployee.JobTitle = jobTitle;
			efEmployee.BirthDate = birthDate;
			efEmployee.MaritalStatus = maritalStatus;
			efEmployee.Gender = gender;
			efEmployee.HireDate = hireDate;
			efEmployee.SalariedFlag = salariedFlag;
			efEmployee.VacationHours = vacationHours;
			efEmployee.SickLeaveHours = sickLeaveHours;
			efEmployee.CurrentFlag = currentFlag;
			efEmployee.Rowguid = rowguid;
			efEmployee.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFEmployee efEmployee,Response response)
		{
			if(efEmployee == null)
			{
				return;
			}
			response.AddEmployee(new POCOEmployee()
			{
				NationalIDNumber = efEmployee.NationalIDNumber,
				LoginID = efEmployee.LoginID,
				OrganizationNode = efEmployee.OrganizationNode,
				OrganizationLevel = efEmployee.OrganizationLevel,
				JobTitle = efEmployee.JobTitle,
				BirthDate = efEmployee.BirthDate,
				MaritalStatus = efEmployee.MaritalStatus,
				Gender = efEmployee.Gender,
				HireDate = efEmployee.HireDate,
				SalariedFlag = efEmployee.SalariedFlag,
				VacationHours = efEmployee.VacationHours,
				SickLeaveHours = efEmployee.SickLeaveHours,
				CurrentFlag = efEmployee.CurrentFlag,
				Rowguid = efEmployee.Rowguid,
				ModifiedDate = efEmployee.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efEmployee.BusinessEntityID,
				                                            "People"),
			});

			PersonRepository.MapEFToPOCO(efEmployee.Person, response);
		}
	}
}

/*<Codenesium>
    <Hash>886a129c3e254af4ea9274a8251964e9</Hash>
</Codenesium>*/