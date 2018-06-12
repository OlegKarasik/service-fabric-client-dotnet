// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Represents a ServiceFabric cluster upgrade
    /// </summary>
    public partial class ClusterUpgradeDescriptionObject
    {
        /// <summary>
        /// Initializes a new instance of the ClusterUpgradeDescriptionObject class.
        /// </summary>
        /// <param name="configVersion">The cluster configuration version (specified in the cluster manifest).</param>
        /// <param name="codeVersion">The ServiceFabric code version of the cluster.</param>
        /// <param name="upgradeKind">The kind of upgrade out of the following possible values. Possible values include:
        /// 'Invalid', 'Rolling'</param>
        /// <param name="rollingUpgradeMode">The mode used to monitor health during a rolling upgrade. The values are
        /// UnmonitoredAuto, UnmonitoredManual, and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto',
        /// 'UnmonitoredManual', 'Monitored'</param>
        /// <param name="upgradeReplicaSetCheckTimeoutInSeconds">The maximum amount of time to block processing of an upgrade
        /// domain and prevent loss of availability when there are unexpected issues. When this timeout expires, processing of
        /// the upgrade domain will proceed regardless of availability loss issues. The timeout is reset at the start of each
        /// upgrade domain. Valid values are between 0 and 42949672925 inclusive. (unsigned 32-bit integer).</param>
        /// <param name="forceRestart">If true, then processes are forcefully restarted during upgrade even when the code
        /// version has not changed (the upgrade only changes configuration or data).</param>
        /// <param name="enableDeltaHealthEvaluation">When true, enables delta health evaluation rather than absolute health
        /// evaluation after completion of each upgrade domain.</param>
        /// <param name="monitoringPolicy">Describes the parameters for monitoring an upgrade in Monitored mode.</param>
        /// <param name="clusterHealthPolicy">Defines a health policy used to evaluate the health of the cluster or of a
        /// cluster node.
        /// </param>
        /// <param name="clusterUpgradeHealthPolicy">Defines a health policy used to evaluate the health of the cluster during
        /// a cluster upgrade.</param>
        /// <param name="applicationHealthPolicyMap">Defines a map that contains specific application health policies for
        /// different applications.
        /// Each entry specifies as key the application name and as value an ApplicationHealthPolicy used to evaluate the
        /// application health.
        /// If an application is not specified in the map, the application health evaluation uses the ApplicationHealthPolicy
        /// found in its application manifest or the default application health policy (if no health policy is defined in the
        /// manifest).
        /// The map is empty by default.
        /// </param>
        public ClusterUpgradeDescriptionObject(
            string configVersion = default(string),
            string codeVersion = default(string),
            UpgradeKind? upgradeKind = Common.UpgradeKind.Rolling,
            UpgradeMode? rollingUpgradeMode = Common.UpgradeMode.UnmonitoredAuto,
            long? upgradeReplicaSetCheckTimeoutInSeconds = default(long?),
            bool? forceRestart = default(bool?),
            bool? enableDeltaHealthEvaluation = default(bool?),
            MonitoringPolicyDescription monitoringPolicy = default(MonitoringPolicyDescription),
            ClusterHealthPolicy clusterHealthPolicy = default(ClusterHealthPolicy),
            ClusterUpgradeHealthPolicyObject clusterUpgradeHealthPolicy = default(ClusterUpgradeHealthPolicyObject),
            IEnumerable<ApplicationHealthPolicyMapItem> applicationHealthPolicyMap = default(IEnumerable<ApplicationHealthPolicyMapItem>))
        {
            this.ConfigVersion = configVersion;
            this.CodeVersion = codeVersion;
            this.UpgradeKind = upgradeKind;
            this.RollingUpgradeMode = rollingUpgradeMode;
            this.UpgradeReplicaSetCheckTimeoutInSeconds = upgradeReplicaSetCheckTimeoutInSeconds;
            this.ForceRestart = forceRestart;
            this.EnableDeltaHealthEvaluation = enableDeltaHealthEvaluation;
            this.MonitoringPolicy = monitoringPolicy;
            this.ClusterHealthPolicy = clusterHealthPolicy;
            this.ClusterUpgradeHealthPolicy = clusterUpgradeHealthPolicy;
            this.ApplicationHealthPolicyMap = applicationHealthPolicyMap;
        }

        /// <summary>
        /// Gets the cluster configuration version (specified in the cluster manifest).
        /// </summary>
        public string ConfigVersion { get; }

        /// <summary>
        /// Gets the ServiceFabric code version of the cluster.
        /// </summary>
        public string CodeVersion { get; }

        /// <summary>
        /// Gets the kind of upgrade out of the following possible values. Possible values include: 'Invalid', 'Rolling'
        /// </summary>
        public UpgradeKind? UpgradeKind { get; }

        /// <summary>
        /// Gets the mode used to monitor health during a rolling upgrade. The values are UnmonitoredAuto, UnmonitoredManual,
        /// and Monitored. Possible values include: 'Invalid', 'UnmonitoredAuto', 'UnmonitoredManual', 'Monitored'
        /// </summary>
        public UpgradeMode? RollingUpgradeMode { get; }

        /// <summary>
        /// Gets the maximum amount of time to block processing of an upgrade domain and prevent loss of availability when
        /// there are unexpected issues. When this timeout expires, processing of the upgrade domain will proceed regardless of
        /// availability loss issues. The timeout is reset at the start of each upgrade domain. Valid values are between 0 and
        /// 42949672925 inclusive. (unsigned 32-bit integer).
        /// </summary>
        public long? UpgradeReplicaSetCheckTimeoutInSeconds { get; }

        /// <summary>
        /// Gets if true, then processes are forcefully restarted during upgrade even when the code version has not changed
        /// (the upgrade only changes configuration or data).
        /// </summary>
        public bool? ForceRestart { get; }

        /// <summary>
        /// Gets when true, enables delta health evaluation rather than absolute health evaluation after completion of each
        /// upgrade domain.
        /// </summary>
        public bool? EnableDeltaHealthEvaluation { get; }

        /// <summary>
        /// Gets describes the parameters for monitoring an upgrade in Monitored mode.
        /// </summary>
        public MonitoringPolicyDescription MonitoringPolicy { get; }

        /// <summary>
        /// Gets defines a health policy used to evaluate the health of the cluster or of a cluster node.
        /// </summary>
        public ClusterHealthPolicy ClusterHealthPolicy { get; }

        /// <summary>
        /// Gets defines a health policy used to evaluate the health of the cluster during a cluster upgrade.
        /// </summary>
        public ClusterUpgradeHealthPolicyObject ClusterUpgradeHealthPolicy { get; }

        /// <summary>
        /// Gets defines a map that contains specific application health policies for different applications.
        /// Each entry specifies as key the application name and as value an ApplicationHealthPolicy used to evaluate the
        /// application health.
        /// If an application is not specified in the map, the application health evaluation uses the ApplicationHealthPolicy
        /// found in its application manifest or the default application health policy (if no health policy is defined in the
        /// manifest).
        /// The map is empty by default.
        /// </summary>
        public IEnumerable<ApplicationHealthPolicyMapItem> ApplicationHealthPolicyMap { get; }
    }
}
