using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using AdventureWorksNS.Api.Contracts;

namespace AdventureWorksNS.Api.DataAccess
{
	public interface IDocumentRepository
	{
		Task<DTODocument> Create(DTODocument dto);

		Task Update(Guid documentNode,
		            DTODocument dto);

		Task Delete(Guid documentNode);

		Task<DTODocument> Get(Guid documentNode);

		Task<List<DTODocument>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");

		Task<DTODocument> GetDocumentLevelDocumentNode(Nullable<short> documentLevel,Guid documentNode);
		Task<List<DTODocument>> GetFileNameRevision(string fileName,string revision);
	}
}

/*<Codenesium>
    <Hash>3c8aca7666864d4792ba35a400812f49</Hash>
</Codenesium>*/