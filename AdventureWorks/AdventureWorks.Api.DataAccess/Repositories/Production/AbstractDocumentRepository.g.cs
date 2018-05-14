using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public abstract class AbstractDocumentRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractDocumentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCODocument Get(Guid documentNode)
		{
			return this.SearchLinqPOCO(x => x.DocumentNode == documentNode).FirstOrDefault();
		}

		public virtual POCODocument Create(
			ApiDocumentModel model)
		{
			Document record = new Document();

			this.Mapper.DocumentMapModelToEF(
				default (Guid),
				model,
				record);

			this.Context.Set<Document>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.DocumentMapEFToPOCO(record);
		}

		public virtual void Update(
			Guid documentNode,
			ApiDocumentModel model)
		{
			Document record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();
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
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			Guid documentNode)
		{
			Document record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<Document>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public POCODocument GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode)
		{
			return this.SearchLinqPOCO(x => x.DocumentLevel == documentLevel && x.DocumentNode == documentNode).FirstOrDefault();
		}

		public List<POCODocument> GetFileNameRevision(string fileName,string revision)
		{
			return this.SearchLinqPOCO(x => x.FileName == fileName && x.Revision == revision);
		}

		protected List<POCODocument> Where(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODocument> SearchLinqPOCO(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODocument> response = new List<POCODocument>();
			List<Document> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DocumentMapEFToPOCO(x)));
			return response;
		}

		private List<Document> SearchLinqEF(Expression<Func<Document, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Document.DocumentNode)} ASC";
			}
			return this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Document>();
		}

		private List<Document> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(Document.DocumentNode)} ASC";
			}

			return this.Context.Set<Document>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<Document>();
		}
	}
}

/*<Codenesium>
    <Hash>8fe66e9bfd19fa37a5dfcdcb0e79696a</Hash>
</Codenesium>*/