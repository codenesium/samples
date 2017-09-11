using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.Validation;
using Autofac;
using Autofac.Extras.NLog;
using FluentValidation;
using FluentValidation.Mvc;

namespace Codenesium.Foundation.CommonMVC
{
    /// <summary>
    /// This is the base controller for any controller that needs transaction support.
    /// We use an action filter to start and commit transactions using the Conttext.
    /// </summary>
    public abstract class AbstractEntityFrameworkApiController : ApiController
    {
        public System.Data.Entity.DbContext Context { get; private set; }
        protected ILogger _logger { get; set; }

        public AbstractEntityFrameworkApiController(
            ILogger logger,
            DbContext context

            )
        {
            this._logger = logger;
            this.Context = context;
            this.Context.Configuration.LazyLoadingEnabled = false;
        }
    }

    /// <summary>
    /// The purpose of this filter is to throw an error when a client passes a null model to a controller
    /// from http://stackoverflow.com/questions/14517151/how-to-ensure-asp-net-web-api-controllers-parameter-is-not-null
    /// </summary>
    public class ModelValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.Any(v => v.Value == null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// This attribute can be added to disable entity framework change tracking
    /// </summary>
    public class ReadOnlyFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionContext.ControllerContext.Controller;
            controller.Context.Configuration.AutoDetectChangesEnabled = false; //disable change tracking in context
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
        }
    }

    public class UnitOfWorkActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionContext.ControllerContext.Controller;
            controller.Context.Database.BeginTransaction();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            AbstractEntityFrameworkApiController controller = (AbstractEntityFrameworkApiController)actionExecutedContext.ActionContext.ControllerContext.Controller;

            if (actionExecutedContext.Exception == null)
            {
                try
                {
                    if (controller.Context.Database.CurrentTransaction != null)
                    {
                        controller.Context.Database.CurrentTransaction.Commit();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    controller.Context.Dispose();
                }
            }
            else
            {
                try
                {
                    if (controller.Context.Database.CurrentTransaction != null)
                    {
                        controller.Context.Database.CurrentTransaction.Rollback();
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    controller.Context.Dispose();
                }
            }

            base.OnActionExecuted(actionExecutedContext);
        }
    }

    /// <summary>
    /// From https://json.codes/blog/integrating-fluent-validation-with-aspnet-web-api/
    /// Provides a validation module for classes that end with "Validator"
    /// </summary>
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IComponentContext _context;

        public AutofacValidatorFactory(IComponentContext context)
        {
            _context = context;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            object instance;
            if (_context.TryResolve(validatorType, out instance))
            {
                var validator = instance as IValidator;
                return validator;
            }

            return null;
        }
    }

    public class ValidationModule : Autofac.Module
    {
        private List<Type> _types = new List<Type>();

        public ValidationModule(List<Type> types)
        {
            this._types = types;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterTypes(this._types.ToArray())
           .Where(t => t.Name.EndsWith("Validator"))
           .AsImplementedInterfaces()
           .AsSelf()
           .PropertiesAutowired();

            builder.RegisterType<FluentValidationModelValidatorProvider>().As<System.Web.Mvc.ModelValidatorProvider>();
            builder.RegisterType<AutofacValidatorFactory>().As<IValidatorFactory>().SingleInstance();

            base.Load(builder);
        }
    }

    /// <summary>
    /// The purpose of this contrller is to allow a redirect in
    /// a WepAPI project to the swagger page.
    /// http://stackoverflow.com/questions/33891721/asp-net-webapi-default-landing-page
    /// </summary>
    public class SwaggerController : System.Web.Mvc.Controller
    {
        // GET: Browser
        public System.Web.Mvc.ActionResult Index()
        {
            return Redirect("swagger");
        }
    }
}