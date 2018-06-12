// ------------------------------------------------------------
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License (MIT). See License.txt in the repo root for license information.
// ------------------------------------------------------------

namespace Microsoft.ServiceFabric.Common
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Describes the parameters for a standalone cluster configuration upgrade.
    /// </summary>
    public partial class ClusterConfigurationUpgradeDescription
    {
        /// <summary>
        /// Initializes a new instance of the ClusterConfigurationUpgradeDescription class.
        /// </summary>
        /// <param name="clusterConfig">The cluster configuration.</param>
        /// <param name="healthCheckRetryTimeout">The length of time between attempts to perform a health checks if the
        /// application or cluster is not healthy.</param>
        /// <param name="healthCheckWaitDurationInSeconds">The length of time to wait after completing an upgrade domain before
        /// starting the health checks process.</param>
        /// <param name="healthCheckStableDurationInSeconds">The length of time that the application or cluster must remain
        /// healthy.</param>
        /// <param name="upgradeDomainTimeoutInSeconds">The timeout for the upgrade domain.</param>
        /// <param name="upgradeTimeoutInSeconds">The upgrade timeout.</param>
        /// <param name="maxPercentUnhealthyApplications">The maximum allowed percentage of unhealthy applications during the
        /// upgrade. Allowed values are integer values from zero to 100.</param>
        /// <param name="maxPercentUnhealthyNodes">The maximum allowed percentage of unhealthy nodes during the upgrade.
        /// Allowed values are integer values from zero to 100.</param>
        /// <param name="maxPercentDeltaUnhealthyNodes">The maximum allowed percentage of delta health degradation during the
        /// upgrade. Allowed values are integer values from zero to 100.</param>
        /// <param name="maxPercentUpgradeDomainDeltaUnhealthyNodes">The maximum allowed percentage of upgrade domain delta
        /// health degradation during the upgrade. Allowed values are integer values from zero to 100.</param>
        public ClusterConfigurationUpgradeDescription(
            string clusterConfig,
            TimeSpan? healthCheckRetryTimeout = default(TimeSpan?),
            TimeSpan? healthCheckWaitDurationInSeconds = default(TimeSpan?),
            TimeSpan? healthCheckStableDurationInSeconds = default(TimeSpan?),
            TimeSpan? upgradeDomainTimeoutInSeconds = default(TimeSpan?),
            TimeSpan? upgradeTimeoutInSeconds = default(TimeSpan?),
            int? maxPercentUnhealthyApplications = 0,
            int? maxPercentUnhealthyNodes = 0,
            int? maxPercentDeltaUnhealthyNodes = 0,
            int? maxPercentUpgradeDomainDeltaUnhealthyNodes = 0)
        {
            clusterConfig.ThrowIfNull(nameof(clusterConfig));
            this.ClusterConfig = clusterConfig;
            this.HealthCheckRetryTimeout = healthCheckRetryTimeout;
            this.HealthCheckWaitDurationInSeconds = healthCheckWaitDurationInSeconds;
            this.HealthCheckStableDurationInSeconds = healthCheckStableDurationInSeconds;
            this.UpgradeDomainTimeoutInSeconds = upgradeDomainTimeoutInSeconds;
            this.UpgradeTimeoutInSeconds = upgradeTimeoutInSeconds;
            this.MaxPercentUnhealthyApplications = maxPercentUnhealthyApplications;
            this.MaxPercentUnhealthyNodes = maxPercentUnhealthyNodes;
            this.MaxPercentDeltaUnhealthyNodes = maxPercentDeltaUnhealthyNodes;
            this.MaxPercentUpgradeDomainDeltaUnhealthyNodes = maxPercentUpgradeDomainDeltaUnhealthyNodes;
        }

        /// <summary>
        /// Gets the cluster configuration.
        /// </summary>
        public string ClusterConfig { get; }

        /// <summary>
        /// Gets the length of time between attempts to perform a health checks if the application or cluster is not healthy.
        /// </summary>
        public TimeSpan? HealthCheckRetryTimeout { get; }

        /// <summary>
        /// Gets the length of time to wait after completing an upgrade domain before starting the health checks process.
        /// </summary>
        public TimeSpan? HealthCheckWaitDurationInSeconds { get; }

        /// <summary>
        /// Gets the length of time that the application or cluster must remain healthy.
        /// </summary>
        public TimeSpan? HealthCheckStableDurationInSeconds { get; }

        /// <summary>
        /// Gets the timeout for the upgrade domain.
        /// </summary>
        public TimeSpan? UpgradeDomainTimeoutInSeconds { get; }

        /// <summary>
        /// Gets the upgrade timeout.
        /// </summary>
        public TimeSpan? UpgradeTimeoutInSeconds { get; }

        /// <summary>
        /// Gets the maximum allowed percentage of unhealthy applications during the upgrade. Allowed values are integer values
        /// from zero to 100.
        /// </summary>
        public int? MaxPercentUnhealthyApplications { get; }

        /// <summary>
        /// Gets the maximum allowed percentage of unhealthy nodes during the upgrade. Allowed values are integer values from
        /// zero to 100.
        /// </summary>
        public int? MaxPercentUnhealthyNodes { get; }

        /// <summary>
        /// Gets the maximum allowed percentage of delta health degradation during the upgrade. Allowed values are integer
        /// values from zero to 100.
        /// </summary>
        public int? MaxPercentDeltaUnhealthyNodes { get; }

        /// <summary>
        /// Gets the maximum allowed percentage of upgrade domain delta health degradation during the upgrade. Allowed values
        /// are integer values from zero to 100.
        /// </summary>
        public int? MaxPercentUpgradeDomainDeltaUnhealthyNodes { get; }
    }
}
