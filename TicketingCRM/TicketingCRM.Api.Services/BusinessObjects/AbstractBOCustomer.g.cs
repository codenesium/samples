using Codenesium.DataConversionExtensions;
using System;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractBOCustomer : AbstractBusinessObject
	{
		public AbstractBOCustomer()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string email,
		                                  string firstName,
		                                  string lastName,
		                                  string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Phone = phone;
		}

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>ed7718615e739795ae5f57ee25da09ab</Hash>
</Codenesium>*/