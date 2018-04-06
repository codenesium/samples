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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractShiftRepository(ILogger logger,
		                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          TimeSpan startTime,
		                          TimeSpan endTime,
		                          DateTime modifiedDate)
		{
			var record = new EFShift ();

			MapPOCOToEF(0, name,
			            startTime,
			            endTime,
			            modifiedDate, record);

			this._context.Set<EFShift>().Add(record);
			this._context.SaveChanges();
			return record.ShiftID;
		}

		public virtual void Update(int shiftID, string name,
		                           TimeSpan startTime,
		                           TimeSpan endTime,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",shiftID);
			}
			else
			{
				MapPOCOToEF(shiftID,  name,
				            startTime,
				            endTime,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int shiftID)
		{
			var record = this.SearchLinqEF(x => x.ShiftID == shiftID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFShift>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int shiftID, Response response)
		{
			this.SearchLinqPOCO(x => x.ShiftID == shiftID,response);
		}

		protected virtual List<EFShift> SearchLinqEF(Expression<Func<EFShift, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFShift> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFShift, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFShift, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFShift> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFShift> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int shiftID, string name,
		                               TimeSpan startTime,
		                               TimeSpan endTime,
		                               DateTime modifiedDate, EFShift   efShift)
		{
			efShift.ShiftID = shiftID;
			efShift.Name = name;
			efShift.StartTime = startTime;
			efShift.EndTime = endTime;
			efShift.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFShift efShift,Response response)
		{
			if(efShift == null)
			{
				return;
			}
			response.AddShift(new POCOShift()
			{
				ShiftID = efShift.ShiftID,
				Name = efShift.Name,
				StartTime = efShift.StartTime,
				EndTime = efShift.EndTime,
				ModifiedDate = efShift.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>0702d90e5c55d9442f7a34341d9aba07</Hash>
</Codenesium>*/