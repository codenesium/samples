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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractLocationRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFLocation>().Add(record);
			this.context.SaveChanges();
			return record.LocationID;
		}

		public virtual void Update(short locationID, string name,
		                           decimal costRate,
		                           decimal availability,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",locationID);
			}
			else
			{
				MapPOCOToEF(locationID,  name,
				            costRate,
				            availability,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(short locationID)
		{
			var record = this.SearchLinqEF(x => x.LocationID == locationID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFLocation>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(short locationID, Response response)
		{
			this.SearchLinqPOCO(x => x.LocationID == locationID,response);
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

		public virtual List<POCOLocation> GetWhereDirect(Expression<Func<EFLocation, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Locations;
		}
		public virtual POCOLocation GetByIdDirect(short locationID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.LocationID == locationID,response);
			return response.Locations.FirstOrDefault();
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
			efLocation.LocationID = locationID;
			efLocation.Name = name;
			efLocation.CostRate = costRate;
			efLocation.Availability = availability;
			efLocation.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFLocation efLocation,Response response)
		{
			if(efLocation == null)
			{
				return;
			}
			response.AddLocation(new POCOLocation()
			{
				LocationID = efLocation.LocationID,
				Name = efLocation.Name,
				CostRate = efLocation.CostRate,
				Availability = efLocation.Availability.ToDecimal(),
				ModifiedDate = efLocation.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>fd30a8961a2eddcb5772926b63c52eb9</Hash>
</Codenesium>*/