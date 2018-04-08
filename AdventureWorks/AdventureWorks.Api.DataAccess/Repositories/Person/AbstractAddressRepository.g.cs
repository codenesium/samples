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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractAddressRepository(ILogger logger,
		                                 ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFAddress>().Add(record);
			this.context.SaveChanges();
			return record.AddressID;
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
			var record =  this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",addressID);
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
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int addressID)
		{
			var record = this.SearchLinqEF(x => x.AddressID == addressID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFAddress>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int addressID, Response response)
		{
			this.SearchLinqPOCO(x => x.AddressID == addressID,response);
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

		public virtual List<POCOAddress > GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Addresses;
		}
		public virtual POCOAddress GetByIdDirect(int addressID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.AddressID == addressID,response);
			return response.Addresses.FirstOrDefault();
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
			efAddress.AddressID = addressID;
			efAddress.AddressLine1 = addressLine1;
			efAddress.AddressLine2 = addressLine2;
			efAddress.City = city;
			efAddress.StateProvinceID = stateProvinceID;
			efAddress.PostalCode = postalCode;
			efAddress.SpatialLocation = spatialLocation;
			efAddress.Rowguid = rowguid;
			efAddress.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFAddress efAddress,Response response)
		{
			if(efAddress == null)
			{
				return;
			}
			response.AddAddress(new POCOAddress()
			{
				AddressID = efAddress.AddressID.ToInt(),
				AddressLine1 = efAddress.AddressLine1,
				AddressLine2 = efAddress.AddressLine2,
				City = efAddress.City,
				PostalCode = efAddress.PostalCode,
				SpatialLocation = efAddress.SpatialLocation,
				Rowguid = efAddress.Rowguid,
				ModifiedDate = efAddress.ModifiedDate.ToDateTime(),

				StateProvinceID = new ReferenceEntity<int>(efAddress.StateProvinceID,
				                                           "StateProvinces"),
			});

			StateProvinceRepository.MapEFToPOCO(efAddress.StateProvince, response);
		}
	}
}

/*<Codenesium>
    <Hash>977daa8539bc5ad33109fbee406189b3</Hash>
</Codenesium>*/