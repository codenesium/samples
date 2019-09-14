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

namespace CADNS.Api.DataAccess
{
	public class CallAssignmentRepository : AbstractRepository, ICallAssignmentRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public CallAssignmentRepository(
			ILogger<ICallAssignmentRepository> logger,
			ApplicationDbContext context)
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<CallAssignment>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  (x.CallIdNavigation == null || x.CallIdNavigation.Id == null?false : x.CallIdNavigation.Id == query.ToInt()) ||
				                  (x.UnitIdNavigation == null || x.UnitIdNavigation.CallSign == null?false : x.UnitIdNavigation.CallSign.StartsWith(query)),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<CallAssignment> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<CallAssignment> Create(CallAssignment item)
		{
			this.Context.Set<CallAssignment>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(CallAssignment item)
		{
			var entity = this.Context.Set<CallAssignment>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<CallAssignment>().Attach(item);
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
			CallAssignment record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CallAssignment>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Non-unique constraint IX_CallAssignment_callId.
		public async virtual Task<List<CallAssignment>> ByCallId(int callId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.CallId == callId, limit, offset);
		}

		// Non-unique constraint IX_CallAssignment_unitId.
		public async virtual Task<List<CallAssignment>> ByUnitId(int unitId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.UnitId == unitId, limit, offset);
		}

		// Foreign key reference to table Call via callId.
		public async virtual Task<Call> CallByCallId(int callId)
		{
			return await this.Context.Set<Call>()
			       .SingleOrDefaultAsync(x => x.Id == callId);
		}

		// Foreign key reference to table Unit via unitId.
		public async virtual Task<Unit> UnitByUnitId(int unitId)
		{
			return await this.Context.Set<Unit>()
			       .SingleOrDefaultAsync(x => x.Id == unitId);
		}

		protected async Task<List<CallAssignment>> Where(
			Expression<Func<CallAssignment, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<CallAssignment, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<CallAssignment>()
			       .Include(x => x.CallIdNavigation)
			       .Include(x => x.UnitIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<CallAssignment>();
		}

		private async Task<CallAssignment> GetById(int id)
		{
			List<CallAssignment> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>71a51f264da0bc0328852a608def8850</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/