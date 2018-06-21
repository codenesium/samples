using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiVenueRequestModel : AbstractApiRequestModel
        {
                public ApiVenueRequestModel()
                        : base()
                {
                }

                public void SetProperties(
                        string address1,
                        string address2,
                        int adminId,
                        string email,
                        string facebook,
                        string name,
                        string phone,
                        int provinceId,
                        string website)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.AdminId = adminId;
                        this.Email = email;
                        this.Facebook = facebook;
                        this.Name = name;
                        this.Phone = phone;
                        this.ProvinceId = provinceId;
                        this.Website = website;
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

                private int adminId;

                [Required]
                public int AdminId
                {
                        get
                        {
                                return this.adminId;
                        }

                        set
                        {
                                this.adminId = value;
                        }
                }

                private string email;

                [Required]
                public string Email
                {
                        get
                        {
                                return this.email;
                        }

                        set
                        {
                                this.email = value;
                        }
                }

                private string facebook;

                [Required]
                public string Facebook
                {
                        get
                        {
                                return this.facebook;
                        }

                        set
                        {
                                this.facebook = value;
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

                private string phone;

                [Required]
                public string Phone
                {
                        get
                        {
                                return this.phone;
                        }

                        set
                        {
                                this.phone = value;
                        }
                }

                private int provinceId;

                [Required]
                public int ProvinceId
                {
                        get
                        {
                                return this.provinceId;
                        }

                        set
                        {
                                this.provinceId = value;
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
        }
}

/*<Codenesium>
    <Hash>04e0e22d1e4df2d8f161266edd7be226</Hash>
</Codenesium>*/