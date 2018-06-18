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
    <Hash>e2dfc1901d6805e5450a05193f8a1e87</Hash>
</Codenesium>*/