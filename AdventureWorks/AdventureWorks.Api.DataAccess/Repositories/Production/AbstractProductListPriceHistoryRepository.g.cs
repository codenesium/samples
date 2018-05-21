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
	public abstract class AbstractProductListPriceHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductListPriceHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductListPriceHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductListPriceHistory> Get(int productID)
		{
			ProductListPriceHistory record = await this.GetById(productID);

			return this.Mapper.ProductListPriceHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductListPriceHistory> Create(
			ApiProductListPriceHistoryModel model)
		{
			ProductListPriceHistory record = new ProductListPriceHistory();

			this.Mapper.ProductListPriceHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductListPriceHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductListPriceHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productID,
			ApiProductListPriceHistoryModel model)
		{
			ProductListPriceHistory record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductListPriceHistoryMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductListPriceHistory record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductListPriceHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOProductListPriceHistory>> Where(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductListPriceHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductListPriceHistory>> SearchLinqPOCO(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductListPriceHistory> response = new List<POCOProductListPriceHistory>();
			List<ProductListPriceHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductListPriceHistoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductListPriceHistory>> SearchLinqEF(Expression<Func<ProductListPriceHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductListPriceHistory.ProductID)} ASC";
			}
			return await this.Context.Set<ProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductListPriceHistory>();
		}

		private async Task<List<ProductListPriceHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductListPriceHistory.ProductID)} ASC";
			}

			return await this.Context.Set<ProductListPriceHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductListPriceHistory>();
		}

		private async Task<ProductListPriceHistory> GetById(int productID)
		{
			List<ProductListPriceHistory> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>36c583c25b377f9c049a33223ea38e8b</Hash>
</Codenesium>*/