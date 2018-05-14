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

		public virtual List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCODepartment Get(short departmentID)
		{
			return this.SearchLinqPOCO(x => x.DepartmentID == departmentID).FirstOrDefault();
		}

		public virtual POCODepartment Create(
			ApiDepartmentModel model)
		{
			Department record = new Department();

			this.Mapper.DepartmentMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<Department>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.DepartmentMapEFToPOCO(record);
		}

		public virtual void Update(
			short departmentID,
			ApiDepartmentModel model)
		{
			Department record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();
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
			Department record = this.SearchLinqEF(x => x.DepartmentID == departmentID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Department>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCODepartment GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		protected List<POCODepartment> Where(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODepartment> SearchLinqPOCO(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODepartment> response = new List<POCODepartment>();
			List<Department> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DepartmentMapEFToPOCO(x)));
			return response;
		}

		private List<Department> SearchLinqEF(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Department.DepartmentID)} ASC";
			}
			return this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Department>();
		}

		private List<Department> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Department.DepartmentID)} ASC";
			}

			return this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Department>();
		}
	}
}

/*<Codenesium>
    <Hash>826a0acc6b0f659557a18e86738697de</Hash>
</Codenesium>*/