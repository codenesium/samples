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
	public abstract class AbstractPersonCreditCardRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractPersonCreditCardRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOPersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOPersonCreditCard> Get(int businessEntityID)
		{
			PersonCreditCard record = await this.GetById(businessEntityID);

			return this.Mapper.PersonCreditCardMapEFToPOCO(record);
		}

		public async virtual Task<POCOPersonCreditCard> Create(
			ApiPersonCreditCardModel model)
		{
			PersonCreditCard record = new PersonCreditCard();

			this.Mapper.PersonCreditCardMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<PersonCreditCard>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.PersonCreditCardMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			ApiPersonCreditCardModel model)
		{
			PersonCreditCard record = await this.GetById(businessEntityID);

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
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int businessEntityID)
		{
			PersonCreditCard record = await this.GetById(businessEntityID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<PersonCreditCard>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOPersonCreditCard>> Where(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPersonCreditCard> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOPersonCreditCard>> SearchLinqPOCO(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOPersonCreditCard> response = new List<POCOPersonCreditCard>();
			List<PersonCreditCard> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.PersonCreditCardMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<PersonCreditCard>> SearchLinqEF(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonCreditCard.BusinessEntityID)} ASC";
			}
			return await this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonCreditCard>();
		}

		private async Task<List<PersonCreditCard>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(PersonCreditCard.BusinessEntityID)} ASC";
			}

			return await this.Context.Set<PersonCreditCard>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<PersonCreditCard>();
		}

		private async Task<PersonCreditCard> GetById(int businessEntityID)
		{
			List<PersonCreditCard> records = await this.SearchLinqEF(x => x.BusinessEntityID == businessEntityID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5d52da2067b5a4f2caf6edc757fcbea1</Hash>
</Codenesium>*/