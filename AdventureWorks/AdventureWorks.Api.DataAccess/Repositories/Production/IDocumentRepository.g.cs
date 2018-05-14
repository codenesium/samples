using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		POCODocument Create(ApiDocumentModel model);

		void Update(Guid documentNode,
		            ApiDocumentModel model);

		void Delete(Guid documentNode);

		POCODocument Get(Guid documentNode);

		List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		POCODocument GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);

		List<POCODocument> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>15f485d4ba113fa8e711939628f9c787</Hash>
</Codenesium>*/