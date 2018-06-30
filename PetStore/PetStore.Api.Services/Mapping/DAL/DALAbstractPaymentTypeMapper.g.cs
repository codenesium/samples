using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
        public abstract class DALAbstractPaymentTypeMapper
        {
                public virtual PaymentType MapBOToEF(
                        BOPaymentType bo)
                {
                        PaymentType efPaymentType = new PaymentType();
                        efPaymentType.SetProperties(
                                bo.Id,
                                bo.Name);
                        return efPaymentType;
                }

                public virtual BOPaymentType MapEFToBO(
                        PaymentType ef)
                {
                        var bo = new BOPaymentType();

                        bo.SetProperties(
                                ef.Id,
                                ef.Name);
                        return bo;
                }

                public virtual List<BOPaymentType> MapEFToBO(
                        List<PaymentType> records)
                {
                        List<BOPaymentType> response = new List<BOPaymentType>();

                        records.ForEach(r =>
                        {
                                response.Add(this.MapEFToBO(r));
                        });

                        return response;
                }
        }
}

/*<Codenesium>
    <Hash>0b5634e0e04a0256708c02b1ce85ea2c</Hash>
</Codenesium>*/