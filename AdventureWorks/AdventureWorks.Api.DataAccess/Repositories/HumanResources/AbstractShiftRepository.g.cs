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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractShiftRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			ShiftModel model)
		{
			var record = new EFShift();

			this.mapper.ShiftMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFShift>().Add(record);
			this.context.SaveChanges();
			return record.ShiftID;
		}

		public virtual void Update(
			int shiftID,
			ShiftModel model)
		{
			var record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{shiftID}");
			}
			else
			{
				this.mapper.ShiftMapModelToEF(
					shiftID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int shiftID)
		{
			var record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFShift>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int shiftID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ShiftID == shiftID, response);
			return response;
		}

		public virtual POCOShift GetByIdDirect(int shiftID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.ShiftID == shiftID, response);
			return response.Shifts.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Shifts;
		}

		private void SearchLinqPOCO(Expression<Func<EFShift, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShift> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ShiftMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShift> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.ShiftMapEFToPOCO(x, response));
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
    <Hash>ab7286eb85dbeae4d1174ae1b16847e7</Hash>
</Codenesium>*/