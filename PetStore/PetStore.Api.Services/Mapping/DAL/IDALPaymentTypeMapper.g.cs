using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;
using System;
using System.Collections.Generic;

namespace PetStoreNS.Api.Services
{
        public interface IDALPaymentTypeMapper
        {
                PaymentType MapBOToEF(
                        BOPaymentType bo);

                BOPaymentType MapEFToBO(
                        PaymentType efPaymentType);

                List<BOPaymentType> MapEFToBO(
                        List<PaymentType> records);
        }
}

/*<Codenesium>
    <Hash>701c5b2f6ce195d690f06b58d4229137</Hash>
</Codenesium>*/