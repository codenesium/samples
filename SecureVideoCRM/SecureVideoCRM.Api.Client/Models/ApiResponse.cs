using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SecureVideoCRMNS.Api.Client
{
	public partial class ApiResponse
	{
		public ApiResponse()
		{
		}

		public void Merge(ApiResponse from)
		{
			from.Videos.ForEach(x => this.AddVideo(x));
			from.Users.ForEach(x => this.AddUser(x));
			from.Subscriptions.ForEach(x => this.AddSubscription(x));
		}

		public List<ApiVideoClientResponseModel> Videos { get; private set; } = new List<ApiVideoClientResponseModel>();

		public List<ApiUserClientResponseModel> Users { get; private set; } = new List<ApiUserClientResponseModel>();

		public List<ApiSubscriptionClientResponseModel> Subscriptions { get; private set; } = new List<ApiSubscriptionClientResponseModel>();

		public void AddVideo(ApiVideoClientResponseModel item)
		{
			if (!this.Videos.Any(x => x.Id == item.Id))
			{
				this.Videos.Add(item);
			}
		}

		public void AddUser(ApiUserClientResponseModel item)
		{
			if (!this.Users.Any(x => x.Id == item.Id))
			{
				this.Users.Add(item);
			}
		}

		public void AddSubscription(ApiSubscriptionClientResponseModel item)
		{
			if (!this.Subscriptions.Any(x => x.Id == item.Id))
			{
				this.Subscriptions.Add(item);
			}
		}
	}
}

/*<Codenesium>
    <Hash>29bdaee401d4c762d108ed335daa92ce</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/