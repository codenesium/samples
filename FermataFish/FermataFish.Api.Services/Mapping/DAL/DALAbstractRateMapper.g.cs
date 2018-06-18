using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractRateMapper
        {
                public virtual Rate MapBOToEF(
                        BORate bo)
                {
                        Rate efRate = new Rate();

                        efRate.SetProperties(
                                bo.AmountPerMinute,
                                bo.Id,
                                bo.TeacherId,
                                bo.TeacherSkillId);
                        return efRate;
                }

                public virtual BORate MapEFToBO(
                        Rate ef)
                {
                        var bo = new BORate();

                        bo.SetProperties(
                                ef.Id,
                                ef.AmountPerMinute,
                                ef.TeacherId,
                                ef.TeacherSkillId);
                        return bo;
                }

                public virtual List<BORate> MapEFToBO(
                        List<Rate> records)
                {
                        List<BORate> response = new List<BORate>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>ec9c39ec5abfa7bc2286906efb28a561</Hash>
</Codenesium>*/