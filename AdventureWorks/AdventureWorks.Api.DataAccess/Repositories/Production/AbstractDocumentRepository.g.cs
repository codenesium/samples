using Codenesium.DataConversionExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDocumentRepository : AbstractRepository
	{
		protected ApplicationDbContext Context { get; }

		protected ILogger Logger { get; }

		public AbstractDocumentRepository(
			ILogger logger,
			ApplicationDbContext context)
			: base()
		{
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<Document>> All(int limit = int.MaxValue, int offset = 0)
		{
			return this.Where(x => true, limit, offset);
		}

		public async virtual Task<Document> Get(Guid rowguid)
		{
			return await this.GetById(rowguid);
		}

		public async virtual Task<Document> Create(Document item)
		{
			this.Context.Set<Document>().Add(item);
			await this.Context.SaveChangesAsync();

			this.Context.Entry(item).State = EntityState.Detached;
			return item;
		}

		public async virtual Task Update(Document item)
		{
			var entity = this.Context.Set<Document>().Local.FirstOrDefault(x => x.Rowguid == item.Rowguid);
			if (entity == null)
			{
				this.Context.Set<Document>().Attach(item);
			}
			else
			{
				this.Context.Entry(entity).CurrentValues.SetValues(item);
			}

			await this.Context.SaveChangesAsync();
		}

		public async virtual Task Delete(
			Guid rowguid)
		{
			Document record = await this.GetById(rowguid);

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Document>().Remove(record);
				await this.Context.SaveChangesAsync();
			}
		}

		public async Task<List<Document>> ByFileNameRevision(string fileName, string revision, int limit = int.MaxValue, int offset = 0)
		{
			return await this.Where(x => x.FileName == fileName && x.Revision == revision, limit, offset);
		}

		public async virtual Task<List<Document>> ByProductID(int productID, int limit = int.MaxValue, int offset = 0)
		{
			return await (from refTable in this.Context.ProductDocuments
			              join documents in this.Context.Documents on
			              refTable.DocumentNode equals documents.DocumentNode
			              where refTable.ProductID == productID
			              select documents).Skip(offset).Take(limit).ToListAsync();
		}

		protected async Task<List<Document>> Where(
			Expression<Func<Document, bool>> predicate,
			int limit = int.MaxValue,
			int offset = 0,
			Expression<Func<Document, dynamic>> orderBy = null,
			ListSortDirection sortDirection = ListSortDirection.Ascending)
		{
			if (orderBy == null)
			{
				orderBy = x => x.Rowguid;
			}

			if (sortDirection == ListSortDirection.Ascending)
			{
				return await this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderBy).Skip(offset).Take(limit).ToListAsync<Document>();
			}
			else
			{
				return await this.Context.Set<Document>().Where(predicate).AsQueryable().OrderByDescending(orderBy).Skip(offset).Take(limit).ToListAsync<Document>();
			}
		}

		private async Task<Document> GetById(Guid rowguid)
		{
			List<Document> records = await this.Where(x => x.Rowguid == rowguid);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>083fa5b3866b9de5943b744f5b78dfb2</Hash>
</Codenesium>*/