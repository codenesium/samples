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
	public abstract class AbstractProductProductPhotoRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductProductPhotoMapper Mapper { get; }

		public AbstractProductProductPhotoRepository(
			IDALProductProductPhotoMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductProductPhoto>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductProductPhoto> Get(int productID)
		{
			ProductProductPhoto record = await this.GetById(productID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductProductPhoto> Create(
			DTOProductProductPhoto dto)
		{
			ProductProductPhoto record = new ProductProductPhoto();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductProductPhoto>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productID,
			DTOProductProductPhoto dto)
		{
			ProductProductPhoto record = await this.GetById(productID);

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
			ProductProductPhoto record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductProductPhoto>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOProductProductPhoto>> Where(Expression<Func<ProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductProductPhoto> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductProductPhoto>> SearchLinqDTO(Expression<Func<ProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductProductPhoto> response = new List<DTOProductProductPhoto>();
			List<ProductProductPhoto> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductProductPhoto>> SearchLinqEF(Expression<Func<ProductProductPhoto, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductProductPhoto.ProductID)} ASC";
			}
			return await this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductProductPhoto>();
		}

		private async Task<List<ProductProductPhoto>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductProductPhoto.ProductID)} ASC";
			}

			return await this.Context.Set<ProductProductPhoto>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductProductPhoto>();
		}

		private async Task<ProductProductPhoto> GetById(int productID)
		{
			List<ProductProductPhoto> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>2f1bec8011cac4b927420366c1934d4e</Hash>
</Codenesium>*/