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

		public virtual ApiResponse GetById(int creditCardID)
		{
			return this.SearchLinqPOCO(x => x.CreditCardID == creditCardID);
		}

		public virtual POCOCreditCard GetByIdDirect(int creditCardID)
		{
			return this.SearchLinqPOCO(x => x.CreditCardID == creditCardID).CreditCards.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOCreditCard> GetWhereDirect(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).CreditCards;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CreditCardMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFCreditCard> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.CreditCardMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFCreditCard> SearchLinqEF(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFCreditCard> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>ec609f0331717020b2333a7b540784b1</Hash>
</Codenesium>*/