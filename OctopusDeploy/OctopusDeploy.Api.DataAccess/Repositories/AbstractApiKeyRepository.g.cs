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

namespace OctopusDeployNS.Api.DataAccess
{
	public abstract class AbstractApiKeyRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractApiKeyRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ApiKey>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<ApiKey> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<ApiKey> Create(ApiKey item)
		{
			this.Context.Set<ApiKey>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ApiKey item)
		{
			var entity = this.Context.Set<ApiKey>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<ApiKey>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			string id)
		{
			ApiKey record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ApiKey>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<ApiKey> ByApiKeyHashed(string apiKeyHashed)
		{
			var records = await this.Where(x => x.ApiKeyHashed == apiKeyHashed);

			return records.FirstOrDefault();
		}

		protected async Task<List<ApiKey>> Where(
			Expression<Func<ApiKey, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<ApiKey, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<ApiKey>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<ApiKey>();
			}
			else
			{
				return await this.Context.Set<ApiKey>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<ApiKey>();
			}
		}

		private async Task<ApiKey> GetById(string id)
		{
			List<ApiKey> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>3c888246c7d03ca871fb9c9901de08a2</Hash>
</Codenesium>*/