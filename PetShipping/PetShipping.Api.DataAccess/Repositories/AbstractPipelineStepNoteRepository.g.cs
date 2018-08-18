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
	public abstract class AbstractPipelineStepNoteRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractPipelineStepNoteRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepNote>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<PipelineStepNote> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<PipelineStepNote> Create(PipelineStepNote item)
		{
			this.Context.Set<PipelineStepNote>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(PipelineStepNote item)
		{
			var entity = this.Context.Set<PipelineStepNote>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<PipelineStepNote>().Attach(item);
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
			PipelineStepNote record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PipelineStepNote>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Employee> GetEmployee(int employeeId)
		{
			return await this.Context.Set<Employee>().SingleOrDefaultAsync(x => x.Id == employeeId);
		}

		public async virtual Task<PipelineStep> GetPipelineStep(int pipelineStepId)
		{
			return await this.Context.Set<PipelineStep>().SingleOrDefaultAsync(x => x.Id == pipelineStepId);
		}

		protected async Task<List<PipelineStepNote>> Where(
			Expression<Func<PipelineStepNote, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepNote, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
			}
			else
			{
				return await this.Context.Set<PipelineStepNote>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
			}
		}

		private async Task<PipelineStepNote> GetById(int id)
		{
			List<PipelineStepNote> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f43a793d1e5409ee5f41b3c49c409cc7</Hash>
</Codenesium>*/