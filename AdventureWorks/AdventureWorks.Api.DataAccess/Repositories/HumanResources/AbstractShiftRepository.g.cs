using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShiftRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractShiftRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOShift>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOShift> Get(int shiftID)
		{
			Shift record = await this.GetById(shiftID);

			return this.Mapper.ShiftMapEFToPOCO(record);
		}

		public async virtual Task<POCOShift> Create(
			ApiShiftModel model)
		{
			Shift record = new Shift();

			this.Mapper.ShiftMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Shift>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ShiftMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int shiftID,
			ApiShiftModel model)
		{
			Shift record = await this.GetById(shiftID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{shiftID}");
			}
			else
			{
				this.Mapper.ShiftMapModelToEF(
					shiftID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
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

		public async Task<POCOShift> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<POCOShift> GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			var records = await this.SearchLinqPOCO(x => x.StartTime == startTime && x.EndTime == endTime);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOShift>> Where(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShift> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOShift>> SearchLinqPOCO(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShift> response = new List<POCOShift>();
			List<Shift> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ShiftMapEFToPOCO(x)));
			return response;
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
    <Hash>164d25db3eb764b49d0e6d690bb0c402</Hash>
</Codenesium>*/