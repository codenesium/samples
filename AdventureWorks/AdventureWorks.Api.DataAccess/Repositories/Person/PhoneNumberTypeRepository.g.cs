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
	public abstract class AbstractPhoneNumberTypeRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractPhoneNumberTypeRepository(ILogger logger,
		                                         ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string name,
		                          DateTime modifiedDate)
		{
			var record = new EFPhoneNumberType ();

			MapPOCOToEF(0, name,
			            modifiedDate, record);

			this._context.Set<EFPhoneNumberType>().Add(record);
			this._context.SaveChanges();
			return record.PhoneNumberTypeID;
		}

		public virtual void Update(int phoneNumberTypeID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",phoneNumberTypeID);
			}
			else
			{
				MapPOCOToEF(phoneNumberTypeID,  name,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int phoneNumberTypeID)
		{
			var record = this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFPhoneNumberType>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int phoneNumberTypeID, Response response)
		{
			this.SearchLinqPOCO(x => x.PhoneNumberTypeID == phoneNumberTypeID,response);
		}

		protected virtual List<EFPhoneNumberType> SearchLinqEF(Expression<Func<EFPhoneNumberType, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPhoneNumberType> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPhoneNumberType, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFPhoneNumberType, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPhoneNumberType> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPhoneNumberType> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int phoneNumberTypeID, string name,
		                               DateTime modifiedDate, EFPhoneNumberType   efPhoneNumberType)
		{
			efPhoneNumberType.PhoneNumberTypeID = phoneNumberTypeID;
			efPhoneNumberType.Name = name;
			efPhoneNumberType.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPhoneNumberType efPhoneNumberType,Response response)
		{
			if(efPhoneNumberType == null)
			{
				return;
			}
			response.AddPhoneNumberType(new POCOPhoneNumberType()
			{
				PhoneNumberTypeID = efPhoneNumberType.PhoneNumberTypeID.ToInt(),
				Name = efPhoneNumberType.Name,
				ModifiedDate = efPhoneNumberType.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>53eee94f5b9f0a408f2e3a1529992b2c</Hash>
</Codenesium>*/