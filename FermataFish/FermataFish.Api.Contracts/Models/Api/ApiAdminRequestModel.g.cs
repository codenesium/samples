using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiAdminRequestModel : AbstractApiRequestModel
        {
                public ApiAdminRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        DateTime? birthday,
                        string email,
                        string firstName,
                        string lastName,
                        string phone,
                        int studioId)
                {
                        this.Birthday = birthday;
                        this.Email = email;
                        this.FirstName = firstName;
                        this.LastName = lastName;
                        this.Phone = phone;
                        this.StudioId = studioId;
                }

                [JsonProperty]
                public DateTime? Birthday { get; private set; }

                [JsonProperty]
                public string Email { get; private set; }

                [JsonProperty]
                public string FirstName { get; private set; }

                [JsonProperty]
                public string LastName { get; private set; }

                [JsonProperty]
                public string Phone { get; private set; }

                [JsonProperty]
                public int StudioId { get; private set; }
        }
}

/*<Codenesium>
    <Hash>e713b93d57ab19f5096bae4458c8def8</Hash>
</Codenesium>*/