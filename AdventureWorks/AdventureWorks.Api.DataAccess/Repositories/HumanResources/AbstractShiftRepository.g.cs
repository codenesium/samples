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

		public virtual ApiResponse GetById(int shiftID)
		{
			return this.SearchLinqPOCO(x => x.ShiftID == shiftID);
		}

		public virtual POCOShift GetByIdDirect(int shiftID)
		{
			return this.SearchLinqPOCO(x => x.ShiftID == shiftID).Shifts.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Shifts;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFShift> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ShiftMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFShift> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ShiftMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFShift> SearchLinqEF(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShift> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>7db3cda5ce13d1a76b53d559ef5c7132</Hash>
</Codenesium>*/