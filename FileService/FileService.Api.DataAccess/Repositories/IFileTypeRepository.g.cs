using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IFileTypeRepository
        {
                Task<FileType> Create(FileType item);

                Task Update(FileType item);

                Task Delete(int id);

                Task<FileType> Get(int id);

                Task<List<FileType>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<File>> Files(int fileTypeId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>e237a8131eb0db82d8fb84536ec6c91d</Hash>
</Codenesium>*/