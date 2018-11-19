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
	public abstract class AbstractFamilyRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractFamilyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Family>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Family> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Family> Create(Family item)
		{
			this.Context.Set<Family>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Family item)
		{
			var entity = this.Context.Set<Family>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Family>().Attach(item);
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
			Family record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Family>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Student via familyId.
		public async virtual Task<List<Student>> StudentsByFamilyId(int familyId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Student>().Where(x => x.FamilyId == familyId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
		}

		// Foreign key reference pass-though. Pass-thru table Student. Foreign Table Family.
		public async virtual Task<List<Family>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.Students
			              join families in this.Context.Families on
			              refTable.FamilyId equals families.Id
			              where refTable.UserId == userId
			              select families).Skip(offset).Take(limit).ToListAsync();
		}

		public async virtual Task<Student> CreateStudent(Student item)
		{
			this.Context.Set<Student>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task DeleteStudent(Student item)
		{
			this.Context.Set<Student>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<Family>> Where(
			Expression<Func<Family, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Family, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Family>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Family>();
		}

		private async Task<Family> GetById(int id)
		{
			List<Family> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1a40f73d7f7ecf6ae5b54068f2ca38d7</Hash>
</Codenesium>*/