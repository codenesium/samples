using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiVenueResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
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
                        this.Id = id;
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.AdminId = adminId;
                        this.Email = email;
                        this.Facebook = facebook;
                        this.Name = name;
                        this.Phone = phone;
                        this.ProvinceId = provinceId;
                        this.Website = website;

                        this.AdminIdEntity = nameof(ApiResponse.Admins);
                        this.ProvinceIdEntity = nameof(ApiResponse.Provinces);
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public int AdminId { get; private set; }

                public string AdminIdEntity { get; set; }

                public string Email { get; private set; }

                public string Facebook { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public string Phone { get; private set; }

                public int ProvinceId { get; private set; }

                public string ProvinceIdEntity { get; set; }

                public string Website { get; private set; }
        }
}

/*<Codenesium>
    <Hash>9fd9b3a73d60664f5b1713c450844ad1</Hash>
</Codenesium>*/