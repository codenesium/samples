using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDepartmentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDepartmentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Department>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Department> Get(short departmentID)
		{
			return await this.GetById(departmentID);
		}

		public async virtual Task<Department> Create(Department item)
		{
			this.Context.Set<Department>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Department item)
		{
			var entity = this.Context.Set<Department>().Local.FirstOrDefault(x => x.DepartmentID == item.DepartmentID);
			if (entity == null)
			{
				this.Context.Set<Department>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
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

		public async Task<Department> ByName(string name)
		{
			var records = await this.Where(x => x.Name == name);

			return records.FirstOrDefault();
		}

		public async virtual Task<List<EmployeeDepartmentHistory>> EmployeeDepartmentHistories(short departmentID, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EmployeeDepartmentHistory>().Where(x => x.DepartmentID == departmentID).AsQueryable().Skip(offset).Take(limit).ToListAsync<EmployeeDepartmentHistory>();
		}

		protected async Task<List<Department>> Where(
			Expression<Func<Department, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Department, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.DepartmentID;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Department>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Department>();
			}
			else
			{
				return await this.Context.Set<Department>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Department>();
			}
		}

		private async Task<Department> GetById(short departmentID)
		{
			List<Department> records = await this.Where(x => x.DepartmentID == departmentID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5633befb9124352fd07c0b17e45be73f</Hash>
</Codenesium>*/