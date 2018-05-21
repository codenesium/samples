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
	public abstract class AbstractProductModelRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductModel> Get(int productModelID)
		{
			ProductModel record = await this.GetById(productModelID);

			return this.Mapper.ProductModelMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductModel> Create(
			ApiProductModelModel model)
		{
			ProductModel record = new ProductModel();

			this.Mapper.ProductModelMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductModel>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductModelMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productModelID,
			ApiProductModelModel model)
		{
			ProductModel record = await this.GetById(productModelID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelMapModelToEF(
					productModelID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productModelID)
		{
			ProductModel record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModel>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOProductModel> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<List<POCOProductModel>> GetCatalogDescription(string catalogDescription)
		{
			var records = await this.SearchLinqPOCO(x => x.CatalogDescription == catalogDescription);

			return records;
		}
		public async Task<List<POCOProductModel>> GetInstructions(string instructions)
		{
			var records = await this.SearchLinqPOCO(x => x.Instructions == instructions);

			return records;
		}

		protected async Task<List<POCOProductModel>> Where(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModel> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductModel>> SearchLinqPOCO(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModel> response = new List<POCOProductModel>();
			List<ProductModel> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductModelMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductModel>> SearchLinqEF(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModel>();
		}

		private async Task<List<ProductModel>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModel>();
		}

		private async Task<ProductModel> GetById(int productModelID)
		{
			List<ProductModel> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>93e6773fc68f0301758d5664bd27b5d0</Hash>
</Codenesium>*/