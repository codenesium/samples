using System;
using System.Linq.Expressions;
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
		            byte[] document,
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
		            byte[] document,
		            Guid rowguid,
		            DateTime modifiedDate);

		void Delete(Guid documentNode);

		void GetById(Guid documentNode, Response response);

		void GetWhere(Expression<Func<EFDocument, bool>> predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");

		void GetWhereDynamic(string predicate, Response response,int skip = 0, int take = Int32.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>a4caad42ccfad77f1ab53cf61fdb82a1</Hash>
</Codenesium>*/