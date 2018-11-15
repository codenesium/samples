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

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShiftRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractShiftRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Shift>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Shift> Get(int shiftID)
		{
			return await this.GetById(shiftID);
		}

		public async virtual Task<Shift> Create(Shift item)
		{
			this.Context.Set<Shift>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Shift item)
		{
			var entity = this.Context.Set<Shift>().Local.FirstOrDefault(x => x.ShiftID == item.ShiftID);
			if (entity == null)
			{
				this.Context.Set<Shift>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int shiftID)
		{
			Shift record = await this.GetById(shiftID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Shift>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task<Shift> ByName(string name)
		{
			return await this.Context.Set<Shift>().SingleOrDefaultAsync(x => x.Name == name);
		}

		public async virtual Task<Shift> ByStartTimeEndTime(TimeSpan startTime, TimeSpan endTime)
		{
			return await this.Context.Set<Shift>().SingleOrDefaultAsync(x => x.StartTime == startTime && x.EndTime == endTime);
		}

		protected async Task<List<Shift>> Where(
			Expression<Func<Shift, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Shift, dynamic>> orderBy = null)
		{
			if (orderBy == null)
			{
				orderBy = x => x.ShiftID;
			}

			return await this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Shift>();
		}

		private async Task<Shift> GetById(int shiftID)
		{
			List<Shift> records = await this.Where(x => x.ShiftID == shiftID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0c9f232479683c3942e63e845fd6eba3</Hash>
</Codenesium>*/