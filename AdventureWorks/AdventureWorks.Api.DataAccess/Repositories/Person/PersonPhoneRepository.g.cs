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
	public abstract class AbstractPersonPhoneRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractPersonPhoneRepository(ILogger logger,
		                                     ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string phoneNumber,
		                          int phoneNumberTypeID,
		                          DateTime modifiedDate)
		{
			var record = new EFPersonPhone ();

			MapPOCOToEF(0, phoneNumber,
			            phoneNumberTypeID,
			            modifiedDate, record);

			this._context.Set<EFPersonPhone>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, string phoneNumber,
		                           int phoneNumberTypeID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.businessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  phoneNumber,
				            phoneNumberTypeID,
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
				this._context.Set<EFPersonPhone>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFPersonPhone> SearchLinqEF(Expression<Func<EFPersonPhone, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPersonPhone> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPersonPhone, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFPersonPhone, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPersonPhone> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPersonPhone> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, string phoneNumber,
		                               int phoneNumberTypeID,
		                               DateTime modifiedDate, EFPersonPhone   efPersonPhone)
		{
			efPersonPhone.businessEntityID = businessEntityID;
			efPersonPhone.phoneNumber = phoneNumber;
			efPersonPhone.phoneNumberTypeID = phoneNumberTypeID;
			efPersonPhone.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPersonPhone efPersonPhone,Response response)
		{
			if(efPersonPhone == null)
			{
				return;
			}
			response.AddPersonPhone(new POCOPersonPhone()
			{
				BusinessEntityID = efPersonPhone.businessEntityID.ToInt(),
				PhoneNumber = efPersonPhone.phoneNumber,
				PhoneNumberTypeID = efPersonPhone.phoneNumberTypeID.ToInt(),
				ModifiedDate = efPersonPhone.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>27d0579f4b83d06d91d4cdef5eec7cc9</Hash>
</Codenesium>*/