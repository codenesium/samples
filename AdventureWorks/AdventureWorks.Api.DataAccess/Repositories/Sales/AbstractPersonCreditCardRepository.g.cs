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
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPersonCreditCardRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCOPersonCreditCard> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOPersonCreditCard Get(int businessEntityID)
		{
			return this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
		}

		public virtual POCOPersonCreditCard Create(
			ApiPersonCreditCardModel model)
		{
			PersonCreditCard record = new PersonCreditCard();

			this.Mapper.PersonCreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PersonCreditCard>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.PersonCreditCardMapEFToPOCO(record);
		}

		public virtual void Update(
			int businessEntityID,
			ApiPersonCreditCardModel model)
		{
			PersonCreditCard record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.PersonCreditCardMapModelToEF(
					businessEntityID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int businessEntityID)
		{
			PersonCreditCard record = this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonCreditCard>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOPersonCreditCard> Where(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOPersonCreditCard> SearchLinqPOCO(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPersonCreditCard> response = new List<POCOPersonCreditCard>();
			List<PersonCreditCard> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.PersonCreditCardMapEFToPOCO(x)));
			return response;
		}

		private List<PersonCreditCard> SearchLinqEF(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonCreditCard.BusinessEntityID)} ASC";
			}
			return this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PersonCreditCard>();
		}

		private List<PersonCreditCard> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonCreditCard.BusinessEntityID)} ASC";
			}

			return this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<PersonCreditCard>();
		}
	}
}

/*<Codenesium>
    <Hash>6b7561d1589764e37d5dd764027ace1b</Hash>
</Codenesium>*/