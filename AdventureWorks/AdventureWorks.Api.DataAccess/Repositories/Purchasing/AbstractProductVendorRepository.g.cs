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
	public abstract class AbstractProductVendorRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductVendorRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductVendor> Get(int productID)
		{
			ProductVendor record = await this.GetById(productID);

			return this.Mapper.ProductVendorMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductVendor> Create(
			ApiProductVendorModel model)
		{
			ProductVendor record = new ProductVendor();

			this.Mapper.ProductVendorMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductVendor>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductVendorMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productID,
			ApiProductVendorModel model)
		{
			ProductVendor record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductVendorMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductVendor record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductVendor>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<POCOProductVendor>> GetBusinessEntityID(int businessEntityID)
		{
			var records = await this.SearchLinqPOCO(x => x.BusinessEntityID == businessEntityID);

			return records;
		}
		public async Task<List<POCOProductVendor>> GetUnitMeasureCode(string unitMeasureCode)
		{
			var records = await this.SearchLinqPOCO(x => x.UnitMeasureCode == unitMeasureCode);

			return records;
		}

		protected async Task<List<POCOProductVendor>> Where(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductVendor> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductVendor>> SearchLinqPOCO(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductVendor> response = new List<POCOProductVendor>();
			List<ProductVendor> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductVendorMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductVendor>> SearchLinqEF(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
			}
			return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductVendor>();
		}

		private async Task<List<ProductVendor>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
			}

			return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductVendor>();
		}

		private async Task<ProductVendor> GetById(int productID)
		{
			List<ProductVendor> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0f10520664209da75cab11e8b5c18777</Hash>
</Codenesium>*/