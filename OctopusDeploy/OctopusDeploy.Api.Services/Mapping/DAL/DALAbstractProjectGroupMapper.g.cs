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
    <Hash>7607b3f97c6e7c13ceb890a4f2e4ec96</Hash>
</Codenesium>*/