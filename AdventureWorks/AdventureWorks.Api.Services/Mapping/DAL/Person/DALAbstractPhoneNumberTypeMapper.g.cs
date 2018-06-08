using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public abstract class DALAbstractPhoneNumberTypeMapper
        {
                public virtual PhoneNumberType MapBOToEF(
                        BOPhoneNumberType bo)
                {
                        PhoneNumberType efPhoneNumberType = new PhoneNumberType();

                        efPhoneNumberType.SetProperties(
                                bo.ModifiedDate,
                                bo.Name,
                                bo.PhoneNumberTypeID);
                        return efPhoneNumberType;
                }

                public virtual BOPhoneNumberType MapEFToBO(
                        PhoneNumberType ef)
                {
                        if (ef == null)
                        {
                                return null;
                        }

                        var bo = new BOPhoneNumberType();

                        bo.SetProperties(
                                ef.PhoneNumberTypeID,
                                ef.ModifiedDate,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOPhoneNumberType> MapEFToBO(
                        List<PhoneNumberType> records)
                {
                        List<BOPhoneNumberType> response = new List<BOPhoneNumberType>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>759b31a3ede5c0de238052bf54480fb7</Hash>
</Codenesium>*/