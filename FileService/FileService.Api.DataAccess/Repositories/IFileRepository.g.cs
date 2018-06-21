using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FileServiceNS.Api.DataAccess
{
        public interface IFileRepository
        {
                Task<File> Create(File item);

                Task Update(File item);

                Task Delete(int id);

                Task<File> Get(int id);

                Task<List<File>> All(int limit = int.MaxValue, int offset = 0);

                Task<Bucket> GetBucket(int bucketId);

                Task<FileType> GetFileType(int fileTypeId);
        }
}

/*<Codenesium>
    <Hash>de10083b9c1d8758cb8a1bf6d0b8b0b4</Hash>
</Codenesium>*/