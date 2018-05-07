using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		Guid Create(DocumentModel model);

		void Update(Guid documentNode,
		            DocumentModel model);

		void Delete(Guid documentNode);

		POCODocument Get(Guid documentNode);

		List<POCODocument> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>4499b783541d926e15447ae47a165fe6</Hash>
</Codenesium>*/