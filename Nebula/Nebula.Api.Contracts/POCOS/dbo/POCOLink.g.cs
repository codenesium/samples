using Codenesium.DataConversionExtensions.AspNetCore;
using Newtonsoft.Json;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class POCOLink
	{
		public POCOLink()
		{}

		public POCOLink(int id,
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

			ChainId = new ReferenceEntity<int>(chainId,
			                                   "Chain");
			AssignedMachineId = new ReferenceEntity<Nullable<int>>(assignedMachineId,
			                                                       "Machine");
			LinkStatusId = new ReferenceEntity<int>(linkStatusId,
			                                        "LinkStatus");
		}

		public int Id {get; set;}
		public string Name {get; set;}
		public string DynamicParameters {get; set;}
		public string StaticParameters {get; set;}
		public ReferenceEntity<int>ChainId {get; set;}
		public ReferenceEntity<Nullable<int>>AssignedMachineId {get; set;}
		public ReferenceEntity<int>LinkStatusId {get; set;}
		public int Order {get; set;}
		public Nullable<DateTime> DateStarted {get; set;}
		public Nullable<DateTime> DateCompleted {get; set;}
		public string Response {get; set;}
		public Guid ExternalId {get; set;}

		[JsonIgnore]
		public bool ShouldSerializeIdValue {get; set;} = true;

		public bool ShouldSerializeId()
		{
			return ShouldSerializeIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeNameValue {get; set;} = true;

		public bool ShouldSerializeName()
		{
			return ShouldSerializeNameValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDynamicParametersValue {get; set;} = true;

		public bool ShouldSerializeDynamicParameters()
		{
			return ShouldSerializeDynamicParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeStaticParametersValue {get; set;} = true;

		public bool ShouldSerializeStaticParameters()
		{
			return ShouldSerializeStaticParametersValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeChainIdValue {get; set;} = true;

		public bool ShouldSerializeChainId()
		{
			return ShouldSerializeChainIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeAssignedMachineIdValue {get; set;} = true;

		public bool ShouldSerializeAssignedMachineId()
		{
			return ShouldSerializeAssignedMachineIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeLinkStatusIdValue {get; set;} = true;

		public bool ShouldSerializeLinkStatusId()
		{
			return ShouldSerializeLinkStatusIdValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeOrderValue {get; set;} = true;

		public bool ShouldSerializeOrder()
		{
			return ShouldSerializeOrderValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateStartedValue {get; set;} = true;

		public bool ShouldSerializeDateStarted()
		{
			return ShouldSerializeDateStartedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeDateCompletedValue {get; set;} = true;

		public bool ShouldSerializeDateCompleted()
		{
			return ShouldSerializeDateCompletedValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeResponseValue {get; set;} = true;

		public bool ShouldSerializeResponse()
		{
			return ShouldSerializeResponseValue;
		}

		[JsonIgnore]
		public bool ShouldSerializeExternalIdValue {get; set;} = true;

		public bool ShouldSerializeExternalId()
		{
			return ShouldSerializeExternalIdValue;
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
    <Hash>7391313339ac066af3b8c7ac7ad3bb88</Hash>
</Codenesium>*/