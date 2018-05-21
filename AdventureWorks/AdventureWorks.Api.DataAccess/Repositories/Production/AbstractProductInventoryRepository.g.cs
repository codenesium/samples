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
	public abstract class AbstractProductInventoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductInventoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductInventory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductInventory> Get(int productID)
		{
			ProductInventory record = await this.GetById(productID);

			return this.Mapper.ProductInventoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductInventory> Create(
			ApiProductInventoryModel model)
		{
			ProductInventory record = new ProductInventory();

			this.Mapper.ProductInventoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductInventory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductInventoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productID,
			ApiProductInventoryModel model)
		{
			ProductInventory record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductInventoryMapModelToEF(
					productID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductInventory record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductInventory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOProductInventory>> Where(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductInventory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductInventory>> SearchLinqPOCO(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductInventory> response = new List<POCOProductInventory>();
			List<ProductInventory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductInventoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductInventory>> SearchLinqEF(Expression<Func<ProductInventory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductInventory.ProductID)} ASC";
			}
			return await this.Context.Set<ProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductInventory>();
		}

		private async Task<List<ProductInventory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductInventory.ProductID)} ASC";
			}

			return await this.Context.Set<ProductInventory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductInventory>();
		}

		private async Task<ProductInventory> GetById(int productID)
		{
			List<ProductInventory> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0fd5a01a80d65a1a46774450bf74b183</Hash>
</Codenesium>*/