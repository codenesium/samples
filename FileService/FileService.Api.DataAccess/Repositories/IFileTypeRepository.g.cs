using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>1fbc8b04d905761cab5d8999be8220d5</Hash>
</Codenesium>*/