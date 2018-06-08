using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractIllustrationMapper
        {
                public virtual Illustration MapBOToEF(
                        BOIllustration bo)
                {
                        Illustration efIllustration = new Illustration();

                        efIllustration.SetProperties(
                                bo.Diagram,
                                bo.IllustrationID,
                                bo.ModifiedDate);
                        return efIllustration;
                }

                public virtual BOIllustration MapEFToBO(
                        Illustration ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOIllustration();

                        bo.SetProperties(
                                ef.IllustrationID,
                                ef.Diagram,
                                ef.ModifiedDate);
                        return bo;
                }

                public virtual List<BOIllustration> MapEFToBO(
                        List<Illustration> records)
                {
                        List<BOIllustration> response = new List<BOIllustration>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0172f28d920137af3d46c6d49935adf1</Hash>
</Codenesium>*/