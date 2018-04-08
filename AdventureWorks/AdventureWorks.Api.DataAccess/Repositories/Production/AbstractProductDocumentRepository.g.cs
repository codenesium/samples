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
		protected ApplicationDbContext context;
		protected ILogger logger;

		public AbstractProductDocumentRepository(ILogger logger,
		                                         ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual int Create(Guid documentNode,
		                          DateTime modifiedDate)
		{
			var record = new EFProductDocument ();

			MapPOCOToEF(0, documentNode,
			            modifiedDate, record);

			this.context.Set<EFProductDocument>().Add(record);
			this.context.SaveChanges();
			return record.ProductID;
		}

		public virtual void Update(int productID, Guid documentNode,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  documentNode,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(int productID)
		{
			var record = this.SearchLinqEF(x => x.ProductID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this.context.Set<EFProductDocument>().Remove(record);
				this.context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.ProductID == productID,response);
		}

		protected virtual List<EFProductDocument> SearchLinqEF(Expression<Func<EFProductDocument, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFProductDocument> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFProductDocument, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		public virtual List<POCOProductDocument > GetWhereDirect(Expression<Func<EFProductDocument, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.ProductDocuments;
		}
		public virtual POCOProductDocument GetByIdDirect(int productID)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.ProductID == productID,response);
			return response.ProductDocuments.FirstOrDefault();
		}

		private void SearchLinqPOCO(Expression<Func<EFProductDocument, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductDocument> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFProductDocument> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(int productID, Guid documentNode,
		                               DateTime modifiedDate, EFProductDocument   efProductDocument)
		{
			efProductDocument.ProductID = productID;
			efProductDocument.DocumentNode = documentNode;
			efProductDocument.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductDocument efProductDocument,Response response)
		{
			if(efProductDocument == null)
			{
				return;
			}
			response.AddProductDocument(new POCOProductDocument()
			{
				ModifiedDate = efProductDocument.ModifiedDate.ToDateTime(),

				ProductID = new ReferenceEntity<int>(efProductDocument.ProductID,
				                                     "Products"),
				DocumentNode = new ReferenceEntity<Guid>(efProductDocument.DocumentNode,
				                                         "Documents"),
			});

			ProductRepository.MapEFToPOCO(efProductDocument.Product, response);

			DocumentRepository.MapEFToPOCO(efProductDocument.Document, response);
		}
	}
}

/*<Codenesium>
    <Hash>f3362625b6e2b198ef6abe9c2752c44f</Hash>
</Codenesium>*/