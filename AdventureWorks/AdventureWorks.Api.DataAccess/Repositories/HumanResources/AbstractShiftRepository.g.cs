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

		public AbstractShiftRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			string name,
			TimeSpan startTime,
			TimeSpan endTime,
			DateTime modifiedDate)
		{
			var record = new EFShift();

			MapPOCOToEF(
				0,
				name,
				startTime,
				endTime,
				modifiedDate,
				record);

			this.context.Set<EFShift>().Add(record);
			this.context.SaveChanges();
			return record.ShiftID;
		}

		public virtual void Update(
			int shiftID,
			string name,
			TimeSpan startTime,
			TimeSpan endTime,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{shiftID}");
			}
			else
			{
				MapPOCOToEF(
					shiftID,
					name,
					startTime,
					endTime,
					modifiedDate,
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

		public virtual Response GetById(int shiftID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ShiftID == shiftID, response);
			return response;
		}

		public virtual POCOShift GetByIdDirect(int shiftID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ShiftID == shiftID, response);
			return response.Shifts.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOShift> GetWhereDirect(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Shifts;
		}

		private void SearchLinqPOCO(Expression<Func<EFShift, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShift> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFShift> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFShift> SearchLinqEF(Expression<Func<EFShift, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShift> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int shiftID,
			string name,
			TimeSpan startTime,
			TimeSpan endTime,
			DateTime modifiedDate,
			EFShift efShift)
		{
			efShift.SetProperties(shiftID, name, startTime, endTime, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFShift efShift,
			Response response)
		{
			if (efShift == null)
			{
				return;
			}

			response.AddShift(new POCOShift(efShift.ShiftID, efShift.Name, efShift.StartTime, efShift.EndTime, efShift.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>61fa86c6f844a52454472b4cd5586751</Hash>
</Codenesium>*/