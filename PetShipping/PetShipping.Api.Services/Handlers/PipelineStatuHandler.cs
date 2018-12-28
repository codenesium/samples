using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineStatuCreatedHandler : INotificationHandler<PipelineStatuCreatedNotification>
	{
		public async Task Handle(PipelineStatuCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStatuUpdatedHandler : INotificationHandler<PipelineStatuUpdatedNotification>
	{
		public async Task Handle(PipelineStatuUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStatuDeletedHandler : INotificationHandler<PipelineStatuDeletedNotification>
	{
		public async Task Handle(PipelineStatuDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineStatuCreatedNotification : INotification
	{
		public ApiPipelineStatuServerResponseModel Record { get; private set; }

		public PipelineStatuCreatedNotification(ApiPipelineStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStatuUpdatedNotification : INotification
	{
		public ApiPipelineStatuServerResponseModel Record { get; private set; }

		public PipelineStatuUpdatedNotification(ApiPipelineStatuServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineStatuDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineStatuDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>d2e50a6380363d04081241095f7fb497</Hash>
</Codenesium>*/