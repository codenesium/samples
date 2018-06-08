using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractLessonStatusMapper
        {
                public virtual LessonStatus MapBOToEF(
                        BOLessonStatus bo)
                {
                        LessonStatus efLessonStatus = new LessonStatus();

                        efLessonStatus.SetProperties(
                                bo.Id,
                                bo.Name,
                                bo.StudioId);
                        return efLessonStatus;
                }

                public virtual BOLessonStatus MapEFToBO(
                        LessonStatus ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOLessonStatus();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name,
                                ef.StudioId);
                        return bo;
                }

                public virtual List<BOLessonStatus> MapEFToBO(
                        List<LessonStatus> records)
                {
                        List<BOLessonStatus> response = new List<BOLessonStatus>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>acf6851a02cc2ca056357d902d404f61</Hash>
</Codenesium>*/