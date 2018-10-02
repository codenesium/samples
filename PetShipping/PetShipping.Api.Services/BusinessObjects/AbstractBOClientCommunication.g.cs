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
		                                  string note)
		{
			this.ClientId = clientId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Id = id;
			this.Note = note;
		}

		public int ClientId { get; private set; }

		public DateTime DateCreated { get; private set; }

		public int EmployeeId { get; private set; }

		public int Id { get; private set; }

		public string Note { get; private set; }
	}
}

/*<Codenesium>
    <Hash>89eada7bc28768d2c98784513fe99dd3</Hash>
</Codenesium>*/