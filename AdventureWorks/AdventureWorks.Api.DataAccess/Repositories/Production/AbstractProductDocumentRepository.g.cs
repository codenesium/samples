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
	public abstract class AbstractProductDocumentRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }

		public AbstractProductDocumentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<ProductDocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqEF(x => true, skip, take, orderClause);
		}

		public async virtual Task<ProductDocument> Get(int productID)
		{
			return await this.GetById(productID);
		}

		public async virtual Task<ProductDocument> Create(ProductDocument item)
		{
			this.Context.Set<ProductDocument>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(ProductDocument item)
		{
			var entity = this.Context.Set<ProductDocument>().Local.FirstOrDefault(x => x.ProductID == item.ProductID);
			if (entity == null)
			{
				this.Context.Set<ProductDocument>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			int productID)
		{
			ProductDocument record = await this.GetById(productID);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductDocument>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		protected async Task<List<ProductDocument>> Where(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<ProductDocument> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<ProductDocument>> SearchLinqEF(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDocument.ProductID)} ASC";
			}
			return await this.Context.Set<ProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDocument>();
		}

		private async Task<List<ProductDocument>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDocument.ProductID)} ASC";
			}

			return await this.Context.Set<ProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<ProductDocument>();
		}

		private async Task<ProductDocument> GetById(int productID)
		{
			List<ProductDocument> records = await this.SearchLinqEF(x => x.ProductID == productID);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>5ca4f489c16e47d6d09aeb4f2aaaeb9c</Hash>
</Codenesium>*/