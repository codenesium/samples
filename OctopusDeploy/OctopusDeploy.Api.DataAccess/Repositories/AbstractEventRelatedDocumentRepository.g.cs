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
	public abstract class AbstractEventRelatedDocumentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractEventRelatedDocumentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<EventRelatedDocument>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<EventRelatedDocument> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<EventRelatedDocument> Create(EventRelatedDocument item)
		{
			this.Context.Set<EventRelatedDocument>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(EventRelatedDocument item)
		{
			var entity = this.Context.Set<EventRelatedDocument>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<EventRelatedDocument>().Attach(item);
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
			EventRelatedDocument record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EventRelatedDocument>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<EventRelatedDocument>> ByEventId(string eventId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.EventId == eventId, limit, offset);

			return records;
		}

		public async Task<List<EventRelatedDocument>> ByEventIdRelatedDocumentId(string eventId, string relatedDocumentId, int limit = int.MaxValue, int offset = 0)
		{
			var records = await this.Where(x => x.EventId == eventId && x.RelatedDocumentId == relatedDocumentId, limit, offset);

			return records;
		}

		public async virtual Task<Event> GetEvent(string eventId)
		{
			return await this.Context.Set<Event>().SingleOrDefaultAsync(x => x.Id == eventId);
		}

		protected async Task<List<EventRelatedDocument>> Where(
			Expression<Func<EventRelatedDocument, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<EventRelatedDocument, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<EventRelatedDocument>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<EventRelatedDocument>();
			}
			else
			{
				return await this.Context.Set<EventRelatedDocument>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<EventRelatedDocument>();
			}
		}

		private async Task<EventRelatedDocument> GetById(int id)
		{
			List<EventRelatedDocument> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fb44c3ff7880e41c66406a0d2c18aa23</Hash>
</Codenesium>*/