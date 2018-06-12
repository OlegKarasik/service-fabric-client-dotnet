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
    /// Converter for <see cref="NodeDeactivationStatus" />.
    /// </summary>
    internal class NodeDeactivationStatusConverter
    {
        /// <summary>
        /// Gets the enum value by reading string value from reader.
        /// </summary>
        /// <param name="reader">The <see cref="T: Newtonsoft.Json.JsonReader" /> to read from, reader must be placed at first property.</param>
        /// <returns>The enum Value.</returns>
        public static NodeDeactivationStatus? Deserialize(JsonReader reader)
        {
            var value = reader.ReadValueAsString();
            var obj = default(NodeDeactivationStatus);

            if (string.Compare(value, "None", StringComparison.Ordinal) == 0)
            {
                obj = NodeDeactivationStatus.None;
            }
            else if (string.Compare(value, "SafetyCheckInProgress", StringComparison.Ordinal) == 0)
            {
                obj = NodeDeactivationStatus.SafetyCheckInProgress;
            }
            else if (string.Compare(value, "SafetyCheckComplete", StringComparison.Ordinal) == 0)
            {
                obj = NodeDeactivationStatus.SafetyCheckComplete;
            }
            else if (string.Compare(value, "Completed", StringComparison.Ordinal) == 0)
            {
                obj = NodeDeactivationStatus.Completed;
            }

            return obj;
        }

        /// <summary>
        /// Serializes the enum value.
        /// </summary>
        /// <param name="writer">The <see cref="T: Newtonsoft.Json.JsonWriter" /> to write to.</param>
        /// <param name="value">The object to serialize to JSON.</param>
        public static void Serialize(JsonWriter writer, NodeDeactivationStatus? value)
        {
            switch (value)
            {
                case NodeDeactivationStatus.None:
                    writer.WriteStringValue("None");
                    break;
                case NodeDeactivationStatus.SafetyCheckInProgress:
                    writer.WriteStringValue("SafetyCheckInProgress");
                    break;
                case NodeDeactivationStatus.SafetyCheckComplete:
                    writer.WriteStringValue("SafetyCheckComplete");
                    break;
                case NodeDeactivationStatus.Completed:
                    writer.WriteStringValue("Completed");
                    break;
                default:
                    throw new ArgumentException($"Invalid value {value.ToString()} for enum type NodeDeactivationStatus");
            }
        }
    }
}
