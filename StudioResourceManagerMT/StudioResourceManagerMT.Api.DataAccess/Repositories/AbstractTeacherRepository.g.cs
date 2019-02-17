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
	public abstract class AbstractTeacherRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractTeacherRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.Birthday == query.ToDateTime() ||
				                  x.Email.StartsWith(query) ||
				                  x.FirstName.StartsWith(query) ||
				                  x.Id == query.ToInt() ||
				                  x.LastName.StartsWith(query) ||
				                  x.Phone.StartsWith(query) ||
				                  x.UserId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Teacher> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Teacher> Create(Teacher item)
		{
			this.Context.Set<Teacher>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Teacher item)
		{
			var entity = this.Context.Set<Teacher>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Teacher>().Attach(item);
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
			Teacher record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Teacher>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Teacher>> Where(
			Expression<Func<Teacher, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Teacher, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Teacher>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Teacher>();
		}

		private async Task<Teacher> GetById(int id)
		{
			List<Teacher> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a2e3d52039ee92b04d2b3de8e5314005</Hash>
</Codenesium>*/