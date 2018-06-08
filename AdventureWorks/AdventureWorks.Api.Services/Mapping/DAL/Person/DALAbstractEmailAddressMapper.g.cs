using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractEmailAddressMapper
        {
                public virtual EmailAddress MapBOToEF(
                        BOEmailAddress bo)
                {
                        EmailAddress efEmailAddress = new EmailAddress();

                        efEmailAddress.SetProperties(
                                bo.BusinessEntityID,
                                bo.EmailAddress1,
                                bo.EmailAddressID,
                                bo.ModifiedDate,
                                bo.Rowguid);
                        return efEmailAddress;
                }

                public virtual BOEmailAddress MapEFToBO(
                        EmailAddress ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOEmailAddress();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.EmailAddress1,
                                ef.EmailAddressID,
                                ef.ModifiedDate,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOEmailAddress> MapEFToBO(
                        List<EmailAddress> records)
                {
                        List<BOEmailAddress> response = new List<BOEmailAddress>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>3b97dd9cba81fc7e509ed697f19ca62c</Hash>
</Codenesium>*/