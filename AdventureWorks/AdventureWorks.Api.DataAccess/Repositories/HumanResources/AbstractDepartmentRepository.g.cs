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
	public abstract class AbstractDepartmentRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractDepartmentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual short Create(
			DepartmentModel model)
		{
			var record = new EFDepartment();

			this.mapper.DepartmentMapModelToEF(
				default (short),
				model,
				record);

			this.context.Set<EFDepartment>().Add(record);
			this.context.SaveChanges();
			return record.DepartmentID;
		}

		public virtual void Update(
			short departmentID,
			DepartmentModel model)
		{
			var record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{departmentID}");
			}
			else
			{
				this.mapper.DepartmentMapModelToEF(
					departmentID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			short departmentID)
		{
			var record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFDepartment>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(short departmentID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.DepartmentID == departmentID, response);
			return response;
		}

		public virtual POCODepartment GetByIdDirect(short departmentID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.DepartmentID == departmentID, response);
			return response.Departments.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Departments;
		}

		private void SearchLinqPOCO(Expression<Func<EFDepartment, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDepartment> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.DepartmentMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDepartment> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.DepartmentMapEFToPOCO(x, response));
		}

		protected virtual List<EFDepartment> SearchLinqEF(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDepartment> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>2a76598c007546d57941d85874778f15</Hash>
</Codenesium>*/