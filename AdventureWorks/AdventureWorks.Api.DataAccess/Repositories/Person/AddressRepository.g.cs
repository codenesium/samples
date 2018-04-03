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
	public abstract class AbstractAddressRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractAddressRepository(ILogger logger,
		                                 ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string addressLine1,
		                          string addressLine2,
		                          string city,
		                          int stateProvinceID,
		                          string postalCode,
		                          object spatialLocation,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFAddress ();

			MapPOCOToEF(0, addressLine1,
			            addressLine2,
			            city,
			            stateProvinceID,
			            postalCode,
			            spatialLocation,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFAddress>().Add(record);
			this._context.SaveChanges();
			return record.addressID;
		}

		public virtual void Update(int addressID, string addressLine1,
		                           string addressLine2,
		                           string city,
		                           int stateProvinceID,
		                           string postalCode,
		                           object spatialLocation,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.addressID == addressID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",addressID);
			}
			else
			{
				MapPOCOToEF(addressID,  addressLine1,
				            addressLine2,
				            city,
				            stateProvinceID,
				            postalCode,
				            spatialLocation,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int addressID)
		{
			var record = this.SearchLinqEF(x => x.addressID == addressID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFAddress>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int addressID, Response response)
		{
			this.SearchLinqPOCO(x => x.addressID == addressID,response);
		}

		protected virtual List<EFAddress> SearchLinqEF(Expression<Func<EFAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFAddress, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFAddress> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFAddress> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int addressID, string addressLine1,
		                               string addressLine2,
		                               string city,
		                               int stateProvinceID,
		                               string postalCode,
		                               object spatialLocation,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFAddress   efAddress)
		{
			efAddress.addressID = addressID;
			efAddress.addressLine1 = addressLine1;
			efAddress.addressLine2 = addressLine2;
			efAddress.city = city;
			efAddress.stateProvinceID = stateProvinceID;
			efAddress.postalCode = postalCode;
			efAddress.spatialLocation = spatialLocation;
			efAddress.rowguid = rowguid;
			efAddress.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFAddress efAddress,Response response)
		{
			if(efAddress == null)
			{
				return;
			}
			response.AddAddress(new POCOAddress()
			{
				AddressID = efAddress.addressID.ToInt(),
				AddressLine1 = efAddress.addressLine1,
				AddressLine2 = efAddress.addressLine2,
				City = efAddress.city,
				StateProvinceID = efAddress.stateProvinceID.ToInt(),
				PostalCode = efAddress.postalCode,
				SpatialLocation = efAddress.spatialLocation,
				Rowguid = efAddress.rowguid,
				ModifiedDate = efAddress.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>08e6cbb4a7c8667b1416c9bebcb56789</Hash>
</Codenesium>*/