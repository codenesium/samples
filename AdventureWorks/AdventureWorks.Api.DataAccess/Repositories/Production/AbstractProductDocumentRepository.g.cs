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
	public abstract class AbstractProductDocumentRepository
	{
		protected ApplicationDbContext Context { get; }
		protected ILogger Logger { get; }
		protected IObjectMapper Mapper { get; }

		public AbstractProductDocumentRepository(
			IObjectMapper mapper,
			ILogger logger,
			ApplicationDbContext context)
		{
			this.Mapper = mapper;
			this.Logger = logger;
			this.Context = context;
		}

		public virtual int Create(
			ProductDocumentModel model)
		{
			EFProductDocument record = new EFProductDocument();

			this.Mapper.ProductDocumentMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<EFProductDocument>().Add(record);
			this.Context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(
			int productID,
			ProductDocumentModel model)
		{
			EFProductDocument record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				throw new RecordNotFoundException($"Unable to find id:{productID}");
			}
			else
			{
				this.Mapper.ProductDocumentMapModelToEF(
					productID,
					model,
					record);
				this.Context.SaveChanges();
			}
		}

		public virtual void Delete(
			int productID)
		{
			EFProductDocument record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<EFProductDocument>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		public virtual ApiResponse GetById(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID);
		}

		public virtual POCOProductDocument GetByIdDirect(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).ProductDocuments.FirstOrDefault();
		}

		public virtual ApiResponse GetWhere(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		public virtual ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCODynamic(predicate, skip, take, orderClause);
		}

		public virtual List<POCOProductDocument> GetWhereDirect(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause).ProductDocuments;
		}

		private ApiResponse SearchLinqPOCO(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductDocument> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductDocumentMapEFToPOCO(x, response));
			return response;
		}

		private ApiResponse SearchLinqPOCODynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			ApiResponse response = new ApiResponse();

			List<EFProductDocument> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => this.Mapper.ProductDocumentMapEFToPOCO(x, response));
			return response;
		}

		protected virtual List<EFProductDocument> SearchLinqEF(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}
	}
}

/*<Codenesium>
    <Hash>1ef9ef2ea8660c0cb712225d1b7542fd</Hash>
</Codenesium>*/