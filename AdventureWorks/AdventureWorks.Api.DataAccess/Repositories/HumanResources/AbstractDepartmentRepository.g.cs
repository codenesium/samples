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
		protected IDALDepartmentMapper Mapper { get; }

		public AbstractDepartmentRepository(
			IDALDepartmentMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTODepartment>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTODepartment> Get(short departmentID)
		{
			Department record = await this.GetById(departmentID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTODepartment> Create(
			DTODepartment dto)
		{
			Department record = new Department();

			this.Mapper.MapDTOToEF(
				default (short),
				dto,
				record);

			this.Context.Set<Department>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			short departmentID,
			DTODepartment dto)
		{
			Department record = await this.GetById(departmentID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{departmentID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					departmentID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTODepartment> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTODepartment>> Where(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODepartment> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTODepartment>> SearchLinqDTO(Expression<Func<Department, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODepartment> response = new List<DTODepartment>();
			List<Department> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>88a4165b302b917f6b21096e15729bb5</Hash>
</Codenesium>*/