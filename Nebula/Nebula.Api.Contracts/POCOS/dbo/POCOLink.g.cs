using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOLink: AbstractPOCO
	{
		public POCOLink() : base()
		{}

		public POCOLink(
			Nullable<int> assignedMachineId,
			int chainId,
			Nullable<DateTime> dateCompleted,
			Nullable<DateTime> dateStarted,
			string dynamicParameters,
			Guid externalId,
			int id,
			int linkStatusId,
			string name,
			int order,
			string response,
			string staticParameters,
			int timeoutInSeconds)
		{
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds.ToInt();

			this.AssignedMachineId = new ReferenceEntity<Nullable<int>>(assignedMachineId,
			                                                            nameof(ApiResponse.Machines));
			this.ChainId = new ReferenceEntity<int>(chainId,
			                                        nameof(ApiResponse.Chains));
			this.LinkStatusId = new ReferenceEntity<int>(linkStatusId,
			                                             nameof(ApiResponse.LinkStatus));
		}

		public ReferenceEntity<Nullable<int>> AssignedMachineId { get; set; }
		public ReferenceEntity<int> ChainId { get; set; }
		public Nullable<DateTime> DateCompleted { get; set; }
		public Nullable<DateTime> DateStarted { get; set; }
		public string DynamicParameters { get; set; }
		public Guid ExternalId { get; set; }
		public int Id { get; set; }
		public ReferenceEntity<int> LinkStatusId { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public string Response { get; set; }
		public string StaticParameters { get; set; }
		public int TimeoutInSeconds { get; set; }

		[JsonIgnore]
		public bool ShouldSerializeAssignedMachineIdValue { get; set; } = true;

		public bool ShouldSerializeAssignedMachineId()
		{
			return this.ShouldSerializeAssignedMachineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChainIdValue { get; set; } = true;

		public bool ShouldSerializeChainId()
		{
			return this.ShouldSerializeChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCompletedValue { get; set; } = true;

		public bool ShouldSerializeDateCompleted()
		{
			return this.ShouldSerializeDateCompletedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateStartedValue { get; set; } = true;

		public bool ShouldSerializeDateStarted()
		{
			return this.ShouldSerializeDateStartedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDynamicParametersValue { get; set; } = true;

		public bool ShouldSerializeDynamicParameters()
		{
			return this.ShouldSerializeDynamicParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue { get; set; } = true;

		public bool ShouldSerializeExternalId()
		{
			return this.ShouldSerializeExternalIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeIdValue { get; set; } = true;

		public bool ShouldSerializeId()
		{
			return this.ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkStatusIdValue { get; set; } = true;

		public bool ShouldSerializeLinkStatusId()
		{
			return this.ShouldSerializeLinkStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue { get; set; } = true;

		public bool ShouldSerializeName()
		{
			return this.ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderValue { get; set; } = true;

		public bool ShouldSerializeOrder()
		{
			return this.ShouldSerializeOrderValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResponseValue { get; set; } = true;

		public bool ShouldSerializeResponse()
		{
			return this.ShouldSerializeResponseValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStaticParametersValue { get; set; } = true;

		public bool ShouldSerializeStaticParameters()
		{
			return this.ShouldSerializeStaticParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeTimeoutInSecondsValue { get; set; } = true;

		public bool ShouldSerializeTimeoutInSeconds()
		{
			return this.ShouldSerializeTimeoutInSecondsValue;
		}

		public void DisableAllFields()
		{
			this.ShouldSerializeAssignedMachineIdValue = false;
			this.ShouldSerializeChainIdValue = false;
			this.ShouldSerializeDateCompletedValue = false;
			this.ShouldSerializeDateStartedValue = false;
			this.ShouldSerializeDynamicParametersValue = false;
			this.ShouldSerializeExternalIdValue = false;
			this.ShouldSerializeIdValue = false;
			this.ShouldSerializeLinkStatusIdValue = false;
			this.ShouldSerializeNameValue = false;
			this.ShouldSerializeOrderValue = false;
			this.ShouldSerializeResponseValue = false;
			this.ShouldSerializeStaticParametersValue = false;
			this.ShouldSerializeTimeoutInSecondsValue = false;
		}
	}
}

/*<Codenesium>
    <Hash>be77a0e0bb33a9c992ef63cd9a367df0</Hash>
</Codenesium>*/