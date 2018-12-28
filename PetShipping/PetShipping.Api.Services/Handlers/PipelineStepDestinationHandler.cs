using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepDestinationCreatedHandler : INotificationHandler<PipelineStepDestinationCreatedNotification>
	{
		public async Task Handle(PipelineStepDestinationCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepDestinationUpdatedHandler : INotificationHandler<PipelineStepDestinationUpdatedNotification>
	{
		public async Task Handle(PipelineStepDestinationUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepDestinationDeletedHandler : INotificationHandler<PipelineStepDestinationDeletedNotification>
	{
		public async Task Handle(PipelineStepDestinationDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepDestinationCreatedNotification : INotification
	{
		public ApiPipelineStepDestinationServerResponseModel Record { get; private set; }

		public PipelineStepDestinationCreatedNotification(ApiPipelineStepDestinationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepDestinationUpdatedNotification : INotification
	{
		public ApiPipelineStepDestinationServerResponseModel Record { get; private set; }

		public PipelineStepDestinationUpdatedNotification(ApiPipelineStepDestinationServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepDestinationDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStepDestinationDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>af7419f11c43ef641c1d8bc1323a0a76</Hash>
</Codenesium>*/