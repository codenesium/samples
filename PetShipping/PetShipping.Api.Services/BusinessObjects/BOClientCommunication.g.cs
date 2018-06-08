using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public partial class BOClientCommunication: AbstractBusinessObject
        {
                public BOClientCommunication() : base()
                {
                }

                public void SetProperties(int id,
                                          int clientId,
                                          DateTime dateCreated,
                                          int employeeId,
                                          string notes)
                {
                        this.ClientId = clientId;
                        this.DateCreated = dateCreated;
                        this.EmployeeId = employeeId;
                        this.Id = id;
                        this.Notes = notes;
                }

                public int ClientId { get; private set; }

                public DateTime DateCreated { get; private set; }

                public int EmployeeId { get; private set; }

                public int Id { get; private set; }

                public string Notes { get; private set; }
        }
}

/*<Codenesium>
    <Hash>f80ad019a5af3af281d1bdaebc97bb13</Hash>
</Codenesium>*/