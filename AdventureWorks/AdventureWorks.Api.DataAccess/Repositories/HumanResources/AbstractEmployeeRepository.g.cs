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

		public AbstractEmployeeRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string nationalIDNumber,
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
			var record = new EFEmployee();

			MapPOCOToEF(
				0,
				nationalIDNumber,
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
				modifiedDate,
				record);

			this.context.Set<EFEmployee>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			string nationalIDNumber,
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
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				MapPOCOToEF(
					businessEntityID,
					nationalIDNumber,
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
				this.context.Set<EFEmployee>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOEmployee GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.Employees.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Employees;
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployee, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployee> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployee> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFEmployee> SearchLinqEF(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployee> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int businessEntityID,
			string nationalIDNumber,
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
			DateTime modifiedDate,
			EFEmployee efEmployee)
		{
			efEmployee.SetProperties(businessEntityID.ToInt(), nationalIDNumber, loginID, organizationNode, organizationLevel, jobTitle, birthDate, maritalStatus, gender, hireDate, salariedFlag, vacationHours, sickLeaveHours, currentFlag, rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFEmployee efEmployee,
			Response response)
		{
			if (efEmployee == null)
			{
				return;
			}

			response.AddEmployee(new POCOEmployee(efEmployee.BusinessEntityID.ToInt(), efEmployee.NationalIDNumber, efEmployee.LoginID, efEmployee.OrganizationNode, efEmployee.OrganizationLevel, efEmployee.JobTitle, efEmployee.BirthDate, efEmployee.MaritalStatus, efEmployee.Gender, efEmployee.HireDate, efEmployee.SalariedFlag, efEmployee.VacationHours, efEmployee.SickLeaveHours, efEmployee.CurrentFlag, efEmployee.Rowguid, efEmployee.ModifiedDate.ToDateTime()));

			PersonRepository.MapEFToPOCO(efEmployee.Person, response);
		}
	}
}

/*<Codenesium>
    <Hash>a9c963bb4f11bf4ad044a20244d6070a</Hash>
</Codenesium>*/