using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractProjectGroupMapper
        {
                public virtual ProjectGroup MapBOToEF(
                        BOProjectGroup bo)
                {
                        ProjectGroup efProjectGroup = new ProjectGroup();

                        efProjectGroup.SetProperties(
                                bo.DataVersion,
                                bo.Id,
                                bo.JSON,
                                bo.Name);
                        return efProjectGroup;
                }

                public virtual BOProjectGroup MapEFToBO(
                        ProjectGroup ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOProjectGroup();

                        bo.SetProperties(
                                ef.Id,
                                ef.DataVersion,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOProjectGroup> MapEFToBO(
                        List<ProjectGroup> records)
                {
                        List<BOProjectGroup> response = new List<BOProjectGroup>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>9eb25a80e77cc72b77f6c56a1fbad27b</Hash>
</Codenesium>*/