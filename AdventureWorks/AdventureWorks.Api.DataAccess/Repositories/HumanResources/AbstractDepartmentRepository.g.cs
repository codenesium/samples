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

		public virtual POCODepartment Get(short departmentID)
		{
			return this.SearchLinqPOCO(x => x.DepartmentID == departmentID).FirstOrDefault();
		}

		public virtual List<POCODepartment> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCODepartment> Where(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODepartment> SearchLinqPOCO(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODepartment> response = new List<POCODepartment>();
			List<EFDepartment> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DepartmentMapEFToPOCO(x)));
			return response;
		}

		private List<EFDepartment> SearchLinqEF(Expression<Func<EFDepartment, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy("DepartmentID ASC").Skip(skip).Take(take).ToList<EFDepartment>();
			}
			else
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDepartment>();
			}
		}

		private List<EFDepartment> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy("DepartmentID ASC").Skip(skip).Take(take).ToList<EFDepartment>();
			}
			else
			{
				return this.Context.Set<EFDepartment>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDepartment>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>eec96d7badd3bfc7a07e8c9afb9d1e2f</Hash>
</Codenesium>*/