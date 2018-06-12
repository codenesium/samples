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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>6701cef12114abb0aada920f74f722cb</Hash>
</Codenesium>*/