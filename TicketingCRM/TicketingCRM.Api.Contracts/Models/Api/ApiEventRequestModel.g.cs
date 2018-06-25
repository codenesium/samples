using Codenesium.DataConversionExtensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace TicketingCRMNS.Api.Contracts
{
        public partial class ApiEventRequestModel : AbstractApiRequestModel
        {
                public ApiEventRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
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
                        this.Name = name;
                        this.StartDate = startDate;
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

                private int cityId;

                [Required]
                public int CityId
                {
                        get
                        {
                                return this.cityId;
                        }

                        set
                        {
                                this.cityId = value;
                        }
                }

                private DateTime date;

                [Required]
                public DateTime Date
                {
                        get
                        {
                                return this.date;
                        }

                        set
                        {
                                this.date = value;
                        }
                }

                private string description;

                [Required]
                public string Description
                {
                        get
                        {
                                return this.description;
                        }

                        set
                        {
                                this.description = value;
                        }
                }

                private DateTime endDate;

                [Required]
                public DateTime EndDate
                {
                        get
                        {
                                return this.endDate;
                        }

                        set
                        {
                                this.endDate = value;
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

                private DateTime startDate;

                [Required]
                public DateTime StartDate
                {
                        get
                        {
                                return this.startDate;
                        }

                        set
                        {
                                this.startDate = value;
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
    <Hash>07940cf94ffb8400e1091928af7cc671</Hash>
</Codenesium>*/