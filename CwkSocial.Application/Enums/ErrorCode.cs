﻿namespace CwkSocial.Application.Enums {

    public enum ErrorCode {
        NotFound = 404,
        ServerError = 500,

        // Valdiation errors should be in the range 100 - 199
        ValidationError = 101,

        // Infrastructure errors should be in the range 200 - 299

        IdentityCreationFailed = 202,

        // Application Error 300-399
        PostUpdateNotPossible = 300,

        PostDeleteNotPossible = 301,
        InteractionRemovalNotAuthorized = 302,
        IdentityUserAlreadyExists = 303,
        IdentityUserDoesNotExist = 304,
        IncorrectPassword = 305,
        UnauthorizedAccountRemoval = 306,
        CommentRemovalNotAuthorized = 307,

        UserProfileDoesNotExist = 205,

        UnknownError = 999
    }
}