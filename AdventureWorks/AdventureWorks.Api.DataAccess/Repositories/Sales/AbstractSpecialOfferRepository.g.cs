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
	public abstract class AbstractSpecialOfferRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpecialOfferRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSpecialOffer>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSpecialOffer> Get(int specialOfferID)
		{
			SpecialOffer record = await this.GetById(specialOfferID);

			return this.Mapper.SpecialOfferMapEFToPOCO(record);
		}

		public async virtual Task<POCOSpecialOffer> Create(
			ApiSpecialOfferModel model)
		{
			SpecialOffer record = new SpecialOffer();

			this.Mapper.SpecialOfferMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpecialOffer>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SpecialOfferMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int specialOfferID,
			ApiSpecialOfferModel model)
		{
			SpecialOffer record = await this.GetById(specialOfferID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.Mapper.SpecialOfferMapModelToEF(
					specialOfferID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int specialOfferID)
		{
			SpecialOffer record = await this.GetById(specialOfferID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOffer>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOSpecialOffer>> Where(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecialOffer> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSpecialOffer>> SearchLinqPOCO(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecialOffer> response = new List<POCOSpecialOffer>();
			List<SpecialOffer> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SpecialOfferMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SpecialOffer>> SearchLinqEF(Expression<Func<SpecialOffer, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
			}
			return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOffer>();
		}

		private async Task<List<SpecialOffer>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOffer.SpecialOfferID)} ASC";
			}

			return await this.Context.Set<SpecialOffer>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOffer>();
		}

		private async Task<SpecialOffer> GetById(int specialOfferID)
		{
			List<SpecialOffer> records = await this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>25fc317cbd0dfe588d0d66d69999c6f6</Hash>
</Codenesium>*/