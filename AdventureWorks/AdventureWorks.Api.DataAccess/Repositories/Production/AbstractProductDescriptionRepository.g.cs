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
	public abstract class AbstractProductDescriptionRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductDescriptionMapper Mapper { get; }

		public AbstractProductDescriptionRepository(
			IDALProductDescriptionMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductDescription>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductDescription> Get(int productDescriptionID)
		{
			ProductDescription record = await this.GetById(productDescriptionID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductDescription> Create(
			DTOProductDescription dto)
		{
			ProductDescription record = new ProductDescription();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductDescription>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productDescriptionID,
			DTOProductDescription dto)
		{
			ProductDescription record = await this.GetById(productDescriptionID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productDescriptionID}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					productDescriptionID,
					dto,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			int productDescriptionID)
		{
			ProductDescription record = await this.GetById(productDescriptionID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductDescription>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOProductDescription>> Where(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductDescription> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductDescription>> SearchLinqDTO(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductDescription> response = new List<DTOProductDescription>();
			List<ProductDescription> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductDescription>> SearchLinqEF(Expression<Func<ProductDescription, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDescription.ProductDescriptionID)} ASC";
			}
			return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDescription>();
		}

		private async Task<List<ProductDescription>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDescription.ProductDescriptionID)} ASC";
			}

			return await this.Context.Set<ProductDescription>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDescription>();
		}

		private async Task<ProductDescription> GetById(int productDescriptionID)
		{
			List<ProductDescription> records = await this.SearchLinqEF(x => x.ProductDescriptionID == productDescriptionID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>b97185b58ea91f0251a98e2fa6da8499</Hash>
</Codenesium>*/