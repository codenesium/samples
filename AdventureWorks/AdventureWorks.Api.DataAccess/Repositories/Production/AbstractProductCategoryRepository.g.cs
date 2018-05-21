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
	public abstract class AbstractProductCategoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductCategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductCategory> Get(int productCategoryID)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			return this.Mapper.ProductCategoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductCategory> Create(
			ApiProductCategoryModel model)
		{
			ProductCategory record = new ProductCategory();

			this.Mapper.ProductCategoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductCategory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductCategoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productCategoryID,
			ApiProductCategoryModel model)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productCategoryID}");
			}
			else
			{
				this.Mapper.ProductCategoryMapModelToEF(
					productCategoryID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productCategoryID)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCategory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOProductCategory> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOProductCategory>> Where(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductCategory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductCategory>> SearchLinqPOCO(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductCategory> response = new List<POCOProductCategory>();
			List<ProductCategory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductCategoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductCategory>> SearchLinqEF(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}
			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCategory>();
		}

		private async Task<List<ProductCategory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}

			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCategory>();
		}

		private async Task<ProductCategory> GetById(int productCategoryID)
		{
			List<ProductCategory> records = await this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>9fd8395425ac669342e227761b40b2cd</Hash>
</Codenesium>*/