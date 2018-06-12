using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractCommunityActionTemplateMapper
        {
                public virtual CommunityActionTemplate MapBOToEF(
                        BOCommunityActionTemplate bo)
                {
                        CommunityActionTemplate efCommunityActionTemplate = new CommunityActionTemplate();

                        efCommunityActionTemplate.SetProperties(
                                bo.ExternalId,
                                bo.Id,
                                bo.JSON,
                                bo.Name);
                        return efCommunityActionTemplate;
                }

                public virtual BOCommunityActionTemplate MapEFToBO(
                        CommunityActionTemplate ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOCommunityActionTemplate();

                        bo.SetProperties(
                                ef.Id,
                                ef.ExternalId,
                                ef.JSON,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOCommunityActionTemplate> MapEFToBO(
                        List<CommunityActionTemplate> records)
                {
                        List<BOCommunityActionTemplate> response = new List<BOCommunityActionTemplate>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>e8086a372a3b4bed218a05e119033447</Hash>
</Codenesium>*/