using System;

namespace Microsoft.Build.Framework
{
    /// <summary>
    /// Identifies how a build related to the MSBuild Server node.
    /// </summary>
    public enum MSBuildServerLifecycleKind
    {
        Spawned,
        Reused,
        NotUsed,
    }

    /// <summary>
    /// Records how a build related to the MSBuild Server node (spawned, reused, or requested but not used).
    /// Emitted by MSBuild under its own binary-log record kind (see dotnet/msbuild).
    /// </summary>
    [Serializable]
    public class MSBuildServerLifecycleEventArgs : BuildMessageEventArgs
    {
        public MSBuildServerLifecycleEventArgs()
        {
        }

        public MSBuildServerLifecycleEventArgs(
            MSBuildServerLifecycleKind kind,
            int processId,
            string reason,
            string reasonCode,
            string message,
            MessageImportance importance,
            bool shortLived)
            : base(message, null, "MSBuild", importance)
        {
            Kind = kind;
            ProcessId = processId;
            Reason = reason;
            ReasonCode = reasonCode;
            ShortLived = shortLived;
        }

        /// <summary>How the build related to the MSBuild Server node.</summary>
        public MSBuildServerLifecycleKind Kind { get; set; }

        /// <summary><see langword="true"/> when a spawned server will shut down after this build (short-lived).</summary>
        public bool ShortLived { get; set; }

        /// <summary>The MSBuild Server node's process id, or 0 when not applicable.</summary>
        public int ProcessId { get; set; }

        /// <summary>A localized reason the server was not used (for <see cref="MSBuildServerLifecycleKind.NotUsed"/>).</summary>
        public string Reason { get; set; }

        /// <summary>A stable, non-localized code for the fall-back cause (for <see cref="MSBuildServerLifecycleKind.NotUsed"/>).</summary>
        public string ReasonCode { get; set; }
    }
}
