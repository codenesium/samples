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

		public virtual List<POCOProductDocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(x => true, skip, take, orderClause);
		}

		public virtual POCOProductDocument Get(int productID)
		{
			return this.SearchLinqPOCO(x => x.ProductID == productID).FirstOrDefault();
		}

		public virtual POCOProductDocument Create(
			ApiProductDocumentModel model)
		{
			ProductDocument record = new ProductDocument();

			this.Mapper.ProductDocumentMapModelToEF(
				default (int),
				model,
				record);

			this.Context.Set<ProductDocument>().Add(record);
			this.Context.SaveChanges();
			return this.Mapper.ProductDocumentMapEFToPOCO(record);
		}

		public virtual void Update(
			int productID,
			ApiProductDocumentModel model)
		{
			ProductDocument record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
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
			ProductDocument record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.Context.Set<ProductDocument>().Remove(record);
				this.Context.SaveChanges();
			}
		}

		protected List<POCOProductDocument> Where(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			return this.SearchLinqPOCO(predicate, skip, take, orderClause);
		}

		private List<POCOProductDocument> SearchLinqPOCO(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<POCOProductDocument> response = new List<POCOProductDocument>();
			List<ProductDocument> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => response.Add(this.Mapper.ProductDocumentMapEFToPOCO(x)));
			return response;
		}

		private List<ProductDocument> SearchLinqEF(Expression<Func<ProductDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDocument.ProductID)} ASC";
			}
			return this.Context.Set<ProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductDocument>();
		}

		private List<ProductDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			if (string.IsNullOrWhiteSpace(orderClause))
			{
				orderClause = $"{nameof(ProductDocument.ProductID)} ASC";
			}

			return this.Context.Set<ProductDocument>().Where(predicate).AsQueryable().OrderBy(orderClause).Skip(skip).Take(take).ToList<ProductDocument>();
		}
	}
}

/*<Codenesium>
    <Hash>53f9bd3c6f7d639cb410ab69a4d081e5</Hash>
</Codenesium>*/