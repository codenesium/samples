using Codenesium.DataConversionExtensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;

namespace PetShippingNS.Api.Contracts
{
        public partial class ApiClientCommunicationRequestModel : AbstractApiRequestModel
        {
                public ApiClientCommunicationRequestModel()
                        : base()
                {
                }

                public virtual void SetProperties(
                        int clientId,
                        DateTime dateCreated,
                        int employeeId,
                        string notes)
                {
                        this.ClientId = clientId;
                        this.DateCreated = dateCreated;
                        this.EmployeeId = employeeId;
                        this.Notes = notes;
                }

                private int clientId;

                [Required]
                public int ClientId
                {
                        get
                        {
                                return this.clientId;
                        }

                        set
                        {
                                this.clientId = value;
                        }
                }

                private DateTime dateCreated;

                [Required]
                public DateTime DateCreated
                {
                        get
                        {
                                return this.dateCreated;
                        }

                        set
                        {
                                this.dateCreated = value;
                        }
                }

                private int employeeId;

                [Required]
                public int EmployeeId
                {
                        get
                        {
                                return this.employeeId;
                        }

                        set
                        {
                                this.employeeId = value;
                        }
                }

                private string notes;

                [Required]
                public string Notes
                {
                        get
                        {
                                return this.notes;
                        }

                        set
                        {
                                this.notes = value;
                        }
                }
        }
}

/*<Codenesium>
    <Hash>b9f8094eead800018c6e81c0a967cd20</Hash>
</Codenesium>*/