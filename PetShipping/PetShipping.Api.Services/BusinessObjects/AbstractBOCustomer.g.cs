using Codenesium.DataConversionExtensions;
using System;

namespace PetShippingNS.Api.Services
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
    <Hash>4b97f321d7b076ae2cbaf822cd6c32f1</Hash>
</Codenesium>*/