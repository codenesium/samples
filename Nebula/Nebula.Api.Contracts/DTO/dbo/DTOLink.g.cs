using Codenesium.DataConversionExtensions.AspNetCore;
using System;

namespace NebulaNS.Api.Contracts
{
	public partial class DTOLink: AbstractDTO
	{
		public DTOLink() : base()
		{}

		public void SetProperties(int id,
		                          Nullable<int> assignedMachineId,
		                          int chainId,
		                          Nullable<DateTime> dateCompleted,
		                          Nullable<DateTime> dateStarted,
		                          string dynamicParameters,
		                          Guid externalId,
		                          int linkStatusId,
		                          string name,
		                          int order,
		                          string response,
		                          string staticParameters,
		                          int timeoutInSeconds)
		{
			this.AssignedMachineId = assignedMachineId.ToNullableInt();
			this.ChainId = chainId.ToInt();
			this.DateCompleted = dateCompleted.ToNullableDateTime();
			this.DateStarted = dateStarted.ToNullableDateTime();
			this.DynamicParameters = dynamicParameters;
			this.ExternalId = externalId.ToGuid();
			this.Id = id.ToInt();
			this.LinkStatusId = linkStatusId.ToInt();
			this.Name = name;
			this.Order = order.ToInt();
			this.Response = response;
			this.StaticParameters = staticParameters;
			this.TimeoutInSeconds = timeoutInSeconds.ToInt();
		}

		public Nullable<int> AssignedMachineId { get; set; }
		public int ChainId { get; set; }
		public Nullable<DateTime> DateCompleted { get; set; }
		public Nullable<DateTime> DateStarted { get; set; }
		public string DynamicParameters { get; set; }
		public Guid ExternalId { get; set; }
		public int Id { get; set; }
		public int LinkStatusId { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public string Response { get; set; }
		public string StaticParameters { get; set; }
		public int TimeoutInSeconds { get; set; }
	}
}

/*<Codenesium>
    <Hash>8ebcc26876bbbeb07f4d8ae596f10821</Hash>
</Codenesium>*/