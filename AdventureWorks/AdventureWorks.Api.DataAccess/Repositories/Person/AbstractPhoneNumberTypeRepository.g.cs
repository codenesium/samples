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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPhoneNumberTypeRepository(ILogger logger,
		                                         ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(string name,
		                          DateTime modifiedDate)
		{
			var record = new EFPhoneNumberType ();

			MapPOCOToEF(0, name,
			            modifiedDate, record);

			this.context.Set<EFPhoneNumberType>().Add(record);
			this.context.SaveChanges();
			return record.PhoneNumberTypeID;
		}

		public virtual void Update(int phoneNumberTypeID, string name,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.PhoneNumberTypeID == phoneNumberTypeID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",phoneNumberTypeID);
			}
			else
			{
				MapPOCOToEF(phoneNumberTypeID,  name,
				            modifiedDate, record);
				this.context.SaveChanges();
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
				this.context.Set<EFPhoneNumberType>().Remove(record);
				this.context.SaveChanges();
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

		public virtual List<POCOPhoneNumberType> GetWhereDirect(Expression<Func<EFPhoneNumberType, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PhoneNumberTypes;
		}
		public virtual POCOPhoneNumberType GetByIdDirect(int phoneNumberTypeID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.PhoneNumberTypeID == phoneNumberTypeID,response);
			return response.PhoneNumberTypes.FirstOrDefault();
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
    <Hash>3a1a585deec4a5ed8750dc7d3fb6c5e7</Hash>
</Codenesium>*/