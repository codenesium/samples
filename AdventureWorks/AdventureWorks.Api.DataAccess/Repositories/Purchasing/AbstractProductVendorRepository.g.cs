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
	public abstract class AbstractProductVendorRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductVendorMapper Mapper { get; }

		public AbstractProductVendorRepository(
			IDALProductVendorMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductVendor>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductVendor> Get(int productID)
		{
			ProductVendor record = await this.GetById(productID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductVendor> Create(
			DTOProductVendor dto)
		{
			ProductVendor record = new ProductVendor();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductVendor>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productID,
			DTOProductVendor dto)
		{
			ProductVendor record = await this.GetById(productID);

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
			ProductVendor record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductVendor>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<DTOProductVendor>> GetBusinessEntityID(int businessEntityID)
		{
			var records = await this.SearchLinqDTO(x => x.BusinessEntityID == businessEntityID);

			return records;
		}
		public async Task<List<DTOProductVendor>> GetUnitMeasureCode(string unitMeasureCode)
		{
			var records = await this.SearchLinqDTO(x => x.UnitMeasureCode == unitMeasureCode);

			return records;
		}

		protected async Task<List<DTOProductVendor>> Where(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductVendor> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductVendor>> SearchLinqDTO(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductVendor> response = new List<DTOProductVendor>();
			List<ProductVendor> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductVendor>> SearchLinqEF(Expression<Func<ProductVendor, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
			}
			return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductVendor>();
		}

		private async Task<List<ProductVendor>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductVendor.ProductID)} ASC";
			}

			return await this.Context.Set<ProductVendor>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductVendor>();
		}

		private async Task<ProductVendor> GetById(int productID)
		{
			List<ProductVendor> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>75116bc07891b85ca818d6860415f5bd</Hash>
</Codenesium>*/