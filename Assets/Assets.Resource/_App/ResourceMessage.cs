﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Assets.Resource {
    public class ResourceMessage {
        #region General
        public const string Ok = nameof(Ok);
        public const string BadRequest = nameof(BadRequest);
        public const string InternalServerError = nameof(InternalServerError);
        public const string SomethingWentWrong = nameof(SomethingWentWrong);
        public const string AuthenticationFailed = nameof(AuthenticationFailed);
        public const string TokenNotFound = nameof(TokenNotFound);
        public const string DeviceIdNotFound = nameof(DeviceIdNotFound);
        public const string DeviceIsNotActive = nameof(DeviceIsNotActive);
        public const string PhoneIsNotVerified = nameof(PhoneIsNotVerified);
        public const string ConnectionError = nameof(ConnectionError);
        public const string UnexpectedError = nameof(UnexpectedError);
        public const string NothingFound = nameof(NothingFound);
        public const string DefectiveEntry = nameof(DefectiveEntry);
        public const string RetrieveLimit = nameof(RetrieveLimit);
        public const string DangerousRequest = nameof(DangerousRequest);
        public const string UnsupportedLanguage = nameof(UnsupportedLanguage);
        public const string UnsupportedTimeZone = nameof(UnsupportedTimeZone);
        public const string WrongPassword = nameof(WrongPassword);
        public const string RequestForVerificationCodeFirst = nameof(RequestForVerificationCodeFirst);
        public const string VerificationCodeHasBeenExpired = nameof(VerificationCodeHasBeenExpired);
        public const string WrongVerificationCode = nameof(WrongVerificationCode);
        public const string AccessDenied = nameof(AccessDenied);
        public const string UnofficialRequest = nameof(UnofficialRequest);
        public const string EmptyHeader = nameof(EmptyHeader);//"You're trying to signing in through the wrong way! buddy."
        #endregion

        #region Account

        #region authentication
        public const string UserNotFound = nameof(UserNotFound);
        public const string UserIsNotActive = nameof(UserIsNotActive);
        #endregion

        #region SignUp
        public const string DefectiveCellPhone = nameof(DefectiveCellPhone);
        public const string DefectiveEmail = nameof(DefectiveEmail);
        public const string DefectiveEmailOrCellPhone = nameof(DefectiveEmailOrCellPhone);//"Please define your Email or CellPhone number."
        public const string InvalidEmailOrCellPhone = nameof(InvalidEmailOrCellPhone);//"Please define a correct Email or CellPhone number."
        public const string CellPhoneAlreadyExists = nameof(CellPhoneAlreadyExists);//"This Phone number is already registered. If you forgot your Password try to use Forgat Password feature."
        public const string EmailAlreadyExists = nameof(EmailAlreadyExists);//"This Email is already registered. If you forgot your Password try to use Forgat Password feature."
        #endregion

        #region SignIn
        public const string DefectiveUsernameOrPassword = nameof(DefectiveUsernameOrPassword);//"Please define your Username and Password."
        public const string InvalidSigninAttempt = nameof(InvalidSigninAttempt);
        public const string GoToStepTwo = nameof(GoToStepTwo);
        public const string ExternalAuthenticationError = nameof(ExternalAuthenticationError);
        #endregion

        #endregion

        #region Business
        public const string InvalidPoint = nameof(InvalidPoint);
        public const string BusinessNotFound = nameof(BusinessNotFound);
        public const string BusinessIsNotActive = nameof(BusinessIsNotActive);
        #endregion

        #region Product
        public const string ProductNotFound = nameof(ProductNotFound);
        public const string ProductIsNotActive = nameof(ProductIsNotActive);
        #endregion

        #region Comment
        public const string CommentNotFound = nameof(CommentNotFound);
        public const string CommentIsNotActive = nameof(CommentIsNotActive);
        #endregion
    }
}
