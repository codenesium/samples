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

namespace StudioResourceManagerMTNS.Api.DataAccess
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

		public virtual Task<List<Tenant>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Name.StartsWith(query),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to this table Admin via tenantId.
		public async virtual Task<List<Admin>> AdminsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Admin>()
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Admin>();
		}

		// Foreign key reference to this table Event via tenantId.
		public async virtual Task<List<Event>> EventsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Event>()
			       .Include(x => x.EventStatusIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Event>();
		}

		// Foreign key reference to this table EventStatus via tenantId.
		public async virtual Task<List<EventStatus>> EventStatusByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStatus>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStatus>();
		}

		// Foreign key reference to this table EventStudent via tenantId.
		public async virtual Task<List<EventStudent>> EventStudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventStudent>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.StudentIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventStudent>();
		}

		// Foreign key reference to this table EventTeacher via tenantId.
		public async virtual Task<List<EventTeacher>> EventTeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventTeacher>()
			       .Include(x => x.EventIdNavigation)
			       .Include(x => x.TeacherIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventTeacher>();
		}

		// Foreign key reference to this table Family via tenantId.
		public async virtual Task<List<Family>> FamiliesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Family>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Family>();
		}

		// Foreign key reference to this table Rate via tenantId.
		public async virtual Task<List<Rate>> RatesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Rate>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Rate>();
		}

		// Foreign key reference to this table Space via tenantId.
		public async virtual Task<List<Space>> SpacesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Space>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Space>();
		}

		// Foreign key reference to this table SpaceFeature via tenantId.
		public async virtual Task<List<SpaceFeature>> SpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceFeature>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceFeature>();
		}

		// Foreign key reference to this table SpaceSpaceFeature via tenantId.
		public async virtual Task<List<SpaceSpaceFeature>> SpaceSpaceFeaturesByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<SpaceSpaceFeature>()
			       .Include(x => x.SpaceFeatureIdNavigation)
			       .Include(x => x.SpaceIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<SpaceSpaceFeature>();
		}

		// Foreign key reference to this table Student via tenantId.
		public async virtual Task<List<Student>> StudentsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Student>()
			       .Include(x => x.FamilyIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
		}

		// Foreign key reference to this table Studio via tenantId.
		public async virtual Task<List<Studio>> StudiosByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Studio>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Studio>();
		}

		// Foreign key reference to this table Teacher via tenantId.
		public async virtual Task<List<Teacher>> TeachersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Teacher>()
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Teacher>();
		}

		// Foreign key reference to this table TeacherSkill via tenantId.
		public async virtual Task<List<TeacherSkill>> TeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherSkill>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherSkill>();
		}

		// Foreign key reference to this table TeacherTeacherSkill via tenantId.
		public async virtual Task<List<TeacherTeacherSkill>> TeacherTeacherSkillsByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<TeacherTeacherSkill>()
			       .Include(x => x.TeacherIdNavigation)
			       .Include(x => x.TeacherSkillIdNavigation)

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<TeacherTeacherSkill>();
		}

		// Foreign key reference to this table User via tenantId.
		public async virtual Task<List<User>> UsersByTenantId(int tenantId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<User>()

			       .Where(x => x.TenantId == tenantId).AsQueryable().Skip(offset).Take(limit).ToListAsync<User>();
		}

		protected async Task<List<Tenant>> Where(
			Expression<Func<Tenant, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Tenant, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Tenant>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Tenant>();
		}

		private async Task<Tenant> GetById(int id)
		{
			List<Tenant> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f617b5db9ce7c73bdf357191718a5ddc</Hash>
</Codenesium>*/