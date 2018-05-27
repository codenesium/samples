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
		protected IDALDocumentMapper Mapper { get; }

		public AbstractDocumentRepository(
			IDALDocumentMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
			: base ()
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual Task<List<DTODocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqDTO(x => true, skip, take, orderClause);
		}

		public async virtual Task<DTODocument> Get(Guid documentNode)
		{
			Document record = await this.GetById(documentNode);

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task<DTODocument> Create(
			DTODocument dto)
		{
			Document record = new Document();

			this.Mapper.MapDTOToEF(
				default (Guid),
				dto,
				record);

			this.Context.Set<Document>().Add(record);
			await this.Context.SaveChangesAsync();

			return this.Mapper.MapEFToDTO(record);
		}

		public async virtual Task Update(
			Guid documentNode,
			DTODocument dto)
		{
			Document record = await this.GetById(documentNode);

			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{documentNode}");
			}
			else
			{
				this.Mapper.MapDTOToEF(
					documentNode,
					dto,
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

		public async Task<DTODocument> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			var records = await this.SearchLinqDTO(x => x.DocumentLevel == documentLevel && x.DocumentNode == documentNode);

			return records.FirstOrDefault();
		}
		public async Task<List<DTODocument>> GetFileNameRevision(string fileName,string revision)
		{
			var records = await this.SearchLinqDTO(x => x.FileName == fileName && x.Revision == revision);

			return records;
		}

		protected async Task<List<DTODocument>> Where(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODocument> records = await this.SearchLinqDTO(predicate, skip, take, orderClause);

			return records;
		}

		private async Task<List<DTODocument>> SearchLinqDTO(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<DTODocument> response = new List<DTODocument>();
			List<Document> records = await this.SearchLinqEF(predicate, skip, take, orderClause);

			records.ForEach(x => response.Add(this.Mapper.MapEFToDTO(x)));
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
    <Hash>1df9bb7a5f8da486a9132fe581925fcc</Hash>
</Codenesium>*/