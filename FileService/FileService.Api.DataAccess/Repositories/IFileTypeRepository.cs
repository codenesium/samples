using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
	public partial interface IFileTypeRepository
	{
		Task<FileType> Create(FileType item);

		Task Update(FileType item);

		Task Delete(int id);

		Task<FileType> Get(int id);

		Task<List<FileType>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<File>> FilesByFileTypeId(int fileTypeId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f0254d46d461316ef50d0fbf9bab033a</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/