using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepCreatedHandler : INotificationHandler<PipelineStepCreatedNotification>
	{
		public async Task Handle(PipelineStepCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepUpdatedHandler : INotificationHandler<PipelineStepUpdatedNotification>
	{
		public async Task Handle(PipelineStepUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepDeletedHandler : INotificationHandler<PipelineStepDeletedNotification>
	{
		public async Task Handle(PipelineStepDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepCreatedNotification : INotification
	{
		public ApiPipelineStepServerResponseModel Record { get; private set; }

		public PipelineStepCreatedNotification(ApiPipelineStepServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepUpdatedNotification : INotification
	{
		public ApiPipelineStepServerResponseModel Record { get; private set; }

		public PipelineStepUpdatedNotification(ApiPipelineStepServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStepDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>1f432d13f2cbcf41397a818c99b7078c</Hash>
</Codenesium>*/