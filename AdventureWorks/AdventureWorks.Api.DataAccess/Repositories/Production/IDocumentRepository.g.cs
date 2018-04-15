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

		ApiResponse GetById(Guid documentNode);

		POCODocument GetByIdDirect(Guid documentNode);

		ApiResponse GetWhere(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		List<POCODocument> GetWhereDirect(Expression<Func<EFDocument, bool>> predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");

		ApiResponse GetWhereDynamic(string predicate, int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>fdf068fdf015d3d96a0f8a24239e3b3d</Hash>
</Codenesium>*/