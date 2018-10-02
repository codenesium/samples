using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
{
	public abstract class AbstractBOClient : AbstractBusinessObject
	{
		public AbstractBOClient()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  string email,
		                                  string firstName,
		                                  string lastName,
		                                  string note,
		                                  string phone)
		{
			this.Email = email;
			this.FirstName = firstName;
			this.Id = id;
			this.LastName = lastName;
			this.Note = note;
			this.Phone = phone;
		}

		public string Email { get; private set; }

		public string FirstName { get; private set; }

		public int Id { get; private set; }

		public string LastName { get; private set; }

		public string Note { get; private set; }

		public string Phone { get; private set; }
	}
}

/*<Codenesium>
    <Hash>0f4d0b5726abc6e38c91e3d20accdf81</Hash>
</Codenesium>*/