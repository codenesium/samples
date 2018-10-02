using Codenesium.DataConversionExtensions;
using System;

namespace NebulaNS.Api.Services
{
	public abstract class AbstractBOLink : AbstractBusinessObject
	{
		public AbstractBOLink()
			: base()
		{
		}

		public virtual void SetProperties(int id,
		                                  int? assignedMachineId,
		                                  int chainId,
		                                  DateTime? dateCompleted,
		                                  DateTime? dateStarted,
		                                  string dynamicParameter,
		                                  Guid externalId,
		                                  int linkStatusId,
		                                  string name,
		                                  int order,
		                                  string response,
		                                  string staticParameter,
		                                  int timeoutInSecond)
		{
			this.AssignedMachineId = assignedMachineId;
			this.ChainId = chainId;
			this.DateCompleted = dateCompleted;
			this.DateStarted = dateStarted;
			this.DynamicParameter = dynamicParameter;
			this.ExternalId = externalId;
			this.Id = id;
			this.LinkStatusId = linkStatusId;
			this.Name = name;
			this.Order = order;
			this.Response = response;
			this.StaticParameter = staticParameter;
			this.TimeoutInSecond = timeoutInSecond;
		}

		public int? AssignedMachineId { get; private set; }

		public int ChainId { get; private set; }

		public DateTime? DateCompleted { get; private set; }

		public DateTime? DateStarted { get; private set; }

		public string DynamicParameter { get; private set; }

		public Guid ExternalId { get; private set; }

		public int Id { get; private set; }

		public int LinkStatusId { get; private set; }

		public string Name { get; private set; }

		public int Order { get; private set; }

		public string Response { get; private set; }

		public string StaticParameter { get; private set; }

		public int TimeoutInSecond { get; private set; }
	}
}

/*<Codenesium>
    <Hash>8253254a20fab43b166b7f98d11fc7fa</Hash>
</Codenesium>*/