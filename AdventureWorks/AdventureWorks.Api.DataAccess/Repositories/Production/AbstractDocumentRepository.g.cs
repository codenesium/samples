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
	public abstract class AbstractDocumentRepository: AbstractRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDocumentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<POCODocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public async virtual Task<POCODocument> Get(Guid documentNode)
		{
			Document record = await this.GetById(documentNode);

			return this.Mapper.DocumentMapEFToPOCO(record);
		}

		public async virtual Task<POCODocument> Create(
			ApiDocumentModel model)
		{
			Document record = new Document();

			this.Mapper.DocumentMapModelToEF(
				default (Guid),
				model,
				record);

			this.Context.Set<Document>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.DocumentMapEFToPOCO(record);
		}

		public async virtual Task Update(
			Guid documentNode,
			ApiDocumentModel model)
		{
			Document record = await this.GetById(documentNode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{documentNode}");
			}
			else
			{
				this.Mapper.DocumentMapModelToEF(
					documentNode,
					model,
					record);

				await this.Context.SaveChangesAsync();
			}
		}

		public async virtual Task Delete(
			Guid documentNode)
		{
			Document record = await this.GetById(documentNode);

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

		public async Task<POCODocument> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			var records = await this.SearchLinqPOCO(x => x.DocumentLevel == documentLevel && x.DocumentNode == documentNode);

			return records.FirstOrDefault();
		}
		public async Task<List<POCODocument>> GetFileNameRevision(string fileName,string revision)
		{
			var records = await this.SearchLinqPOCO(x => x.FileName == fileName && x.Revision == revision);

			return records;
		}

		protected async Task<List<POCODocument>> Where(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODocument> records = await this.SearchLinqPOCO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<POCODocument>> SearchLinqPOCO(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODocument> response = new List<POCODocument>();
			List<Document> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.DocumentMapEFToPOCO(x)));
			return response;
		}

		private async Task<List<Document>> SearchLinqEF(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Document.DocumentNode)} ASC";
			}
			return await this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Document>();
		}

		private async Task<List<Document>> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Document.DocumentNode)} ASC";
			}

			return await this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToListAsync<Document>();
		}

		private async Task<Document> GetById(Guid documentNode)
		{
			List<Document> records = await this.SearchLinqEF(x => x.DocumentNode == documentNode);

			return records.FirstOrDefault();
		}
	}
}

/*<Codenesium>
    <Hash>c59f27e83b1207e147c1e45303bfee46</Hash>
</Codenesium>*/