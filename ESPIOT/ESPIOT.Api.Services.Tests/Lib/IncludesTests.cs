using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ESPIOTNS.Api.Services.Tests
{
	[Trait("Type", "Unit")]
	[Trait("Area", "Includes")]
	public partial class ServiceIncludesTests
	{
		[Fact]
		public void Test_ValidationError()
		{
			var error = new ValidationError("1", "error", "field1");
			error.ErrorCode.Should().Be("1");
			error.ErrorMessage.Should().Be("error");
			error.PropertyName.Should().Be("field1");
		}

		[Fact]
		public void ActionResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			var response = ValidationResponseFactory<object>.ActionResponse(result);

			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void ActionResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			var result = new ValidationResult(failures);
			var response = ValidationResponseFactory<object>.ActionResponse(result);

			response.Success.Should().BeTrue();
		}

		[Fact]
		public void CreateResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			CreateResponse<int> response = ValidationResponseFactory<int>.CreateResponse(result);

			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void CreateResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);
			CreateResponse<int> response = ValidationResponseFactory<int>.CreateResponse(result);

			response.Success.Should().BeTrue();
		}

		[Fact]
		public void CreateResponse_SetRecord()
		{
			List<ValidationFailure> failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);

			var item = new
			{
				id = 1
			};

			CreateResponse<object> response = ValidationResponseFactory<object>.CreateResponse(result);

			response.SetRecord(item);
			response.Record.Should().NotBeNull();
		}

		[Fact]
		public void UpdateResponse_Error()
		{
			var failures = new List<ValidationFailure>();
			failures.Add(new ValidationFailure("field1", "error"));
			var result = new ValidationResult(failures);
			UpdateResponse<int> response = ValidationResponseFactory<int>.UpdateResponse(result);

			response.Success.Should().BeFalse();
			response.ValidationErrors.Count.Should().Be(1);
		}

		[Fact]
		public void UpdateResponse_No_Error()
		{
			var failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);
			UpdateResponse<int> response = ValidationResponseFactory<int>.UpdateResponse(result);

			response.Success.Should().BeTrue();
		}

		[Fact]
		public void UpdateResponse_SetRecord()
		{
			List<ValidationFailure> failures = new List<ValidationFailure>();
			ValidationResult result = new ValidationResult(failures);

			var item = new
			{
				id = 1
			};

			UpdateResponse<object> response = ValidationResponseFactory<object>.UpdateResponse(result);

			response.SetRecord(item);
			response.Record.Should().NotBeNull();
		}
	}

	[Trait("Type", "Unit")]
	[Trait("Area", "Auth")]
	public partial class ServiceIncludesAuthTests
	{

		Mock<UserManager<AuthUser>> GetDefaultUserManagerUserFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtHelper = new Mock<IJWTHelper>();
			jwtHelper.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<IList<Claim>>())).Returns("token");

			var emailSender = new Mock<IEmailSender>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.JwtSettings).Returns(new JwtSettings());

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.GetClaimsAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(claims));
			userManager.Setup(x => x.GetRolesAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(roles));

			return userManager;
		}

		Mock<UserManager<AuthUser>> GetDefaultUserManagerUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtHelper = new Mock<IJWTHelper>();
			jwtHelper.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<IList<Claim>>())).Returns("token");

			var emailSender = new Mock<IEmailSender>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.JwtSettings).Returns(new JwtSettings());

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));
			userManager.Setup(x => x.GetClaimsAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(claims));
			userManager.Setup(x => x.GetRolesAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(roles));

			return userManager;
		}

		[Fact]
		public async void LoginSucceeded()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtHelper = new Mock<IJWTHelper>();
			jwtHelper.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<IList<Claim>>())).Returns("token");

			var emailSender = new Mock<IEmailSender>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.JwtSettings).Returns(new JwtSettings());

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>> () { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.GetClaimsAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(claims));
			userManager.Setup(x => x.GetRolesAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(roles));

			var service = new AuthService(apiSettings.Object,
				userManager.Object,
				emailSender.Object,
				jwtHelper.Object);

			AuthResponse result = await service.Login(new LoginRequestModel()
			{
				Email = "test@test.com",
				Password = "1"
			});

			result.Success.Should().BeTrue();
			result.Token.Should().Be("token");
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void LoginFaileUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtHelper = new Mock<IJWTHelper>();
			jwtHelper.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<IList<Claim>>())).Returns("token");

			var emailSender = new Mock<IEmailSender>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.JwtSettings).Returns(new JwtSettings());

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));
			userManager.Setup(x => x.GetClaimsAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(claims));
			userManager.Setup(x => x.GetRolesAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(roles));

			var service = new AuthService(apiSettings.Object,
				userManager.Object,
				emailSender.Object,
				jwtHelper.Object);

			AuthResponse result = await service.Login(new LoginRequestModel()
			{
				Email = "test@test.com",
				Password = "1"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Invalid email or password");
			result.ErrorCode.Should().Be(AuthErrorCodes.InvalidUsernameOrPassword);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void LoginFailedInvalidPassword()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtHelper = new Mock<IJWTHelper>();
			jwtHelper.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<IList<Claim>>())).Returns("token");

			var emailSender = new Mock<IEmailSender>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.JwtSettings).Returns(new JwtSettings());

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Failed);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.GetClaimsAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(claims));
			userManager.Setup(x => x.GetRolesAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(roles));

			var service = new AuthService(apiSettings.Object,
				userManager.Object,
				emailSender.Object,
				jwtHelper.Object);

			AuthResponse result = await service.Login(new LoginRequestModel()
			{
				Email = "test@test.com",
				Password = "1"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Invalid email or password");
			result.ErrorCode.Should().Be(AuthErrorCodes.InvalidUsernameOrPassword);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void RegisterSuceededWithDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtHelper = new Mock<IJWTHelper>();
			jwtHelper.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<string>(),
				It.IsAny<IList<Claim>>())).Returns("token");

			var emailSender = new Mock<IEmailSender>();
			emailSender.Setup(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.CompletedTask);
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.DebugSendAuthEmailsToClient).Returns(true);
			apiSettings.SetupGet(x => x.ExternalBaseUrl).Returns("http://localhost/");

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));

			userManager.Setup(x => x.CreateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Success));
			userManager.Setup(x => x.GenerateEmailConfirmationTokenAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult("token"));
			userManager.Setup(x => x.AddPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));
			var service = new AuthService(apiSettings.Object,
				userManager.Object,
				emailSender.Object,
				jwtHelper.Object);

			AuthResponse result = await service.Register(new RegisterRequestModel()
			{
				Email = "test@test.com",
				Password = "Passw0rd$"
			});

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public void RegisterSuceededWithoutDebugEmail()
		{
		}

		[Fact]
		public void RegisterFailedUserAlreadyExists()
		{
		}

		[Fact]
		public void RegisterFailedUnableToCreateUser()
		{
		}

		[Fact]
		public void RegisterFailedUnableToSetPassword()
		{
		}

		[Fact]
		public void ResetPasswordSuceededWithDebugEmail()
		{
		}

		[Fact]
		public void ResetPasswordSuceededWithoutDebugEmail()
		{
		}

		[Fact]
		public void ResetPasswordFailedUserNotFound()
		{
		}


		[Fact]
		public void ChangeEmailSuceededWithDebugEmail()
		{
		}

		[Fact]
		public void ChangeEmailSuceededWithoutDebugEmail()
		{
		}

		[Fact]
		public void ChangeEmailFailedUserNotFound()
		{
		}

		[Fact]
		public void ChangeEmailFailedInvalidPassword()
		{
		}

		[Fact]
		public void ConfirmChangeEmailSuceeded()
		{
		}

		[Fact]
		public void ConfirmChangeEmailFailedUserNotFound()
		{
		}

		[Fact]
		public void ConfirmChangeEmailFailedUnableToConfirmToken()
		{
		}

		[Fact]
		public void ChangePasswordSuceeded()
		{
		}

		[Fact]
		public void ChangePasswordFailedUserNotFound()
		{
		}

		[Fact]
		public void ChangePasswordFailedUnableToChangePassword()
		{
		}

		[Fact]
		public void ConfirmRegistrationSuceeded()
		{
		}

		[Fact]
		public void ConfirmRegistrationFailedUserNotFound()
		{
		}

		[Fact]
		public void ConfirmRegistrationFailedUnableToConfirmRegistration()
		{
		}

		[Fact]
		public void ConfirmPasswordResetSuceeded()
		{
		}

		[Fact]
		public void ConfirmPasswordResetFailedUserNotFound()
		{
		}

		[Fact]
		public void ConfirmPasswordResetFailedUnableToConfirmPasswordReset()
		{
		}

	}

}


/*<Codenesium>
    <Hash>9bdce45567481f287085ef593a339456</Hash>
</Codenesium>*/