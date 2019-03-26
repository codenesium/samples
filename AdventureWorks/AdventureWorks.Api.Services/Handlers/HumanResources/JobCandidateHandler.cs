using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Services
{
	public class JobCandidateCreatedHandler : INotificationHandler<JobCandidateCreatedNotification>
	{
		public async Task Handle(JobCandidateCreatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class JobCandidateUpdatedHandler : INotificationHandler<JobCandidateUpdatedNotification>
	{
		public async Task Handle(JobCandidateUpdatedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class JobCandidateDeletedHandler : INotificationHandler<JobCandidateDeletedNotification>
	{
		public async Task Handle(JobCandidateDeletedNotification notification, CancellationToken cancellation)
		{
			await Task.CompletedTask;
		}
	}

	public class JobCandidateCreatedNotification : INotification
	{
		public ApiJobCandidateServerResponseModel Record { get; private set; }

		public JobCandidateCreatedNotification(ApiJobCandidateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class JobCandidateUpdatedNotification : INotification
	{
		public ApiJobCandidateServerResponseModel Record { get; private set; }

		public JobCandidateUpdatedNotification(ApiJobCandidateServerResponseModel record)
		{
			this.Record = record;
		}
	}

	public class JobCandidateDeletedNotification : INotification
	{
		public int JobCandidateID { get; private set; }

		public JobCandidateDeletedNotification(int jobCandidateID)
		{
			this.JobCandidateID = jobCandidateID;
		}
	}
}

/*<Codenesium>
    <Hash>e1464cc7a9c4df778b1ca5fff318f168</Hash>
</Codenesium>*/