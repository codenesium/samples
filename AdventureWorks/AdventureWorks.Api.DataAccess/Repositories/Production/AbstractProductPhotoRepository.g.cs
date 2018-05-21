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
	public abstract class AbstractProductPhotoRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductPhotoRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductPhoto> Get(int productPhotoID)
		{
			ProductPhoto record = await this.GetById(productPhotoID);

			return this.Mapper.ProductPhotoMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductPhoto> Create(
			ApiProductPhotoModel model)
		{
			ProductPhoto record = new ProductPhoto();

			this.Mapper.ProductPhotoMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductPhoto>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductPhotoMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productPhotoID,
			ApiProductPhotoModel model)
		{
			ProductPhoto record = await this.GetById(productPhotoID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productPhotoID}");
			}
			else
			{
				this.Mapper.ProductPhotoMapModelToEF(
					productPhotoID,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productPhotoID)
		{
			ProductPhoto record = await this.GetById(productPhotoID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductPhoto>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<POCOProductPhoto>> Where(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductPhoto> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductPhoto>> SearchLinqPOCO(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductPhoto> response = new List<POCOProductPhoto>();
			List<ProductPhoto> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductPhotoMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<ProductPhoto>> SearchLinqEF(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductPhoto.ProductPhotoID)} ASC";
			}
			return await this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductPhoto>();
		}

		private async Task<List<ProductPhoto>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductPhoto.ProductPhotoID)} ASC";
			}

			return await this.Context.Set<ProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductPhoto>();
		}

		private async Task<ProductPhoto> GetById(int productPhotoID)
		{
			List<ProductPhoto> records = await this.SearchLinqEF(x => x.ProductPhotoID == productPhotoID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c464842e8495213be6491cf43e3d60f4</Hash>
</Codenesium>*/