using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractTeacherMapper
        {
                public virtual Teacher MapBOToEF(
                        BOTeacher bo)
                {
                        Teacher efTeacher = new Teacher();

                        efTeacher.SetProperties(
                                bo.Birthday,
                                bo.Email,
                                bo.FirstName,
                                bo.Id,
                                bo.LastName,
                                bo.Phone,
                                bo.StudioId);
                        return efTeacher;
                }

                public virtual BOTeacher MapEFToBO(
                        Teacher ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOTeacher();

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

                public virtual List<BOTeacher> MapEFToBO(
                        List<Teacher> records)
                {
                        List<BOTeacher> response = new List<BOTeacher>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>464335bbd3b3ad49ce089dfe22acf5a2</Hash>
</Codenesium>*/