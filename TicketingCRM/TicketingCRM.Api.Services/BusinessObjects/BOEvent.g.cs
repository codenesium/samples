using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace TicketingCRMNS.Api.Services
{
        public partial class BOEvent: AbstractBusinessObject
        {
                public BOEvent() : base()
                {
                }

                public void SetProperties(int id,
                                          string address1,
                                          string address2,
                                          int cityId,
                                          DateTime date,
                                          string description,
                                          DateTime endDate,
                                          string facebook,
                                          string name,
                                          DateTime startDate,
                                          string website)
                {
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.CityId = cityId;
                        this.Date = date;
                        this.Description = description;
                        this.EndDate = endDate;
                        this.Facebook = facebook;
                        this.Id = id;
                        this.Name = name;
                        this.StartDate = startDate;
                        this.Website = website;
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public int CityId { get; private set; }

                public DateTime Date { get; private set; }

                public string Description { get; private set; }

                public DateTime EndDate { get; private set; }

                public string Facebook { get; private set; }

                public int Id { get; private set; }

                public string Name { get; private set; }

                public DateTime StartDate { get; private set; }

                public string Website { get; private set; }
        }
}

/*<Codenesium>
    <Hash>a65ac0e0dc83e3e3bebd10d0f0d8904e</Hash>
</Codenesium>*/