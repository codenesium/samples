using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractActionTemplateVersionMapper
        {
                public virtual ActionTemplateVersion MapBOToEF(
                        BOActionTemplateVersion bo)
                {
                        ActionTemplateVersion efActionTemplateVersion = new ActionTemplateVersion();

                        efActionTemplateVersion.SetProperties(
                                bo.ActionType,
                                bo.Id,
                                bo.JSON,
                                bo.LatestActionTemplateId,
                                bo.Name,
                                bo.Version);
                        return efActionTemplateVersion;
                }

                public virtual BOActionTemplateVersion MapEFToBO(
                        ActionTemplateVersion ef)
                {
                        var bo = new BOActionTemplateVersion();

                        bo.SetProperties(
                                ef.Id,
                                ef.ActionType,
                                ef.JSON,
                                ef.LatestActionTemplateId,
                                ef.Name,
                                ef.Version);
                        return bo;
                }

                public virtual List<BOActionTemplateVersion> MapEFToBO(
                        List<ActionTemplateVersion> records)
                {
                        List<BOActionTemplateVersion> response = new List<BOActionTemplateVersion>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>7fb7a6fcb9a0044635670b5254ed53fe</Hash>
</Codenesium>*/