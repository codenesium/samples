using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PetStoreNS.Api.Contracts;
using PetStoreNS.Api.DataAccess;

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
    <Hash>1877e910a8584d3388178de1925a8ea4</Hash>
</Codenesium>*/