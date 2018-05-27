using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.ComponentModel.DataAnnotations;
namespace PetShippingNS.Api.Contracts
{
	public partial class ApiClientCommunicationResponseModel: AbstractApiResponseModel
	{
		public ApiClientCommunicationResponseModel() : base()
		{}

		public void SetProperties(
			int clientId,
			DateTime dateCreated,
			int employeeId,
			int id,
			string notes)
		{
			this.DateCreated = dateCreated.ToDateTime();
			this.Id = id.ToInt();
			this.Notes = notes;

			this.ClientId = new ReferenceEntity<int>(clientId,
			                                         nameof(ApiResponse.Clients));
			this.EmployeeId = new ReferenceEntity<int>(employeeId,
			                                           nameof(ApiResponse.Employees));
		}

		public ReferenceEntity<int> ClientId { get; set; }
		public DateTime DateCreated { get; set; }
		public ReferenceEntity<int> EmployeeId { get; set; }
		public int Id { get; set; }
		public string Notes { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeClientIdValue { get; set; } = true;

		public bool ShouldSerializeClientId()
		{
			return this.ShouldSerializeClientIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCreatedValue { get; set; } = true;

		public bool ShouldSerializeDateCreated()
		{
			return this.ShouldSerializeDateCreatedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeEmployeeIdValue { get; set; } = true;

		public bool ShouldSerializeEmployeeId()
		{
			return this.ShouldSerializeEmployeeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNotesValue { get; set; } = true;

		public bool ShouldSerializeNotes()
		{
			return this.ShouldSerializeNotesValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeClientIdValue = false;
			this.ShouldSerializeDateCreatedValue = false;
			this.ShouldSerializeEmployeeIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNotesValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>fb3fa0bf53573ca1428c18108cab3081</Hash>
</Codenesium>*/