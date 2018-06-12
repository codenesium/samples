using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public abstract class DALAbstractUserMapper
        {
                public virtual User MapBOToEF(
                        BOUser bo)
                {
                        User efUser = new User();

                        efUser.SetProperties(
                                bo.DisplayName,
                                bo.EmailAddress,
                                bo.ExternalId,
                                bo.ExternalIdentifiers,
                                bo.Id,
                                bo.IdentificationToken,
                                bo.IsActive,
                                bo.IsService,
                                bo.JSON,
                                bo.Username);
                        return efUser;
                }

                public virtual BOUser MapEFToBO(
                        User ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOUser();

                        bo.SetProperties(
                                ef.Id,
                                ef.DisplayName,
                                ef.EmailAddress,
                                ef.ExternalId,
                                ef.ExternalIdentifiers,
                                ef.IdentificationToken,
                                ef.IsActive,
                                ef.IsService,
                                ef.JSON,
                                ef.Username);
                        return bo;
                }

                public virtual List<BOUser> MapEFToBO(
                        List<User> records)
                {
                        List<BOUser> response = new List<BOUser>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>8c8f0cbf2c087add029f61afcb6a5a66</Hash>
</Codenesium>*/