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
		protected IDALProductDocumentMapper Mapper { get; }

		public AbstractProductDocumentRepository(
			IDALProductDocumentMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductDocument> Get(int productID)
		{
			ProductDocument record = await this.GetById(productID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductDocument> Create(
			DTOProductDocument dto)
		{
			ProductDocument record = new ProductDocument();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductDocument>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productID,
			DTOProductDocument dto)
		{
			ProductDocument record = await this.GetById(productID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productID,
					dto,
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

		protected async Task<List<DTOProductDocument>> Where(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductDocument> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductDocument>> SearchLinqDTO(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductDocument> response = new List<DTOProductDocument>();
			List<ProductDocument> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>0efc49c28de50ef1cc3bf0307b0d5054</Hash>
</Codenesium>*/