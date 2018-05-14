using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		POCOFile Create(FileModel model);

		void Update(int id,
		            FileModel model);

		void Delete(int id);

		POCOFile Get(int id);

		List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0f2946c4db9664a173835a046508a390</Hash>
</Codenesium>*/