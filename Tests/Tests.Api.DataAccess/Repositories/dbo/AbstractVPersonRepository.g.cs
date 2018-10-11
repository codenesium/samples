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
    <Hash>ffbe13e7c219574f460c6a3083778c63</Hash>
</Codenesium>*/