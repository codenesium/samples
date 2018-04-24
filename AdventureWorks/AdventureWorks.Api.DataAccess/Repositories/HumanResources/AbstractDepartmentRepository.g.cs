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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDepartmentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual short Create(
			DepartmentModel model)
		{
			EFDepartment record = new EFDepartment();

			this.Mapper.DepartmentMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<EFDepartment>().Add(record);
			this.Context.SaveChanges();
			return record.DepartmentID;
		}

		public virtual void Update(
			short departmentID,
			DepartmentModel model)
		{
			EFDepartment record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{departmentID}");
			}
			else
			{
				this.Mapper.DepartmentMapModelToEF(
					departmentID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			short departmentID)
		{
			EFDepartment record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFDepartment>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(short departmentID)
		{
			return this.SearchLinqPOCO(x => x.DepartmentID == departmentID);
		}

		public virtual POCODepartment GetByIdDirect(short departmentID)
		{
			return this.SearchLinqPOCO(x => x.DepartmentID == departmentID).Departments.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCODepartment> GetWhereDirect(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Departments;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFDepartment> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.DepartmentMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFDepartment> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.DepartmentMapEFToPOCO(x, response));
			return response;
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
    <Hash>413eae90e95d22daf288974ad0e16c78</Hash>
</Codenesium>*/