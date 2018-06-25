using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace FermataFishNS.Api.Contracts
{
        public partial class ApiStudioRequestModel : AbstractApiRequestModel
        {
                public ApiStudioRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
                        this.Name = name;
                        this.StateId = stateId;
                        this.Website = website;
                        this.Zip = zip;
                }

                private string address1;

                [Required]
                public string Address1
                {
                        get
                        {
                                return this.address1;
                        }

                        set
                        {
                                this.address1 = value;
                        }
                }

                private string address2;

                [Required]
                public string Address2
                {
                        get
                        {
                                return this.address2;
                        }

                        set
                        {
                                this.address2 = value;
                        }
                }

                private string city;

                [Required]
                public string City
                {
                        get
                        {
                                return this.city;
                        }

                        set
                        {
                                this.city = value;
                        }
                }

                private string name;

                [Required]
                public string Name
                {
                        get
                        {
                                return this.name;
                        }

                        set
                        {
                                this.name = value;
                        }
                }

                private int stateId;

                [Required]
                public int StateId
                {
                        get
                        {
                                return this.stateId;
                        }

                        set
                        {
                                this.stateId = value;
                        }
                }

                private string website;

                [Required]
                public string Website
                {
                        get
                        {
                                return this.website;
                        }

                        set
                        {
                                this.website = value;
                        }
                }

                private string zip;

                [Required]
                public string Zip
                {
                        get
                        {
                                return this.zip;
                        }

                        set
                        {
                                this.zip = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>c733ecc9c36d97e9c68ad1f93370e071</Hash>
</Codenesium>*/