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
	public abstract class AbstractProductSubcategoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductSubcategoryRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductSubcategory> Get(int productSubcategoryID)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			return this.Mapper.ProductSubcategoryMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductSubcategory> Create(
			ApiProductSubcategoryModel model)
		{
			ProductSubcategory record = new ProductSubcategory();

			this.Mapper.ProductSubcategoryMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductSubcategory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductSubcategoryMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productSubcategoryID,
			ApiProductSubcategoryModel model)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productSubcategoryID}");
			}
			else
			{
				this.Mapper.ProductSubcategoryMapModelToEF(
					productSubcategoryID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productSubcategoryID)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductSubcategory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOProductSubcategory> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOProductSubcategory>> Where(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductSubcategory> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductSubcategory>> SearchLinqPOCO(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductSubcategory> response = new List<POCOProductSubcategory>();
			List<ProductSubcategory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductSubcategoryMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductSubcategory>> SearchLinqEF(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}
			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductSubcategory>();
		}

		private async Task<List<ProductSubcategory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}

			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductSubcategory>();
		}

		private async Task<ProductSubcategory> GetById(int productSubcategoryID)
		{
			List<ProductSubcategory> records = await this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>1ac2d621399f3426a61db483fbba4629</Hash>
</Codenesium>*/