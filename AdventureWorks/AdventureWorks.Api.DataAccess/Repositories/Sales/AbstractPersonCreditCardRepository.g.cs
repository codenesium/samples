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
	public abstract class AbstractPersonCreditCardRepository
	{
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractPersonCreditCardRepository(ILogger logger,
		                                          ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(int creditCardID,
		                          DateTime modifiedDate)
		{
			var record = new EFPersonCreditCard ();

			MapPOCOToEF(0, creditCardID,
			            modifiedDate, record);

			this.context.Set<EFPersonCreditCard>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(int businessEntityID, int creditCardID,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",businessEntityID);
			}
			else
			{
				MapPOCOToEF(businessEntityID,  creditCardID,
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
				this.context.Set<EFPersonCreditCard>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int businessEntityID, Response response)
		{
			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
		}

		protected virtual List<EFPersonCreditCard> SearchLinqEF(Expression<Func<EFPersonCreditCard, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPersonCreditCard> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PersonCreditCards;
		}
		public virtual POCOPersonCreditCard GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID,response);
			return response.PersonCreditCards.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFPersonCreditCard, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPersonCreditCard> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFPersonCreditCard> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int businessEntityID, int creditCardID,
		                               DateTime modifiedDate, EFPersonCreditCard   efPersonCreditCard)
		{
			efPersonCreditCard.BusinessEntityID = businessEntityID;
			efPersonCreditCard.CreditCardID = creditCardID;
			efPersonCreditCard.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFPersonCreditCard efPersonCreditCard,Response response)
		{
			if(efPersonCreditCard == null)
			{
				return;
			}
			response.AddPersonCreditCard(new POCOPersonCreditCard()
			{
				ModifiedDate = efPersonCreditCard.ModifiedDate.ToDateTime(),

				BusinessEntityID = new ReferenceEntity<int>(efPersonCreditCard.BusinessEntityID,
				                                            "People"),
				CreditCardID = new ReferenceEntity<int>(efPersonCreditCard.CreditCardID,
				                                        "CreditCards"),
			});

			PersonRepository.MapEFToPOCO(efPersonCreditCard.Person, response);

			CreditCardRepository.MapEFToPOCO(efPersonCreditCard.CreditCard, response);
		}
	}
}

/*<Codenesium>
    <Hash>2bd0bfa584b379a35f8c6094fa5083d4</Hash>
</Codenesium>*/