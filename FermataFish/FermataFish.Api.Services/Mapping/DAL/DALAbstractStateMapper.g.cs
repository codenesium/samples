using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public abstract class DALAbstractStateMapper
        {
                public virtual State MapBOToEF(
                        BOState bo)
                {
                        State efState = new State();

                        efState.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efState;
                }

                public virtual BOState MapEFToBO(
                        State ef)
                {
                        var bo = new BOState();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOState> MapEFToBO(
                        List<State> records)
                {
                        List<BOState> response = new List<BOState>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>a270a8dd4024c6ebbb0b3ff8ba8aee20</Hash>
</Codenesium>*/