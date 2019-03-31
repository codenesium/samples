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

namespace PetStoreNS.Api.DataAccess
{
	public abstract class AbstractPenRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPenRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Pen>> All(int limit = int.MaxValue, int offset = 0, string query = "")
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

		public async virtual Task<Pen> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Pen> Create(Pen item)
		{
			this.Context.Set<Pen>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Pen item)
		{
			var entity = this.Context.Set<Pen>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Pen>().Attach(item);
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
			Pen record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Pen>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Pet via penId.
		public async virtual Task<List<Pet>> PetsByPenId(int penId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Pet>()
			       .Include(x => x.BreedIdNavigation)
			       .Include(x => x.PenIdNavigation)

			       .Where(x => x.PenId == penId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Pet>();
		}

		protected async Task<List<Pen>> Where(
			Expression<Func<Pen, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Pen, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Pen>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Pen>();
		}

		private async Task<Pen> GetById(int id)
		{
			List<Pen> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c6645aefba6e1770d001e57de91a1010</Hash>
</Codenesium>*/