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
	public abstract class AbstractProductModelProductDescriptionCultureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelProductDescriptionCultureRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductModelProductDescriptionCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductModelProductDescriptionCulture> Get(int productModelID)
		{
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

			return this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductModelProductDescriptionCulture> Create(
			ApiProductModelProductDescriptionCultureModel model)
		{
			ProductModelProductDescriptionCulture record = new ProductModelProductDescriptionCulture();

			this.Mapper.ProductModelProductDescriptionCultureMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductModelProductDescriptionCulture>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productModelID,
			ApiProductModelProductDescriptionCultureModel model)
		{
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelProductDescriptionCultureMapModelToEF(
					productModelID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productModelID)
		{
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelProductDescriptionCulture>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOProductModelProductDescriptionCulture>> Where(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModelProductDescriptionCulture> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductModelProductDescriptionCulture>> SearchLinqPOCO(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModelProductDescriptionCulture> response = new List<POCOProductModelProductDescriptionCulture>();
			List<ProductModelProductDescriptionCulture> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductModelProductDescriptionCultureMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductModelProductDescriptionCulture>> SearchLinqEF(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelProductDescriptionCulture>();
		}

		private async Task<List<ProductModelProductDescriptionCulture>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelProductDescriptionCulture>();
		}

		private async Task<ProductModelProductDescriptionCulture> GetById(int productModelID)
		{
			List<ProductModelProductDescriptionCulture> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ed048ced4fef924869c8d48d1972d5c7</Hash>
</Codenesium>*/