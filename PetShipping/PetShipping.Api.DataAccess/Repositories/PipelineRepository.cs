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
	public class PipelineRepository : AbstractRepository, IPipelineRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PipelineRepository(
			ILogger<IPipelineRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Pipeline>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.PipelineStatusIdNavigation == null || x.PipelineStatusIdNavigation.Name == null?false : x.PipelineStatusIdNavigation.Name.StartsWith(query)) ||
				                  x.SaleId == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Pipeline> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Pipeline> Create(Pipeline item)
		{
			this.Context.Set<Pipeline>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Pipeline item)
		{
			var entity = this.Context.Set<Pipeline>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Pipeline>().Attach(item);
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
			Pipeline record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Pipeline>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to table PipelineStatus via pipelineStatusId.
		public async virtual Task<PipelineStatus> PipelineStatusByPipelineStatusId(int pipelineStatusId)
		{
			return await this.Context.Set<PipelineStatus>()
			       .SingleOrDefaultAsync(x => x.Id == pipelineStatusId);
		}

		protected async Task<List<Pipeline>> Where(
			Expression<Func<Pipeline, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Pipeline, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Pipeline>()
			       .Include(x => x.PipelineStatusIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Pipeline>();
		}

		private async Task<Pipeline> GetById(int id)
		{
			List<Pipeline> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f127ab3507a546e6962091ec0f06883b</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/