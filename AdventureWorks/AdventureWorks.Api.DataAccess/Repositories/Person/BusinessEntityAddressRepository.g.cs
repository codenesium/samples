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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractBusinessEntityAddressRepository(ILogger logger,
		                                               ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
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

			this._context.Set<EFBusinessEntityAddress>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, int addressID,
		                           int addressTypeID,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  addressID,
				            addressTypeID,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int businessEntityID)
		{
			var record = this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFBusinessEntityAddress>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFBusinessEntityAddress> SearchLinqEF(Expression<Func<EFBusinessEntityAddress, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFBusinessEntityAddress> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFBusinessEntityAddress, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
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

		public static void MapPOCOToEF(int businessEntityID, int addressID,
		                               int addressTypeID,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFBusinessEntityAddress   efBusinessEntityAddress)
		{
			efBusinessEntityAddress.businessEntityID = businessEntityID;
			efBusinessEntityAddress.addressID = addressID;
			efBusinessEntityAddress.addressTypeID = addressTypeID;
			efBusinessEntityAddress.rowguid = rowguid;
			efBusinessEntityAddress.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFBusinessEntityAddress efBusinessEntityAddress,Response response)
		{
			if(efBusinessEntityAddress == null)
			{
				return;
			}
			response.AddBusinessEntityAddress(new POCOBusinessEntityAddress()
			{
				BusinessEntityID = efBusinessEntityAddress.businessEntityID.ToInt(),
				AddressID = efBusinessEntityAddress.addressID.ToInt(),
				AddressTypeID = efBusinessEntityAddress.addressTypeID.ToInt(),
				Rowguid = efBusinessEntityAddress.rowguid,
				ModifiedDate = efBusinessEntityAddress.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>46750785d02f3ef63ab8de15d709ee79</Hash>
</Codenesium>*/