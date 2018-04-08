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

		public AbstractDocumentRepository(ILogger logger,
		                                  ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
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
		                           byte[] document1,
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
			            document1,
			            rowguid,
			            modifiedDate, record);

			this.context.Set<EFDocument>().Add(record);
			this.context.SaveChanges();
			return record.DocumentNode;
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
		                           byte[] document1,
		                           Guid rowguid,
		                           DateTime modifiedDate)
		{
			var record =  this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError("Unable to find id:{0}",documentNode);
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
				            document1,
				            rowguid,
				            modifiedDate, record);
				this.context.SaveChanges();
			}
		}

		public virtual void Delete(Guid documentNode)
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

		public virtual void GetById(Guid documentNode, Response response)
		{
			this.SearchLinqPOCO(x => x.DocumentNode == documentNode,response);
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

		public virtual List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Documents;
		}
		public virtual POCODocument GetByIdDirect(Guid documentNode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.DocumentNode == documentNode,response);
			return response.Documents.FirstOrDefault();
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
		                               byte[] document1,
		                               Guid rowguid,
		                               DateTime modifiedDate, EFDocument   efDocument)
		{
			efDocument.DocumentNode = documentNode;
			efDocument.DocumentLevel = documentLevel;
			efDocument.Title = title;
			efDocument.Owner = owner;
			efDocument.FolderFlag = folderFlag;
			efDocument.FileName = fileName;
			efDocument.FileExtension = fileExtension;
			efDocument.Revision = revision;
			efDocument.ChangeNumber = changeNumber;
			efDocument.Status = status;
			efDocument.DocumentSummary = documentSummary;
			efDocument.Document1 = document1;
			efDocument.Rowguid = rowguid;
			efDocument.ModifiedDate = modifiedDate;
		}

		public static void MapEFToPOCO(EFDocument efDocument,Response response)
		{
			if(efDocument == null)
			{
				return;
			}
			response.AddDocument(new POCODocument()
			{
				DocumentNode = efDocument.DocumentNode,
				DocumentLevel = efDocument.DocumentLevel,
				Title = efDocument.Title,
				FolderFlag = efDocument.FolderFlag,
				FileName = efDocument.FileName,
				FileExtension = efDocument.FileExtension,
				Revision = efDocument.Revision,
				ChangeNumber = efDocument.ChangeNumber.ToInt(),
				Status = efDocument.Status,
				DocumentSummary = efDocument.DocumentSummary,
				Document1 = efDocument.Document1,
				Rowguid = efDocument.Rowguid,
				ModifiedDate = efDocument.ModifiedDate.ToDateTime(),

				Owner = new ReferenceEntity<int>(efDocument.Owner,
				                                 "Employees"),
			});

			EmployeeRepository.MapEFToPOCO(efDocument.Employee, response);
		}
	}
}

/*<Codenesium>
    <Hash>9d83d9d759c5d4e644df09bcd3a86080</Hash>
</Codenesium>*/