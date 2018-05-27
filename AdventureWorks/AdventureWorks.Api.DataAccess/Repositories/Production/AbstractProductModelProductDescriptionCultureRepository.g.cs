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
	public abstract class AbstractProductModelProductDescriptionCultureRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductModelProductDescriptionCultureMapper Mapper { get; }

		public AbstractProductModelProductDescriptionCultureRepository(
			IDALProductModelProductDescriptionCultureMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductModelProductDescriptionCulture>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductModelProductDescriptionCulture> Get(int productModelID)
		{
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductModelProductDescriptionCulture> Create(
			DTOProductModelProductDescriptionCulture dto)
		{
			ProductModelProductDescriptionCulture record = new ProductModelProductDescriptionCulture();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductModelProductDescriptionCulture>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productModelID,
			DTOProductModelProductDescriptionCulture dto)
		{
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

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
			ProductModelProductDescriptionCulture record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelProductDescriptionCulture>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOProductModelProductDescriptionCulture>> Where(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductModelProductDescriptionCulture> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductModelProductDescriptionCulture>> SearchLinqDTO(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductModelProductDescriptionCulture> response = new List<DTOProductModelProductDescriptionCulture>();
			List<ProductModelProductDescriptionCulture> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductModelProductDescriptionCulture>> SearchLinqEF(Expression<Func<ProductModelProductDescriptionCulture, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelProductDescriptionCulture>();
		}

		private async Task<List<ProductModelProductDescriptionCulture>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelProductDescriptionCulture.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModelProductDescriptionCulture>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelProductDescriptionCulture>();
		}

		private async Task<ProductModelProductDescriptionCulture> GetById(int productModelID)
		{
			List<ProductModelProductDescriptionCulture> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>0783a4e9ed22198bed30055d5bd2221f</Hash>
</Codenesium>*/