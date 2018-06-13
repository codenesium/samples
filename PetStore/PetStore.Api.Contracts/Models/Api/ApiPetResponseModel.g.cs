using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;

namespace PetStoreNS.Api.Contracts
{
        public partial class ApiPetResponseModel: AbstractApiPetResponseModel
        {
                public ApiPetResponseModel()
                        : base()
                {
                }
        }
}

/*<Codenesium>
    <Hash>0f0948f680b3e3c133c7b26026091316</Hash>
</Codenesium>*/