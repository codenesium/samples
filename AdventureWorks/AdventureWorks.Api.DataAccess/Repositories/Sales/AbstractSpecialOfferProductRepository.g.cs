using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractSpecialOfferProductRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractSpecialOfferProductRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<SpecialOfferProduct>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<SpecialOfferProduct> Get(int specialOfferID)
		{
			return await this.GetById(specialOfferID);
		}

		public async virtual Task<SpecialOfferProduct> Create(SpecialOfferProduct item)
		{
			this.Context.Set<SpecialOfferProduct>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(SpecialOfferProduct item)
		{
			var entity = this.Context.Set<SpecialOfferProduct>().Local.FirstOrDefault(x => x.SpecialOfferID == item.SpecialOfferID);
			if (entity == null)
			{
				this.Context.Set<SpecialOfferProduct>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int specialOfferID)
		{
			SpecialOfferProduct record = await this.GetById(specialOfferID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<SpecialOfferProduct>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<SpecialOfferProduct>> GetProductID(int productID)
		{
			var records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records;
		}

		protected async Task<List<SpecialOfferProduct>> Where(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<SpecialOfferProduct> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<SpecialOfferProduct>> SearchLinqEF(Expression<Func<SpecialOfferProduct, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}
			return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOfferProduct>();
		}

		private async Task<List<SpecialOfferProduct>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(SpecialOfferProduct.SpecialOfferID)} ASC";
			}

			return await this.Context.Set<SpecialOfferProduct>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<SpecialOfferProduct>();
		}

		private async Task<SpecialOfferProduct> GetById(int specialOfferID)
		{
			List<SpecialOfferProduct> records = await this.SearchLinqEF(x => x.SpecialOfferID == specialOfferID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c862e68f0953154f5c25f42ba5058dd9</Hash>
</Codenesium>*/