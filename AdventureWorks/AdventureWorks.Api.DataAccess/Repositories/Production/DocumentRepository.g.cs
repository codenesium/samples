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
		protected ApplicationContext _context;
		protected ILogger _logger;

		public AbstractDocumentRepository(ILogger logger,
		                                  ApplicationContext context)
		{
			this._logger = logger;
			this._context = context;
		}

		public virtual Guid Create(Nullable<short> documentLevel,
		                           string title,
		                           int owner,
		                           bool folderFlag,
		                           string fileName,
		                           string fileExtension,
		                           string revision,
		                           int changeNumber,
		                           int status,
		                           string documentSummary,
		                           byte[] document,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record = new EFDocument ();

			MapPOCOToEF(Guid.Empty, documentLevel,
			            title,
			            owner,
			            folderFlag,
			            fileName,
			            fileExtension,
			            revision,
			            changeNumber,
			            status,
			            documentSummary,
			            document,
			            rowguid,
			            modifiedDate, record);

			this._context.Set<EFDocument>().Add(record);
			this._context.SaveChanges();
			return record.documentNode;
		}

		public virtual void Update(Guid documentNode, Nullable<short> documentLevel,
		                           string title,
		                           int owner,
		                           bool folderFlag,
		                           string fileName,
		                           string fileExtension,
		                           string revision,
		                           int changeNumber,
		                           int status,
		                           string documentSummary,
		                           byte[] document,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.documentNode == documentNode).FirstOrDefault();
			if (record == null)
			{
				this._logger.LogError("Unable to find id:{0}",documentNode);
			}
			else
			{
				MapPOCOToEF(documentNode,  documentLevel,
				            title,
				            owner,
				            folderFlag,
				            fileName,
				            fileExtension,
				            revision,
				            changeNumber,
				            status,
				            documentSummary,
				            document,
				            rowguid,
				            modifiedDate, record);
				this._context.SaveChanges();
			}
		}

		public virtual void Delete(Guid documentNode)
		{
			var record = this.SearchLinqEF(x => x.documentNode == documentNode).FirstOrDefault();

			if (record == null)
			{
				return;
			}
			else
			{
				this._context.Set<EFDocument>().Remove(record);
				this._context.SaveChanges();
			}
		}

		public virtual void GetById(Guid documentNode, Response response)
		{
			this.SearchLinqPOCO(x => x.documentNode == documentNode,response);
		}

		protected virtual List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDocument> SearchLinqEFDynamic(string predicate,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public virtual void GetWhere(Expression<Func<EFDocument, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
		}

		public virtual void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
		}

		private void SearchLinqPOCO(Expression<Func<EFDocument, bool>> predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDocument> records = this.SearchLinqEF(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		private void SearchLinqPOCODynamic(string predicate,Response response,int skip=0,int take=Int32.MaxValue,string orderClause="")
		{
			List<EFDocument> records = this.SearchLinqEFDynamic(predicate,skip,take,orderClause);
			records.ForEach(x => MapEFToPOCO(x,response));
		}

		public static void MapPOCOToEF(Guid documentNode, Nullable<short> documentLevel,
		                               string title,
		                               int owner,
		                               bool folderFlag,
		                               string fileName,
		                               string fileExtension,
		                               string revision,
		                               int changeNumber,
		                               int status,
		                               string documentSummary,
		                               byte[] document,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFDocument   efDocument)
		{
			efDocument.documentNode = documentNode;
			efDocument.documentLevel = documentLevel;
			efDocument.title = title;
			efDocument.owner = owner;
			efDocument.folderFlag = folderFlag;
			efDocument.fileName = fileName;
			efDocument.fileExtension = fileExtension;
			efDocument.revision = revision;
			efDocument.changeNumber = changeNumber;
			efDocument.status = status;
			efDocument.documentSummary = documentSummary;
			efDocument.document = document;
			efDocument.rowguid = rowguid;
			efDocument.modifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFDocument efDocument,Response response)
		{
			if(efDocument == null)
			{
				return;
			}
			response.AddDocument(new POCODocument()
			{
				DocumentNode = efDocument.documentNode,
				DocumentLevel = efDocument.documentLevel,
				Title = efDocument.title,
				Owner = efDocument.owner.ToInt(),
				FolderFlag = efDocument.folderFlag,
				FileName = efDocument.fileName,
				FileExtension = efDocument.fileExtension,
				Revision = efDocument.revision,
				ChangeNumber = efDocument.changeNumber.ToInt(),
				Status = efDocument.status,
				DocumentSummary = efDocument.documentSummary,
				Document = efDocument.document,
				Rowguid = efDocument.rowguid,
				ModifiedDate = efDocument.modifiedDate.ToDateTime(),
			});
		}
	}
}

/*<Codenesium>
    <Hash>fa4fad4a5e52ee0d77c6dcd96af7f879</Hash>
</Codenesium>*/