// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    /// <summary>
    /// Defines values for BackupScheduleFrequencyType.
    /// </summary>
    public enum BackupScheduleFrequencyType
    {
        /// <summary>
        /// Indicates an invalid backup schedule frequency type. All Service Fabric enumerations have the invalid type..
        /// </summary>
        Invalid,

        /// <summary>
        /// Indicates that the time based backup schedule is repeated at a daily frequency..
        /// </summary>
        Daily,

        /// <summary>
        /// Indicates that the time based backup schedule is repeated at a weekly frequency..
        /// </summary>
        Weekly,
    }
}
