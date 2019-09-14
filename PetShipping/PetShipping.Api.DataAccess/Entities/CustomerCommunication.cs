using Codenesium.DataConversionExtensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace PetShippingNS.Api.DataAccess
{
	[Table("CustomerCommunication", Schema="dbo")]
	public partial class CustomerCommunication : AbstractEntity
	{
		public CustomerCommunication()
		{
		}

		public virtual void SetProperties(
			int id,
			int customerId,
			DateTime dateCreated,
			int employeeId,
			string notes)
		{
			this.Id = id;
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Notes = notes;
		}

		[Column("customerId")]
		public virtual int CustomerId { get; private set; }

		[Column("dateCreated")]
		public virtual DateTime DateCreated { get; private set; }

		[Column("employeeId")]
		public virtual int EmployeeId { get; private set; }

		[Key]
		[Column("id")]
		public virtual int Id { get; private set; }

		[MaxLength(2147483647)]
		[Column("notes")]
		public virtual string Notes { get; private set; }

		[ForeignKey("CustomerId")]
		public virtual Customer CustomerIdNavigation { get; private set; }

		public void SetCustomerIdNavigation(Customer item)
		{
			this.CustomerIdNavigation = item;
		}

		[ForeignKey("EmployeeId")]
		public virtual Employee EmployeeIdNavigation { get; private set; }

		public void SetEmployeeIdNavigation(Employee item)
		{
			this.EmployeeIdNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>d78dcac54ed3cce3b5a57b30fd5bb398</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/