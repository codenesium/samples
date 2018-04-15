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
		protected ApplicationDbContext context;
		protected ILogger logger;
		protected IObjectMapper mapper;

		public AbstractDocumentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.mapper = mapper;
			this.logger = logger;
			this.context = context;
		}

		public virtual Guid Create(
			DocumentModel model)
		{
			var record = new EFDocument();

			this.mapper.DocumentMapModelToEF(
				default (Guid),
				model,
				record);

			this.context.Set<EFDocument>().Add(record);
			this.context.SaveChanges();
			return record.DocumentNode;
		}

		public virtual void Update(
			Guid documentNode,
			DocumentModel model)
		{
			var record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{documentNode}");
			}
			else
			{
				this.mapper.DocumentMapModelToEF(
					documentNode,
					model,
					record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(
			Guid documentNode)
		{
			var record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFDocument>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(Guid documentNode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.DocumentNode == documentNode, response);
			return response;
		}

		public virtual POCODocument GetByIdDirect(Guid documentNode)
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(x => x.DocumentNode == documentNode, response);
			return response.Documents.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new ApiResponse();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Documents;
		}

		private void SearchLinqPOCO(Expression<Func<EFDocument, bool>> predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDocument> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.DocumentMapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, ApiResponse response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDocument> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.mapper.DocumentMapEFToPOCO(x, response));
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
    <Hash>6b717752bac0e7768f7ce96fd582dc91</Hash>
</Codenesium>*/