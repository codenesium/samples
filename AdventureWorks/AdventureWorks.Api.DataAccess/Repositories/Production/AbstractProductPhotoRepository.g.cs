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
		protected IDALProductPhotoMapper Mapper { get; }

		public AbstractProductPhotoRepository(
			IDALProductPhotoMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductPhoto> Get(int productPhotoID)
		{
			ProductPhoto record = await this.GetById(productPhotoID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductPhoto> Create(
			DTOProductPhoto dto)
		{
			ProductPhoto record = new ProductPhoto();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductPhoto>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productPhotoID,
			DTOProductPhoto dto)
		{
			ProductPhoto record = await this.GetById(productPhotoID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productPhotoID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productPhotoID,
					dto,
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

		protected async Task<List<DTOProductPhoto>> Where(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductPhoto> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductPhoto>> SearchLinqDTO(Expression<Func<ProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductPhoto> response = new List<DTOProductPhoto>();
			List<ProductPhoto> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>f3b431ef9f566006c5b3eb20a813d5ea</Hash>
</Codenesium>*/