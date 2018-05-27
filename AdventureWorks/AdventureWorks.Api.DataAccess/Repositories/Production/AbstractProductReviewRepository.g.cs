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
	public abstract class AbstractProductReviewRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductReviewMapper Mapper { get; }

		public AbstractProductReviewRepository(
			IDALProductReviewMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductReview>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductReview> Get(int productReviewID)
		{
			ProductReview record = await this.GetById(productReviewID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductReview> Create(
			DTOProductReview dto)
		{
			ProductReview record = new ProductReview();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductReview>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productReviewID,
			DTOProductReview dto)
		{
			ProductReview record = await this.GetById(productReviewID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productReviewID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productReviewID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productReviewID)
		{
			ProductReview record = await this.GetById(productReviewID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductReview>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOProductReview>> GetCommentsProductIDReviewerName(string comments,int productID,string reviewerName)
		{
			var records = await this.SearchLinqDTO(x => x.Comments == comments && x.ProductID == productID && x.ReviewerName == reviewerName);

			return records;
		}

		protected async Task<List<DTOProductReview>> Where(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductReview> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductReview>> SearchLinqDTO(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductReview> response = new List<DTOProductReview>();
			List<ProductReview> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductReview>> SearchLinqEF(Expression<Func<ProductReview, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductReview.ProductReviewID)} ASC";
			}
			return await this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductReview>();
		}

		private async Task<List<ProductReview>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductReview.ProductReviewID)} ASC";
			}

			return await this.Context.Set<ProductReview>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductReview>();
		}

		private async Task<ProductReview> GetById(int productReviewID)
		{
			List<ProductReview> records = await this.SearchLinqEF(x => x.ProductReviewID == productReviewID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>54ebf08925851617543b2c86e2932f6e</Hash>
</Codenesium>*/