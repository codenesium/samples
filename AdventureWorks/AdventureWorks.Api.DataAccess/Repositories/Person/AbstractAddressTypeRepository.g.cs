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
				this.logger.LogError($"Unable to find id:{addressTypeID}");
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

		public virtual Response GetById(int addressTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID,response);
			return response;
		}

		public virtual POCOAddressType GetByIdDirect(int addressTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.AddressTypeID == addressTypeID,response);
			return response.AddressTypes.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOAddressType> GetWhereDirect(Expression<Func<EFAddressType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.AddressTypes;
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

		protected virtual List<EFAddressType> SearchLinqEF(Expression<Func<EFAddressType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFAddressType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(int addressTypeID, string name,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFAddressType   efAddressType)
		{
			efAddressType.SetProperties(addressTypeID.ToInt(),name,rowguid,modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(EFAddressType efAddressType,Response response)
		{
			if(efAddressType == null)
			{
				return;
			}
			response.AddAddressType(new POCOAddressType(efAddressType.AddressTypeID.ToInt(),efAddressType.Name,efAddressType.Rowguid,efAddressType.ModifiedDate.ToDateTime()));
		}
	}
}

/*<Codenesium>
    <Hash>5b160d11e7b7574ea76a44d310f54b79</Hash>
</Codenesium>*/