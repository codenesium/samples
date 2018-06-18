using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public abstract class AbstractBOVenue: AbstractBusinessObject
        {
                public AbstractBOVenue() : base()
                {
                }

                public virtual void SetProperties(int id,
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
                        this.Id = id;
                        this.Name = name;
                        this.Phone = phone;
                        this.ProvinceId = provinceId;
                        this.Website = website;
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public int AdminId { get; private set; }

                public string Email { get; private set; }

                public string Facebook { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public string Phone { get; private set; }

                public int ProvinceId { get; private set; }

                public string Website { get; private set; }
        }
}

/*<Codenesium>
    <Hash>412181fe7f10d656cd996bdb4fba94b9</Hash>
</Codenesium>*/