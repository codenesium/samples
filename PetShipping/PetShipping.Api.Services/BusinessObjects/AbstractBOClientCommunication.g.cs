using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
        public abstract class AbstractBOClientCommunication : AbstractBusinessObject
        {
                public AbstractBOClientCommunication()
                        : base()
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
    <Hash>68f4e34b396a94a75213491f0c0a1665</Hash>
</Codenesium>*/