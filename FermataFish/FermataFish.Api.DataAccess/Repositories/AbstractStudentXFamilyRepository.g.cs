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

namespace FermataFishNS.Api.DataAccess
{
	public abstract class AbstractStudentXFamilyRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractStudentXFamilyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<StudentXFamily>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<StudentXFamily> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<StudentXFamily> Create(StudentXFamily item)
		{
			this.Context.Set<StudentXFamily>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(StudentXFamily item)
		{
			var entity = this.Context.Set<StudentXFamily>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<StudentXFamily>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int id)
		{
			StudentXFamily record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<StudentXFamily>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Family> GetFamily(int familyId)
		{
			return await this.Context.Set<Family>().SingleOrDefaultAsync(x => x.Id == familyId);
		}

		public async virtual Task<Student> GetStudent(int studentId)
		{
			return await this.Context.Set<Student>().SingleOrDefaultAsync(x => x.Id == studentId);
		}

		protected async Task<List<StudentXFamily>> Where(
			Expression<Func<StudentXFamily, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<StudentXFamily, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<StudentXFamily>();
			}
			else
			{
				return await this.Context.Set<StudentXFamily>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<StudentXFamily>();
			}
		}

		private async Task<StudentXFamily> GetById(int id)
		{
			List<StudentXFamily> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>7b9d43e763c8c3958969528d8c2783aa</Hash>
</Codenesium>*/