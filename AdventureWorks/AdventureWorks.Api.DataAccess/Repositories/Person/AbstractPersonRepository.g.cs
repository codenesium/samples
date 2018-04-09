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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPersonRepository(ILogger logger,
		                                ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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

			this.context.Set<EFPerson>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
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
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
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
				this.context.Set<EFPerson>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response;
		}

		public virtual POCOPerson GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.People.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
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

		public virtual List<POCOPerson> GetWhereDirect(Expression<Func<EFPerson, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.People;
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

		protected virtual List<EFPerson> SearchLinqEF(Expression<Func<EFPerson, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPerson> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
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
			efPerson.BusinessEntityID = businessEntityID;
			efPerson.PersonType = personType;
			efPerson.NameStyle = nameStyle;
			efPerson.Title = title;
			efPerson.FirstName = firstName;
			efPerson.MiddleName = middleName;
			efPerson.LastName = lastName;
			efPerson.Suffix = suffix;
			efPerson.EmailPromotion = emailPromotion;
			efPerson.AdditionalContactInfo = additionalContactInfo;
			efPerson.Demographics = demographics;
			efPerson.Rowguid = rowguid;
			efPerson.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPerson efPerson,Response response)
		{
			if(efPerson == null)
			{
				return;
			}
			response.AddPerson(new POCOPerson()
			{
				PersonType = efPerson.PersonType,
				NameStyle = efPerson.NameStyle,
				Title = efPerson.Title,
				FirstName = efPerson.FirstName,
				MiddleName = efPerson.MiddleName,
				LastName = efPerson.LastName,
				Suffix = efPerson.Suffix,
				EmailPromotion = efPerson.EmailPromotion.ToInt(),
				AdditionalContactInfo = efPerson.AdditionalContactInfo,
				Demographics = efPerson.Demographics,
				Rowguid = efPerson.Rowguid,
				ModifiedDate = efPerson.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efPerson.BusinessEntityID,
				                                            "BusinessEntities"),
			});

			BusinessEntityRepository.MapEFToPOCO(efPerson.BusinessEntity, response);
		}
	}
}

/*<Codenesium>
    <Hash>d4ceeaa51a6bd69c0a1e27fdf07c4ae7</Hash>
</Codenesium>*/