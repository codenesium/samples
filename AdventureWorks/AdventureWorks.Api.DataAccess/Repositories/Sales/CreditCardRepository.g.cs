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
	public abstract class AbstractCreditCardRepository
	{
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractCreditCardRepository(ILogger logger,
		                                    ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(string cardType,
		                          string cardNumber,
		                          int expMonth,
		                          short expYear,
		                          DateTime modifiedDate)
		{
			var record = new EFCreditCard ();

			MapPOCOToEF(0, cardType,
			            cardNumber,
			            expMonth,
			            expYear,
			            modifiedDate, record);

			this._context.Set<EFCreditCard>().Add(record);
			this._context.SaveChanges();
			return record.CreditCardID;
		}

		public virtual void Update(int creditCardID, string cardType,
		                           string cardNumber,
		                           int expMonth,
		                           short expYear,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",creditCardID);
			}
			else
			{
				MapPOCOToEF(creditCardID,  cardType,
				            cardNumber,
				            expMonth,
				            expYear,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int creditCardID)
		{
			var record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFCreditCard>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int creditCardID, Response response)
		{
			this.SearchLinqPOCO(x => x.CreditCardID == creditCardID,response);
		}

		protected virtual List<EFCreditCard> SearchLinqEF(Expression<Func<EFCreditCard, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCreditCard> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFCreditCard, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFCreditCard, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCreditCard> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFCreditCard> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int creditCardID, string cardType,
		                               string cardNumber,
		                               int expMonth,
		                               short expYear,
		                               DateTime modifiedDate, EFCreditCard   efCreditCard)
		{
			efCreditCard.CreditCardID = creditCardID;
			efCreditCard.CardType = cardType;
			efCreditCard.CardNumber = cardNumber;
			efCreditCard.ExpMonth = expMonth;
			efCreditCard.ExpYear = expYear;
			efCreditCard.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFCreditCard efCreditCard,Response response)
		{
			if(efCreditCard == null)
			{
				return;
			}
			response.AddCreditCard(new POCOCreditCard()
			{
				CreditCardID = efCreditCard.CreditCardID.ToInt(),
				CardType = efCreditCard.CardType,
				CardNumber = efCreditCard.CardNumber,
				ExpMonth = efCreditCard.ExpMonth,
				ExpYear = efCreditCard.ExpYear,
				ModifiedDate = efCreditCard.ModifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>3b1f21c88d94ce018fc934074e57ed9d</Hash>
</Codenesium>*/