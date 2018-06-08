using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractAdminMapper
        {
                public virtual Admin MapBOToEF(
                        BOAdmin bo)
                {
                        Admin efAdmin = new Admin();

                        efAdmin.SetProperties(
                                bo.Birthday,
                                bo.Email,
                                bo.FirstName,
                                bo.Id,
                                bo.LastName,
                                bo.Phone,
                                bo.StudioId);
                        return efAdmin;
                }

                public virtual BOAdmin MapEFToBO(
                        Admin ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOAdmin();

                        bo.SetProperties(
                                ef.Id,
                                ef.Birthday,
                                ef.Email,
                                ef.FirstName,
                                ef.LastName,
                                ef.Phone,
                                ef.StudioId);
                        return bo;
                }

                public virtual List<BOAdmin> MapEFToBO(
                        List<Admin> records)
                {
                        List<BOAdmin> response = new List<BOAdmin>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>27b2dd15f595994a0c73adc3b5426555</Hash>
</Codenesium>*/