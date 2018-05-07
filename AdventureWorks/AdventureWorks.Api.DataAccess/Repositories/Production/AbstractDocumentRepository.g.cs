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

		public virtual Guid Create(
			DocumentModel model)
		{
			EFDocument record = new EFDocument();

			this.Mapper.DocumentMapModelToEF(
				default (Guid),
				model,
				record);

			this.Context.Set<EFDocument>().Add(record);
			this.Context.SaveChanges();
			return record.DocumentNode;
		}

		public virtual void Update(
			Guid documentNode,
			DocumentModel model)
		{
			EFDocument record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();
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
			EFDocument record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFDocument>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual POCODocument Get(Guid documentNode)
		{
			return this.SearchLinqPOCO(x => x.DocumentNode == documentNode).FirstOrDefault();
		}

		public virtual List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		private List<POCODocument> Where(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCODocument> SearchLinqPOCO(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCODocument> response = new List<POCODocument>();
			List<EFDocument> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.DocumentMapEFToPOCO(x)));
			return response;
		}

		private List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("DocumentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this.Context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}

		private List<EFDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrEmpty(orderClause))
			{
				return this.Context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy("DocumentNode ASC").Skip(skip).Take(take).ToList<EFDocument>();
			}
			else
			{
				return this.Context.Set<EFDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<EFDocument>();
			}
		}
	}
}

/*<Codenesium>
    <Hash>7f80f900cefca9421870de6640a5b115</Hash>
</Codenesium>*/