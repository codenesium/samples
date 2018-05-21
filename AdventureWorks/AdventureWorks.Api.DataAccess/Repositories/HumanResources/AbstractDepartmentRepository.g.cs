using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDepartmentRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDepartmentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCODepartment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCODepartment> Get(short departmentID)
		{
			Department record = await this.GetById(departmentID);

			return this.Mapper.DepartmentMapEFToPOCO(record);
		}

		public async virtual Task<POCODepartment> Create(
			ApiDepartmentModel model)
		{
			Department record = new Department();

			this.Mapper.DepartmentMapModelToEF(
				default (short),
				model,
				record);

			this.Context.Set<Department>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.DepartmentMapEFToPOCO(record);
		}

		public async virtual Task Update(
			short departmentID,
			ApiDepartmentModel model)
		{
			Department record = await this.GetById(departmentID);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			short departmentID)
		{
			Department record = await this.GetById(departmentID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Department>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCODepartment> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCODepartment>> Where(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODepartment> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCODepartment>> SearchLinqPOCO(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODepartment> response = new List<POCODepartment>();
			List<Department> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.DepartmentMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Department>> SearchLinqEF(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Department.DepartmentID)} ASC";
			}
			return await this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Department>();
		}

		private async Task<List<Department>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Department.DepartmentID)} ASC";
			}

			return await this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Department>();
		}

		private async Task<Department> GetById(short departmentID)
		{
			List<Department> records = await this.SearchLinqEF(x => x.DepartmentID == departmentID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ea6a3e1f2f8109c5a755d5cf3478efdf</Hash>
</Codenesium>*/