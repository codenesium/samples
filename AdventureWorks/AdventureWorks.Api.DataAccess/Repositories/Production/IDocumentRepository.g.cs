using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		Guid Create(
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
			DateTime modifiedDate);

		void Update(Guid documentNode,
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
		            DateTime modifiedDate);

		void Delete(Guid documentNode);

		Response GetById(Guid documentNode);

		POCODocument GetByIdDirect(Guid documentNode);

		Response GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		Response GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>78b4cb10e225f92ac859af1a89182d1d</Hash>
</Codenesium>*/