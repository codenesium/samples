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
	public abstract class AbstractSpecialOfferProductRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractSpecialOfferProductRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOSpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOSpecialOfferProduct> Get(int specialOfferID)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			return this.Mapper.SpecialOfferProductMapEFToPOCO(record);
		}

		public async virtual Task<POCOSpecialOfferProduct> Create(
			ApiSpecialOfferProductModel model)
		{
			SpecialOfferProduct record = new SpecialOfferProduct();

			this.Mapper.SpecialOfferProductMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<SpecialOfferProduct>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.SpecialOfferProductMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int specialOfferID,
			ApiSpecialOfferProductModel model)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{specialOfferID}");
			}
			else
			{
				this.Mapper.SpecialOfferProductMapModelToEF(
					specialOfferID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int specialOfferID)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOfferProduct>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOSpecialOfferProduct>> GetProductID(int productID)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<POCOSpecialOfferProduct>> Where(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecialOfferProduct> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOSpecialOfferProduct>> SearchLinqPOCO(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOSpecialOfferProduct> response = new List<POCOSpecialOfferProduct>();
			List<SpecialOfferProduct> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.SpecialOfferProductMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<SpecialOfferProduct>> SearchLinqEF(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}
			return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOfferProduct>();
		}

		private async Task<List<SpecialOfferProduct>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}

			return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOfferProduct>();
		}

		private async Task<SpecialOfferProduct> GetById(int specialOfferID)
		{
			List<SpecialOfferProduct> records = await this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5f591f7c7514c689195bd37fbce30bef</Hash>
</Codenesium>*/