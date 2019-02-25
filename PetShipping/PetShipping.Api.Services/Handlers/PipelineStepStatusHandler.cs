using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepStatusCreatedHandler : INotificationHandler<PipelineStepStatusCreatedNotification>
	{
		public async Task Handle(PipelineStepStatusCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStatusUpdatedHandler : INotificationHandler<PipelineStepStatusUpdatedNotification>
	{
		public async Task Handle(PipelineStepStatusUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStatusDeletedHandler : INotificationHandler<PipelineStepStatusDeletedNotification>
	{
		public async Task Handle(PipelineStepStatusDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStatusCreatedNotification : INotification
	{
		public ApiPipelineStepStatusServerResponseModel Record { get; private set; }

		public PipelineStepStatusCreatedNotification(ApiPipelineStepStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepStatusUpdatedNotification : INotification
	{
		public ApiPipelineStepStatusServerResponseModel Record { get; private set; }

		public PipelineStepStatusUpdatedNotification(ApiPipelineStepStatusServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepStatusDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStepStatusDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>fc185de62b4266e69c3bc967ff64477c</Hash>
</Codenesium>*/