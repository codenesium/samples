using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		POCOFileType Create(ApiFileTypeModel model);

		void Update(int id,
		            ApiFileTypeModel model);

		void Delete(int id);

		POCOFileType Get(int id);

		List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>875b89b5bf500827f4077eec0d460e4e</Hash>
</Codenesium>*/