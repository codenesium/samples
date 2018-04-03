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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractProductDocumentRepository(ILogger logger,
		                                         ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual int Create(Guid documentNode,
		                          DateTime modifiedDate)
		{
			var record = new EFProductDocument ();

			MapPOCOToEF(0, documentNode,
			            modifiedDate, record);

			this._context.Set<EFProductDocument>().Add(record);
			this._context.SaveChanges();
			return record.productID;
		}

		public virtual void Update(int productID, Guid documentNode,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",productID);
			}
			else
			{
				MapPOCOToEF(productID,  documentNode,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(int productID)
		{
			var record = this.SearchLinqEF(x => x.productID == productID).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFProductDocument>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(int productID, Response response)
		{
			this.SearchLinqPOCO(x => x.productID == productID,response);
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
			efProductDocument.productID = productID;
			efProductDocument.documentNode = documentNode;
			efProductDocument.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFProductDocument efProductDocument,Response response)
		{
			if(efProductDocument == null)
			{
				return;
			}
			response.AddProductDocument(new POCOProductDocument()
			{
				ProductID = efProductDocument.productID.ToInt(),
				DocumentNode = efProductDocument.documentNode,
				ModifiedDate = efProductDocument.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>b607f700fff5b77d7ec0d6b829841854</Hash>
</Codenesium>*/