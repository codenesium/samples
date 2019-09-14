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

namespace SecureVideoCRMNS.Api.DataAccess
{
	public class SubscriptionRepository : AbstractRepository, ISubscriptionRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public SubscriptionRepository(
			ILogger<ISubscriptionRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Subscription>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.Name == null?false : x.Name.StartsWith(query)) ||
				                  (x.StripePlanName == null?false : x.StripePlanName.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Subscription> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Subscription> Create(Subscription item)
		{
			this.Context.Set<Subscription>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Subscription item)
		{
			var entity = this.Context.Set<Subscription>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Subscription>().Attach(item);
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
			Subscription record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Subscription>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<Subscription>> Where(
			Expression<Func<Subscription, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Subscription, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Subscription>()

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Subscription>();
		}

		private async Task<Subscription> GetById(int id)
		{
			List<Subscription> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>d1c846629d8e116b07519443eded2803</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/