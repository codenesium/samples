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
	public abstract class AbstractProductSubcategoryRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductSubcategoryMapper Mapper { get; }

		public AbstractProductSubcategoryRepository(
			IDALProductSubcategoryMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductSubcategory>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductSubcategory> Get(int productSubcategoryID)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductSubcategory> Create(
			DTOProductSubcategory dto)
		{
			ProductSubcategory record = new ProductSubcategory();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductSubcategory>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productSubcategoryID,
			DTOProductSubcategory dto)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productSubcategoryID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productSubcategoryID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productSubcategoryID)
		{
			ProductSubcategory record = await this.GetById(productSubcategoryID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductSubcategory>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<DTOProductSubcategory> GetName(string name)
		{
			var records = await this.SearchLinqDTO(x => x.Name == name);

			return records.FirstOrDefault();
		}

		protected async Task<List<DTOProductSubcategory>> Where(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductSubcategory> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductSubcategory>> SearchLinqDTO(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductSubcategory> response = new List<DTOProductSubcategory>();
			List<ProductSubcategory> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductSubcategory>> SearchLinqEF(Expression<Func<ProductSubcategory, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}
			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductSubcategory>();
		}

		private async Task<List<ProductSubcategory>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductSubcategory.ProductSubcategoryID)} ASC";
			}

			return await this.Context.Set<ProductSubcategory>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductSubcategory>();
		}

		private async Task<ProductSubcategory> GetById(int productSubcategoryID)
		{
			List<ProductSubcategory> records = await this.SearchLinqEF(x => x.ProductSubcategoryID == productSubcategoryID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>42995c79f99c4ad9f281423468dbec4a</Hash>
</Codenesium>*/