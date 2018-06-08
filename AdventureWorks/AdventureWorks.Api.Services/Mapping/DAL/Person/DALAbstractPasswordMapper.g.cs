using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractPasswordMapper
        {
                public virtual Password MapBOToEF(
                        BOPassword bo)
                {
                        Password efPassword = new Password();

                        efPassword.SetProperties(
                                bo.BusinessEntityID,
                                bo.ModifiedDate,
                                bo.PasswordHash,
                                bo.PasswordSalt,
                                bo.Rowguid);
                        return efPassword;
                }

                public virtual BOPassword MapEFToBO(
                        Password ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOPassword();

                        bo.SetProperties(
                                ef.BusinessEntityID,
                                ef.ModifiedDate,
                                ef.PasswordHash,
                                ef.PasswordSalt,
                                ef.Rowguid);
                        return bo;
                }

                public virtual List<BOPassword> MapEFToBO(
                        List<Password> records)
                {
                        List<BOPassword> response = new List<BOPassword>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>786cbb2f791ab8659294da245be13434</Hash>
</Codenesium>*/