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
	public class PipelineStepNoteRepository : AbstractRepository, IPipelineStepNoteRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public PipelineStepNoteRepository(
			ILogger<IPipelineStepNoteRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<PipelineStepNote>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.EmployeeIdNavigation == null || x.EmployeeIdNavigation.LastName == null?false : x.EmployeeIdNavigation.LastName.StartsWith(query)) ||
				                  (x.Note == null?false : x.Note.StartsWith(query)) ||
				                  (x.PipelineStepIdNavigation == null || x.PipelineStepIdNavigation.Name == null?false : x.PipelineStepIdNavigation.Name.StartsWith(query)),
				                  limit,
				                  offset);
			}
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

		// Foreign key reference to table Employee via employeeId.
		public async virtual Task<Employee> EmployeeByEmployeeId(int employeeId)
		{
			return await this.Context.Set<Employee>()
			       .SingleOrDefaultAsync(x => x.Id == employeeId);
		}

		// Foreign key reference to table PipelineStep via pipelineStepId.
		public async virtual Task<PipelineStep> PipelineStepByPipelineStepId(int pipelineStepId)
		{
			return await this.Context.Set<PipelineStep>()
			       .SingleOrDefaultAsync(x => x.Id == pipelineStepId);
		}

		protected async Task<List<PipelineStepNote>> Where(
			Expression<Func<PipelineStepNote, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<PipelineStepNote, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<PipelineStepNote>()
			       .Include(x => x.EmployeeIdNavigation)
			       .Include(x => x.PipelineStepIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<PipelineStepNote>();
		}

		private async Task<PipelineStepNote> GetById(int id)
		{
			List<PipelineStepNote> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4415f27dcf5100a51a017f81e469d647</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/