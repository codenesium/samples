using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using FileServiceNS.Api.Contracts;

namespace FileServiceNS.Api.DataAccess
{
	public interface IFileTypeRepository
	{
		int Create(FileTypeModel model);

		void Update(int id,
		            FileTypeModel model);

		void Delete(int id);

		POCOFileType Get(int id);

		List<POCOFileType> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>30f9b114f2f1e7823a43fe8bbe749edd</Hash>
</Codenesium>*/