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

		public virtual int Create(
			ShiftModel model)
		{
			EFShift record = new EFShift();

			this.Mapper.ShiftMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFShift>().Add(record);
			this.Context.SaveChanges();
			return record.ShiftID;
		}

		public virtual void Update(
			int shiftID,
			ShiftModel model)
		{
			EFShift record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();
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
			EFShift record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFShift>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOShift Get(int shiftID)
		{
			return this.SearchLinqPOCO(x => x.ShiftID == shiftID).FirstOrDefault();
		}

		public virtual List<POCOShift> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOShift> Where(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOShift> SearchLinqPOCO(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOShift> response = new List<POCOShift>();
			List<EFShift> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ShiftMapEFToPOCO(x)));
			return response;
		}

		private List<EFShift> SearchLinqEF(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy("ShiftID ASC").Skip(skip).Take(take).ToList<EFShift>();
			}
			else
			{
				return this.Context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShift>();
			}
		}

		private List<EFShift> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy("ShiftID ASC").Skip(skip).Take(take).ToList<EFShift>();
			}
			else
			{
				return this.Context.Set<EFShift>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFShift>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>d6d97216d31da731101c1fb8b465c30b</Hash>
</Codenesium>*/