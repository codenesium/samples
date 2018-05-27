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
		protected IDALCreditCardMapper Mapper { get; }

		public AbstractCreditCardRepository(
			IDALCreditCardMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOCreditCard> Get(int creditCardID)
		{
			CreditCard record = await this.GetById(creditCardID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOCreditCard> Create(
			DTOCreditCard dto)
		{
			CreditCard record = new CreditCard();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<CreditCard>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int creditCardID,
			DTOCreditCard dto)
		{
			CreditCard record = await this.GetById(creditCardID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{creditCardID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					creditCardID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		public async Task<DTOCreditCard> GetCardNumber(string cardNumber)
		{
			var records = await this.SearchLinqDTO(x => x.CardNumber == cardNumber);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOCreditCard>> Where(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCreditCard> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOCreditCard>> SearchLinqDTO(Expression<Func<CreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOCreditCard> response = new List<DTOCreditCard>();
			List<CreditCard> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>9f1f108dfb93013b134da86042455278</Hash>
</Codenesium>*/