//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//     Generation parameters:
//     - DataFilename: Patterns\Base-GUID.yaml
//     - Language: NULL
//     - ClassName: BaseGUID
// </auto-generated>
//
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
// ------------------------------------------------------------------------------

namespace Microsoft.Recognizers.Definitions
{
    using System;
    using System.Collections.Generic;

    public static class BaseGUID
    {
      public const string GUIDRegexElement = @"(([A-Fa-f0-9]{8}(-[A-Fa-f0-9]{4}){3}-[A-Fa-f0-9]{12})|([A-Fa-f0-9]{32}))";
      public static readonly string GUIDRegex = $@"(\b{GUIDRegexElement}\b|\{{{GUIDRegexElement}\}}|urn:uuid:{GUIDRegexElement}\b|%7[Bb]{GUIDRegexElement}%7[Dd]|[Xx]\'{GUIDRegexElement}\')";
    }
}