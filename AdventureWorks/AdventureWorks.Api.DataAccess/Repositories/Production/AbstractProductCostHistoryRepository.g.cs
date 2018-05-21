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
	public abstract class AbstractProductCostHistoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductCostHistoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductCostHistory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductCostHistory> Get(int productID)
		{
			ProductCostHistory record = await this.GetById(productID);

			return this.Mapper.ProductCostHistoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductCostHistory> Create(
			ApiProductCostHistoryModel model)
		{
			ProductCostHistory record = new ProductCostHistory();

			this.Mapper.ProductCostHistoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductCostHistory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductCostHistoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productID,
			ApiProductCostHistoryModel model)
		{
			ProductCostHistory record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductCostHistoryMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductCostHistory record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCostHistory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOProductCostHistory>> Where(Expression<Func<ProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductCostHistory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductCostHistory>> SearchLinqPOCO(Expression<Func<ProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductCostHistory> response = new List<POCOProductCostHistory>();
			List<ProductCostHistory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductCostHistoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductCostHistory>> SearchLinqEF(Expression<Func<ProductCostHistory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCostHistory.ProductID)} ASC";
			}
			return await this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCostHistory>();
		}

		private async Task<List<ProductCostHistory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCostHistory.ProductID)} ASC";
			}

			return await this.Context.Set<ProductCostHistory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCostHistory>();
		}

		private async Task<ProductCostHistory> GetById(int productID)
		{
			List<ProductCostHistory> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0afd9ae316838e8c55d7187acc10102d</Hash>
</Codenesium>*/