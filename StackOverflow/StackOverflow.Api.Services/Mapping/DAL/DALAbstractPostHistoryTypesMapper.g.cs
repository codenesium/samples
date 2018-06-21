using Microsoft.EntityFrameworkCore;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace StackOverflowNS.Api.Services
{
        public abstract class DALAbstractPostHistoryTypesMapper
        {
                public virtual PostHistoryTypes MapBOToEF(
                        BOPostHistoryTypes bo)
                {
                        PostHistoryTypes efPostHistoryTypes = new PostHistoryTypes();
                        efPostHistoryTypes.SetProperties(
                                bo.Id,
                                bo.Type);
                        return efPostHistoryTypes;
                }

                public virtual BOPostHistoryTypes MapEFToBO(
                        PostHistoryTypes ef)
                {
                        var bo = new BOPostHistoryTypes();

                        bo.SetProperties(
                                ef.Id,
                                ef.Type);
                        return bo;
                }

                public virtual List<BOPostHistoryTypes> MapEFToBO(
                        List<PostHistoryTypes> records)
                {
                        List<BOPostHistoryTypes> response = new List<BOPostHistoryTypes>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f367f209a3f384bee6d3d0172bf05fc0</Hash>
</Codenesium>*/