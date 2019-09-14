using FluentAssertions;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.DataAccess;
using Xunit;

namespace TwitterNS.Api.Services.Tests.Tests
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
		[Fact]
		public async void LoginSucceeded()
		{
			var store = new Mock<IUserStore<AuthUser>>();

			var jwtService = new Mock<IJwtService>();
			jwtService.Setup(x => x.GenerateBearerToken(It.IsAny<string>(),
			                                            It.IsAny<string>(),
			                                            It.IsAny<string>(),
			                                            It.IsAny<string>(),
			                                            It.IsAny<string>(),
			                                            It.IsAny<IList<Claim>>())).Returns("token");

			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.JwtSettings).Returns(new JwtSettings());

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

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
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

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
			passwordHasher.Verify(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>()));
			userManager.Verify(x => x.GetClaimsAsync(It.IsAny<AuthUser>()));
			userManager.Verify(x => x.GetRolesAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void LoginFaileUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));
			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

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
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Failed);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

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
			passwordHasher.Verify(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void RegisterSuceededWithDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			guidService.Setup(x => x.NewGuid()).Returns(Guid.Parse("ffa474d6-1b19-4e98-803a-c9f5e064c975"));
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.DebugSendAuthEmailsToClient).Returns(true);
			apiSettings.SetupGet(x => x.ExternalBaseUrl).Returns("http://localhost");

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

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
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

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
			result.LinkText.Should().Be("Click this link to complete registration");
			result.LinkValue.Should().Be($"http://localhost/confirmregistration/{Guid.Parse("ffa474d6-1b19-4e98-803a-c9f5e064c975")}/token");
			emailService.Verify(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
			userManager.Verify(x => x.CreateAsync(It.IsAny<AuthUser>()));
			userManager.Verify(x => x.GenerateEmailConfirmationTokenAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void RegisterSuceededWithoutDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();

			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.DebugSendAuthEmailsToClient).Returns(false);
			apiSettings.SetupGet(x => x.ExternalBaseUrl).Returns("http://localhost");

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

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
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.Register(new RegisterRequestModel()
			{
				Email = "test@test.com",
				Password = "Passw0rd$"
			});

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Click the link sent to the provided email to complete registration");
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			emailService.Verify(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
			userManager.Verify(x => x.CreateAsync(It.IsAny<AuthUser>()));
			userManager.Verify(x => x.GenerateEmailConfirmationTokenAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void RegisterFailedUserAlreadyExists()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.Register(new RegisterRequestModel()
			{
				Email = "test@test.com",
				Password = "Passw0rd$"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("User already exists");
			result.ErrorCode.Should().Be(AuthErrorCodes.UserAlreadyExists);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void RegisterFailedUnableToCreateUser()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));
			userManager.Setup(x => x.CreateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error"} }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.Register(new RegisterRequestModel()
			{
				Email = "test@test.com",
				Password = "Passw0rd$"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().StartWith("error");
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToRegister);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.CreateAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void RegisterFailedUnableToSetPassword()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();

			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.DebugSendAuthEmailsToClient).Returns(true);
			apiSettings.SetupGet(x => x.ExternalBaseUrl).Returns("http://localhost");

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));
			userManager.Setup(x => x.CreateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Success));
			userManager.Setup(x => x.AddPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.Register(new RegisterRequestModel()
			{
				Email = "test@test.com",
				Password = "Passw0rd$"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().StartWith("error");
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToRegister);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.CreateAsync(It.IsAny<AuthUser>()));
			userManager.Verify(x => x.AddPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ResetPasswordSuceededWithDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.DebugSendAuthEmailsToClient).Returns(true);
			apiSettings.SetupGet(x => x.ExternalBaseUrl).Returns("http://localhost");

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser() { Id = "ffa474d6-1b19-4e98-803a-c9f5e064c975" }));
			userManager.Setup(x => x.GeneratePasswordResetTokenAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult("token"));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ResetPassword(new ResetPasswordRequestModel()
			{
				Email = "test@test.com",
			});

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().Be("Click this link to reset your password");
			result.LinkValue.Should().Be($"http://localhost/confirmpasswordreset/{Guid.Parse("ffa474d6-1b19-4e98-803a-c9f5e064c975")}/token");
			userManager.Verify(x => x.GeneratePasswordResetTokenAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void ResetPasswordSuceededWithoutDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser() { Id = "ffa474d6-1b19-4e98-803a-c9f5e064c975" }));
			userManager.Setup(x => x.GeneratePasswordResetTokenAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult("token"));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ResetPassword(new ResetPasswordRequestModel()
			{
				Email = "test@test.com",
			});

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Click the link sent to the provided email to reset your password");
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			emailService.Verify(x => x.SendEmailAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));
			userManager.Verify(x => x.GeneratePasswordResetTokenAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void ResetPasswordFailedUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ResetPassword(new ResetPasswordRequestModel()
			{
				Email = "test@test.com",
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("User not found");
			result.ErrorCode.Should().Be(AuthErrorCodes.UserDoesNotExist);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ChangeEmailSuceededWithDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			apiSettings.SetupGet(x => x.DebugSendAuthEmailsToClient).Returns(true);
			apiSettings.SetupGet(x => x.ExternalBaseUrl).Returns("http://localhost");

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser() {Id = "ffa474d6-1b19-4e98-803a-c9f5e064c975", Email = "current@test.com" }));
			userManager.Setup(x => x.UpdateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Success));
			userManager.Setup(x => x.GenerateChangeEmailTokenAsync(It.IsAny<AuthUser>(), It.IsAny<string>())).Returns(Task.FromResult("token"));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangeEmail(new ChangeEmailRequestModel()
			{
				NewEmail = "test@test.com",
				Password = "Passw0rd$"
			}, "existingemail@test.com");

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().Be("Click the link to change your email");
			result.LinkValue.Should().Be($"http://localhost/confirmchangeemail/{Guid.Parse("ffa474d6-1b19-4e98-803a-c9f5e064c975")}/token");
			userManager.Verify(x => x.UpdateAsync(It.IsAny<AuthUser>()));
			userManager.Verify(x => x.GenerateChangeEmailTokenAsync(It.IsAny<AuthUser>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ChangeEmailSucceededWithoutDebugEmail()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();

			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			passwordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(PasswordVerificationResult.Success);

			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();
			passwordValidator.Setup(x => x.ValidateAsync(It.IsAny<UserManager<AuthUser>>(), It.IsAny<AuthUser>(), It.IsAny<string>()));

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser() { Id = "ffa474d6-1b19-4e98-803a-c9f5e064c975", Email = "current@test.com" }));
			userManager.Setup(x => x.UpdateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Success));
			userManager.Setup(x => x.GenerateChangeEmailTokenAsync(It.IsAny<AuthUser>(), It.IsAny<string>())).Returns(Task.FromResult("token"));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangeEmail(new ChangeEmailRequestModel()
			{
				NewEmail = "test@test.com",
				Password = "Passw0rd$"
			}, "existingemail@test.com");

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Click the link sent to the provided email to complete changing your account email");
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.UpdateAsync(It.IsAny<AuthUser>()));
			userManager.Verify(x => x.GenerateChangeEmailTokenAsync(It.IsAny<AuthUser>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ChangeEmailFailedUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangeEmail(new ChangeEmailRequestModel()
			{
				NewEmail = "test@test.com",
				Password = "Passw0rd$"
			}, "existingemail@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("User not found");
			result.ErrorCode.Should().Be(AuthErrorCodes.UserDoesNotExist);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ChangeEmailFailedInvalidPassword()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
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

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangeEmail(new ChangeEmailRequestModel()
			{
				NewEmail = "test@test.com",
				Password = "Passw0rd$"
			}, "existingemail@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Invalid email or password");
			result.ErrorCode.Should().Be(AuthErrorCodes.InvalidUsernameOrPassword);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ChangeEmailUpdatedFailed()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
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
			userManager.Setup(x => x.UpdateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangeEmail(new ChangeEmailRequestModel()
			{
				NewEmail = "test@test.com",
				Password = "Passw0rd$"
			}, "existingemail@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("Unable to update user");
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToUpdateUser);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.UpdateAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void ConfirmChangeEmailSucceeded()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
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
			userManager.Setup(x => x.ChangeEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));
			userManager.Setup(x => x.UpdateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Success));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmChangeEmail(new ConfirmChangeEmailRequestModel()
			{
				Token = "test"
			}, "newemail@test.com");

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.ChangeEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ConfirmChangeEmailFailedUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmChangeEmail(new ConfirmChangeEmailRequestModel()
			{
				Token = "test"
			}, "newemail@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("User not found");
			result.ErrorCode.Should().Be(AuthErrorCodes.UserDoesNotExist);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ConfirmChangeEmailFailedUnableToConfirmToken()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
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
			userManager.Setup(x => x.ChangeEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmChangeEmail(new ConfirmChangeEmailRequestModel()
			{
				Token = "test"
			}, "newemail@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().NotBeNullOrWhiteSpace();
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToChangeEmail);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ConfirmChangeEmailUpdateFailed()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
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
			userManager.Setup(x => x.ChangeEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));

			userManager.Setup(x => x.UpdateAsync(It.IsAny<AuthUser>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmChangeEmail(new ConfirmChangeEmailRequestModel()
			{
				Token = "test"
			}, "newemail@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().NotBeNullOrWhiteSpace();
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToUpdateUser);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.UpdateAsync(It.IsAny<AuthUser>()));
		}

		[Fact]
		public async void ChangePasswordSucceeded()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.ChangePasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangePassword(new ChangePasswordRequestModel()
			{
				CurrentPassword = "Passw0rd$",
				NewPassword = "NewPassw0rd0$"
			}, "test@test.com");

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.ChangePasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ChangePasswordFailedUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangePassword(new ChangePasswordRequestModel()
			{
				CurrentPassword = "Passw0rd$",
				NewPassword = "NewPassw0rd0$"
			}, "test@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("User not found");
			result.ErrorCode.Should().Be(AuthErrorCodes.UserDoesNotExist);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ChangePasswordFailedUnableToChangePassword()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByEmailAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.ChangePasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ChangePassword(new ChangePasswordRequestModel()
			{
				CurrentPassword = "Passw0rd$",
				NewPassword = "NewPassw0rd0$"
			}, "test@test.com");

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().NotBeNullOrWhiteSpace();
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToChangePassword);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ConfirmRegistrationSuceeded()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.ConfirmEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmRegistration(new ConfirmRegistrationRequestModel()
			{
				Token = "token",
				Id = "test"
			});

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.ConfirmEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ConfirmRegistrationFailedUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmRegistration(new ConfirmRegistrationRequestModel()
			{
				Token = "token",
				Id = "test"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().NotBeNullOrWhiteSpace();
			result.ErrorCode.Should().Be(AuthErrorCodes.UserDoesNotExist);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ConfirmRegistrationFailedUnableToConfirmRegistration()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.ConfirmEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));
			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmRegistration(new ConfirmRegistrationRequestModel()
			{
				Token = "token",
				Id = "test"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().NotBeNullOrWhiteSpace();
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToConfirmRegistration);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.ConfirmEmailAsync(It.IsAny<AuthUser>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ConfirmPasswordResetSucceeded()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.ResetPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmPasswordReset(new ConfirmPasswordResetRequestModel()
			{
				Token = "token",
				Id = "test",
				NewPassword = "Passw0rd$"
			});

			result.Success.Should().BeTrue();
			result.Token.Should().BeNull();
			result.Message.Should().BeNull();
			result.ErrorCode.Should().BeNull();
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
			userManager.Verify(x => x.ResetPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>()));
		}

		[Fact]
		public async void ConfirmPasswordResetFailedUserNotFound()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(null as AuthUser));
			userManager.Setup(x => x.ResetPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Success));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmPasswordReset(new ConfirmPasswordResetRequestModel()
			{
				Token = "token",
				Id = "test",
				NewPassword = "Passw0rd$"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().Be("User not found");
			result.ErrorCode.Should().Be(AuthErrorCodes.UserDoesNotExist);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public async void ConfirmPasswordResetFailedUnableToConfirmPasswordReset()
		{
			var store = new Mock<IUserStore<AuthUser>>();
			var jwtService = new Mock<IJwtService>();
			var guidService = new Mock<IGuidService>();
			var emailService = new Mock<IEmailService>();
			var apiSettings = new Mock<ApiSettings>();
			var passwordHasher = new Mock<IPasswordHasher<AuthUser>>();
			var passwordValidator = new Mock<IPasswordValidator<AuthUser>>();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("testClaim", "testValue"));

			IList<string> roles = new List<string>();
			roles.Add("testRole");

			var userManager = new Mock<UserManager<AuthUser>>(store.Object, null, passwordHasher.Object, new List<IUserValidator<AuthUser>>() { }, new List<IPasswordValidator<AuthUser>>() { passwordValidator.Object }, null, null, null, null);
			userManager.Setup(x => x.FindByIdAsync(It.IsAny<string>())).Returns(Task.FromResult(new AuthUser()));
			userManager.Setup(x => x.ResetPasswordAsync(It.IsAny<AuthUser>(), It.IsAny<string>(), It.IsAny<string>())).Returns(Task.FromResult(IdentityResult.Failed(new List<IdentityError>() { new IdentityError() { Code = "error", Description = "error" } }.ToArray())));

			var service = new AuthService(apiSettings.Object,
			                              userManager.Object,
			                              emailService.Object,
			                              jwtService.Object,
			                              guidService.Object);

			AuthResponse result = await service.ConfirmPasswordReset(new ConfirmPasswordResetRequestModel()
			{
				Token = "token",
				Id = "test",
				NewPassword = "Passw0rd$"
			});

			result.Success.Should().BeFalse();
			result.Token.Should().BeNull();
			result.Message.Should().NotBeNullOrWhiteSpace();
			result.ErrorCode.Should().Be(AuthErrorCodes.UnableToConfirmPasssordReset);
			result.ValidationErrors.Should().BeEmpty();
			result.LinkText.Should().BeNull();
			result.LinkValue.Should().BeNull();
		}

		[Fact]
		public void JwtServiceGeneratedToken()
		{
			IJwtService service = new JwtService();

			IList<Claim> claims = new List<Claim>();
			claims.Add(new Claim("test_claim", "value"));

			string token = service.GenerateBearerToken("Passw0rdPassw0rd", "audience", "issuer", "userId", "test@test.com", claims);

			JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
			var result = tokenHandler.ReadJwtToken(token);
			result.Audiences.First().Should().Be("audience");
			result.Issuer.Should().Be("issuer");
			result.Claims.First(x => x.Type == "unique_name").Value.Should().Be("userId");
			result.Claims.First(x => x.Type == "email").Value.Should().Be("test@test.com");
			result.Claims.First(x => x.Type == "test_claim").Value.Should().Be("value");
		}
	}
}

/*<Codenesium>
    <Hash>2279d3eba2feea1494568c9cdf1bbcb1</Hash>
    <Hello>
		This code was generated using the Codenesium platform. You can visit our site at https://www.codenesium.com. 
	</Hello>
</Codenesium>*/