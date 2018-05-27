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
	public abstract class AbstractProductModelRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductModelMapper Mapper { get; }

		public AbstractProductModelRepository(
			IDALProductModelMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductModel> Get(int productModelID)
		{
			ProductModel record = await this.GetById(productModelID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductModel> Create(
			DTOProductModel dto)
		{
			ProductModel record = new ProductModel();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductModel>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productModelID,
			DTOProductModel dto)
		{
			ProductModel record = await this.GetById(productModelID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productModelID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productModelID)
		{
			ProductModel record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModel>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOProductModel> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}
		public async Task<List<DTOProductModel>> GetCatalogDescription(string catalogDescription)
		{
			var records = await this.SearchLinqDTO(x => x.CatalogDescription == catalogDescription);

			return records;
		}
		public async Task<List<DTOProductModel>> GetInstructions(string instructions)
		{
			var records = await this.SearchLinqDTO(x => x.Instructions == instructions);

			return records;
		}

		protected async Task<List<DTOProductModel>> Where(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductModel> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductModel>> SearchLinqDTO(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductModel> response = new List<DTOProductModel>();
			List<ProductModel> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductModel>> SearchLinqEF(Expression<Func<ProductModel, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModel>();
		}

		private async Task<List<ProductModel>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModel.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModel>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModel>();
		}

		private async Task<ProductModel> GetById(int productModelID)
		{
			List<ProductModel> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>4a361be244aa68a1f88b4b40b658d9be</Hash>
</Codenesium>*/