using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractContactTypeMapper
        {
                public virtual ContactType MapBOToEF(
                        BOContactType bo)
                {
                        ContactType efContactType = new ContactType();

                        efContactType.SetProperties(
                                bo.ContactTypeID,
                                bo.ModifiedDate,
                                bo.Name);
                        return efContactType;
                }

                public virtual BOContactType MapEFToBO(
                        ContactType ef)
                {
                        var bo = new BOContactType();

                        bo.SetProperties(
                                ef.ContactTypeID,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOContactType> MapEFToBO(
                        List<ContactType> records)
                {
                        List<BOContactType> response = new List<BOContactType>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>391c9bfedd14fe5d4437849614118ca7</Hash>
</Codenesium>*/