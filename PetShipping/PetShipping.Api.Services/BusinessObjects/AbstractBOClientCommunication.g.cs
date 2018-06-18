using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOClientCommunication: AbstractBusinessObject
        {
                public AbstractBOClientCommunication() : base()
                {
                }

                public virtual void SetProperties(int id,
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
    <Hash>4cfe872c3bbbc274df2214862bc78b76</Hash>
</Codenesium>*/