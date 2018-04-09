using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		Guid Create(Nullable<short> documentLevel,
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
		            DateTime modifiedDate);

		void Update(Guid documentNode, Nullable<short> documentLevel,
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
		            DateTime modifiedDate);

		void Delete(Guid documentNode);

		Response GetById(Guid documentNode);

		POCODocument GetByIdDirect(Guid documentNode);

		Response GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>24ef2f92987c680321234031c732284a</Hash>
</Codenesium>*/