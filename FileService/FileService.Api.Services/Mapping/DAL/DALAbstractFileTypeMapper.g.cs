using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;

namespace FileServiceNS.Api.Services
{
        public abstract class DALAbstractFileTypeMapper
        {
                public virtual FileType MapBOToEF(
                        BOFileType bo)
                {
                        FileType efFileType = new FileType();

                        efFileType.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efFileType;
                }

                public virtual BOFileType MapEFToBO(
                        FileType ef)
                {
                        var bo = new BOFileType();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOFileType> MapEFToBO(
                        List<FileType> records)
                {
                        List<BOFileType> response = new List<BOFileType>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8cee9624f505f41f6e625e5bd3b13dc8</Hash>
</Codenesium>*/