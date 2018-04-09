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
				this.logger.LogError($"Unable to find id:{addressID}");
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

		public virtual Response GetById(int addressID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.AddressID == addressID,response);
			return response;
		}

		public virtual POCOAddress GetByIdDirect(int addressID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.AddressID == addressID,response);
			return response.Addresses.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOAddress> GetWhereDirect(Expression<Func<EFAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Addresses;
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

		protected virtual List<EFAddress> SearchLinqEF(Expression<Func<EFAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efAddress.SetProperties(addressID.ToInt(),addressLine1,addressLine2,city,stateProvinceID.ToInt(),postalCode,spatialLocation,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFAddress efAddress,Response response)
		{
			if(efAddress == null)
			{
				return;
			}
			response.AddAddress(new POCOAddress(efAddress.AddressID.ToInt(),efAddress.AddressLine1,efAddress.AddressLine2,efAddress.City,efAddress.StateProvinceID.ToInt(),efAddress.PostalCode,efAddress.SpatialLocation,efAddress.Rowguid,efAddress.ModifiedDate.ToDateTime()));

			StateProvinceRepository.MapEFToPOCO(efAddress.StateProvince, response);
		}
	}
}

/*<Codenesium>
    <Hash>45c89e0bfe3be7e670181e6c759fa583</Hash>
</Codenesium>*/