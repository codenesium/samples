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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>285c4341fbbd81d5322c02d61c0e97fc</Hash>
</Codenesium>*/