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

namespace StudioResourceManagerNS.Api.DataAccess
{
	public abstract class AbstractStudentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractStudentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Student>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Student> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Student> Create(Student item)
		{
			this.Context.Set<Student>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Student item)
		{
			var entity = this.Context.Set<Student>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Student>().Attach(item);
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
			Student record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Student>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Family> FamilyByFamilyId(int familyId)
		{
			return await this.Context.Set<Family>().SingleOrDefaultAsync(x => x.Id == familyId);
		}

		public async virtual Task<User> UserByUserId(int userId)
		{
			return await this.Context.Set<User>().SingleOrDefaultAsync(x => x.Id == userId);
		}

		public async virtual Task<List<Student>> ByEventId(int eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.EventStudents
			              join students in this.Context.Students on
			              refTable.StudentId equals students.Id
			              where refTable.EventId == eventId
			              select students).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Student>> Where(
			Expression<Func<Student, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Student, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Student>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Student>();
			}
			else
			{
				return await this.Context.Set<Student>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Student>();
			}
		}

		private async Task<Student> GetById(int id)
		{
			List<Student> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>58d828be0832a667cbce43576d5f87a5</Hash>
</Codenesium>*/