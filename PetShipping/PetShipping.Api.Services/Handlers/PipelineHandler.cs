using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PetShippingNS.Api.Services
{
	public class PipelineCreatedHandler : INotificationHandler<PipelineCreatedNotification>
	{
		public async Task Handle(PipelineCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineUpdatedHandler : INotificationHandler<PipelineUpdatedNotification>
	{
		public async Task Handle(PipelineUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineDeletedHandler : INotificationHandler<PipelineDeletedNotification>
	{
		public async Task Handle(PipelineDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class PipelineCreatedNotification : INotification
	{
		public ApiPipelineServerResponseModel Record { get; private set; }

		public PipelineCreatedNotification(ApiPipelineServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineUpdatedNotification : INotification
	{
		public ApiPipelineServerResponseModel Record { get; private set; }

		public PipelineUpdatedNotification(ApiPipelineServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class PipelineDeletedNotification : INotification
	{
		public int Id { get; private set; }

		public PipelineDeletedNotification(int id)
		{
			this.Id = id;
		}
	}
}

/*<Codenesium>
    <Hash>802fdc45f1b13cc44fcfe37d33975a23</Hash>
</Codenesium>*/