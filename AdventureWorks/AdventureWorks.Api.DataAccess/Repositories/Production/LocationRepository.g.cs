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
	public abstract class AbstractLocationRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractLocationRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual short Create(string name,
		                            decimal costRate,
		                            decimal availability,
		                            DateTime modifiedDate)
		{
			var record = new EFLocation ();

			MapPOCOToEF(0, name,
			            costRate,
			            availability,
			            modifiedDate, record);

			this._context.Set<EFLocation>().Add(record);
			this._context.SaveChanges();
			return record.locationID;
		}

		public virtual void Update(short locationID, string name,
		                           decimal costRate,
		                           decimal availability,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.locationID == locationID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",locationID);
			}
			else
			{
				MapPOCOToEF(locationID,  name,
				            costRate,
				            availability,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(short locationID)
		{
			var record = this.SearchLinqEF(x => x.locationID == locationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFLocation>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(short locationID, Response response)
		{
			this.SearchLinqPOCO(x => x.locationID == locationID,response);
		}

		protected virtual List<EFLocation> SearchLinqEF(Expression<Func<EFLocation, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFLocation> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFLocation, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFLocation, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFLocation> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFLocation> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(short locationID, string name,
		                               decimal costRate,
		                               decimal availability,
		                               DateTime modifiedDate, EFLocation   efLocation)
		{
			efLocation.locationID = locationID;
			efLocation.name = name;
			efLocation.costRate = costRate;
			efLocation.availability = availability;
			efLocation.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFLocation efLocation,Response response)
		{
			if(efLocation == null)
			{
				return;
			}
			response.AddLocation(new POCOLocation()
			{
				LocationID = efLocation.locationID,
				Name = efLocation.name,
				CostRate = efLocation.costRate,
				Availability = efLocation.availability.ToDecimal(),
				ModifiedDate = efLocation.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>28eaa5dfaed8fd1bff1a87bcf5dca490</Hash>
</Codenesium>*/