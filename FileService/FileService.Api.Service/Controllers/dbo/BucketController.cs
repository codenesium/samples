using Autofac.Extras.NLog;
using Codenesium.DataConversionExtensions;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq.Expressions;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FileServiceNS.Api.Contracts;
using FileServiceNS.Api.DataAccess;
namespace FileServiceNS.Api.Service
{
	[RoutePrefix("api/buckets")]
	public class BucketsController: BucketsControllerAbstract
	{
		public BucketsController(
			ILogger logger,
			DbContext context,
			BucketRepository bucketRepository,
			BucketModelValidator bucketModelValidator
			) : base(logger,
			         context,
			         bucketRepository,
			         bucketModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e78d268f521347279fa9c1b7376fb48c</Hash>
</Codenesium>*/