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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCreditCardRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOCreditCard Get(int creditCardID)
		{
			return this.SearchLinqPOCO(x => x.CreditCardID == creditCardID).FirstOrDefault();
		}

		public virtual POCOCreditCard Create(
			ApiCreditCardModel model)
		{
			CreditCard record = new CreditCard();

			this.Mapper.CreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<CreditCard>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.CreditCardMapEFToPOCO(record);
		}

		public virtual void Update(
			int creditCardID,
			ApiCreditCardModel model)
		{
			CreditCard record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{creditCardID}");
			}
			else
			{
				this.Mapper.CreditCardMapModelToEF(
					creditCardID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int creditCardID)
		{
			CreditCard record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CreditCard>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCOCreditCard GetCardNumber(string cardNumber)
		{
			return this.SearchLinqPOCO(x => x.CardNumber == cardNumber).FirstOrDefault();
		}

		protected List<POCOCreditCard> Where(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCreditCard> SearchLinqPOCO(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCreditCard> response = new List<POCOCreditCard>();
			List<CreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CreditCardMapEFToPOCO(x)));
			return response;
		}

		private List<CreditCard> SearchLinqEF(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CreditCard.CreditCardID)} ASC";
			}
			return this.Context.Set<CreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CreditCard>();
		}

		private List<CreditCard> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CreditCard.CreditCardID)} ASC";
			}

			return this.Context.Set<CreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<CreditCard>();
		}
	}
}

/*<Codenesium>
    <Hash>6d6fd1571fe47f8f733868a92fa27de0</Hash>
</Codenesium>*/