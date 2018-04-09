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
	public abstract class AbstractBusinessEntityAddressRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractBusinessEntityAddressRepository(ILogger logger,
		                                               ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int addressID,
		                          int addressTypeID,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFBusinessEntityAddress ();

			MapPOCOToEF(0, addressID,
			            addressTypeID,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFBusinessEntityAddress>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, int addressID,
		                           int addressTypeID,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  addressID,
				            addressTypeID,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFBusinessEntityAddress>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOBusinessEntityAddress GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.BusinessEntityAddresses.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOBusinessEntityAddress> GetWhereDirect(Expression<Func<EFBusinessEntityAddress, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.BusinessEntityAddresses;
		}

		private void SearchLinqPOCO(Expression<Func<EFBusinessEntityAddress, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBusinessEntityAddress> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFBusinessEntityAddress> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		protected virtual List<EFBusinessEntityAddress> SearchLinqEF(Expression<Func<EFBusinessEntityAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBusinessEntityAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int businessEntityID, int addressID,
		                               int addressTypeID,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFBusinessEntityAddress   efBusinessEntityAddress)
		{
			efBusinessEntityAddress.BusinessEntityID = businessEntityID;
			efBusinessEntityAddress.AddressID = addressID;
			efBusinessEntityAddress.AddressTypeID = addressTypeID;
			efBusinessEntityAddress.Rowguid = rowguid;
			efBusinessEntityAddress.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFBusinessEntityAddress efBusinessEntityAddress,Response response)
		{
			if(efBusinessEntityAddress == null)
			{
				return;
			}
			response.AddBusinessEntityAddress(new POCOBusinessEntityAddress()
			{
				Rowguid = efBusinessEntityAddress.Rowguid,
				ModifiedDate = efBusinessEntityAddress.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efBusinessEntityAddress.BusinessEntityID,
				                                            "BusinessEntities"),
				AddressID = new ReferenceEntity<int>(efBusinessEntityAddress.AddressID,
				                                     "Addresses"),
				AddressTypeID = new ReferenceEntity<int>(efBusinessEntityAddress.AddressTypeID,
				                                         "AddressTypes"),
			});

			BusinessEntityRepository.MapEFToPOCO(efBusinessEntityAddress.BusinessEntity, response);

			AddressRepository.MapEFToPOCO(efBusinessEntityAddress.Address, response);

			AddressTypeRepository.MapEFToPOCO(efBusinessEntityAddress.AddressType, response);
		}
	}
}

/*<Codenesium>
    <Hash>3433be40437074dbcb75323d9b24a665</Hash>
</Codenesium>*/