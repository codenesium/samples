using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace NebulaNS.Api.Services
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
    <Hash>e46fcc644f96bdc7f51f833352983145</Hash>
</Codenesium>*/