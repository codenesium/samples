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
		protected IObjectMapper mapper;

		public AbstractEmployeeRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			EmployeeModel model)
		{
			var record = new EFEmployee();

			this.mapper.EmployeeMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFEmployee>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			EmployeeModel model)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.mapper.EmployeeMapModelToEF(
					businessEntityID,
					model,
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

		public virtual ApiResponse GetById(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOEmployee GetByIdDirect(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.Employees.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOEmployee> GetWhereDirect(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Employees;
		}

		private void SearchLinqPOCO(Expression<Func<EFEmployee, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployee> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.EmployeeMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFEmployee> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.EmployeeMapEFToPOCO(x, response));
		}

		protected virtual List<EFEmployee> SearchLinqEF(Expression<Func<EFEmployee, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFEmployee> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>4890e89b9257ff1a08d8d40bbe5098a4</Hash>
</Codenesium>*/