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
	public abstract class AbstractCallRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractCallRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Call>> All(int limit = int.MaxValue, int offset = 0, string query = "")
		{
			if (string.IsNullOrWhiteSpace(query))
			{
				return this.Where(x => true, limit, offset);
			}
			else
			{
				return this.Where(x =>
				                  x.AddressId == query.ToNullableInt() ||
				                  x.CallDispositionId == query.ToNullableInt() ||
				                  x.CallStatusId == query.ToNullableInt() ||
				                  x.CallString.StartsWith(query) ||
				                  x.CallTypeId == query.ToNullableInt() ||
				                  x.DateCleared == query.ToNullableDateTime() ||
				                  x.DateCreated == query.ToDateTime() ||
				                  x.DateDispatched == query.ToNullableDateTime() ||
				                  x.Id == query.ToInt() ||
				                  x.QuickCallNumber == query.ToInt(),
				                  limit,
				                  offset);
			}
		}

		public async virtual Task<Call> Get(int id)
		{
			return await this.GetById(id);
		}

		public async virtual Task<Call> Create(Call item)
		{
			this.Context.Set<Call>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Call item)
		{
			var entity = this.Context.Set<Call>().Local.FirstOrDefault(x => x.Id == item.Id);
			if (entity == null)
			{
				this.Context.Set<Call>().Attach(item);
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
			Call record = await this.GetById(id);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Call>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		// Foreign key reference to this table Note via callId.
		public async virtual Task<List<Note>> NotesByCallId(int callId, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Context.Set<Note>()
			       .Include(x => x.CallIdNavigation)
			       .Include(x => x.OfficerIdNavigation)

			       .Where(x => x.CallId == callId).AsQueryable().Skip(offset).Take(limit).ToListAsync<Note>();
		}

		// Foreign key reference to table Address via addressId.
		public async virtual Task<Address> AddressByAddressId(int? addressId)
		{
			return await this.Context.Set<Address>()
			       .SingleOrDefaultAsync(x => x.Id == addressId);
		}

		// Foreign key reference to table CallDisposition via callDispositionId.
		public async virtual Task<CallDisposition> CallDispositionByCallDispositionId(int? callDispositionId)
		{
			return await this.Context.Set<CallDisposition>()
			       .SingleOrDefaultAsync(x => x.Id == callDispositionId);
		}

		// Foreign key reference to table CallStatu via callStatusId.
		public async virtual Task<CallStatu> CallStatuByCallStatusId(int? callStatusId)
		{
			return await this.Context.Set<CallStatu>()
			       .SingleOrDefaultAsync(x => x.Id == callStatusId);
		}

		// Foreign key reference to table CallType via callTypeId.
		public async virtual Task<CallType> CallTypeByCallTypeId(int? callTypeId)
		{
			return await this.Context.Set<CallType>()
			       .SingleOrDefaultAsync(x => x.Id == callTypeId);
		}

		// Foreign key reference pass-though. Pass-thru table CallAssignment. Foreign Table Call.
		public async virtual Task<List<Call>> ByUnitId(int unitId, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.CallAssignments
			              join calls in this.Context.Calls on
			              refTable.CallId equals calls.Id
			              where refTable.UnitId == unitId
			              select calls).Skip(offset).Take(limit).ToListAsync();
		}

		// Foreign key reference pass-though. Pass-thru table CallAssignment. Foreign Table Call.
		public async virtual Task<CallAssignment> CreateCallAssignment(CallAssignment item)
		{
			this.Context.Set<CallAssignment>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		// Foreign key reference pass-though. Pass-thru table CallAssignment. Foreign Table Call.
		public async virtual Task DeleteCallAssignment(CallAssignment item)
		{
			this.Context.Set<CallAssignment>().Remove(item);
			await this.Context.SaveChangesAsync();
		}

		protected async Task<List<Call>> Where(
			Expression<Func<Call, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Call, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Id;
			}

			return await this.Context.Set<Call>()
			       .Include(x => x.AddressIdNavigation)
			       .Include(x => x.CallDispositionIdNavigation)
			       .Include(x => x.CallStatusIdNavigation)
			       .Include(x => x.CallTypeIdNavigation)

			       .Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Call>();
		}

		private async Task<Call> GetById(int id)
		{
			List<Call> records = await this.Where(x => x.Id == id);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>95a0d2bf9e203c66191caf25ac9612a7</Hash>
</Codenesium>*/