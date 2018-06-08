using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NebulaNS.Api.Contracts;
using NebulaNS.Api.DataAccess;

namespace NebulaNS.Api.Services
{
        public abstract class DALAbstractOrganizationMapper
        {
                public virtual Organization MapBOToEF(
                        BOOrganization bo)
                {
                        Organization efOrganization = new Organization();

                        efOrganization.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efOrganization;
                }

                public virtual BOOrganization MapEFToBO(
                        Organization ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOOrganization();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOOrganization> MapEFToBO(
                        List<Organization> records)
                {
                        List<BOOrganization> response = new List<BOOrganization>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a887b2b8833fefe791fb7044b9bcbd97</Hash>
</Codenesium>*/