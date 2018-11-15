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
			int customerId,
			DateTime dateCreated,
			int employeeId,
			int id,
			string note)
		{
			this.CustomerId = customerId;
			this.DateCreated = dateCreated;
			this.EmployeeId = employeeId;
			this.Id = id;
			this.Note = note;
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
		public virtual string Note { get; private set; }

		[ForeignKey("CustomerId")]
		public virtual Customer CustomerNavigation { get; private set; }

		public void SetCustomerNavigation(Customer item)
		{
			this.CustomerNavigation = item;
		}

		[ForeignKey("EmployeeId")]
		public virtual Employee EmployeeNavigation { get; private set; }

		public void SetEmployeeNavigation(Employee item)
		{
			this.EmployeeNavigation = item;
		}
	}
}

/*<Codenesium>
    <Hash>1ce86f194c0e8936fe6013dee0ca4953</Hash>
</Codenesium>*/