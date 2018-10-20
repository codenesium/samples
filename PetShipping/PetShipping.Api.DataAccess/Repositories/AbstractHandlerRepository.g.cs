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

namespace PetShippingNS.Api.DataAccess
{
	public abstract class AbstractHandlerRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractHandlerRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Handler>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Handler> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Handler> Create(Handler item)
		{
			this.Context.Set<Handler>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Handler item)
		{
			var entity = this.Context.Set<Handler>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Handler>().Attach(item);
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
			Handler record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Handler>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<List<AirTransport>> AirTransportsByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<AirTransport>().Where(x => x.HandlerId == handlerId).AsQueryable().Skip(offset).Take(limit).ToListAsync<AirTransport>();
		}

		public async virtual Task<List<Handler>> ByHandlerId(int handlerId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.HandlerPipelineSteps
			              join handlers in this.Context.Handlers on
			              refTable.HandlerId equals handlers.Id
			              where refTable.HandlerId == handlerId
			              select handlers).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Handler>> Where(
			Expression<Func<Handler, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Handler, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Handler>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Handler>();
			}
			else
			{
				return await this.Context.Set<Handler>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Handler>();
			}
		}

		private async Task<Handler> GetById(int id)
		{
			List<Handler> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b59fdad76197502964b0f0c59292176b</Hash>
</Codenesium>*/