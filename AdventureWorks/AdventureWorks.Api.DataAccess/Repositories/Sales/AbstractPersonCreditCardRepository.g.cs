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
		protected IDALPersonCreditCardMapper Mapper { get; }

		public AbstractPersonCreditCardRepository(
			IDALPersonCreditCardMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOPersonCreditCard>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOPersonCreditCard> Get(int businessEntityID)
		{
			PersonCreditCard record = await this.GetById(businessEntityID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOPersonCreditCard> Create(
			DTOPersonCreditCard dto)
		{
			PersonCreditCard record = new PersonCreditCard();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<PersonCreditCard>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int businessEntityID,
			DTOPersonCreditCard dto)
		{
			PersonCreditCard record = await this.GetById(businessEntityID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{businessEntityID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					businessEntityID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
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

		protected async Task<List<DTOPersonCreditCard>> Where(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPersonCreditCard> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOPersonCreditCard>> SearchLinqDTO(Expression<Func<PersonCreditCard, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOPersonCreditCard> response = new List<DTOPersonCreditCard>();
			List<PersonCreditCard> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>8bc5086eaa6931a7a56e5e6cdb16c035</Hash>
</Codenesium>*/