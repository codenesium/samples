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

namespace TestsNS.Api.DataAccess
{
	public abstract class AbstractVPersonRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractVPersonRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<VPerson>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<VPerson> Get(int personId)
		{
			return await this.GetById(personId);
		}

		public async virtual Task<VPerson> Create(VPerson item)
		{
			this.Context.Set<VPerson>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(VPerson item)
		{
			var entity = this.Context.Set<VPerson>().Local.FirstOrDefault(x => x.PersonId == item.PersonId);
			if (entity == null)
			{
				this.Context.Set<VPerson>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int personId)
		{
			VPerson record = await this.GetById(personId);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<VPerson>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<VPerson> ByPersonId(int personId)
		{
			var records = await this.Where(x => x.PersonId == personId);

			return records.FirstOrDefault();
		}

		protected async Task<List<VPerson>> Where(
			Expression<Func<VPerson, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<VPerson, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.PersonId;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<VPerson>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<VPerson>();
			}
			else
			{
				return await this.Context.Set<VPerson>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<VPerson>();
			}
		}

		private async Task<VPerson> GetById(int personId)
		{
			List<VPerson> records = await this.Where(x => x.PersonId == personId);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fb4f8aa7d1921d4fe79581d4ca39af76</Hash>
</Codenesium>*/