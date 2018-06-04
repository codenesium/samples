using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShiftRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractShiftRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Shift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
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

		public async Task<Shift> GetName(string name)
		{
			var records = await this.SearchLinqEF(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<Shift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			var records = await this.SearchLinqEF(x => x.StartTime == startTime && x.EndTime == endTime);

			return records.FirstOrDefault();
		}

		protected async Task<List<Shift>> Where(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<Shift> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<Shift>> SearchLinqEF(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Shift.ShiftID)} ASC";
			}
			return await this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Shift>();
		}

		private async Task<List<Shift>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Shift.ShiftID)} ASC";
			}

			return await this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Shift>();
		}

		private async Task<Shift> GetById(int shiftID)
		{
			List<Shift> records = await this.SearchLinqEF(x => x.ShiftID == shiftID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1b8d79379eb5c75e6a352133f1ddea05</Hash>
</Codenesium>*/