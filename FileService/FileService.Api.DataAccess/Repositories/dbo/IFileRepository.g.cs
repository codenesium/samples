using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileRepository
	{
		int Create(FileModel model);

		void Update(int id,
		            FileModel model);

		void Delete(int id);

		POCOFile Get(int id);

		List<POCOFile> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>ade3dae9d65999eee8a2bfa4de3c1d53</Hash>
</Codenesium>*/