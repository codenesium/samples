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
	public abstract class AbstractProductCategoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductCategoryMapper Mapper { get; }

		public AbstractProductCategoryRepository(
			IDALProductCategoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductCategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductCategory> Get(int productCategoryID)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductCategory> Create(
			DTOProductCategory dto)
		{
			ProductCategory record = new ProductCategory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductCategory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productCategoryID,
			DTOProductCategory dto)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productCategoryID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productCategoryID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productCategoryID)
		{
			ProductCategory record = await this.GetById(productCategoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductCategory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOProductCategory> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOProductCategory>> Where(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductCategory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductCategory>> SearchLinqDTO(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductCategory> response = new List<DTOProductCategory>();
			List<ProductCategory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductCategory>> SearchLinqEF(Expression<Func<ProductCategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}
			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCategory>();
		}

		private async Task<List<ProductCategory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductCategory.ProductCategoryID)} ASC";
			}

			return await this.Context.Set<ProductCategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductCategory>();
		}

		private async Task<ProductCategory> GetById(int productCategoryID)
		{
			List<ProductCategory> records = await this.SearchLinqEF(x => x.ProductCategoryID == productCategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>fef684d9244bb5961edbed5368decba1</Hash>
</Codenesium>*/