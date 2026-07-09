namespace Microsoft.Build.Logging.StructuredLogger
{
    /// <summary>
    /// Represents an MSBuild Server lifecycle event for a build: the server node was freshly spawned,
    /// an already-running node was reused, or the server was requested but the build ran in-process.
    /// MSBuild emits these as a dedicated MSBuildServerLifecycleEventArgs (its own binary-log record kind);
    /// see documentation/MSBuild-Server.md in dotnet/msbuild.
    /// </summary>
    public class MSBuildServerNode : Message
    {
        /// <summary>"Spawned", "Reused", or "NotUsed".</summary>
        public string Kind { get; set; }

        /// <summary>True when a spawned server will shut down after this build (short-lived).</summary>
        public bool ShortLived { get; set; }

        /// <summary>The server node's process id, when known (for spawned/reused).</summary>
        public int? ProcessId { get; set; }

        /// <summary>The localized reason the server was not used, when applicable (for not-used).</summary>
        public string Reason { get; set; }

        /// <summary>A stable, non-localized code for the fall-back cause (for not-used), e.g. "node-reuse-disabled".</summary>
        public string ReasonCode { get; set; }

        // Serialize as a plain Message (matching TimedMessage / MessageWithLocation) so .buildlog round-tripping
        // keeps working; the dedicated DataTemplate keyed on this CLR type still gives it a distinct icon.
        public override string TypeName => nameof(Message);
    }
}
