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
	public abstract class AbstractPersonRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractPersonRepository(ILogger logger,
		                                ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string personType,
		                          bool nameStyle,
		                          string title,
		                          string firstName,
		                          string middleName,
		                          string lastName,
		                          string suffix,
		                          int emailPromotion,
		                          string additionalContactInfo,
		                          string demographics,
		                          Guid rowguid,
		                          DateTime modifiedDate)
		{
			var record = new EFPerson ();

			MapPOCOToEF(0, personType,
			            nameStyle,
			            title,
			            firstName,
			            middleName,
			            lastName,
			            suffix,
			            emailPromotion,
			            additionalContactInfo,
			            demographics,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFPerson>().Add(record);
			this._context.SaveChanges();
			return record.businessEntityID;
		}

		public virtual void Update(int businessEntityID, string personType,
		                           bool nameStyle,
		                           string title,
		                           string firstName,
		                           string middleName,
		                           string lastName,
		                           string suffix,
		                           int emailPromotion,
		                           string additionalContactInfo,
		                           string demographics,
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
				MapPOCOToEF(businessEntityID,  personType,
				            nameStyle,
				            title,
				            firstName,
				            middleName,
				            lastName,
				            suffix,
				            emailPromotion,
				            additionalContactInfo,
				            demographics,
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
				this._context.Set<EFPerson>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.businessEntityID == businessEntityID,response);
		}

		protected virtual List<EFPerson> SearchLinqEF(Expression<Func<EFPerson, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPerson> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPerson, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFPerson, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPerson> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPerson> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, string personType,
		                               bool nameStyle,
		                               string title,
		                               string firstName,
		                               string middleName,
		                               string lastName,
		                               string suffix,
		                               int emailPromotion,
		                               string additionalContactInfo,
		                               string demographics,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFPerson   efPerson)
		{
			efPerson.businessEntityID = businessEntityID;
			efPerson.personType = personType;
			efPerson.nameStyle = nameStyle;
			efPerson.title = title;
			efPerson.firstName = firstName;
			efPerson.middleName = middleName;
			efPerson.lastName = lastName;
			efPerson.suffix = suffix;
			efPerson.emailPromotion = emailPromotion;
			efPerson.additionalContactInfo = additionalContactInfo;
			efPerson.demographics = demographics;
			efPerson.rowguid = rowguid;
			efPerson.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPerson efPerson,Response response)
		{
			if(efPerson == null)
			{
				return;
			}
			response.AddPerson(new POCOPerson()
			{
				BusinessEntityID = efPerson.businessEntityID.ToInt(),
				PersonType = efPerson.personType,
				NameStyle = efPerson.nameStyle,
				Title = efPerson.title,
				FirstName = efPerson.firstName,
				MiddleName = efPerson.middleName,
				LastName = efPerson.lastName,
				Suffix = efPerson.suffix,
				EmailPromotion = efPerson.emailPromotion.ToInt(),
				AdditionalContactInfo = efPerson.additionalContactInfo,
				Demographics = efPerson.demographics,
				Rowguid = efPerson.rowguid,
				ModifiedDate = efPerson.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>9d5019173cec89a633bc19c64bfc7d12</Hash>
</Codenesium>*/