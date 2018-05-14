using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractShiftRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractShiftRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOShift Get(int shiftID)
		{
			return this.SearchLinqPOCO(x => x.ShiftID == shiftID).FirstOrDefault();
		}

		public virtual POCOShift Create(
			ApiShiftModel model)
		{
			Shift record = new Shift();

			this.Mapper.ShiftMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Shift>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ShiftMapEFToPOCO(record);
		}

		public virtual void Update(
			int shiftID,
			ApiShiftModel model)
		{
			Shift record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int shiftID)
		{
			Shift record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Shift>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOShift GetName(string name)
		{
			return this.SearchLinqPOCO(x => x.Name == name).FirstOrDefault();
		}

		public POCOShift GetStartTimeEndTime(TimeSpan startTime,TimeSpan endTime)
		{
			return this.SearchLinqPOCO(x => x.StartTime == startTime && x.EndTime == endTime).FirstOrDefault();
		}

		protected List<POCOShift> Where(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOShift> SearchLinqPOCO(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShift> response = new List<POCOShift>();
			List<Shift> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ShiftMapEFToPOCO(x)));
			return response;
		}

		private List<Shift> SearchLinqEF(Expression<Func<Shift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Shift.ShiftID)} ASC";
			}
			return this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Shift>();
		}

		private List<Shift> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Shift.ShiftID)} ASC";
			}

			return this.Context.Set<Shift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Shift>();
		}
	}
}

/*<Codenesium>
    <Hash>e942f608d3251774c247c6660628ed7a</Hash>
</Codenesium>*/