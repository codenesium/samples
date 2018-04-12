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
			this.Name = name;
			this.DynamicParameters = dynamicParameters;
			this.StaticParameters = staticParameters;
			this.Order = order.ToInt();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.Response = response;
			this.ExternalId = externalId;

			this.ChainId = new ReferenceEntity<int>(chainId,
			                                        "Chain");
			this.AssignedMachineId = new ReferenceEntity<Nullable<int>>(assignedMachineId,
			                                                            "Machine");
			this.LinkStatusId = new ReferenceEntity<int>(linkStatusId,
			                                             "LinkStatus");
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
    <Hash>b69c00d6704e3e0f2a0717c4e753dbe5</Hash>
</Codenesium>*/