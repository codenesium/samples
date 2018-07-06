using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStudioResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
                        string address1,
                        string address2,
                        string city,
                        string name,
                        int stateId,
                        string website,
                        string zip)
                {
                        this.Id = id;
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.City = city;
                        this.Name = name;
                        this.StateId = stateId;
                        this.Website = website;
                        this.Zip = zip;

                        this.StateIdEntity = nameof(ApiResponse.States);
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public string City { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StateId { get; private set; }

                public string StateIdEntity { get; set; }

                public string Website { get; private set; }

                public string Zip { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f47e1fe69335e9bd7c37a016b217a4ac</Hash>
</Codenesium>*/