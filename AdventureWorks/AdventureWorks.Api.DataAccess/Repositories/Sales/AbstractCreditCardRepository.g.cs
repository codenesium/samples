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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractCreditCardRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			CreditCardModel model)
		{
			var record = new EFCreditCard();

			this.mapper.CreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFCreditCard>().Add(record);
			this.context.SaveChanges();
			return record.CreditCardID;
		}

		public virtual void Update(
			int creditCardID,
			CreditCardModel model)
		{
			var record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{creditCardID}");
			}
			else
			{
				this.mapper.CreditCardMapModelToEF(
					creditCardID,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			int creditCardID)
		{
			var record = this.SearchLinqEF(x => x.CreditCardID == creditCardID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFCreditCard>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int creditCardID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CreditCardID == creditCardID, response);
			return response;
		}

		public virtual POCOCreditCard GetByIdDirect(int creditCardID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.CreditCardID == creditCardID, response);
			return response.CreditCards.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCOCreditCard> GetWhereDirect(Expression<Func<EFCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.CreditCards;
		}

		private void SearchLinqPOCO(Expression<Func<EFCreditCard, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CreditCardMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFCreditCard> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.CreditCardMapEFToPOCO(x, response));
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
    <Hash>c5d4c945ce6db835d33dbe0eab998db3</Hash>
</Codenesium>*/