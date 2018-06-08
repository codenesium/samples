using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractCultureMapper
        {
                public virtual Culture MapBOToEF(
                        BOCulture bo)
                {
                        Culture efCulture = new Culture();

                        efCulture.SetProperties(
                                bo.CultureID,
                                bo.ModifiedDate,
                                bo.Name);
                        return efCulture;
                }

                public virtual BOCulture MapEFToBO(
                        Culture ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOCulture();

                        bo.SetProperties(
                                ef.CultureID,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOCulture> MapEFToBO(
                        List<Culture> records)
                {
                        List<BOCulture> response = new List<BOCulture>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>f3e292b5749d5923f6d81cd74df706f9</Hash>
</Codenesium>*/