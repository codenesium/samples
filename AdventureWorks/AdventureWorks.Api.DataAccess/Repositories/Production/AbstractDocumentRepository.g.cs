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

		public AbstractDocumentRepository(
			ILogger logger,
			ApplicationDbContext context)
		{
			this.logger = logger;
			this.context = context;
		}

		public virtual Guid Create(
			Nullable<short> documentLevel,
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
			var record = new EFDocument();

			MapPOCOToEF(
				Guid.Empty,
				documentLevel,
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
				modifiedDate,
				record);

			this.context.Set<EFDocument>().Add(record);
			this.context.SaveChanges();
			return record.DocumentNode;
		}

		public virtual void Update(
			Guid documentNode,
			Nullable<short> documentLevel,
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
			var record = this.SearchLinqEF(x => x.DocumentNode == documentNode).FirstOrDefault();
			if (record == null)
			{
				this.logger.LogError($"Unable to find id:{documentNode}");
			}
			else
			{
				MapPOCOToEF(
					documentNode,
					documentLevel,
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
					modifiedDate,
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

		public virtual Response GetById(Guid documentNode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.DocumentNode == documentNode, response);
			return response;
		}

		public virtual POCODocument GetByIdDirect(Guid documentNode)
		{
			var response = new Response();

			this.SearchLinqPOCO(x => x.DocumentNode == documentNode, response);
			return response.Documents.FirstOrDefault();
		}

		public virtual Response GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCODynamic(predicate, response, skip, take, orderClause);
			return response;
		}

		public virtual List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			var response = new Response();

			this.SearchLinqPOCO(predicate, response, skip, take, orderClause);
			return response.Documents;
		}

		private void SearchLinqPOCO(Expression<Func<EFDocument, bool>> predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDocument> records = this.SearchLinqEF(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		private void SearchLinqPOCODynamic(string predicate, Response response, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			List<EFDocument> records = this.SearchLinqEFDynamic(predicate, skip, take, orderClause);
			records.ForEach(x => MapEFToPOCO(x, response));
		}

		protected virtual List<EFDocument> SearchLinqEF(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		protected virtual List<EFDocument> SearchLinqEFDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "")
		{
			throw new NotImplementedException("This method should be implemented in a derived class");
		}

		public static void MapPOCOToEF(
			Guid documentNode,
			Nullable<short> documentLevel,
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
			DateTime modifiedDate,
			EFDocument efDocument)
		{
			efDocument.SetProperties(documentNode, documentLevel, title, owner.ToInt(), folderFlag, fileName, fileExtension, revision, changeNumber.ToInt(), status, documentSummary, document1, rowguid, modifiedDate.ToDateTime());
		}

		public static void MapEFToPOCO(
			EFDocument efDocument,
			Response response)
		{
			if (efDocument == null)
			{
				return;
			}

			response.AddDocument(new POCODocument(efDocument.DocumentNode, efDocument.DocumentLevel, efDocument.Title, efDocument.Owner.ToInt(), efDocument.FolderFlag, efDocument.FileName, efDocument.FileExtension, efDocument.Revision, efDocument.ChangeNumber.ToInt(), efDocument.Status, efDocument.DocumentSummary, efDocument.Document1, efDocument.Rowguid, efDocument.ModifiedDate.ToDateTime()));

			EmployeeRepository.MapEFToPOCO(efDocument.Employee, response);
		}
	}
}

/*<Codenesium>
    <Hash>7886753b85053bfa22711455a4c234b9</Hash>
</Codenesium>*/