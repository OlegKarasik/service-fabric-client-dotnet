// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Client.Http.Serialization
{
    using System;
    using System.Collections.Generic;
    using Microsoft.ServiceFabric.Common;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Converter for <see cref="ApplicationBackupConfigurationInfo" />.
    /// </summary>
    internal class ApplicationBackupConfigurationInfoConverter
    {
        /// <summary>
        /// Deserializes the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationBackupConfigurationInfo Deserialize(JsonReader reader)
        {
            return reader.Deserialize(GetFromJsonProperties);
        }

        /// <summary>
        /// Gets the object from Json properties.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The object Value.</returns>
        internal static ApplicationBackupConfigurationInfo GetFromJsonProperties(JsonReader reader)
        {
            var policyName = default(string);
            var policyInheritedFrom = default(BackupPolicyScope?);
            var suspensionInfo = default(BackupSuspensionInfo);
            var applicationName = default(ApplicationName);

            do
            {
                var propName = reader.ReadPropertyName();
                if (string.Compare("PolicyName", propName, StringComparison.Ordinal) == 0)
                {
                    policyName = reader.ReadValueAsString();
                }
                else if (string.Compare("PolicyInheritedFrom", propName, StringComparison.Ordinal) == 0)
                {
                    policyInheritedFrom = BackupPolicyScopeConverter.Deserialize(reader);
                }
                else if (string.Compare("SuspensionInfo", propName, StringComparison.Ordinal) == 0)
                {
                    suspensionInfo = BackupSuspensionInfoConverter.Deserialize(reader);
                }
                else if (string.Compare("ApplicationName", propName, StringComparison.Ordinal) == 0)
                {
                    applicationName = ApplicationNameConverter.Deserialize(reader);
                }
                else
                {
                    reader.SkipPropertyValue();
                }
            }
            while (reader.TokenType != JsonToken.EndObject);

            return new ApplicationBackupConfigurationInfo(
                policyName: policyName,
                policyInheritedFrom: policyInheritedFrom,
                suspensionInfo: suspensionInfo,
                applicationName: applicationName);
        }

        /// <summary>
        /// Serializes the object to JSON.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="obj">The object to serialize to JSON.</param>
        internal static void Serialize(JsonWriter writer, ApplicationBackupConfigurationInfo obj)
        {
            // Required properties are always serialized, optional properties are serialized when not null.
            writer.WriteStartObject();
            writer.WriteProperty(obj.Kind.ToString(), "Kind", JsonWriterExtensions.WriteStringValue);
            writer.WriteProperty(obj.PolicyInheritedFrom, "PolicyInheritedFrom", BackupPolicyScopeConverter.Serialize);
            if (obj.PolicyName != null)
            {
                writer.WriteProperty(obj.PolicyName, "PolicyName", JsonWriterExtensions.WriteStringValue);
            }

            if (obj.SuspensionInfo != null)
            {
                writer.WriteProperty(obj.SuspensionInfo, "SuspensionInfo", BackupSuspensionInfoConverter.Serialize);
            }

            if (obj.ApplicationName != null)
            {
                writer.WriteProperty(obj.ApplicationName, "ApplicationName", ApplicationNameConverter.Serialize);
            }

            writer.WriteEndObject();
        }
    }
}
