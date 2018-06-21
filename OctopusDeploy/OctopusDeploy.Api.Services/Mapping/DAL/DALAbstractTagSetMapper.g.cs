using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractTagSetMapper
        {
                public virtual TagSet MapBOToEF(
                        BOTagSet bo)
                {
                        TagSet efTagSet = new TagSet();
                        efTagSet.SetProperties(
                                bo.DataVersion,
                                bo.Id,
                                bo.JSON,
                                bo.Name,
                                bo.SortOrder);
                        return efTagSet;
                }

                public virtual BOTagSet MapEFToBO(
                        TagSet ef)
                {
                        var bo = new BOTagSet();

                        bo.SetProperties(
                                ef.Id,
                                ef.DataVersion,
                                ef.JSON,
                                ef.Name,
                                ef.SortOrder);
                        return bo;
                }

                public virtual List<BOTagSet> MapEFToBO(
                        List<TagSet> records)
                {
                        List<BOTagSet> response = new List<BOTagSet>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3a4fe37f0a97fa1e02880f0c3d0a0d7e</Hash>
</Codenesium>*/