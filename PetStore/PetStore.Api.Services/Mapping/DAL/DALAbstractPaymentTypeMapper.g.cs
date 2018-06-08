using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
                        if (ef == null)
                        {
                                return null;
                        }

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
    <Hash>f0246cd1c7bbe591bc168913840e1c3b</Hash>
</Codenesium>*/