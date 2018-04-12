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

		public AbstractPersonCreditCardRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			int creditCardID,
			DateTime modifiedDate)
		{
			var record = new EFPersonCreditCard();

			MapPOCOToEF(
				0,
				creditCardID,
				modifiedDate,
				record);

			this.context.Set<EFPersonCreditCard>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				MapPOCOToEF(
					businessEntityID,
					creditCardID,
					modifiedDate,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
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

		public virtual Response GetById(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOPersonCreditCard GetByIdDirect(int businessEntityID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.PersonCreditCards.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PersonCreditCards;
		}

		private void SearchLinqPOCO(Expression<Func<EFPersonCreditCard, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPersonCreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPersonCreditCard> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFPersonCreditCard> SearchLinqEF(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPersonCreditCard> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			int businessEntityID,
			int creditCardID,
			DateTime modifiedDate,
			EFPersonCreditCard efPersonCreditCard)
		{
			efPersonCreditCard.SetProperties(businessEntityID.ToInt(), creditCardID.ToInt(), modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFPersonCreditCard efPersonCreditCard,
			Response response)
		{
			if (efPersonCreditCard == null)
			{
				return;
			}

			response.AddPersonCreditCard(new POCOPersonCreditCard(efPersonCreditCard.BusinessEntityID.ToInt(), efPersonCreditCard.CreditCardID.ToInt(), efPersonCreditCard.ModifiedDate.ToDateTime()));

			PersonRepository.MapEFToPOCO(efPersonCreditCard.Person, response);

			CreditCardRepository.MapEFToPOCO(efPersonCreditCard.CreditCard, response);
		}
	}
}

/*<Codenesium>
    <Hash>180f5d4be6b6262cac7409354edbf379</Hash>
</Codenesium>*/