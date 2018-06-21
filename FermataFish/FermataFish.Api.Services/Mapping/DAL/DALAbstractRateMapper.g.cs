using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>743e3af92838d92f18ebc091c1f76e48</Hash>
</Codenesium>*/