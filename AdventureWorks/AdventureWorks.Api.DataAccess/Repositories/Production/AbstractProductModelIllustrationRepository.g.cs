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
	public abstract class AbstractProductModelIllustrationRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IDALProductModelIllustrationMapper Mapper { get; }

		public AbstractProductModelIllustrationRepository(
			IDALProductModelIllustrationMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTOProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTOProductModelIllustration> Get(int productModelID)
		{
			ProductModelIllustration record = await this.GetById(productModelID);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTOProductModelIllustration> Create(
			DTOProductModelIllustration dto)
		{
			ProductModelIllustration record = new ProductModelIllustration();

			this.Mapper.MapDTOToEF(
				default (int),
				dto,
				record);

			this.Context.Set<ProductModelIllustration>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			int productModelID,
			DTOProductModelIllustration dto)
		{
			ProductModelIllustration record = await this.GetById(productModelID);

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
			ProductModelIllustration record = await this.GetById(productModelID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductModelIllustration>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<DTOProductModelIllustration>> Where(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductModelIllustration> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTOProductModelIllustration>> SearchLinqDTO(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTOProductModelIllustration> response = new List<DTOProductModelIllustration>();
			List<ProductModelIllustration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
			return response;
		}

		private async Task<List<ProductModelIllustration>> SearchLinqEF(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
			}
			return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelIllustration>();
		}

		private async Task<List<ProductModelIllustration>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductModelIllustration.ProductModelID)} ASC";
			}

			return await this.Context.Set<ProductModelIllustration>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductModelIllustration>();
		}

		private async Task<ProductModelIllustration> GetById(int productModelID)
		{
			List<ProductModelIllustration> records = await this.SearchLinqEF(x => x.ProductModelID == productModelID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>829e2d6062d4c17d3a3c054f1301871d</Hash>
</Codenesium>*/