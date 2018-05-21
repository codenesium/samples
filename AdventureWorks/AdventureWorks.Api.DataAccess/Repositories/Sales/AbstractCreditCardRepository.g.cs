using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractCreditCardRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractCreditCardRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOCreditCard> Get(int creditCardID)
		{
			CreditCard record = await this.GetById(creditCardID);

			return this.Mapper.CreditCardMapEFToPOCO(record);
		}

		public async virtual Task<POCOCreditCard> Create(
			ApiCreditCardModel model)
		{
			CreditCard record = new CreditCard();

			this.Mapper.CreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<CreditCard>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.CreditCardMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int creditCardID,
			ApiCreditCardModel model)
		{
			CreditCard record = await this.GetById(creditCardID);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int creditCardID)
		{
			CreditCard record = await this.GetById(creditCardID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<CreditCard>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOCreditCard> GetCardNumber(string cardNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.CardNumber == cardNumber);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOCreditCard>> Where(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCreditCard> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOCreditCard>> SearchLinqPOCO(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOCreditCard> response = new List<POCOCreditCard>();
			List<CreditCard> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.CreditCardMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<CreditCard>> SearchLinqEF(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CreditCard.CreditCardID)} ASC";
			}
			return await this.Context.Set<CreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CreditCard>();
		}

		private async Task<List<CreditCard>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(CreditCard.CreditCardID)} ASC";
			}

			return await this.Context.Set<CreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<CreditCard>();
		}

		private async Task<CreditCard> GetById(int creditCardID)
		{
			List<CreditCard> records = await this.SearchLinqEF(x => x.CreditCardID == creditCardID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>f3997b0832d65573148bbcb9056b9cc7</Hash>
</Codenesium>*/