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
		protected IObjectMapper mapper;

		public AbstractPersonCreditCardRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(
			PersonCreditCardModel model)
		{
			var record = new EFPersonCreditCard();

			this.mapper.PersonCreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.context.Set<EFPersonCreditCard>().Add(record);
			this.context.SaveChanges();
			return record.BusinessEntityID;
		}

		public virtual void Update(
			int businessEntityID,
			PersonCreditCardModel model)
		{
			var record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.mapper.PersonCreditCardMapModelToEF(
					businessEntityID,
					model,
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

		public virtual ApiResponse GetById(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response;
		}

		public virtual POCOPersonCreditCard GetByIdDirect(int businessEntityID)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID, response);
			return response.PersonCreditCards.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
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

		public virtual List<POCOPersonCreditCard> GetWhereDirect(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.PersonCreditCards;
		}

		private void SearchLinqPOCO(Expression<Func<EFPersonCreditCard, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPersonCreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PersonCreditCardMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFPersonCreditCard> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.PersonCreditCardMapEFToPOCO(x, response));
		}

		protected virtual List<EFPersonCreditCard> SearchLinqEF(Expression<Func<EFPersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFPersonCreditCard> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>53dbf818a10be2e7df97639bce4731e0</Hash>
</Codenesium>*/