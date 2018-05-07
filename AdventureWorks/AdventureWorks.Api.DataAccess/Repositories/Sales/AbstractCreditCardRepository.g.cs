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

		public virtual int Create(
			CreditCardModel model)
		{
			EFCreditCard record = new EFCreditCard();

			this.Mapper.CreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFCreditCard>().Add(record);
			this.Context.SaveChanges();
			return record.CreditCardID;
		}

		public virtual void Update(
			int creditCardID,
			CreditCardModel model)
		{
			EFCreditCard record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();
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
			EFCreditCard record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFCreditCard>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCOCreditCard Get(int creditCardID)
		{
			return this.SearchLinqPOCO(x => x.CreditCardID == creditCardID).FirstOrDefault();
		}

		public virtual List<POCOCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCOCreditCard> Where(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOCreditCard> SearchLinqPOCO(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCreditCard> response = new List<POCOCreditCard>();
			List<EFCreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.CreditCardMapEFToPOCO(x)));
			return response;
		}

		private List<EFCreditCard> SearchLinqEF(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy("CreditCardID ASC").Skip(skip).Take(take).ToList<EFCreditCard>();
			}
			else
			{
				return this.Context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCreditCard>();
			}
		}

		private List<EFCreditCard> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy("CreditCardID ASC").Skip(skip).Take(take).ToList<EFCreditCard>();
			}
			else
			{
				return this.Context.Set<EFCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFCreditCard>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>c483dabaf91cec3dcefd36e3c7c89b43</Hash>
</Codenesium>*/