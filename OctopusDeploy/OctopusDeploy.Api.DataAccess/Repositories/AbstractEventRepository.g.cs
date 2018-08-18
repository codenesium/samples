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
	public abstract class AbstractEventRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEventRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Event>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Event> Get(string id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Event> Create(Event item)
		{
			this.Context.Set<Event>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Event item)
		{
			var entity = this.Context.Set<Event>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Event>().Attach(item);
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
			Event record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Event>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Event>> ByAutoId(long autoId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.AutoId == autoId, limit, offset);

			return records;
		}

		public async Task<List<Event>> ByIdRelatedDocumentIdsOccurredCategoryAutoId(string id, string relatedDocumentIds, DateTimeOffset occurred, string category, long autoId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.Id == id && x.RelatedDocumentIds == relatedDocumentIds && x.Occurred == occurred && x.Category == category && x.AutoId == autoId, limit, offset);

			return records;
		}

		public async Task<List<Event>> ByIdRelatedDocumentIdsProjectIdEnvironmentIdCategoryUserIdOccurredTenantId(string id, string relatedDocumentIds, string projectId, string environmentId, string category, string userId, DateTimeOffset occurred, string tenantId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.Id == id && x.RelatedDocumentIds == relatedDocumentIds && x.ProjectId == projectId && x.EnvironmentId == environmentId && x.Category == category && x.UserId == userId && x.Occurred == occurred && x.TenantId == tenantId, limit, offset);

			return records;
		}

		public async Task<List<Event>> ByIdOccurred(string id, DateTimeOffset occurred, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.Id == id && x.Occurred == occurred, limit, offset);

			return records;
		}

		public async virtual Task<List<EventRelatedDocument>> EventRelatedDocuments(string eventId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<EventRelatedDocument>().Where(x => x.EventId == eventId).AsQueryable().Skip(offset).Take(limit).ToListAsync<EventRelatedDocument>();
		}

		protected async Task<List<Event>> Where(
			Expression<Func<Event, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Event, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
			}
			else
			{
				return await this.Context.Set<Event>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Event>();
			}
		}

		private async Task<Event> GetById(string id)
		{
			List<Event> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1c535da7aed4ff7fc11c04397effafe2</Hash>
</Codenesium>*/