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
    /// Converter for <see cref="ApplicationPackageCleanupPolicy" />.
    /// </summary>
    internal class ApplicationPackageCleanupPolicyConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static ApplicationPackageCleanupPolicy? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(ApplicationPackageCleanupPolicy);

            if (string.Compare(value, "Invalid", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationPackageCleanupPolicy.Invalid;
            }
            else if (string.Compare(value, "Default", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationPackageCleanupPolicy.Default;
            }
            else if (string.Compare(value, "Automatic", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationPackageCleanupPolicy.Automatic;
            }
            else if (string.Compare(value, "Manual", StringComparison.Ordinal) == 0)
            {
                obj = ApplicationPackageCleanupPolicy.Manual;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, ApplicationPackageCleanupPolicy? value)
        {
            switch (value)
            {
                case ApplicationPackageCleanupPolicy.Invalid:
                    writer.WriteStringValue("Invalid");
                    break;
                case ApplicationPackageCleanupPolicy.Default:
                    writer.WriteStringValue("Default");
                    break;
                case ApplicationPackageCleanupPolicy.Automatic:
                    writer.WriteStringValue("Automatic");
                    break;
                case ApplicationPackageCleanupPolicy.Manual:
                    writer.WriteStringValue("Manual");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type ApplicationPackageCleanupPolicy");
            }
        }
    }
}
