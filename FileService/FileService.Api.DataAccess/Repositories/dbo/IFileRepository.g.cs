using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		POCOFile Create(ApiFileModel model);

		void Update(int id,
		            ApiFileModel model);

		void Delete(int id);

		POCOFile Get(int id);

		List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>17d810c76590b6af06d2e6acca403027</Hash>
</Codenesium>*/