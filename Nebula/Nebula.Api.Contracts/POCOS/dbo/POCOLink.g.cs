using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOLink
	{
		public POCOLink()
		{}

		public POCOLink(
			int id,
			string name,
			string dynamicParameters,
			string staticParameters,
			int chainId,
			Nullable<int> assignedMachineId,
			int linkStatusId,
			int order,
			Nullable<DateTime> dateStarted,
			Nullable<DateTime> dateCompleted,
			string response,
			Guid externalId)
		{
			this.Id = id.ToInt();
			this.Name = name.ToString();
			this.DynamicParameters = dynamicParameters.ToString();
			this.StaticParameters = staticParameters.ToString();
			this.Order = order.ToInt();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.Response = response.ToString();
			this.ExternalId = externalId.ToGuid();

			this.ChainId = new ReferenceEntity<int>(chainId,
			                                        nameof(ApiResponse.Chains));
			this.AssignedMachineId = new ReferenceEntity<Nullable<int>>(assignedMachineId,
			                                                            nameof(ApiResponse.Machines));
			this.LinkStatusId = new ReferenceEntity<int>(linkStatusId,
			                                             nameof(ApiResponse.LinkStatus));
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string DynamicParameters { get; set; }
		public string StaticParameters { get; set; }
		public ReferenceEntity<int> ChainId { get; set; }
		public ReferenceEntity<Nullable<int>> AssignedMachineId { get; set; }
		public ReferenceEntity<int> LinkStatusId { get; set; }
		public int Order { get; set; }
		public Nullable<DateTime> DateStarted { get; set; }
		public Nullable<DateTime> DateCompleted { get; set; }
		public string Response { get; set; }
		public Guid ExternalId { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDynamicParametersValue { get; set; } = true;

		public bool ShouldSerializeDynamicParameters()
		{
			return this.ShouldSerializeDynamicParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStaticParametersValue { get; set; } = true;

		public bool ShouldSerializeStaticParameters()
		{
			return this.ShouldSerializeStaticParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChainIdValue { get; set; } = true;

		public bool ShouldSerializeChainId()
		{
			return this.ShouldSerializeChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAssignedMachineIdValue { get; set; } = true;

		public bool ShouldSerializeAssignedMachineId()
		{
			return this.ShouldSerializeAssignedMachineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkStatusIdValue { get; set; } = true;

		public bool ShouldSerializeLinkStatusId()
		{
			return this.ShouldSerializeLinkStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderValue { get; set; } = true;

		public bool ShouldSerializeOrder()
		{
			return this.ShouldSerializeOrderValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateStartedValue { get; set; } = true;

		public bool ShouldSerializeDateStarted()
		{
			return this.ShouldSerializeDateStartedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCompletedValue { get; set; } = true;

		public bool ShouldSerializeDateCompleted()
		{
			return this.ShouldSerializeDateCompletedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResponseValue { get; set; } = true;

		public bool ShouldSerializeResponse()
		{
			return this.ShouldSerializeResponseValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = true;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeDynamicParametersValue = false;
			this.ShouldSerializeStaticParametersValue = false;
			this.ShouldSerializeChainIdValue = false;
			this.ShouldSerializeAssignedMachineIdValue = false;
			this.ShouldSerializeLinkStatusIdValue = false;
			this.ShouldSerializeOrderValue = false;
			this.ShouldSerializeDateStartedValue = false;
			this.ShouldSerializeDateCompletedValue = false;
			this.ShouldSerializeResponseValue = false;
			this.ShouldSerializeExternalIdValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>9b1019eef9ac921289af689a80808f17</Hash>
</Codenesium>*/