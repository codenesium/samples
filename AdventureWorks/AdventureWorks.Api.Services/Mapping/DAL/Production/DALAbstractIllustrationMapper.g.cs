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
    <Hash>fe9f0c4415847def8f89369b0211c81e</Hash>
</Codenesium>*/