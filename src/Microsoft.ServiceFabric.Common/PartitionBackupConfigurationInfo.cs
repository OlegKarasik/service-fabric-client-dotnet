// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Backup configuration information, for a specific partition, specifying what backup policy is being applied and
    /// suspend description, if any.
    /// </summary>
    public partial class PartitionBackupConfigurationInfo : BackupConfigurationInfo
    {
        /// <summary>
        /// Initializes a new instance of the PartitionBackupConfigurationInfo class.
        /// </summary>
        /// <param name="policyName">The name of the backup policy which is applicable to this Service Fabric application or
        /// service or partition.</param>
        /// <param name="policyInheritedFrom">Specifies the scope at which the backup policy is applied.
        /// . Possible values include: 'Invalid', 'Partition', 'Service', 'Application'</param>
        /// <param name="suspensionInfo">Describes the backup suspension details.
        /// </param>
        /// <param name="serviceName">The full name of the service with 'fabric:' URI scheme.</param>
        /// <param name="partitionId">An internal ID used by Service Fabric to uniquely identify a partition. This is a
        /// randomly generated GUID when the service was created. The partition ID is unique and does not change for the
        /// lifetime of the service. If the same service was deleted and recreated the IDs of its partitions would be
        /// different.</param>
        public PartitionBackupConfigurationInfo(
            string policyName = default(string),
            BackupPolicyScope? policyInheritedFrom = default(BackupPolicyScope?),
            BackupSuspensionInfo suspensionInfo = default(BackupSuspensionInfo),
            ServiceName serviceName = default(ServiceName),
            PartitionId partitionId = default(PartitionId))
            : base(
                Common.BackupEntityKind.Partition,
                policyName,
                policyInheritedFrom,
                suspensionInfo)
        {
            this.ServiceName = serviceName;
            this.PartitionId = partitionId;
        }

        /// <summary>
        /// Gets the full name of the service with 'fabric:' URI scheme.
        /// </summary>
        public ServiceName ServiceName { get; }

        /// <summary>
        /// Gets an internal ID used by Service Fabric to uniquely identify a partition. This is a randomly generated GUID when
        /// the service was created. The partition ID is unique and does not change for the lifetime of the service. If the
        /// same service was deleted and recreated the IDs of its partitions would be different.
        /// </summary>
        public PartitionId PartitionId { get; }
    }
}
