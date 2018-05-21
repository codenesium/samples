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
	public abstract class AbstractProductRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProduct> Get(int productID)
		{
			Product record = await this.GetById(productID);

			return this.Mapper.ProductMapEFToPOCO(record);
		}

		public async virtual Task<POCOProduct> Create(
			ApiProductModel model)
		{
			Product record = new Product();

			this.Mapper.ProductMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<Product>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productID,
			ApiProductModel model)
		{
			Product record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			Product record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Product>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<POCOProduct> GetName(string name)
		{
			var records = await this.SearchLinqPOCO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<POCOProduct> GetProductNumber(string productNumber)
		{
			var records = await this.SearchLinqPOCO(x => x.ProductNumber == productNumber);

			return records.FirstOrDefault();
		}

		protected async Task<List<POCOProduct>> Where(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProduct> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProduct>> SearchLinqPOCO(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProduct> response = new List<POCOProduct>();
			List<Product> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Product>> SearchLinqEF(Expression<Func<Product, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Product.ProductID)} ASC";
			}
			return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Product>();
		}

		private async Task<List<Product>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Product.ProductID)} ASC";
			}

			return await this.Context.Set<Product>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Product>();
		}

		private async Task<Product> GetById(int productID)
		{
			List<Product> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>a25be0161da29303fbff4931e5b76da0</Hash>
</Codenesium>*/