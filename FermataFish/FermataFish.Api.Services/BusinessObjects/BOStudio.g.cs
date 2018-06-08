using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace FermataFishNS.Api.Services
{
        public partial class BOStudio: AbstractBusinessObject
        {
                public BOStudio() : base()
                {
                }

                public void SetProperties(int id,
                                          string address1,
                                          string address2,
                                          string city,
                                          string name,
                                          int stateId,
                                          string website,
                                          string zip)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.City = city;
                        this.Id = id;
                        this.Name = name;
                        this.StateId = stateId;
                        this.Website = website;
                        this.Zip = zip;
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public string City { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public int StateId { get; private set; }

                public string Website { get; private set; }

                public string Zip { get; private set; }
        }
}

/*<Codenesium>
    <Hash>16bc3c35fd99803e264fe15cc31781f9</Hash>
</Codenesium>*/