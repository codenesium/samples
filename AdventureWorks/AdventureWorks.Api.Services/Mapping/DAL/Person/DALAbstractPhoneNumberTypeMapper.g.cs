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
    <Hash>051236b9d5be71073a00390e68d734ec</Hash>
</Codenesium>*/