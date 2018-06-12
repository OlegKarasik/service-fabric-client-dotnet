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
    /// Converter for <see cref="BackupScheduleFrequencyType" />.
    /// </summary>
    internal class BackupScheduleFrequencyTypeConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static BackupScheduleFrequencyType? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(BackupScheduleFrequencyType);

            if (string.Compare(value, "Invalid", StringComparison.Ordinal) == 0)
            {
                obj = BackupScheduleFrequencyType.Invalid;
            }
            else if (string.Compare(value, "Daily", StringComparison.Ordinal) == 0)
            {
                obj = BackupScheduleFrequencyType.Daily;
            }
            else if (string.Compare(value, "Weekly", StringComparison.Ordinal) == 0)
            {
                obj = BackupScheduleFrequencyType.Weekly;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, BackupScheduleFrequencyType? value)
        {
            switch (value)
            {
                case BackupScheduleFrequencyType.Invalid:
                    writer.WriteStringValue("Invalid");
                    break;
                case BackupScheduleFrequencyType.Daily:
                    writer.WriteStringValue("Daily");
                    break;
                case BackupScheduleFrequencyType.Weekly:
                    writer.WriteStringValue("Weekly");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type BackupScheduleFrequencyType");
            }
        }
    }
}
