using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FileServiceNS.Api.Services
{
        public abstract class DALAbstractVersionInfoMapper
        {
                public virtual VersionInfo MapBOToEF(
                        BOVersionInfo bo)
                {
                        VersionInfo efVersionInfo = new VersionInfo();
                        efVersionInfo.SetProperties(
                                bo.AppliedOn,
                                bo.Description,
                                bo.Version);
                        return efVersionInfo;
                }

                public virtual BOVersionInfo MapEFToBO(
                        VersionInfo ef)
                {
                        var bo = new BOVersionInfo();

                        bo.SetProperties(
                                ef.Version,
                                ef.AppliedOn,
                                ef.Description);
                        return bo;
                }

                public virtual List<BOVersionInfo> MapEFToBO(
                        List<VersionInfo> records)
                {
                        List<BOVersionInfo> response = new List<BOVersionInfo>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>73cf47f148f44037efb9af272e2e04da</Hash>
</Codenesium>*/