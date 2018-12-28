using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStepStatuCreatedHandler : INotificationHandler<PipelineStepStatuCreatedNotification>
	{
		public async Task Handle(PipelineStepStatuCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStatuUpdatedHandler : INotificationHandler<PipelineStepStatuUpdatedNotification>
	{
		public async Task Handle(PipelineStepStatuUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStatuDeletedHandler : INotificationHandler<PipelineStepStatuDeletedNotification>
	{
		public async Task Handle(PipelineStepStatuDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStepStatuCreatedNotification : INotification
	{
		public ApiPipelineStepStatuServerResponseModel Record { get; private set; }

		public PipelineStepStatuCreatedNotification(ApiPipelineStepStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepStatuUpdatedNotification : INotification
	{
		public ApiPipelineStepStatuServerResponseModel Record { get; private set; }

		public PipelineStepStatuUpdatedNotification(ApiPipelineStepStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStepStatuDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStepStatuDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>247d6b24153d5e9fb457ee26cbd4274a</Hash>
</Codenesium>*/