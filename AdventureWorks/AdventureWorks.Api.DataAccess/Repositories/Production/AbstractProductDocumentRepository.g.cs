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
	public abstract class AbstractProductDocumentRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductDocumentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductDocument> Get(int productID)
		{
			ProductDocument record = await this.GetById(productID);

			return this.Mapper.ProductDocumentMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductDocument> Create(
			ApiProductDocumentModel model)
		{
			ProductDocument record = new ProductDocument();

			this.Mapper.ProductDocumentMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductDocument>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductDocumentMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productID,
			ApiProductDocumentModel model)
		{
			ProductDocument record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductDocumentMapModelToEF(
					productID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductDocument record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductDocument>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOProductDocument>> Where(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductDocument> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductDocument>> SearchLinqPOCO(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductDocument> response = new List<POCOProductDocument>();
			List<ProductDocument> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductDocumentMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductDocument>> SearchLinqEF(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDocument.ProductID)} ASC";
			}
			return await this.Context.Set<ProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDocument>();
		}

		private async Task<List<ProductDocument>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDocument.ProductID)} ASC";
			}

			return await this.Context.Set<ProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDocument>();
		}

		private async Task<ProductDocument> GetById(int productID)
		{
			List<ProductDocument> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>ba3e23b9260f4172298593b46a32bcd9</Hash>
</Codenesium>*/