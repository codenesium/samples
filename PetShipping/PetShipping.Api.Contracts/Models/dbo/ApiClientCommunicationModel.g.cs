using Codenesium.DataConversionExtensions.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientCommunicationModel: AbstractModel
	{
		public ApiClientCommunicationModel() : base()
		{}

		public ApiClientCommunicationModel(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			string notes)
		{
			this.ClientId = clientId.ToInt();
			this.DateCreated = dateCreated.ToDateTime();
			this.EmployeeId = employeeId.ToInt();
			this.Notes = notes;
		}

		private int clientId;

		[Required]
		public int ClientId
		{
			get
			{
				return this.clientId;
			}

			set
			{
				this.clientId = value;
			}
		}

		private DateTime dateCreated;

		[Required]
		public DateTime DateCreated
		{
			get
			{
				return this.dateCreated;
			}

			set
			{
				this.dateCreated = value;
			}
		}

		private int employeeId;

		[Required]
		public int EmployeeId
		{
			get
			{
				return this.employeeId;
			}

			set
			{
				this.employeeId = value;
			}
		}

		private string notes;

		[Required]
		public string Notes
		{
			get
			{
				return this.notes;
			}

			set
			{
				this.notes = value;
			}
		}
	}
}

/*<Codenesium>
    <Hash>f0895a83fde72f4ad0f173289b780a20</Hash>
</Codenesium>*/