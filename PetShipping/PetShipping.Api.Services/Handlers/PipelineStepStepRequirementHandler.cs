using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepStepRequirementCreatedHandler : INotificationHandler<PipelineStepStepRequirementCreatedNotification>
	{
		public async Task Handle(PipelineStepStepRequirementCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStepRequirementUpdatedHandler : INotificationHandler<PipelineStepStepRequirementUpdatedNotification>
	{
		public async Task Handle(PipelineStepStepRequirementUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStepRequirementDeletedHandler : INotificationHandler<PipelineStepStepRequirementDeletedNotification>
	{
		public async Task Handle(PipelineStepStepRequirementDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStepRequirementCreatedNotification : INotification
	{
		public ApiPipelineStepStepRequirementServerResponseModel Record { get; private set; }

		public PipelineStepStepRequirementCreatedNotification(ApiPipelineStepStepRequirementServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepStepRequirementUpdatedNotification : INotification
	{
		public ApiPipelineStepStepRequirementServerResponseModel Record { get; private set; }

		public PipelineStepStepRequirementUpdatedNotification(ApiPipelineStepStepRequirementServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepStepRequirementDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStepStepRequirementDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>f0e089ff588435459463a22a07516cb8</Hash>
</Codenesium>*/