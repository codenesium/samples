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
	public abstract class AbstractAddressTypeRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractAddressTypeRepository(ILogger logger,
		                                     ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFAddressType ();

			MapPOCOToEF(0, name,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFAddressType>().Add(record);
			this.context.SaveChanges();
			return record.AddressTypeID;
		}

		public virtual void Update(int addressTypeID, string name,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",addressTypeID);
			}
			else
			{
				MapPOCOToEF(addressTypeID,  name,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int addressTypeID)
		{
			var record = this.SearchLinqEF(x => x.AddressTypeID == addressTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFAddressType>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int addressTypeID, Response response)
		{
			this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID,response);
		}

		protected virtual List<EFAddressType> SearchLinqEF(Expression<Func<EFAddressType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAddressType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFAddressType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.AddressTypes;
		}
		public virtual POCOAddressType GetByIdDirect(int addressTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID,response);
			return response.AddressTypes.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFAddressType, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFAddressType> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFAddressType> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int addressTypeID, string name,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFAddressType   efAddressType)
		{
			efAddressType.AddressTypeID = addressTypeID;
			efAddressType.Name = name;
			efAddressType.Rowguid = rowguid;
			efAddressType.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFAddressType efAddressType,Response response)
		{
			if(efAddressType == null)
			{
				return;
			}
			response.AddAddressType(new POCOAddressType()
			{
				AddressTypeID = efAddressType.AddressTypeID.ToInt(),
				Name = efAddressType.Name,
				Rowguid = efAddressType.Rowguid,
				ModifiedDate = efAddressType.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>a4f663bcd15ce60a43164b7bdc709c95</Hash>
</Codenesium>*/