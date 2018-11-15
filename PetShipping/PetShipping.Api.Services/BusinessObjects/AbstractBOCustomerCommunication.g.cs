using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOCustomerCommunication : AbstractBusinessObject
	{
		public AbstractBOCustomerCommunication()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int customerId,
		                                  DateTime dateCreated,
		                                  int employeeId,
		                                  string note)
		{
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Id = id;
			this.Note = note;
		}

		public int CustomerId { get; private set; }

		public DateTime DateCreated { get; private set; }

		public int EmployeeId { get; private set; }

		public int Id { get; private set; }

		public string Note { get; private set; }
	}
}

/*<Codenesium>
    <Hash>634ed605ce04895d17621916bc498a29</Hash>
</Codenesium>*/