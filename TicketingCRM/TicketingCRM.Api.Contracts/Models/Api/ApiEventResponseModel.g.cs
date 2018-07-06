using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiEventResponseModel : AbstractApiResponseModel
        {
                public virtual void SetProperties(
                        int id,
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
                        this.Id = id;
                        this.Address1 = address1;
                        this.Address2 = address2;
                        this.CityId = cityId;
                        this.Date = date;
                        this.Description = description;
                        this.EndDate = endDate;
                        this.Facebook = facebook;
                        this.Name = name;
                        this.StartDate = startDate;
                        this.Website = website;

                        this.CityIdEntity = nameof(ApiResponse.Cities);
                }

                public string Address1 { get; private set; }

                public string Address2 { get; private set; }

                public int CityId { get; private set; }

                public string CityIdEntity { get; set; }

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
    <Hash>ed394e58553c73ce0dabf2325808ac11</Hash>
</Codenesium>*/