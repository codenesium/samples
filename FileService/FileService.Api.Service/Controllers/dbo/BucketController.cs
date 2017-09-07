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
		{}
	}
}

/*<Codenesium>
    <Hash>a047174e2ead6dac13f2a01ff5cf5913</Hash>
</Codenesium>*/