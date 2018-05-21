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
		protected IObjectMapper Mapper { get; }

		public AbstractProductModelIllustrationRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCOProductModelIllustration>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCOProductModelIllustration> Get(int productModelID)
		{
			ProductModelIllustration record = await this.GetById(productModelID);

			return this.Mapper.ProductModelIllustrationMapEFToPOCO(record);
		}

		public async virtual Task<POCOProductModelIllustration> Create(
			ApiProductModelIllustrationModel model)
		{
			ProductModelIllustration record = new ProductModelIllustration();

			this.Mapper.ProductModelIllustrationMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductModelIllustration>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.ProductModelIllustrationMapEFToPOCO(record);
		}

		public async virtual Task Update(
			int productModelID,
			ApiProductModelIllustrationModel model)
		{
			ProductModelIllustration record = await this.GetById(productModelID);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productModelID}");
			}
			else
			{
				this.Mapper.ProductModelIllustrationMapModelToEF(
					productModelID,
					model,
					record);
				this.Context.SaveChangesAsync();
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

		protected async Task<List<POCOProductModelIllustration>> Where(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModelIllustration> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCOProductModelIllustration>> SearchLinqPOCO(Expression<Func<ProductModelIllustration, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductModelIllustration> response = new List<POCOProductModelIllustration>();
			List<ProductModelIllustration> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.ProductModelIllustrationMapEFToPOCO(x)));
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
    <Hash>563e026a8112e72b19fce1545e2c5fe3</Hash>
</Codenesium>*/