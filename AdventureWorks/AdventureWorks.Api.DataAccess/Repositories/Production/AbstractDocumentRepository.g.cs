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

		public virtual ApiResponse GetById(Guid documentNode)
		{
			return this.SearchLinqPOCO(x => x.DocumentNode == documentNode);
		}

		public virtual POCODocument GetByIdDirect(Guid documentNode)
		{
			return this.SearchLinqPOCO(x => x.DocumentNode == documentNode).Documents.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).Documents;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFDocument> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.DocumentMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFDocument> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.DocumentMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>01bee3a722d29d866764ffe8eff2a8dd</Hash>
</Codenesium>*/