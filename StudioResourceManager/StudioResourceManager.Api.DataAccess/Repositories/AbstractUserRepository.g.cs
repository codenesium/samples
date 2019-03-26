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
	public abstract class AbstractUserRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractUserRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<User>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Id == query.ToInt() ||
				                  x.Password.StartsWith(query) ||
				                  x.Username.StartsWith(query),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<User> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<User> Create(User item)
		{
			this.Context.Set<User>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(User item)
		{
			var entity = this.Context.Set<User>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<User>().Attach(item);
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
			User record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<User>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Admin via userId.
		public async virtual Task<List<Admin>> AdminsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Admin>()
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Admin>();
		}

		// Foreign key reference to this table Student via userId.
		public async virtual Task<List<Student>> StudentsByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Student>()
			       .Include(x => x.FamilyIdNavigation)
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Student>();
		}

		// Foreign key reference to this table Teacher via userId.
		public async virtual Task<List<Teacher>> TeachersByUserId(int userId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Teacher>()
			       .Include(x => x.UserIdNavigation)

			       .Where(x => x.UserId == userId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Teacher>();
		}

		protected async Task<List<User>> Where(
			Expression<Func<User, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<User, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<User>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<User>();
		}

		private async Task<User> GetById(int id)
		{
			List<User> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>49e9656fc2938d828dc250db81290855</Hash>
</Codenesium>*/