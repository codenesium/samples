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
	public abstract class AbstractTenantRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTenantRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Tenant> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Tenant> Create(Tenant item)
		{
			this.Context.Set<Tenant>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Tenant item)
		{
			var entity = this.Context.Set<Tenant>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Tenant>().Attach(item);
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
			Tenant record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Tenant>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<Admin>> Admins(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Admin>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Admin>();
		}

		public async virtual Task<List<Event>> Events(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Event>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Event>();
		}

		public async virtual Task<List<EventStatus>> EventStatuses(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStatus>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStatus>();
		}

		public async virtual Task<List<EventStudent>> EventStudents(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStudent>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStudent>();
		}

		public async virtual Task<List<EventTeacher>> EventTeachers(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventTeacher>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventTeacher>();
		}

		public async virtual Task<List<Family>> Families(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Family>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Family>();
		}

		public async virtual Task<List<Rate>> Rates(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		public async virtual Task<List<Space>> Spaces(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Space>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Space>();
		}

		public async virtual Task<List<SpaceFeature>> SpaceFeatures(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceFeature>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
		}

		public async virtual Task<List<SpaceSpaceFeature>> SpaceSpaceFeatures(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceSpaceFeature>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
		}

		public async virtual Task<List<Student>> Students(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Student>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
		}

		public async virtual Task<List<Studio>> Studios(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Studio>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Studio>();
		}

		public async virtual Task<List<Teacher>> Teachers(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Teacher>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Teacher>();
		}

		public async virtual Task<List<TeacherSkill>> TeacherSkills(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherSkill>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
		}

		public async virtual Task<List<TeacherTeacherSkill>> TeacherTeacherSkills(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherTeacherSkill>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
		}

		public async virtual Task<List<User>> Users(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<User>().Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<User>();
		}

		protected async Task<List<Tenant>> Where(
			Expression<Func<Tenant, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Tenant, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Tenant>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tenant>();
			}
			else
			{
				return await this.Context.Set<Tenant>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Tenant>();
			}
		}

		private async Task<Tenant> GetById(int id)
		{
			List<Tenant> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>871966d7abd57b209525d143085733c3</Hash>
</Codenesium>*/